using System.Collections.Generic;

namespace AppGoat.Domain.Entities
{
    public partial class ColorPromo
    {
        public byte Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public ColorPromo()
        {
            Offers = new HashSet<Offer>();
        }
    }
}