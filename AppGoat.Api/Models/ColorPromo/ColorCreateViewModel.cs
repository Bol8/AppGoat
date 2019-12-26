using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AppGoat.Api.Models.ColorPromo
{
    public class ColorCreateViewModel
    {
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Color")]
        public Color Color { get; set; }
    }
}