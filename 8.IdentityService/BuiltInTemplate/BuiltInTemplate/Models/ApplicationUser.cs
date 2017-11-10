using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BuiltInTemplate.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser //IdentityUser ve IdentityRole sınıfları bizim built-in olarak bulunuyor.varsayılan kullanıcı ve rol sınıfları. szi eğer bunu genişletmek istiyosaız bir sınıf yazıp kalıtım yapmalısınız
    {
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

    }
}
