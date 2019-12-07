using AppGoat.Domain.Entities;
using AppGoat.Repository.Mappers;

namespace AppGoat.Repository.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GoatDb : DbContext
    {
        public virtual DbSet<Offer> Offer { get; set; }


        public GoatDb()
            : base("name=GoatDb")
        {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OfferMapper());
        }
    }
}
