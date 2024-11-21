using Microsoft.EntityFrameworkCore;
namespace SharedModels.Models
{
    public class PagedList<T>
    {
        public int? CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public List<T> data { set; get; }
        public PagedList(List<T> items, int count, int? pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            data = items;
        }
        public static async Task<PagedList<T>> ToPagedList(IQueryable<T> source, int? pageNumber, int? pageSize)
        {
            int myPageSize = pageSize ?? 50;
            var count = await source.CountAsync();
            var Items = new List<T>();
            try
            {
                var itemsdata = source.Skip((pageNumber ?? 1 - 1) * myPageSize).Take(myPageSize);
                Items = await itemsdata.ToListAsync();

            }
            catch (Exception e)
            {

            }
            return new PagedList<T>(Items, count, pageNumber, myPageSize);
        }
    }
}

