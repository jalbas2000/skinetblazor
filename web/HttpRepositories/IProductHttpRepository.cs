using System;
using System.Threading.Tasks;
using web.Models;
using web.Helpers;

namespace web.HttpRepositories
{
    public interface IProductHttpRepository
    {
        Task<Pagination<ProductToReturnDto>> GetProducts();
    }
}
