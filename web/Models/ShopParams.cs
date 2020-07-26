namespace web.Models
{
    public class ShopParams
    {
        public int? brandId = 0;
        public int? typeId = 0;
        public string sort = "name";
        public int pageNumber = 1;
        public int pageSize = 6;
        public string search;
    }
}
