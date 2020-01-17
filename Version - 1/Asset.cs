using System;
using System.Collections.Generic;
using AssetManagement;

namespace AssetManagement
{
     public class Asset
    {
        protected int AssetCost, AssetID;
        protected static int NextAssetID = 0;
        protected static int GetAssetID(){
            NextAssetID++;
            return NextAssetID;
        }

        public static void AddNewAsset<T >(ref List<T > AssetList, T newAsset){
            AssetList.Add(newAsset);
        }
    }
}