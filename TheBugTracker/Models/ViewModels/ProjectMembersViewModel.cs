using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBugTracker.Models.ViewModels
{
    public class ProjectMembersViewModel
    {
        public Project Project { get; set; }

        public MultiSelectList Users { get; set; }

        //multiple members wanted to add to project
        //when submit is hit. users will go to POST Method
        public List<string> SelectedUsers { get; set; }
    }
}
