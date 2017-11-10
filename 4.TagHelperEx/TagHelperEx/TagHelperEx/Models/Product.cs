using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelperEx.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} alanı gerekli")]
        public int ProductId { get; set; }
        [Required(ErrorMessage ="{0} alanı gerekli")]
        [StringLength(128,MinimumLength =5,ErrorMessage ="{0} alanı en fazla {1} en az {2} karakter uzunluğunda olmalı")]
        public string Name { get; set; }
        public bool IsInStock { get; set; }
    }
}
