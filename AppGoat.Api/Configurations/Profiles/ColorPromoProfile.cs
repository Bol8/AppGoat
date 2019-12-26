using System.Drawing;
using AppGoat.Api.Models.ColorPromo;
using AppGoat.Domain.Entities;

namespace AppGoat.Api.Configurations.Profiles
{
    public partial class AutoMapperProfile
    {
        private void LoadColorPromoProfile()
        {
            CreateMap<ColorCreateViewModel, ColorPromo>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Code, opt => opt.MapFrom(x => ColorTranslator.ToHtml(x.Color)));
        }
    }
}