using AutoMapper;
using FluentResults;
using FluentValidation;
using Jibble.TripPin.Application.Common;
using Jibble.TripPin.Application.Interfaces.Services;
using Jibble.TripPin.Application.Validators;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Jibble.TripPin.Application.Features.People.Queries;

public sealed class GetPeopleByFilterQuery : IRequest<IResult<List<GetPeopleByFilterDto>>>
{
    
    public string FilterValue { get; } = string.Empty;

    public GetPeopleByFilterQuery(string filterValue)
    {
        FilterValue = filterValue;
    }
}

public sealed class GetPeopleByFilterQueryHandler : GenericValidator<GetPeopleByFilterQuery>, IRequestHandler<GetPeopleByFilterQuery, IResult<List<GetPeopleByFilterDto>>>
{    
    private readonly IPeopleService _service;
    private readonly IMapper _mapper;
    private readonly ILogger<GetPeopleByFilterQueryHandler> _logger;

    public GetPeopleByFilterQueryHandler(IPeopleService service, IMapper mapper, ILogger<GetPeopleByFilterQueryHandler> logger, IValidator<GetPeopleByFilterQuery> validator) : base(validator)
    {
        _service = service;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IResult<List<GetPeopleByFilterDto>>> Handle(GetPeopleByFilterQuery request, CancellationToken cancellationToken)
    {
         ArgumentNullException.ThrowIfNull(request);

        try
        {
            var validationResult = await Validate(request);
            if (validationResult.IsFailed)
            {
                return Result.Fail<List<GetPeopleByFilterDto>>(validationResult.Errors.FirstOrDefault());
            }
            var people = await _service.SearchAsync(request.FilterValue);
            return Result.Ok<List<GetPeopleByFilterDto>>(_mapper.Map<List<GetPeopleByFilterDto>>(people));
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, MessageConstants.GenericMessageError);
            return Result.Fail<List<GetPeopleByFilterDto>>(new Error(ex.Message).CausedBy(ex));
        }
    }
}
