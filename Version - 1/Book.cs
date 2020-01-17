using System.Collections;
using System;
using System.Collections.Generic;
using AssetManagement;

namespace AssetManagement
{
    public class Book : Asset
    {
        int BookPublishedYear, BookID;
        string BookTitle, BookAuthorName, BookPublisher;
        

        public Book(){

        }
        public Book(int BookID, string BookTitle, string BookAuthorName, string BookPublisher, int BookPublishedYear, int AssetCost){
            this.BookID = BookID;
            this.BookTitle = BookTitle;
            this.BookAuthorName = BookAuthorName;
            this.BookPublisher = BookPublisher;
            this.BookPublishedYear = BookPublishedYear;
            this.AssetCost = AssetCost;
            this.AssetID = Asset.GetAssetID();
        }
        
        public void DisplayBook(Book book){
            Console.WriteLine("Asset ID " + book.AssetID);
            Console.WriteLine("Book Cost : " + book.AssetCost);
            Console.WriteLine("Book Id : " + book.BookID);
            Console.WriteLine("Book title : " + book.BookTitle);
            Console.WriteLine("Book Author Name : " + book.BookAuthorName);
            Console.WriteLine("Book Publisher Name : " + book.BookPublisher);
            Console.WriteLine("Book Published Year : " + book.BookPublishedYear);

            Console.WriteLine();
        }
        
        public Book SearchBook(List<Book > BookList, int bookID){
            
            foreach(Book book in BookList){
                if(book.BookID == bookID){
                    return book;
                }
            }
            return null;
        }

        public void DeleteBook(ref List<Book > BookList, int bookID){
            int indexOfBook = 0;

            foreach(Book book in BookList){
                if(book.BookID == bookID){
                    break;
                }
                indexOfBook++;
            }

            BookList.RemoveAt(indexOfBook);
        }

        public void UpdateBook(ref List<Book > BookList, int bookID){
            
             foreach(Book book in BookList){
                 if(book.BookID == bookID){
                     
                     Console.WriteLine("Enter the new Book Name : ");
                     book.BookTitle = Console.ReadLine();

                     Console.WriteLine("Enter the new author name : ");
                     book.BookAuthorName = Console.ReadLine();

                     Console.WriteLine("Enter the new publisher name : ");
                     book.BookPublisher = Console.ReadLine();

                     Console.WriteLine("Enter the updated book published year:");
                     book.BookPublishedYear = Convert.ToInt32(Console.ReadLine());

                     Console.WriteLine("Enter the updated cost :");
                     book.AssetCost = Convert.ToInt32(Console.ReadLine());
                     break;
                 }
             }
        }
        public static Dictionary<string, string> GetNewBook(){
            Dictionary<string, string> NewBook = new Dictionary<string, string>();
            
            Console.WriteLine("Enter the book ID : ");
            NewBook["BookID"] = Console.ReadLine();

            Console.WriteLine("Enter Book Title : ");
            NewBook["BookTitle"] = Console.ReadLine();

            Console.WriteLine("Enter Book Author Name : ");
            NewBook["BookAuthorName"] = Console.ReadLine();

            Console.WriteLine("Book Publisher name : " );
            NewBook["BookPublisher"] = Console.ReadLine();

            Console.WriteLine("Book published Year : ");
            NewBook["BookPublishedYear"] = Console.ReadLine();

            Console.WriteLine("Enter book Cost : ");
            NewBook["BookCost"] = Console.ReadLine();

            return NewBook;
        }

        public static bool CheckBookAlreadyPresent(Dictionary<string, string> NewBook, List<Book> BookList){
            
            foreach(Book book in BookList){
                if(book.BookID == Convert.ToInt32(NewBook["BookID"]) && book.BookTitle == NewBook["BookTitle"] && book.BookAuthorName == NewBook["BookAuthorName"]
                   && book.BookPublisher == NewBook["BookPublisher"] && book.BookPublishedYear == Convert.ToInt32(NewBook["BookPublishedYear"]) && book.AssetCost == Convert.ToInt32(NewBook["BookCost"])){
                   
                   return true;
                }
            }
            return false;
        }
    }
}