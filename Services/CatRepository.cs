using Dotnet_API.Data;
using Dotnet_API.Models;

namespace Dotnet_API.Services
{
    public class CatRepository : ICatRepository
    {
        private readonly MyDbContext _context;

        public CatRepository(MyDbContext context)
        {
            _context = context;
        }
        public CatVM Add(CatModel catModel)
        {
            var _cat = new Category{
                NameCat = catModel.NameCat
            };
            _context.Add(_cat);
            _context.SaveChanges();
            return new CatVM{
                IdCat = _cat.IdCat,
                NameCat = _cat.NameCat
            };
        }

        public void Delete(int id)
        {
            var cat = _context.Categories.SingleOrDefault(c => c.IdCat == id);
            if (cat != null)
            {
                _context.Remove(cat);
                _context.SaveChanges();
            }
        }

        public List<CatVM> GetAll()
        {
            var cat = _context.Categories.Select(c => new CatVM{
                IdCat = c.IdCat,
                NameCat = c.NameCat
            });
            return cat.ToList();
        }

        public CatVM GetById(int id)
        {
            var cat = _context.Categories.SingleOrDefault(c => c.IdCat == id);

            if (cat != null)
            {
                return new CatVM{
                    IdCat = cat.IdCat,
                    NameCat = cat.NameCat
                };
            }
            return null;
        }

        public void Update(CatVM catVM)
        {
            var cat = _context.Categories.SingleOrDefault(c => c.IdCat == catVM.IdCat);
            cat.NameCat = catVM.NameCat;
            _context.SaveChanges();
        }
    }
}