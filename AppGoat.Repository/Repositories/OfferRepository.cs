using System.Data.Entity;
using AppGoat.Domain.Entities;
using AppGoat.Domain.RepositoryServices;

namespace AppGoat.Repository.Repositories
{
    public class OfferRepository : BaseRepository<Offer>, IOfferRepository
    {

        public OfferRepository(DbContext context) 
            : base(context)
        {

        }
    }
}