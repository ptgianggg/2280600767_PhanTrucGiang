using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _2280600767_PhanTrucGiang.Models
{
    public class ApplicationUser : IdentityUser
    {
   
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Age { get; set; }
    }
}
