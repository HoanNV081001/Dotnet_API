using Dotnet_API.Models;

namespace Dotnet_API.Services
{
    public class CatRepositoryInMemory : ICatRepository
    {
        static List<CatVM> catVM = new List<CatVM>
        {
            new CatVM{IdCat = 1, NameCat = "Tivi"},
            new CatVM{IdCat = 2, NameCat = "Tủ lạnh"},
            new CatVM{IdCat = 3, NameCat = "Điều hòa"},
            new CatVM{IdCat = 4, NameCat = "Máy giặt"},
        };
        public CatVM Add(CatModel catModel)
        {
            var _cat = new CatVM
            {
                IdCat = catVM.Max(lo => lo.IdCat) + 1,
                NameCat = catModel.NameCat
            };
            catVM.Add(_cat);
            return _cat;
        }

        public void Delete(int id)
        {
            var _cat = catVM.SingleOrDefault(lo => lo.IdCat == id);
            catVM.Remove(_cat);
        }

        public List<CatVM> GetAll()
        {
            return catVM;
        }

        public CatVM GetById(int id)
        {
            return catVM.SingleOrDefault(lo => lo.IdCat == id);
        }

        public void Update(CatVM cat)
        {
            var _cat = catVM.SingleOrDefault(lo => lo.IdCat == cat.IdCat);
            if (_cat != null)
            {
                _cat.NameCat = cat.NameCat;
            }
        }
    }
}