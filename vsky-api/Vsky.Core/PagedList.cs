using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsky.Core
{
    /// <summary>
    /// Paged list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    [Serializable]
    public partial class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
        {
            // min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);

            TotalCount = source.Count();
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
            {
                TotalPages++;
            }
            else
            {
                TotalPages = 1;
            }

            PageSize = pageSize==1 ? TotalCount : pageSize;
            PageIndex = pageIndex;

            if (getOnlyTotalCount)
            {
                return;
            }

            AddRange(source.Skip((pageIndex - 1) * pageSize).Take(PageSize).ToList());
        }

        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            // min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);

            TotalCount = source.Count;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
            {
                TotalPages++;
            }

            PageSize = pageSize;
            PageIndex = pageIndex;

            AddRange(source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalCount">Total count</param>
        public PagedList(IList<T> source, int pageIndex, int pageSize, int? totalCount = null)
        {
            //min allowed page size is 1
            pageSize = Math.Max(pageSize, 1);

            TotalCount = totalCount ?? source.Count;
            TotalPages = TotalCount / pageSize;

            if (TotalCount % pageSize > 0)
            {
                TotalPages++;
            }

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(totalCount != null ? source : source.Skip((pageIndex - 1) * pageSize).Take(pageSize));
        }

        /// <summary>
        /// Page index
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Total count
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Total pages
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Has previous page
        /// </summary>
        public bool HasPreviousPage => PageIndex > 0;

        /// <summary>
        /// Has next page
        /// </summary>
        public bool HasNextPage => PageIndex + 1 < TotalPages;
    }
}