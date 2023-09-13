using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.BookStore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name = "Bangla ")]
        Bangla=10,
        [Display(Name = "Eglish ")]
        English=11,
        [Display(Name = "German ")]
        German=12,
        [Display(Name = "Chinse ")]
        Chinese=13,
        [Display(Name = "Urdu ")]
        Urdu=14
    }
}
