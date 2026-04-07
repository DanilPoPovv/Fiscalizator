namespace Fiscalizator.FiscalizationClasses.Dto.BaseDtoClasses
{
    public class BasePaginationDto
    {
        private int _page;
        public int Page { get => _page;
            set => _page = value > 0 ? value : 1; }
        private int _pageSize;
        public int PageSize { get => _pageSize;
            set => _pageSize = value > 0 ? value : 10; }
    }
}
