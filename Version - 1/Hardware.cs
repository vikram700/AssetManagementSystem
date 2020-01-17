using System;
using System.Collections.Generic;
using AssetManagement;

namespace AssetManagement
{
    public class Hardware : Asset
    {
        int HardwareID;
        string HardwareName, HardwareCompany;
        
        public Hardware(){

        }
        public Hardware(int HardwareID, string HardwareName, string HardwareCompany, int AssetCost){
            this.HardwareID = HardwareID;
            this.HardwareName = HardwareName;
            this.HardwareCompany = HardwareCompany;
            this.AssetCost = AssetCost;
            this.AssetID = Asset.GetAssetID();
        }
        
        
        public void DisplayHardware(Hardware hardware){
            Console.WriteLine("Asset ID : " + hardware.AssetID);
            Console.WriteLine("Hardware Cost : " + hardware.AssetCost);
            Console.WriteLine("Hardware ID : " + hardware.HardwareID);
            Console.WriteLine("Hardware Name : " + hardware.HardwareName);
            Console.WriteLine("Hardware Company Name : " + hardware.HardwareCompany);

            Console.WriteLine();
        }

        public Hardware SearchHardware(List<Hardware > HardwareList, int hardwareID){

            foreach(Hardware hardware in HardwareList){
                if(hardware.HardwareID == hardwareID){
                    return hardware;
                }
            }
            return null;
        }

        public void DeleteHardware(ref List<Hardware > HardwareList, int hardwareID){
            int indexOfHardware = 0;

            foreach(Hardware hardware in HardwareList){
                if(hardware.HardwareID == hardwareID){
                    break;
                }
                indexOfHardware++;
            }

            HardwareList.RemoveAt(indexOfHardware);
        }

        public void UpdateHardware(ref List<Hardware > HardwareList, int hardwareID){

            foreach(Hardware hardware in HardwareList){
                if(hardware.HardwareID == hardwareID){
                    
                    Console.WriteLine("Enter the updated hardware name : ");
                    hardware.HardwareName = Console.ReadLine();

                    Console.WriteLine("enter the updated company name by which hardware produced!!");
                    hardware.HardwareCompany = Console.ReadLine();

                    Console.WriteLine("Enter the updated cost of the hardware : ");
                    hardware.AssetCost = Convert.ToInt32(Console.ReadLine());

                    break;
                }
            }
        }
        public static Dictionary<string, string> GetNewHardware(){
            Dictionary<string, string> NewHardware = new Dictionary<string, string>();

            Console.WriteLine("Enter Hardware ID : ");
            NewHardware["HardwareID"] = Console.ReadLine();

            Console.WriteLine("Enter Hardware Name : ");
            NewHardware["HardwareName"] = Console.ReadLine();

            Console.WriteLine("Enter Hardware Company name :");
            NewHardware["HardwareCompany"] = Console.ReadLine();

            Console.WriteLine("Enter hardware cost : ");
            NewHardware["HardwareCost"] = Console.ReadLine();

            return NewHardware;

        }


        public static bool CheckHardwareAlreadyPresent(Dictionary<string, string> NewHardware, List<Hardware > HardwareList){
            
            foreach(Hardware hardware in HardwareList){
                if(hardware.HardwareID == Convert.ToInt32(NewHardware["HardwareID"]) && hardware.HardwareName == NewHardware["HardwareName"] &&
                   hardware.HardwareCompany == NewHardware["HardwareCompany"] && hardware.AssetCost == Convert.ToInt32(NewHardware["HardwareCost"])){
                       return true;
                   }
            }
            return false;
        }
    }

}