using System;

namespace Webgentle.BookStore.Data
{
    public class Books
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Aurthor { get; set; }
        public string Discription { get; set; }
        public string Category { get; set; }
        public int LanguageId { get; set; }
        public int TotalPages { get; set; }

        public DateTime? CreatedOn { get; set; }    
        public DateTime? UpdateOn { get; set; } 

        public Language Language { get; set; }
    }
}
