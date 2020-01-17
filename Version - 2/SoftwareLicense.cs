using System;
using System.Collections.Generic;
using AssetManagement;

namespace AssetManagement
{
    public class SoftwareLicense : Asset
    {
        private long _licenseId;
        private string _softwareName, _licenseIssuedBy;
        
        public SoftwareLicense(){

        }
        public SoftwareLicense(long licenseId, string softwareName, string licenseIssuedBy, long assetCost){
            this._licenseId = licenseId;
            this._softwareName = softwareName;
            this._licenseIssuedBy = licenseIssuedBy;
            this.assetCost = assetCost;
            this.assetId = Asset.GetAssetId();
        }

        public void DisplayAllSoftwareLicense(SortedDictionary<long, SoftwareLicense> softwareLicenseDict){
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Display all software license");

            foreach(KeyValuePair<long, SoftwareLicense> keyValue in softwareLicenseDict){
                SoftwareLicense softwareLicense = keyValue.Value;
                softwareLicense.DisplaySoftwareLicense(softwareLicense);
            }
        }
         
        
        public void DisplaySoftwareLicense(SoftwareLicense softwareLicense){
            Console.WriteLine("Software License is : ");
            Console.WriteLine("Asset ID : " + softwareLicense.assetId);
            Console.WriteLine("License Cost : " + softwareLicense.assetCost);
            Console.WriteLine("Software License ID : " + softwareLicense._licenseId);
            Console.WriteLine("Software Name : " + softwareLicense._softwareName);
            Console.WriteLine("License issused by : " + softwareLicense._licenseIssuedBy);

            Console.WriteLine();
        }
        public void SearchSoftwareLicense(SortedDictionary<long, SoftwareLicense > softwareLicenseDict,long licenseId){
            if(!softwareLicenseDict.ContainsKey(licenseId)){
                Console.WriteLine("Software with this license id is not present!!!");
            }
            else{
                SoftwareLicense softwareLicense = softwareLicenseDict[licenseId];
                softwareLicense.DisplaySoftwareLicense(softwareLicense);
            }
        }

        public void DeleteSoftwareLicense(ref SortedDictionary<long, SoftwareLicense> softwareLicenseDict, long licenseId){
            if (!softwareLicenseDict.ContainsKey(licenseId))
            {
                Console.WriteLine($"Software with this id - {licenseId} is not present into list so need of deletion");
            }
            else
            {
                softwareLicenseDict.Remove(licenseId);
                Console.WriteLine("Sfotware License has been deleted successfully");
            }
        }
        

        public void UpdateSoftwareLicense(ref SortedDictionary<long, SoftwareLicense> softwareLicenseDict, long licenseId){
            
            SoftwareLicense softwareLicense = new SoftwareLicense();

            softwareLicense._licenseId = licenseId;
            softwareLicense.assetId = softwareLicenseDict[licenseId].assetId;

            Console.WriteLine("Enter the updated software license name :");
            softwareLicense._softwareName = Console.ReadLine();

            Console.WriteLine("Enter the updated name company by which license issued : ");
            softwareLicense._licenseIssuedBy = Console.ReadLine();

            Console.WriteLine("Enter the updated cost : ");
            softwareLicense.assetCost = Convert.ToInt64(Console.ReadLine());
            
            softwareLicenseDict.Remove(licenseId);
            softwareLicenseDict[licenseId] = softwareLicense;
        }


        public static Dictionary<string, string> GetNewSoftwareLicense(SortedDictionary<long, SoftwareLicense> softwareLicenseDict){
            Dictionary<string, string> newSoftware = new Dictionary<string, string>();
            
            newSoftware["licenseId"] = GetSoftwareLicenseID(softwareLicenseDict);
            
            Console.WriteLine("Enter Software License Name : ");
            newSoftware["softwareName"] = Console.ReadLine();

            Console.WriteLine("Enter Company name by which software license issued :");
            newSoftware["softwareIssuedBy"] = Console.ReadLine();

            Console.WriteLine("Enter Cost of Software License : ");
            newSoftware["softwareCost"] = Console.ReadLine();

            return newSoftware;
        }

        private static string GetSoftwareLicenseID(SortedDictionary<long, SoftwareLicense> softwareLicenseDict){

            AgainEnter :
            Console.WriteLine("Enter Software License ID");
            string licenseId = Console.ReadLine();
            
            if(softwareLicenseDict.ContainsKey(Convert.ToInt64(licenseId))){
                Console.WriteLine("License with this id is already present, So again enter another license id");
                goto AgainEnter;
            }
            else{
                return licenseId;
            }
        }
    }
    
}