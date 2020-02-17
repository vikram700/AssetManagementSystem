using System.Collections.Generic;
using System;

namespace version_1.Models
{
    public interface ISoftwareRepository
    {
        void AddNewSoftware(Software software);

        void DeleteSoftware(int assetId);

        IEnumerable<Software > SearchSoftware(string softwareName);

        void UpdateSoftware(Software software);

        Software GetSoftwareById(int assetId);

        IEnumerable<Software > GetAllSoftwares();
    }
}