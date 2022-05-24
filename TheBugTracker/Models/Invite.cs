using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TheBugTracker.Models
{
    public class Invite
    {
        //Primary Key
        public int Id { get; set; }

        [DisplayName("Date Sent")]
        public DateTimeOffset InviteDate { get; set; }

        [DisplayName("Join Date")]
        public DateTimeOffset JoinDate { get; set; }

        //GUID - Global Unique Identifier
        //Alpha Numeric - 15 characters or so, letters and numbers 
        [DisplayName("Code")]
        public Guid CompanyToken { get; set; }

        //reps primary key in another table 
        [DisplayName("Company")]
        public int CompanyID { get; set; }

        [DisplayName("Project")]
        public int ProjectID { get; set; }

        [DisplayName("Invitor")]
        public string InvitorId { get; set; }

        [DisplayName("Invitee")]
        public string InviteeID { get; set; }

        [DisplayName("Invitee Email")]
        public int InviteeEmail { get; set; }

        [DisplayName("Invitee First Name")]
        public int InviteeFirstName { get; set; }

        [DisplayName("Invitee Last Name")]
        public int InviteeLastName { get; set; }

        public bool IsValid { get; set; }

        //Nav Props
        public virtual Company Company { get; set; }

        public virtual BTUser Invitor { get; set; }

        public virtual BTUser Invitee { get; set; }

        public virtual Project Project { get; set; }
    }
}
