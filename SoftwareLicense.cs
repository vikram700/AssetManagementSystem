using System;
using System.Collections.Generic;
using AssetManagement;

namespace AssetManagement
{
    public class SoftwareLicense : Asset
    {
        int LicenseID;
        string SoftwareName, LicenseIssuedBy;
        
        public SoftwareLicense(){

        }
        public SoftwareLicense(int LicenseID, string SoftwareName, string LicenseIssuedBy, int AssetCost){
            this.LicenseID = LicenseID;
            this.SoftwareName = SoftwareName;
            this.LicenseIssuedBy = LicenseIssuedBy;
            this.AssetCost = AssetCost;
            this.AssetID = Asset.GetAssetID();
        }

        public void DisplaySoftwareLicense(SoftwareLicense softwareLicense){
            Console.WriteLine("Asset ID : " + softwareLicense.AssetID);
            Console.WriteLine("License Cost : " + softwareLicense.AssetCost);
            Console.WriteLine("Software License ID : " + softwareLicense.LicenseID);
            Console.WriteLine("Software Name : " + softwareLicense.SoftwareName);
            Console.WriteLine("License issused by : " + softwareLicense.LicenseIssuedBy);

            Console.WriteLine();
        }

        public SoftwareLicense SearchSoftwareLicense(List<SoftwareLicense > SoftwareLicenseList,int licenseID){

            foreach(SoftwareLicense softwareLicense in SoftwareLicenseList){
                if(softwareLicense.LicenseID == licenseID){
                    return softwareLicense;
                }
            }
            return null;
        }

        public void DeleteSoftwareLicense(ref List<SoftwareLicense > SoftwareLicenseList, int licenseID){
            int indexOfSoftware = 0;

            foreach(SoftwareLicense softwareLicense in SoftwareLicenseList){
                if(softwareLicense.LicenseID == licenseID){
                    break;
                }
                indexOfSoftware++;
            }
            
            SoftwareLicenseList.RemoveAt(indexOfSoftware);
        }
        

        public void UpdateSoftwareLicense(ref List<SoftwareLicense > SoftwareLicenseList, int licenseID){

            foreach(SoftwareLicense softwareLicense in SoftwareLicenseList){
                if(softwareLicense.LicenseID == licenseID){
                    
                    Console.WriteLine("Enter the updated software license name :");
                    softwareLicense.SoftwareName = Console.ReadLine();

                    Console.WriteLine("Enter the updated name company by which license issued : ");
                    softwareLicense.LicenseIssuedBy = Console.ReadLine();

                    Console.WriteLine("Enter the updated cost : ");
                    softwareLicense.AssetCost = Convert.ToInt32(Console.ReadLine());

                    break;
                }
            }
        }


        public static Dictionary<string, string> GetNewSoftwareLicense(){
            Dictionary<string, string> NewSoftware = new Dictionary<string, string>();

            Console.WriteLine("Enter Software License ID");
            NewSoftware["LicenseID"] = Console.ReadLine();

            Console.WriteLine("Enter Software License Name : ");
            NewSoftware["SoftwareName"] = Console.ReadLine();

            Console.WriteLine("Enter Company name by which software license issued :");
            NewSoftware["SoftwareIssuedBy"] = Console.ReadLine();

            Console.WriteLine("Enter Cost of Software License : ");
            NewSoftware["SoftwareCost"] = Console.ReadLine();

            return NewSoftware;
        }

        public static bool CheckSoftwareAlreadyPresent(Dictionary<string, string> NewSoftware, List<SoftwareLicense > SoftwareLicensesList){
            
            foreach(SoftwareLicense softwareLicense in SoftwareLicensesList){
                if(softwareLicense.LicenseID == Convert.ToInt32(NewSoftware["LicenseID"]) && softwareLicense.SoftwareName == NewSoftware["SoftwareName"] &&
                   softwareLicense.LicenseIssuedBy == NewSoftware["LicenseIssuedBy"] && softwareLicense.AssetCost == Convert.ToInt32(NewSoftware["SoftwareCost"])){
                       return true;
                   }
            }
            return false;
        }
    }
    
}