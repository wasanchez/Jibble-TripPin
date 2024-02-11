using AutoMapper;
using Jibble.TripPin.Application.Features.People.Queries;
using Jibble.TripPin.Application.Models;

namespace Jibble.TripPin.Application.Profiles;

public class PeopleProfile : Profile
{
    public PeopleProfile()
    {
        CreateMap<PersonDto, GetPersonByUserNameDto>()
            .ForMember(x => x.Emails, opt => opt.MapFrom(src => string.Join(',', src.Emails))) ;;
        CreateMap<PersonDto, GetPeopleWithPaginationDto>()
            .ForMember(x => x.Emails, opt => opt.MapFrom(src => string.Join(',', src.Emails))) ;
        CreateMap<PersonDto, GetPeopleByFilterDto>()
            .ForMember(x => x.Emails, opt => opt.MapFrom(src => string.Join(',', src.Emails)));
    }
}
