
using System.Collections.Generic;

namespace version_1.Models
{
    public interface IGenericinterface<TSource >
    {
        public void AddNewAsset(TSource asset);
        public IEnumerable<TSource > SearchAsset(string assetName);
        public void DeleteAsset(int assetId);
        public void UpdateAsset(Asset asset);
        public Asset GetAssetById(int id);
        public IEnumerable<TSource > GetAllAssets();
    }
}