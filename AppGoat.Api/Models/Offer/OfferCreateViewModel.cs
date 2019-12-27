using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace AppGoat.Api.Models.Offer
{
    public class OfferCreateViewModel
    {
        [Display(Name = "Id")]
        public short Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        [Display(Name = "Activo")]
        public bool IsActive { get; set; }

        [Display(Name = "Color")]
        public byte IdColor { get; set; }

        public SelectList Colors { get; set; }

        public OfferCreateViewModel() { }

        public OfferCreateViewModel(IEnumerable<Domain.Entities.ColorPromo> colors)
        {
            Colors = new SelectList(colors.OrderBy(x => x.Name),"Id","Name");
        }

        public void LoadCollections(IEnumerable<Domain.Entities.ColorPromo> colors)
        {
            Colors = new SelectList(colors.OrderBy(x => x.Name), "Id", "Name");
        }
    }
}