using System.Linq;
using System;
using System.Collections.Generic;

namespace version_1.Models
{
    public class SoftwareRepository : ISoftwareRepository
    {   
        private List<Software > softwareList;

        public SoftwareRepository()
        {
            softwareList = new List<Software>()
            {
                new Software() { AssetId = 1, SoftwareName = "Microsoft Power Point", SoftwareCompany = "Starx",
                                    AssetPrice = 12343.123},
                new Software() { AssetId = 2, SoftwareName = "Microsoft Excel", SoftwareCompany = "Starx",
                                    AssetPrice = 156343.123},
                new Software() { AssetId = 3, SoftwareName = "Microsoft Word", SoftwareCompany = "Starx",
                                    AssetPrice = 112343.123}
            };
        }

        public void AddNewSoftware(Software software)
        {
            software.AssetId = softwareList.Max(ele => ele.AssetId) + 1;

            softwareList.Add(software);
        }

        public void DeleteSoftware(int assetId)
        {
            foreach(Software software in softwareList)
            {
                if(software.AssetId == assetId)
                {
                    softwareList.Remove(software);
                    break;
                }
            }
        }

        public IEnumerable<Software> GetAllSoftwares()
        {
            return softwareList;
        }

        public Software GetSoftwareById(int assetId)
        {
            foreach(Software software in softwareList)
            {
                if(software.AssetId == assetId)
                {
                    return software;
                }
            }
            
            return null;
        }

        public IEnumerable<Software> SearchSoftware(string softwareName)
        {
            List<Software > searchedSoftwares = new List<Software>();

            string[] searchedKeyword = softwareName.Split(" ");

            foreach(Software software in softwareList)
            {
                string[] presentSoftwareKeyword = software.SoftwareName.Split(" ");
                
                bool isKeyFound = false;

                foreach(var searchKey in searchedKeyword)
                {   
                    bool isKeyPresent = false;

                    foreach(var presentKey in presentSoftwareKeyword)
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
                    searchedSoftwares.Add(software);
                }
            }

            return searchedSoftwares;
        }

        public void UpdateSoftware(Software software)
        {
            for(int i = 0; i < softwareList.Count; i++)
            {
                if(softwareList[i].AssetId == software.AssetId)
                {
                    softwareList[i] = software;
                    break;
                }
            }
        }
    }
}