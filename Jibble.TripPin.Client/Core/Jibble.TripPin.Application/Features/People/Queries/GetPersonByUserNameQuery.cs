using AutoMapper;
using FluentResults;
using FluentValidation;
using Jibble.TripPin.Application.Common;
using Jibble.TripPin.Application.Interfaces.Services;
using Jibble.TripPin.Application.Models;
using Jibble.TripPin.Application.Validators;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Jibble.TripPin.Application.Features.People.Queries;


public sealed class GetPersonByUserNameQuery : IRequest<IResult<GetPersonByUserNameDto>>
{
    public string UserName { get; }

    public GetPersonByUserNameQuery(string userName) {
        UserName = userName;
    }
}

public sealed class GetPersonByUserNameQueryHandler : GenericValidator<GetPersonByUserNameQuery>,  IRequestHandler<GetPersonByUserNameQuery, IResult<GetPersonByUserNameDto>>
{
    private readonly IPeopleService _service;
    private readonly IMapper _mapper;
    private readonly ILogger<GetPersonByUserNameQueryHandler> _logger;
    
    public GetPersonByUserNameQueryHandler(IPeopleService service, IMapper mapper, ILogger<GetPersonByUserNameQueryHandler> logger, IValidator<GetPersonByUserNameQuery> validator) : base(validator)
    {
        _service = service;
        _mapper = mapper;
        _logger = logger;       
    }

    public async Task<IResult<GetPersonByUserNameDto>> Handle(GetPersonByUserNameQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        try
        {
            var validationResult = await Validate(request);
            if (validationResult.IsFailed)
            {
                return Result.Fail<GetPersonByUserNameDto>(validationResult.Errors.FirstOrDefault());
            }
            var person = await _service.GetPersonByUserNameAsync(request.UserName);
            return Result.Ok<GetPersonByUserNameDto>(_mapper.Map<PersonDto, GetPersonByUserNameDto>(person));
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, MessageConstants.GenericMessageError);
            return Result.Fail<GetPersonByUserNameDto>(new Error(ex.ToString()));
        }
    }
}
 
