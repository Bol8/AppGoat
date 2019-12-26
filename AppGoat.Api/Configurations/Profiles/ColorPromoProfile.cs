using AppGoat.Api.Models.ColorPromo;
using AppGoat.Domain.Entities;
using System.Drawing;

namespace AppGoat.Api.Configurations.Profiles
{
    public partial class AutoMapperProfile
    {
        private void LoadColorPromoProfile()
        {
            CreateMap<ColorCreateViewModel, ColorPromo>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Code, opt => opt.MapFrom(x => ColorTranslator.ToHtml(x.Color)));

            CreateMap<ColorPromo, ColorCreateViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Color, opt => opt.MapFrom(x => ColorTranslator.FromHtml(x.Code)));

            CreateMap<ColorPromo, ColorViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Code, opt => opt.MapFrom(x => x.Code));

            CreateMap<ColorViewModel, ColorPromo>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Code, opt => opt.MapFrom(x => x.Code));
        }
    }
}