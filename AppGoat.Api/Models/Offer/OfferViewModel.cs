using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppGoat.Api.Models.Offer
{
    public class OfferViewModel
    {
        [Display(Name = "Id")]
        public short Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Color")]
        public string CodeColor { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }

        [Display(Name = "Id Color")]
        public byte IdColor { get; set; }
    }
}