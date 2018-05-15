//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobPortal_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.JobApplications = new HashSet<JobApplication>();
            this.Listings = new HashSet<Listing>();
            this.Messages = new HashSet<Message>();
            this.Messages1 = new HashSet<Message>();
        }
    
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<double> Gpa { get; set; }
        public Nullable<double> Age { get; set; }
        public Nullable<double> Experience { get; set; }
    
        public virtual ICollection<JobApplication> JobApplications { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Message> Messages1 { get; set; }
    }
}
