using System;
using System.Collections.Generic;
using System.Text;
using VL1.Domain.Common;

namespace VL1.Infra
{
    public class FilteredRepository<T> : SortedRepository<T>, ISearching
    {
        public string SearchString { get ; set; }
    }
}