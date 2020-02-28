using System;
using System.Collections.Generic;
using System.Text;

namespace VL1.Domain.Common
{
    public interface IPaging
    {
        int PageIndex { get; set; }
        bool HasNextPage { get; set; }
        bool HasPreviousPage { get; set; }
    }
}
