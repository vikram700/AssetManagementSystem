using System.Linq;
using System;
using System.Collections.Generic;

namespace version_1.Models
{
    public class BookRepository : IBookRepository
    {   
        private List<Book > bookList;

        public BookRepository()
        {
            bookList = new List<Book>()
            {
                new Book() { AssetId = 1, BookTitle = "Data Structure", BookAuthorName = "Devid", BookPublisher = "Starx",
                                BookPublishedYear = 2020, AssetPrice = 123.123},
                new Book() { AssetId = 2, BookTitle = "Operating System", BookAuthorName = "Vikram Singh", BookPublisher = "Starx",
                                BookPublishedYear = 2018, AssetPrice = 154.345},
                new Book() { AssetId = 3, BookTitle = "Database Management System", BookAuthorName = "Vedraj Sharma", BookPublisher = "Starx",
                                BookPublishedYear = 2019, AssetPrice = 154.123}
            };
        }
        public void AddNewBook(Book book)
        {
            book.AssetId = bookList.Max(ele => ele.AssetId) + 1;

            bookList.Add(book);
        }

        public void DeleteBook(int assetId)
        {
            foreach(Book book in bookList)
            {
                if(book.AssetId == assetId)
                {
                    bookList.Remove(book);
                    break;
                }
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return bookList;
        }

        public Book GetBookById(int id)
        {
            foreach(Book book in bookList)
            {
                if(book.AssetId == id)
                {
                    return book;
                }
            }

            return null;
        }

        public IEnumerable<Book> SearchBook(string bookName)
        {
            List<Book > searchedBooks = new List<Book>();

            string[] searchedKeyword = bookName.Split(" ");

            foreach(Book book in bookList)
            {
                string[] presentBookKeyword = book.BookTitle.Split(" ");
                
                bool isKeyFound = false;

                foreach(var searchKey in searchedKeyword)
                {   
                    bool isKeyPresent = false;

                    foreach(var presentKey in presentBookKeyword)
                    {
                        if(searchKey.ToLower() == presentKey.ToLower())
                        {
                            isKeyPresent = true;
                            break;
                        }
                    }

                    if(isKeyPresent)
                    {
                        isKeyFound = true;
                        break;
                    }
                }

                if(isKeyFound)
                {
                    searchedBooks.Add(book);
                }
            }

            return searchedBooks;
        }

        public void UpdateBook(Book book)
        {
            for(int i = 0; i < bookList.Count; i++)
            {
                if(bookList[i].AssetId == book.AssetId)
                {
                    bookList[i] = book;
                    break;
                }
            }
        }
    }
}