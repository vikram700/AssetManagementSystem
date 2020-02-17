
using System.Linq;
using System.Collections.Generic;

namespace version_1.Models
{
    public class LaptopRepository : ILaptopRepository
    {   
        private List<Laptop > _laptopList;
        private readonly IHardwareRepository _hardwareRepository;

        public LaptopRepository()
        {    
            _hardwareRepository = new HardwareRepository();

            _laptopList = new List<Laptop>()
            {
                new Laptop() { AssetId = 1, HardwareType = "Laptop", LaptopName = "Lenovo Large", CompanyName = "HP", SerialNumber = "QAS123ER",
                                OperatingSystem = "Window", WarrantyPeriod = 3, AssetPrice = 234.234},
                new Laptop() { AssetId = 2, HardwareType = "Laptop", LaptopName = "Mac Book", CompanyName = "Lenovo ", SerialNumber = "QWE345EARS",
                                OperatingSystem = "DOS", WarrantyPeriod = 4, AssetPrice = 345.56}
            };
        }

        public int TotalLaptops()
        {
            return _laptopList.Count;
        }
        
        public void AddNewLaptop(Laptop laptop)
        {   
            laptop.AssetId = _laptopList.Max(ele => ele.AssetId) + 1;
            laptop.HardwareType = "Laptop";

            _laptopList.Add(laptop);
        }

        public void DeleteLaptop(int assetId)
        {
            for(int index = 0; index < _laptopList.Count; ++index)
            {
                if(_laptopList[index].AssetId == assetId)
                {
                    _laptopList.RemoveAt(index);
                    break;
                }
            }
        }

        public IEnumerable<Laptop> GetAllLaptops()
        {
            return _laptopList;
        }

        public Laptop GetLaptopById(int id)
        {
            foreach(Laptop laptop in _laptopList)
            {
                if(laptop.AssetId == id)
                {
                    return laptop;
                }
            }

            return null;
        }

        public IEnumerable<Laptop> SearchLaptop(string laptopName)
        {
            List<Laptop > searchedLaptops = new List<Laptop >();

            string[] searchedKeyword = laptopName.Split(" ");

            foreach(Laptop laptop in _laptopList)
            {
                string[] presentLaptopKeyword = laptop.LaptopName.Split(" ");
                
                bool isKeyFound = false;

                foreach(var searchKey in searchedKeyword)
                {   
                    bool isKeyPresent = false;

                    foreach(var presentKey in presentLaptopKeyword)
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
                    searchedLaptops.Add(laptop);
                }
            }

            return searchedLaptops;
        }

        public void UpdateLaptop(Laptop laptop)
        {
            for (int index = 0; index < _laptopList.Count; index++)
            {
                if(_laptopList[index].AssetId == laptop.AssetId)
                {
                    _laptopList[index] = laptop;
                    break;
                }
            }
        }
    }
}