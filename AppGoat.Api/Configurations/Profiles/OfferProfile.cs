using System.Drawing;
using AppGoat.Api.Models.Offer;
using AppGoat.Domain.Entities;

namespace AppGoat.Api.Configurations.Profiles
{
    public partial class AutoMapperProfile
    {
        private void LoadOfferProfile()
        {
            CreateMap<Offer, OfferViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.CodeColor, opt => opt.MapFrom(x => x.Color.Code))
                .ForMember(x => x.IdColor, opt => opt.MapFrom(x => x.IdColor));

            CreateMap<OfferCreateViewModel, Offer>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.IdColor, opt => opt.MapFrom(x => x.IdColor));

            CreateMap<Offer, OfferCreateViewModel>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(x => x.IdColor, opt => opt.MapFrom(x => x.IdColor));

        }
    }
}