using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Utility.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ReverseMap()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<Movie, MovieDTO>()
                .ReverseMap()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}