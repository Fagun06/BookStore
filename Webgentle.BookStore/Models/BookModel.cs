using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Webgentle.BookStore.Enums;

namespace Webgentle.BookStore.Models
{
    public class BookModel
    {
      
        public int Id { get; set; }
        [StringLength(100,MinimumLength = 5)]
        [Required(ErrorMessage ="please enter the title of your book")]
        public string Title { get; set; }
        [Required(ErrorMessage ="please enter the Author name")]
        public string Aurthor { get; set; }

        [StringLength(300, MinimumLength = 10)]
        public string Discription { get; set; }
        public string Category { get; set; }

        [Required(ErrorMessage = "Please choose the language of your book")]
        public int LanguageId { get; set; }
        
        public string Language { get; set; }    

        [Required(ErrorMessage = "please enter the Total pages")]
        [Display(Name="Total Pages of Book")]
        public int? TotalPages { get; set; }
    }
}
