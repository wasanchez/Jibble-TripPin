using AutoMapper;
using Jibble.TripPin.Application.Features.People.Queries;
using Jibble.TripPin.Application.Models;

namespace Jibble.TripPin.Application.Profiles;

public class PeopleProfile : Profile
{
    public PeopleProfile()
    {
        CreateMap<PersonDto, GetPersonByUserNameDto>()
            .ForMember(x => x.Emails, opt => opt.MapFrom(src => string.Join(',', src.Emails)))
            .ForMember(x => x.AddressInfo, opt => opt.MapFrom(src =>  string.Join(",\n", src.AddressInfo.Select(x => x.Address).ToArray())))
            .ForMember(x => x.HomeAddress, opt => opt.MapFrom(src => src.HomeAddress.Address))
            .ForMember(x => x.Features, opt => opt.MapFrom(src => string.Join(", ", src.Features)))
            .ForMember(x => x.Friends, opt => opt.MapFrom(src => 
                                string.Join(", ", src.Friends.Select(x => string.Format("{0} {1} \n", x.LastName, x.FirstName).ToArray()))))
            .ForMember(x => x.BestFriend, opt => opt.MapFrom(src => string.Format("{0} {1} ", src.BestFriend.LastName, src.FirstName)));
        CreateMap<PersonDto, GetPeopleWithPaginationDto>()
            .ForMember(x => x.Emails, opt => opt.MapFrom(src => string.Join(',', src.Emails))) ;
        CreateMap<PersonDto, GetPeopleByFilterDto>()
            .ForMember(x => x.Emails, opt => opt.MapFrom(src => string.Join(',', src.Emails)))
            ;
    }
}
