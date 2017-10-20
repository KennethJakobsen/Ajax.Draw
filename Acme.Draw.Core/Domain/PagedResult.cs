using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Draw.Core.Domain
{
    public class PageResult<T>
    {
        public IEnumerable<T> Rows { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
