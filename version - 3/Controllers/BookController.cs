using System.Xml.Schema;
using System;
using Microsoft.AspNetCore.Mvc;
using version_1.Models;
using version_1.ViewModels;

namespace version_1.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ViewResult Details(string bookName)
        {   
            GenericViewModel<Book > bookViewModel = new GenericViewModel<Book>()
            {
                PageTitle = "Book Details"
            };

            if(string.IsNullOrEmpty(bookName))
            {
                bookViewModel.AssetType = _bookRepository.GetAllBooks();   
            }
            else if(!string.IsNullOrEmpty(bookName))
            {
                bookViewModel.AssetType = _bookRepository.SearchBook(bookName);
            }
            

            return View(bookViewModel);
        }
        
        [HttpGet]
        public ViewResult AddNewBook()
        {   
            return View("AddNewBook");
        }
        
        [HttpPost]
        public IActionResult AddNewBook(Book newBook)
        {
            if(ModelState.IsValid)
            {
                _bookRepository.AddNewBook(newBook);

                return RedirectToAction("Details");
            }

            return View();
        }

        [HttpGet]
        public IActionResult UpdateBook(int id)
        {   
            Book book = _bookRepository.GetBookById(id);

            return View(book);
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book, int id)
        {   
            if(ModelState.IsValid)
            {
                book.AssetId = id;

                _bookRepository.UpdateBook(book);

                return RedirectToAction("Details");
            }

            book = _bookRepository.GetBookById(id);
            
            return View(book);
        }
        
        public IActionResult Delete(int id)
        {
            _bookRepository.DeleteBook(id);

            return RedirectToAction("Details");
        }
    }
}