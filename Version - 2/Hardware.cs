using System;
using System.Collections.Generic;
using AssetManagement;

namespace AssetManagement
{
    public class Hardware : Asset
    {
        private long _hardwareId;
        private string _hardwareName, _hardwareCompany;
        
        public Hardware(){

        }
        public Hardware(long hardwareId, string hardwareName, string hardwareCompany, long assetCost){
            this._hardwareId = hardwareId;
            this._hardwareName = hardwareName;
            this._hardwareCompany = hardwareCompany;
            this.assetCost = assetCost;
            this.assetId = Asset.GetAssetId();
        }
        
        
        public void DisplayAllHardware(SortedDictionary<long, Hardware> hardwareDict){
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Display all Hardwares : ");

            foreach(KeyValuePair<long, Hardware> keyValue in hardwareDict){
                Hardware hardware = keyValue.Value;
                hardware.DisplayHardware(hardware);
            }
        }
        
        public void DisplayHardware(Hardware hardware){
            
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Hardware is : ");
            Console.WriteLine("Asset ID : " + hardware.assetId);
            Console.WriteLine("Hardware Cost : " + hardware.assetCost);
            Console.WriteLine("Hardware ID : " + hardware._hardwareId);
            Console.WriteLine("Hardware Name : " + hardware._hardwareName);
            Console.WriteLine("Hardware Company Name : " + hardware._hardwareCompany);

            Console.WriteLine();
        }
        public void SearchHardware(SortedDictionary<long, Hardware > hardwareDict, long hardwareId){
            if(!hardwareDict.ContainsKey(hardwareId)){
                Console.WriteLine("Hardware with this id is not present!!!");
            }
            else{
                Hardware hardware = hardwareDict[hardwareId];
                hardware.DisplayHardware(hardware);
            }
        }

        public void DeleteHardware(ref SortedDictionary<long, Hardware> hardwareDict, long hardwareId){
            
            if (!hardwareDict.ContainsKey(hardwareId))
            {
                Console.WriteLine($"Hardware with this id - {hardwareId} is not present into list so no need of deletion");
            }
            else
            {
                hardwareDict.Remove(hardwareId);
                Console.WriteLine("Hardware has been deleted successfully");
            }
        }

        public void UpdateHardware(ref SortedDictionary<long, Hardware> hardwareDict, long hardwareId){
            
            Hardware hardware = new Hardware();

            hardware._hardwareId = hardwareId;
            hardware.assetId = hardwareDict[hardwareId].assetId;

            Console.WriteLine("Enter the updated hardware name : ");
            hardware._hardwareName = Console.ReadLine();

            Console.WriteLine("enter the updated company name by which hardware produced!!");
            hardware._hardwareCompany = Console.ReadLine();

            Console.WriteLine("Enter the updated cost of the hardware : ");
            hardware.assetCost = Convert.ToInt64(Console.ReadLine());
            
            hardwareDict.Remove(hardwareId);
            hardwareDict[hardwareId] = hardware;
        }
        public static Dictionary<string, string> GetNewHardware(SortedDictionary<long, Hardware> hardwareDict){
            Dictionary<string, string> newHardware = new Dictionary<string, string>();
            
            newHardware["hardwareId"] = GetHardwareId(hardwareDict);

            Console.WriteLine("Enter Hardware Name : ");
            newHardware["hardwareName"] = Console.ReadLine();

            Console.WriteLine("Enter Hardware Company name :");
            newHardware["hardwareCompany"] = Console.ReadLine();

            Console.WriteLine("Enter hardware cost : ");
            newHardware["hardwareCost"] = Console.ReadLine();

            return newHardware;

        }

        private static string GetHardwareId(SortedDictionary<long, Hardware> hardwareDict){
            AgainEnter:
            Console.WriteLine("Enter Hardware ID : ");
            string hardwareId = Console.ReadLine();
            
            if(hardwareDict.ContainsKey(Convert.ToInt64(hardwareId))){
                Console.WriteLine("Hardware with this id is already present. So again enter another hardware id");
                goto AgainEnter;
            }
            else{
                return hardwareId;
            }
        }
    }

}