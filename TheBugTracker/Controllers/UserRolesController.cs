using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBugTracker.Extensions;
using TheBugTracker.Models;
using TheBugTracker.Models.ViewModels;
using TheBugTracker.Services.Interfaces;

namespace TheBugTracker.Controllers
{
    [Authorize]
    public class UserRolesController : Controller
    {        
        private readonly IBTRolesService _rolesService;
        private readonly IBTCompanyInfoService _companyInfoService;

        public UserRolesController(IBTRolesService rolesService, 
                                   IBTCompanyInfoService companyInfoService)
        {
            _rolesService = rolesService;
            _companyInfoService = companyInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles()
        {
            //Add an instance of the viewmodel
            List<ManageUserRolesViewModel> model = new();

            //Get CompanyId
            int companyId = User.Identity.GetCompanyId().Value;

            //Get all company Users
            List<BTUser> users = await _companyInfoService.GetAllMembersAsync(companyId);


            //Loop over users to populate the VM
            // - instantiate VM
            // - use _rolesService
            // - Creat multi selects
            foreach(BTUser user in users)
            {
                ManageUserRolesViewModel viewModel = new();
                viewModel.BTUser = user;
                IEnumerable<string> selected = await _rolesService.GetUserRolesAsync(user);
                viewModel.Roles = new MultiSelectList(await _rolesService.GetRolesAsync(), "Name", "Name", selected);

                model.Add(viewModel);
            }

            // return VM
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageUserRoles(ManageUserRolesViewModel member)
        {
            //Get companyId
            int companyId = User.Identity.GetCompanyId().Value;

            //Instantiate the BTUser
            BTUser btUser = (await _companyInfoService.GetAllMembersAsync(companyId)).FirstOrDefault(u => u.Id == member.BTUser.Id);

            //Get roles for the user
            IEnumerable<string> roles = await _rolesService.GetUserRolesAsync(btUser);


            //Grab the selected role
            string userRole = member.SelectedRoles.FirstOrDefault();

            if (!string.IsNullOrEmpty(userRole))
            {
                if (await _rolesService.RemoveUserFromRolesAsync(btUser, roles))
                {
                    await _rolesService.AddUserToRoleAsync(btUser, userRole);
                }
            }
            //Nav back to the view
            return RedirectToAction(nameof(ManageUserRoles));
        }



    }
}
