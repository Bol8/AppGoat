namespace AppGoat.Domain.Entities
{
    public partial class Offer
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ColorCode { get; set; }

        public bool IsActive { get; set; }
    }
}