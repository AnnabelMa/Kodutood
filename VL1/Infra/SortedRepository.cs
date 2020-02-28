using System;
using System.Collections.Generic;
using System.Text;
using VL1.Domain.Common;

namespace VL1.Infra
{
    public class SortedRepository<T> : BaseRepository<T>, ISorting
    {
        public string SortOrder { get; set; }
    }
}