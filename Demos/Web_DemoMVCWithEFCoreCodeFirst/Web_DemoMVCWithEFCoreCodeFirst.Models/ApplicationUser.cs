using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Web_DemoMVCWithEFCoreCodeFirst.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? Address { get; set; }
    }
}
