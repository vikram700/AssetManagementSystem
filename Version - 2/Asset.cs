using System;
using System.Collections.Generic;
using AssetManagement;

namespace AssetManagement
{
     public class Asset
    {
        protected long assetCost, assetId;
        protected static long nextAssetId = 0;
        protected static long GetAssetId(){
            nextAssetId++;
            return nextAssetId;
        }

        public void AddNewAsset<T >(ref SortedDictionary<long, T> AssetList, T newAsset, long keyId){
            AssetList.Add(keyId, newAsset);
        }
    }
}