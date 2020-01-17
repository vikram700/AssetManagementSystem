
using System;
using System.Collections.Generic;
using AssetManagement;

namespace AssetManagement
{
    public class Program
    {
        public static void Main(string[] args){

            // List of all Assets : Book, Software License and Hardware
            SortedDictionary<long, Book> bookDict = new SortedDictionary<long, Book>();
            SortedDictionary<long, SoftwareLicense> softwareLicenseDict = new SortedDictionary<long, SoftwareLicense>();
            SortedDictionary<long, Hardware> hardwareDict = new SortedDictionary<long, Hardware>();


            // all the operation onto the assets is followed here
            while (true){

                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.WriteLine("1> Add Asset \n2> Search Asset \n3> Update Asset \n4> Delete Asset \n5> List Assets \n6> Exit.");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------------");

                long operationType = Convert.ToInt64(Console.ReadLine());
                bool noOperationSelected = false;

                string operationOnAsset;
                switch (operationType){

                    case 1:
                        operationOnAsset = SelectAssetForOperation("Add Asset");
                        if (operationOnAsset == "book"){
                            Dictionary<string, string> newBookDict = Book.GetNewBook(bookDict);   // this Dictionary consist information about to a book.
                            Book newBook = new Book(Convert.ToInt64(newBookDict["bookId"]), newBookDict["bookTitle"], newBookDict["bookAuthorName"], newBookDict["bookPublisher"], Convert.ToInt64(newBookDict["bookPublishedYear"]), Convert.ToInt64(newBookDict["bookCost"]));
                            newBook.AddNewAsset(ref bookDict, newBook, Convert.ToInt64(newBookDict["bookId"]));
                            
                        }
                        else if (operationOnAsset == "software license"){
                            Dictionary<string, string> newSoftwareDict = SoftwareLicense.GetNewSoftwareLicense(softwareLicenseDict); // this dictionary consist information about a software. 
                            SoftwareLicense newSoftware = new SoftwareLicense(Convert.ToInt64(newSoftwareDict["licenseId"]), newSoftwareDict["softwareName"], newSoftwareDict["softwareIssuedBy"], Convert.ToInt64(newSoftwareDict["softwareCost"]));
                            newSoftware.AddNewAsset(ref softwareLicenseDict, newSoftware, Convert.ToInt64(newSoftwareDict["licenseId"]));
                        
                        }
                        else {
                            Dictionary<string, string> newHardwareDict = Hardware.GetNewHardware(hardwareDict); // this dictionary consist infromation about a hardware
                            Hardware newHardware = new Hardware(Convert.ToInt64(newHardwareDict["hardwareId"]), newHardwareDict["hardwareName"], newHardwareDict["hardwareCompany"], Convert.ToInt64(newHardwareDict["hardwareCost"]));
                            newHardware.AddNewAsset(ref hardwareDict, newHardware, Convert.ToInt64(newHardwareDict["hardwareId"]));
                        
                        }
                        break;

                    
                    case 2:
                        operationOnAsset = SelectAssetForOperation("Search Asset");
                        if (operationOnAsset == "book"){
                            Book book = new Book();
                            long bookId = GetAssetIDInformation("book");
                            book.SearchBook(bookDict, bookId);

                        }
                        else if (operationOnAsset == "software license"){
                            SoftwareLicense softwareLicense = new SoftwareLicense();
                            long licenseId = GetAssetIDInformation("software");
                            softwareLicense.SearchSoftwareLicense(softwareLicenseDict, licenseId);
                        }
                        else{
                            Hardware hardware = new Hardware();
                            long hardwareId = GetAssetIDInformation("hardware");
                            hardware.SearchHardware(hardwareDict, hardwareId);
                        }
                        break;

                    case 3:

                        operationOnAsset = SelectAssetForOperation("Update Asset");
                        if (operationOnAsset == "book"){
                            long bookId = GetAssetIDInformation("book");
                            Book book = new Book();

                            if (!bookDict.ContainsKey(bookId)){
                                Console.WriteLine($"book with book id - {bookId} not present, so we cannot update it.");
                            }
                            else{
                                book.UpdateBook(ref bookDict, bookId);
                                Console.WriteLine("Book has benn successfully updated");
                            }
                        }
                        else if (operationOnAsset == "software license"){
                            long licenseId = GetAssetIDInformation("software license");
                            SoftwareLicense softwareLicense = new SoftwareLicense();

                            if (!softwareLicenseDict.ContainsKey(licenseId)){
                                Console.WriteLine($"software with software id - {licenseId} not present, So we cannot update it.");
                            }
                            else{
                                softwareLicense.UpdateSoftwareLicense(ref softwareLicenseDict, licenseId);
                                Console.WriteLine("Software license has been successfully Updated!!!");
                            }
                        }
                        else{
                            long hardwareId = GetAssetIDInformation("hardware");
                            Hardware hardware = new Hardware();
                            
                            if (!hardwareDict.ContainsKey(hardwareId)){
                                Console.WriteLine($"hardware with hardware id {hardwareId} not present, so we cannot update it.");
                            }
                            else{
                                hardware.UpdateHardware(ref hardwareDict, hardwareId);
                                Console.WriteLine("Hardware has been successfully updated");
                            }
                        }
                        break;

                    
                    case 4:

                        operationOnAsset = SelectAssetForOperation("Delete Asset");
                        if (operationOnAsset == "book"){
                            Book book = new Book();
                            long bookId = GetAssetIDInformation("book");
                            book.DeleteBook(ref bookDict, bookId);

                        }
                        else if (operationOnAsset == "software license"){
                            SoftwareLicense software = new SoftwareLicense();
                            long licenseId = GetAssetIDInformation("Software");
                            software.DeleteSoftwareLicense(ref softwareLicenseDict, licenseId);

                        }
                        else{
                            Hardware hardware = new Hardware();
                            long hardwareId = GetAssetIDInformation("Hardware");
                            hardware.DeleteHardware(ref hardwareDict, hardwareId);

                        }

                        break;
                        
                    
                    case 5:

                        operationOnAsset = SelectAssetForOperation("Traverse Assets");
                        if (operationOnAsset == "book"){
                            Book book = new Book();
                            book.DisplayAllBook(bookDict);
                        
                        }
                        else if (operationOnAsset == "software license"){
                            SoftwareLicense softwareLicense = new SoftwareLicense();
                            softwareLicense.DisplayAllSoftwareLicense(softwareLicenseDict);
                        
                        }
                        else{
                            Hardware hardware = new Hardware();
                            hardware.DisplayAllHardware(hardwareDict);
                        
                        }
                        break;

                    default:
                        noOperationSelected = true;
                        Console.WriteLine("User do not want to perform any operation :");
                        break;
                }

                if (noOperationSelected) break;
            }

            Console.WriteLine();
            Console.WriteLine("App Closed");
        }

        public static string SelectAssetForOperation(string assetOperationName){
            
            AgainEnter:
            Console.WriteLine($"Enter the Asset on which {assetOperationName} operation will be performed!!!, Select - book, software license or hardware");
            string assetName = Console.ReadLine();
            assetName.ToLower();
            if (assetName != "book" && assetName != "software license" && assetName != "hardware") goto AgainEnter;
            return assetName;
        }

        public static long GetAssetIDInformation(string assetName){
            Console.WriteLine($"Enter the {assetName} ID on which you want to perform operation : ");
            long assetIDInformation = Convert.ToInt64(Console.ReadLine());

            return assetIDInformation;
        }
    }
}