using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Data;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public BookRepository()
        {
        }

        public async Task<int> AddBook(BookModel model)
        {
            var newBook = new Books()
            {
                Aurthor = model.Aurthor,
                CreatedOn = DateTime.UtcNow,
                Discription = model.Discription,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages= model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdateOn= DateTime.UtcNow

            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks =await _context.Books.ToListAsync();

            if(allbooks?.Any()==true)
            {
                foreach(var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Aurthor = book.Aurthor,
                        Category=book.Category,
                        Discription=book.Discription,
                        Id=book.Id,
                        LanguageId=book.LanguageId,
                        Language = book.Language.Name,
                        Title =book.Title,
                        TotalPages=book.TotalPages

                    });  
                }
            }
            return books;
        }
        public async Task<BookModel> GetAllBookById(int id)
        {
            return  await _context.Books.Where(x => x.Id==id)
                .Select(book => new BookModel()
                {
                     Aurthor = book.Aurthor,
                     Category = book.Category,
                     Discription = book.Discription,
                     Id = book.Id,
                     LanguageId = book.LanguageId,
                     Language = book.Language.Name,
                     Title = book.Title,
                     TotalPages = book.TotalPages
                }).FirstOrDefaultAsync();

           
        }

        public List<BookModel> SearchBook(string title, string authorName) 
        { 
            return null;
        }


    }
}
