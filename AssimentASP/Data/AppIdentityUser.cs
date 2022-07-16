using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AssimentASP.Data
{
    public class AppIdentityUser:IdentityUser
    {
        [StringLength(100)]
        public string CompanyName { get; set; }
    }
}
