using AutoMapper;

namespace AppGoat.Api.Configurations.Profiles
{
    public partial class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            LoadColorPromoProfile();
        }
    }
}