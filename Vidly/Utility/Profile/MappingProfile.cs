using Vidly.DTOs;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Utility.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ReverseMap();
        }
    }
}