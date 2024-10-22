using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Helper
{
    public class PaginationDto<T>
    {

        public IReadOnlyList<T> Data { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public int Count { get; set; }

        public PaginationDto(IReadOnlyList<T> _data, int? _pageIndex, int? _pageSize, int _count)
        {
            Data = _data;
            PageSize = _pageSize;
            PageIndex = _pageIndex;
            Count = _count;
        }
    }
}

