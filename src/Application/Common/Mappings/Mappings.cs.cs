using ChallengeClean.Application.Models;
using ChallengeClean.Domain.Entities;

namespace ChallengeClean.Application.Common.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<Person, PersonDTO>()
            .ForMember(x => x.Addresses,
                mopt => mopt.MapFrom(src => src.Addresses.Select(x => new AddressDTO { City = x.City, Street = x.Street })
                        .ToList()));
    }
}
