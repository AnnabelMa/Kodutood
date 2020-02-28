using System;
using System.Collections.Generic;
using System.Text;
using VL1.Domain.Common;

namespace VL1.Infra
{
    public class PaginatedRepository<T> : FilteredRepository<T>, IPaging
    {
        public int PageIndex { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}