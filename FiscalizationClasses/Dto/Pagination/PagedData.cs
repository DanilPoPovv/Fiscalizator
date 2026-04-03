namespace Fiscalizator.FiscalizationClasses.Dto.Pagination
{
    public class PagedData <T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
