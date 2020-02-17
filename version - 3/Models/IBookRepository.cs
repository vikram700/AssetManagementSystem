using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace version_1.Models
{
    public interface IBookRepository
    {   
        public void AddNewBook(Book book);
        public IEnumerable<Book > SearchBook(string bookName);
        public void DeleteBook(int assetId);
        public void UpdateBook(Book book);
        public Book GetBookById(int id);
        public IEnumerable<Book > GetAllBooks();
       
    }
}