using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AppGoat.Domain.Entities;
using AppGoat.Domain.RepositoryServices;
using Bogus;

namespace AppGoat.Repository.Repositories
{
    public class FakeOfferRepository : IBaseRepository<Offer>
    {

        public FakeOfferRepository() { }


        public Offer GetElement(object id)
        {
            var fake = new Faker<Offer>()
                // .RuleFor(x => x.Id, f => 0)
                .RuleFor(x => x.Name, f => f.Name.JobTitle())
                .RuleFor(x => x.Description, f => f.Lorem.Text())
                .RuleFor(x => x.ColorCode, f => "");

            return fake.Generate();
        }

        public IEnumerable<Offer> GetElements()
        {
            var fake = new Faker<Offer>()
               // .RuleFor(x => x.Id, f => 0)
                .RuleFor(x => x.Name, f => f.Name.JobTitle())
                .RuleFor(x => x.Description, f => f.Lorem.Text())
                .RuleFor(x => x.ColorCode, f => "");

            var a = fake.Generate(10);

            return fake.Generate(10);
        }

        public IEnumerable<Offer> GetElements(Expression<Func<Offer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Offer element)
        {
            throw new NotImplementedException();
        }

        public void Edit(Offer element)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}