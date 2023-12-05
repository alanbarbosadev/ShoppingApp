namespace ShoppingApp.Application.Specifications
{
    public class ProductSpecificationParams
    {
        private const int MAX_PAGE_SIZE = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value; }
        }

        public Guid? TypeId { get; set; }
        public Guid? BrandId { get; set; }
        public string Sort { get; set; }

        private string _search;

        public string Search
        {
            get { return _search; }
            set { _search = value.ToLower(); }
        }
    }
}
