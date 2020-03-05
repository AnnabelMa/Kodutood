using System;
using System.Collections.Generic;
using System.Text;

namespace VL1.Domain.Common
{
    public interface IPaging
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int TotalPages { get; }
        bool HasNextPage { get; }
        bool HasPreviousPage { get;}
    }
}
