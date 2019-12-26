using System.ComponentModel.DataAnnotations;

namespace AppGoat.Api.Models.ColorPromo
{
    public class ColorViewModel
    {
        [Display(Name = "Id")]
        public byte Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Color")]
        public string Code { get; set; }
    }
}