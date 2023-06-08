using Microsoft.AspNetCore.Identity;
using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace TestProject1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "User Lastname is required")]
        public string? Lastname { get; set; }
        public string? Birthday { get; set; }

        public string? Country { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }
        
        public string? Zip { get; set; }

        public string? Role { get; set; }

        public Podcast? Podcast { get; set; }

        //[Required(ErrorMessage = "Agreement not accepted!")]
        //public bool? AcceptAgreement { get; set; }

        public bool DebugMode { get; set; } = false;
    }
}
