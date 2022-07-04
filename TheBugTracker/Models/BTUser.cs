using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheBugTracker.Models
{
    public class BTUser : IdentityUser  //inherits identity user role/claim and log in 
    {
        // ability to customize a user 
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName { get { return $"{FirstName } {LastName}"; } }

        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile AvatarFormFile { get; set; }

        [DisplayName("Avatar")]
        public string AvatarFileName { get; set; }

        public byte[] AvatarFileData { get; set; }

        [Display(Name ="File Extension")]
        public string AvatarContentType { get; set; }

        public int CompanyId { get; set; }

        //Nav Props
        public virtual Company Company { get; set; }

        //Relationship Between tables, many to many relationship between project and user 
        //User can be on many projects, etc
        //join table - list of ID's that allows for id's of projects to match up with the id of a user
        public virtual ICollection<Project> Projects { get; set; }
    }
}
