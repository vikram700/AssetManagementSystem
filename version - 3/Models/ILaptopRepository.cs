
using System.Collections.Generic;

namespace version_1.Models
{
    public interface ILaptopRepository
    {
        public void AddNewLaptop(Laptop laptop);
        public IEnumerable<Laptop > SearchLaptop(string laptopName);
        public void DeleteLaptop(int assetId);
        public void UpdateLaptop(Laptop laptop);
        public Laptop GetLaptopById(int id);
        public IEnumerable<Laptop > GetAllLaptops();

        public int TotalLaptops();
    }
}