using System.Data.Entity;
using AppGoat.Domain.Entities;
using AppGoat.Domain.RepositoryServices;

namespace AppGoat.Repository.Repositories
{
    public class ColorPromoRepository : BaseRepository<ColorPromo>, IColorPromoRepository
    {

        public ColorPromoRepository(DbContext context) 
            : base(context)
        {

        }
    }
}