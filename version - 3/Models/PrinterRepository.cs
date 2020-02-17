
using System.Linq;
using System.Collections.Generic;

namespace version_1.Models
{
    public class PrinterRepository : IPrinterRepository
    {   
        private List<Printer > _printerList;
        private readonly IHardwareRepository _hardwareRepository;

        public PrinterRepository()
        {    
            _hardwareRepository = new HardwareRepository();

            _printerList = new List<Printer>()
            {
                new Printer() { AssetId = 1, HardwareType = "Laptop", PrinterName = "Printer HP", CompanyName = "HP", PrinterType = "Color",
                                PrinterQuality = "Low", AssetPrice = 234.234},
                new Printer() { AssetId = 2, HardwareType = "Laptop", PrinterName = "Mac Book", CompanyName = "Lenovo ", PrinterType = "Black",
                                PrinterQuality = "High", AssetPrice = 345.56}
            };
        }

        public int TotalPrinters()
        {
            return _printerList.Count;
        }
        
        public void AddNewPrinter(Printer printer)
        {   
            printer.AssetId = _printerList.Max(ele => ele.AssetId) + 1;
            printer.HardwareType = "Printer";

            _printerList.Add(printer);
        }

        public void DeletePrinter(int assetId)
        {
            for(int index = 0; index < _printerList.Count; ++index)
            {
                if(_printerList[index].AssetId == assetId)
                {
                    _printerList.RemoveAt(index);
                    break;
                }
            }
        }

        public IEnumerable<Printer> GetAllPrinters()
        {
            return _printerList;
        }

        public Printer GetPrinterById(int id)
        {
            foreach(Printer printer in _printerList)
            {
                if(printer.AssetId == id)
                {
                    return printer;
                }
            }

            return null;
        }

        public IEnumerable<Printer> SearchPrinter(string printerName)
        {
            List<Printer > searchedPrinters = new List<Printer >();

            string[] searchedKeyword = printerName.Split(" ");

            foreach(Printer printer in _printerList)
            {
                string[] presentPrinterKeyword = printer.PrinterName.Split(" ");
                
                bool isKeyFound = false;

                foreach(var searchKey in searchedKeyword)
                {   
                    bool isKeyPresent = false;

                    foreach(var presentKey in presentPrinterKeyword)
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
                    searchedPrinters.Add(printer);
                }
            }

            return searchedPrinters;
        }

        public void UpdatePrinter(Printer printer)
        {
            for (int index = 0; index < _printerList.Count; index++)
            {
                if(_printerList[index].AssetId == printer.AssetId)
                {
                    _printerList[index] = printer;
                    break;
                }
            }
        }
    }
}