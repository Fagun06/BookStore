using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;

namespace Webgentle.BookStore.Controllers
{
    public class BookController : Controller
    {

        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data =await _bookRepository.GetAllBooks();
            return View(data);
        }
        [Route("book-details/{id}", Name ="bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id) 
        {
          
            var data=await _bookRepository.GetAllBookById(id);;
            return View(data);
        }
        public List<BookModel> SearchBooks(string bN, string aN)
        {
            return _bookRepository.SearchBook(bN, aN);
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel()
            {
               // Language = "2"
            };

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            int id =await _bookRepository.AddBook(bookModel);

            if(ModelState.IsValid) 
            {
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }

            }
            //ViewBag.IsSuccess = false;
            //ViewBag.BookId = 0;


            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            return View();

        }

    }
}
