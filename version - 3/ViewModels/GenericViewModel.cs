using System.Collections.Generic;
using System;

namespace version_1.ViewModels
{
    public class GenericViewModel<TSource >
    {
        public IEnumerable<TSource> AssetType { get; set; }
        public string PageTitle { get; set; }
    }
}