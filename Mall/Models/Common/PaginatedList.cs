using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mall.Models.Common
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }// 当前是第几页
        public int PageSize { get; private set; }//每页显示多少条
        public int TotalCount { get; private set; }//总条数 
        public int TotalPages { get; private set; }//总页数

        public PaginatedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            this.AddRange(source.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList());
        }

        public PaginatedList(IList<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            this.AddRange(source.Skip((PageIndex-1) * PageSize).Take(PageSize));
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex + 1 < TotalPages);
            }
        }
    }
}