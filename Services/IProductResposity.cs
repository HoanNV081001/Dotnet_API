using Dotnet_API.Models;

namespace Dotnet_API.Services
{
    public interface IProductResposity
    {
        List<ProductModel> GetAll(string search, double? from, double? to, string sortBy, int page = 1);
    }
}