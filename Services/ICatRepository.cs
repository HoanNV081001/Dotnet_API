using Dotnet_API.Models;

namespace Dotnet_API.Services
{
    public interface ICatRepository
    {
        List<CatVM> GetAll();
        CatVM GetById(int id);
        CatVM Add(CatModel catModel);
        void Update(CatVM catVM);
        void Delete(int id);
    }
}