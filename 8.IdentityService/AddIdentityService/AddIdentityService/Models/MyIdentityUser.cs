using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddIdentityService.Models
{
    public class MyIdentityUser:IdentityUser
    {
        public string TCNO { get; set; }
    }
}
