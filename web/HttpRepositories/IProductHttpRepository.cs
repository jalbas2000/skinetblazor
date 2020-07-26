using System;
using System.Threading.Tasks;
using web.Models;
using web.Helpers;
using System.Collections.Generic;

namespace web.HttpRepositories
{
    public interface IProductHttpRepository
    {
        Task<Pagination<Product>> GetProducts(ShopParams shopParams);
        Task<IReadOnlyList<ProductBrand>> GetProductBrands();
        Task<IReadOnlyList<ProductType>> GetProductTypes();
    }
}
