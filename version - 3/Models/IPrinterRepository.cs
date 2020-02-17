
using System.Collections.Generic;

namespace version_1.Models
{
    public interface IPrinterRepository
    {
        public void AddNewPrinter(Printer printer);
        public IEnumerable<Printer > SearchPrinter(string printerName);
        public void DeletePrinter(int assetId);
        public void UpdatePrinter(Printer printer);
        public Printer GetPrinterById(int id);
        public IEnumerable<Printer > GetAllPrinters();

        public int TotalPrinters();
    }
}