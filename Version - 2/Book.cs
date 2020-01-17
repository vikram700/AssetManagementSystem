using System.Collections;
using System;
using System.Collections.Generic;
using AssetManagement;

namespace AssetManagement
{
    public class Book : Asset
    {
        private long _bookPublishedYear, _bookId;
        private string _bookTitle, _bookAuthorName, _bookPublisher;
        

        public Book(){

        }
        public Book(long bookId, string bookTitle, string bookAuthorName, string bookPublisher, long bookPublishedYear, long assetCost){
            this._bookId = bookId;
            this._bookTitle = bookTitle;
            this._bookAuthorName = bookAuthorName;
            this._bookPublisher = bookPublisher;
            this._bookPublishedYear = bookPublishedYear;
            this.assetCost = assetCost;
            this.assetId = Asset.GetAssetId();
        }
        
        public void DisplayAllBook(SortedDictionary<long, Book> bookDict){
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Display all books : ");
            
            foreach(KeyValuePair<long, Book> keyValue in bookDict){
                Book book = keyValue.Value;
                book.DisplayBook(book);
            }
        }
        
        public void DisplayBook(Book book){

            Console.WriteLine("Book is : ");
            Console.WriteLine("Asset ID " + book.assetId);
            Console.WriteLine("Book Cost : " + book.assetCost);
            Console.WriteLine("Book Id : " + book._bookId);
            Console.WriteLine("Book title : " + book._bookTitle);
            Console.WriteLine("Book Author Name : " + book._bookAuthorName);
            Console.WriteLine("Book Publisher Name : " + book._bookPublisher);
            Console.WriteLine("Book Published Year : " + book._bookPublishedYear);
            
            Console.WriteLine();
        }

        public void SearchBook(SortedDictionary<long, Book> bookDict, long bookId){
            if(!bookDict.ContainsKey(bookId)){
                Console.WriteLine("Book with this id is not present!!!");
            }
            else{
                Book book = bookDict.GetValueOrDefault(bookId);
                book.DisplayBook(book);
            }
        }

        public void DeleteBook(ref SortedDictionary<long, Book> bookDict, long bookId){
             
            if (!bookDict.ContainsKey(bookId))
            {
                Console.WriteLine($"Book with this id - {bookId} is not present into list so no need of deletion");
            }
            else
            {
                bookDict.Remove(bookId);
                Console.WriteLine("Book has been successfully deleted!!!");
            }
        }

        public void UpdateBook(ref SortedDictionary<long, Book> bookDict, long bookId){
            
            Book book = new Book();

            book._bookId = bookId;
            book.assetId = bookDict[bookId].assetId;

            Console.WriteLine("Enter the new Book Name : ");
            book._bookTitle = Console.ReadLine();

            Console.WriteLine("Enter the new author name : ");
            book._bookAuthorName = Console.ReadLine();

            Console.WriteLine("Enter the new publisher name : ");
            book._bookPublisher = Console.ReadLine();

            Console.WriteLine("Enter the updated book published year:");
            book._bookPublishedYear = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter the updated cost :");
            book.assetCost = Convert.ToInt64(Console.ReadLine());
            
            bookDict.Remove(bookId);
            bookDict[bookId] = book;
        }

        public static Dictionary<string, string> GetNewBook(SortedDictionary<long, Book> bookDict){
            Dictionary<string, string> newBook = new Dictionary<string, string>();
            
            newBook["bookId"] = GetBookId(bookDict);

            Console.WriteLine("Enter Book Title : ");
            newBook["bookTitle"] = Console.ReadLine();

            Console.WriteLine("Enter Book Author Name : ");
            newBook["bookAuthorName"] = Console.ReadLine();

            Console.WriteLine("Book Publisher name : " );
            newBook["bookPublisher"] = Console.ReadLine();

            Console.WriteLine("Book published Year : ");
            newBook["bookPublishedYear"] = Console.ReadLine();

            Console.WriteLine("Enter book Cost : ");
            newBook["bookCost"] = Console.ReadLine();

            return newBook;
        }

        private static string GetBookId(SortedDictionary<long, Book> bookDict){

            AgainEnter :
            
            Console.WriteLine("Enter the book ID : ");
            string bookId = Console.ReadLine();
            
            if(bookDict.ContainsKey(Convert.ToInt64(bookId)) == true){
                Console.WriteLine("Book with this id is already present, So again enter another bookID");
                goto AgainEnter;
            } 
            else{
                return bookId;
            }
        }
    }
}