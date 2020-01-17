using System;
using System.Collections.Generic;
using AssetManagement;

namespace AssetManagement
{
     public class Solution
    {
        public static void Main(string[] args){

            // List of all Assets : Book, Software License and Hardware
            List<Book> BookList = new List<Book >();
            List<SoftwareLicense> SoftwareLicenseList = new List<SoftwareLicense >();
            List<Hardware> HardwareList = new List<Hardware >();


            // all the operation onto the assets is followed here
            while(true){
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.WriteLine("1> Add Asset \n2> Search Asset \n3> Update Asset \n4> Delete Asset \n5> List Assets \n6> Exit.");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                
                int OperationType = Convert.ToInt32(Console.ReadLine());
                bool NoOperationSelected = false;
                
                string OperationOnAsset;
                switch(OperationType){
                    case 1:
                        OperationOnAsset = SelectAssetForOperation("Add Asset");
                        if(OperationOnAsset == "book"){
                           Dictionary<string, string> NewBookDict = Book.GetNewBook();   // this Dictionary consist information about to a book.
                           if(Book.CheckBookAlreadyPresent(NewBookDict, BookList)){
                               Console.WriteLine("This book already present into the book list!!");
                           }
                           else{
                               Book newBook = new Book(Convert.ToInt32(NewBookDict["BookID"]), NewBookDict["BookTitle"], NewBookDict["BookAuthorName"], NewBookDict["BookPublisher"], Convert.ToInt32(NewBookDict["BookPublishedYear"]), Convert.ToInt32(NewBookDict["BookCost"]));
                               Asset.AddNewAsset(ref BookList, newBook);
                           }
                        }
                        else if(OperationOnAsset == "software license"){
                            Dictionary<string, string> NewSoftwareDict = SoftwareLicense.GetNewSoftwareLicense(); // this dictionary consist information about a software. 
                            if(SoftwareLicense.CheckSoftwareAlreadyPresent(NewSoftwareDict, SoftwareLicenseList)){
                                Console.WriteLine("This software already present into the list, So no need to add it again");
                            }
                            else{
                                SoftwareLicense NewSoftware = new SoftwareLicense(Convert.ToInt32(NewSoftwareDict["LicenseID"]), NewSoftwareDict["SoftwareName"], NewSoftwareDict["SoftwareIssuedBy"], Convert.ToInt32(NewSoftwareDict["SoftwareCost"]));
                                Asset.AddNewAsset(ref SoftwareLicenseList, NewSoftware);
                            }
                        }
                        else{
                            Dictionary<string, string> NewHardwareDict = Hardware.GetNewHardware(); // this dictionary consist infromation about a hardware
                            if(Hardware.CheckHardwareAlreadyPresent(NewHardwareDict, HardwareList)){
                                Console.WriteLine("This hardware already present into the hardware list, So no need to add it again");

                            }
                            else{
                                Hardware NewHardware = new Hardware(Convert.ToInt32(NewHardwareDict["HardwareID"]), NewHardwareDict["HardwareName"], NewHardwareDict["HardwareCompany"], Convert.ToInt32(NewHardwareDict["HardwareCost"]));
                                Asset.AddNewAsset(ref HardwareList, NewHardware);
                            }
                        }
                        break;

                    case 2:
                        OperationOnAsset = SelectAssetForOperation("Search Asset");
                        if(OperationOnAsset == "book"){
                           Book book = new Book();
                           int bookID = GetAssetIDInformation("book");
                           Book presentBook = book.SearchBook(BookList, bookID);
                           if(presentBook == null){
                               Console.WriteLine("Book with this book id is not present");
                           }
                           else{
                               Console.WriteLine($"Book with bookID - {bookID} is : ");
                               book.DisplayBook(presentBook);
                           }
                        }
                        else if(OperationOnAsset == "software license"){
                           SoftwareLicense softwareLicense = new SoftwareLicense();
                           int licenseID = GetAssetIDInformation("software");
                           SoftwareLicense presentSoftware = softwareLicense.SearchSoftwareLicense(SoftwareLicenseList, licenseID);
                           if(presentSoftware == null){
                               Console.WriteLine("Software with this software id not present : ");
                           }
                           else{
                               Console.WriteLine($"Software with License id - {licenseID} is : ");
                               softwareLicense.DisplaySoftwareLicense(presentSoftware);
                           }
                        }
                        else{
                           Hardware hardware = new Hardware();
                           int hardwareID = GetAssetIDInformation("hardware");
                           Hardware presentHardware = hardware.SearchHardware(HardwareList, hardwareID);
                           if(presentHardware == null){
                               Console.WriteLine("Hardware with this hardware id is not present : ");
                           }
                           else{
                               Console.WriteLine($"Hardware with hardware id - {hardwareID} is : ");
                               hardware.DisplayHardware(presentHardware);
                           }
                        }
                        
                        break;

                    case 3:
                        
                        OperationOnAsset = SelectAssetForOperation("Update Asset");
                        if(OperationOnAsset == "book"){
                            int bookID = GetAssetIDInformation("book");
                            Book book = new Book();
                            Book presentBook = book.SearchBook(BookList, bookID);
                            if(presentBook == null){
                                Console.WriteLine($"book with book id - {bookID} not present, so we cannot update it.");
                            }
                            else{
                                book.UpdateBook(ref BookList, bookID);
                                Console.WriteLine("Book has benn successfully updated");
                            }
                        }
                        else if(OperationOnAsset == "software license"){
                            int licenseID = GetAssetIDInformation("software license");
                            SoftwareLicense softwareLicense = new SoftwareLicense();
                            SoftwareLicense presentSoftware = softwareLicense.SearchSoftwareLicense(SoftwareLicenseList, licenseID);
                            
                            if(presentSoftware == null){
                                Console.WriteLine($"software with software id - {licenseID} not present, So we cannot update it.");
                            }
                            else{
                                softwareLicense.UpdateSoftwareLicense(ref SoftwareLicenseList, licenseID);
                                Console.WriteLine("Software license has been successfully Updated!!!");
                            }
                        }
                        else{
                            int hardwareID = GetAssetIDInformation("hardware");
                            Hardware hardware = new Hardware();
                            Hardware presentHardware = hardware.SearchHardware(HardwareList, hardwareID);

                            if(presentHardware == null){
                                Console.WriteLine($"hardware with hardware id {hardwareID} not present, so we cannot update it.");
                            }
                            else{
                                hardware.UpdateHardware(ref HardwareList, hardwareID);
                                Console.WriteLine("Hardware has been successfully updated");
                            }
                        }

                        break;
 
                    case 4:

                        OperationOnAsset = SelectAssetForOperation("Delete Asset");
                        if(OperationOnAsset == "book"){
                            Book book = new Book();
                            int bookID = GetAssetIDInformation("book");
                            Book presentBook = book.SearchBook(BookList ,bookID);
                            if(presentBook == null){
                                Console.WriteLine($"Book with this id - {bookID} is not present into list so no need of deletion");
                            }
                            else{
                                book.DeleteBook(ref BookList, bookID);
                                Console.WriteLine("Book has been successfully deleted!!!");
                            }
                        }
                        else if(OperationOnAsset == "software license"){
                            SoftwareLicense software = new SoftwareLicense();
                            int licenseID = GetAssetIDInformation("Software");
                            SoftwareLicense presentSoftware = software.SearchSoftwareLicense(SoftwareLicenseList, licenseID);
                            if(presentSoftware == null){
                                Console.WriteLine($"Software with this id - {licenseID} is not present into list so need of deletion");
                            }
                            else{
                                software.DeleteSoftwareLicense(ref SoftwareLicenseList, licenseID);
                                Console.WriteLine("Sfotware License has been deleted successfully");
                            }
                        }
                        else{
                            Hardware hardware = new Hardware();
                            int hardwareID = GetAssetIDInformation("Hardware");
                            Hardware presentHardware = hardware.SearchHardware(HardwareList, hardwareID);
                            if(presentHardware == null){
                                Console.WriteLine($"Hardware with this id - {hardwareID} is not present into list so no need of deletion");
                            }
                            else{
                                hardware.DeleteHardware(ref HardwareList, hardwareID);
                                Console.WriteLine("Hardware has been deleted successfully");
                            }
                        }

                        break;

                    case 5:
                        
                        OperationOnAsset = SelectAssetForOperation("Traverse Assets");
                        if(OperationOnAsset == "book"){
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("Display all books : ");
                            foreach(Book book in BookList){
                               book.DisplayBook(book);
                            }
                        }
                        else if(OperationOnAsset == "software license"){
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("Display all software license");
                            foreach(SoftwareLicense softwareLicense in SoftwareLicenseList){
                               softwareLicense.DisplaySoftwareLicense(softwareLicense);
                            }
                        }
                        else{
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine("Display all Hardwares : ");
                            foreach(Hardware hardware in HardwareList){
                               hardware.DisplayHardware(hardware);
                            }
                        }
                        break;
                
                    default:
                        NoOperationSelected = true;
                        Console.WriteLine("User do not want to perform any operation :");  
                        break;
                }

                if(NoOperationSelected) break;
            }

            Console.WriteLine();
            Console.WriteLine("App Closed");
        }
 
        public static string SelectAssetForOperation(string AssetOperationName){
            AgainEnter : 
            Console.WriteLine($"Enter the Asset on which {AssetOperationName} operation will be performed!!!, Select - book, software license or hardware");
            string AssetName = Console.ReadLine();
            AssetName.ToLower();
            if(AssetName != "book" && AssetName != "software license" && AssetName != "hardware") goto AgainEnter;
            return AssetName;
        }

        public static int GetAssetIDInformation(string AssetName){
            Console.WriteLine($"Enter the {AssetName} ID on which you want to perform operation : ");
            int AssetIDInformation  = Convert.ToInt32(Console.ReadLine());

            return AssetIDInformation;
        }
    }
}