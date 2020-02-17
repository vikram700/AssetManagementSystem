using System.Linq;
using System;
using System.Collections.Generic;

namespace version_1.Models
{
    public class BookReposecond : IGenericinterface<Book >
    {   
        private List<Book > bookList;

        public BookReposecond()
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
        public void AddNewAsset(Book book)
        {
            book.AssetId = bookList.Max(ele => ele.AssetId) + 1;

            bookList.Add(book);
        }

        public void DeleteAsset(int assetId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllAssets()
        {
            throw new NotImplementedException();
        }

        public Asset GetAssetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> SearchAsset(string assetName)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsset(Asset asset)
        {
            throw new NotImplementedException();
        }

        // public void DeleteAsset(int assetId)
        // {
        //     foreach(Book book in bookList)
        //     {
        //         if(book.AssetId == assetId)
        //         {
        //             bookList.Remove(book);
        //             break;
        //         }
        //     }
        // }

        // public IEnumerable<Book> GetAllAssets()
        // {
        //     return bookList;
        // }

        // public Book GetAssetById(int id)
        // {
        //     foreach(Book book in bookList)
        //     {
        //         if(book.AssetId == id)
        //         {
        //             return book;
        //         }
        //     }

        //     return null;
        // }

        // public IEnumerable<Book> SearchAsset(string bookName)
        // {
        //     List<Book > searchedBooks = new List<Book>();

        //     string[] searchedKeyword = bookName.Split(" ");

        //     foreach(Book book in bookList)
        //     {
        //         string[] presentBookKeyword = book.BookTitle.Split(" ");

        //         bool isKeyFound = false;

        //         foreach(var searchKey in searchedKeyword)
        //         {   
        //             bool isKeyPresent = false;

        //             foreach(var presentKey in presentBookKeyword)
        //             {
        //                 if(searchKey.ToLower() == presentKey.ToLower())
        //                 {
        //                     isKeyPresent = true;
        //                     break;
        //                 }
        //             }

        //             if(isKeyPresent)
        //             {
        //                 isKeyFound = true;
        //                 break;
        //             }
        //         }

        //         if(isKeyFound)
        //         {
        //             searchedBooks.Add(book);
        //         }
        //     }

        //     return searchedBooks;
        // }

        // public void UpdateAsset(Book book)
        // {
        //     for(int i = 0; i < bookList.Count; i++)
        //     {
        //         if(bookList[i].AssetId == book.AssetId)
        //         {
        //             bookList[i] = book;
        //             break;
        //         }
        //     }
        // }
    }
}