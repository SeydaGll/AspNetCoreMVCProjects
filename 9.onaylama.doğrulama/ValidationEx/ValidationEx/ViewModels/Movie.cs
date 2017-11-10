using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationEx.CustomValidation;

namespace ValidationEx.ViewModels
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(60,MinimumLength =3,ErrorMessage ="{0} alanı en fazla {1} ve en az {2} karakter olmalı")]
        [Required(ErrorMessage ="{0} alanı boş olamaz")] //zorunlu olduğunu bildirir. title alanı boş geçilemez
        [Display(Name ="Film Adı")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd.MM.yyyy}",ApplyFormatInEditMode =true)]
        [Display(Name ="Vizyon Tarihi")]
        public DateTime ReleaseDate { get; set; }

        [ClassicMovie]
        [DataType(DataType.Currency)] // para birimi olduğunu söyledik
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]  //regular expression: düzenli ifade
        public string Genre { get; set; }  //tür

        [Required]
        public string Rating { get; set; }
    }
}
