using AutoMapper;
using FluentResults;
using FluentValidation;
using Jibble.TripPin.Application.Common;
using Jibble.TripPin.Application.Interfaces.Services;
using Jibble.TripPin.Application.Validators;
using Jibble.TripPin.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Jibble.TripPin.Application.Features.People.Queries;

public sealed class GetPeopleWithPaginationQuery : IRequest<IResult<PaginatedResult<GetPeopleWithPaginationDto>>>
{
    public GetPeopleWithPaginationQuery( int pageNumber, int pageSize)
    {
        PageNamber = pageNumber;
        PageSize = pageSize;
    }

    public int PageNamber { get;}
    public int PageSize { get; }

}

public sealed class GetPeopleWithPaginationQueryHandler : GenericValidator<GetPeopleWithPaginationQuery>, IRequestHandler<GetPeopleWithPaginationQuery, IResult<PaginatedResult<GetPeopleWithPaginationDto>>>
{
    private readonly IPeopleService _service;
    private readonly IMapper _mapper;
    private readonly ILogger<GetPeopleWithPaginationQueryHandler> _logger;
    
    public GetPeopleWithPaginationQueryHandler(IPeopleService service, IMapper mapper, ILogger<GetPeopleWithPaginationQueryHandler> logger, IValidator<GetPeopleWithPaginationQuery> validator) : base(validator)
    {
        _service = service;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IResult<PaginatedResult<GetPeopleWithPaginationDto>>> Handle(GetPeopleWithPaginationQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        try
        {
            var validationResult = await Validate(request);
            if (validationResult.IsFailed)
            {
                return Result.Fail<PaginatedResult<GetPeopleWithPaginationDto>>(validationResult.Errors.FirstOrDefault());
            }
            var people = await _service.GetPeopleAsync(request.PageNamber, request.PageSize);
            var paginatedResult =  PaginatedResult<GetPeopleWithPaginationDto>.Create(_mapper.Map<List<GetPeopleWithPaginationDto>>(people.Data), people.TotalCount, people.CurrentPage, people.PageSize);
            return Result.Ok<PaginatedResult<GetPeopleWithPaginationDto>>(paginatedResult);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, MessageConstants.GenericMessageError);
            return Result.Fail<PaginatedResult<GetPeopleWithPaginationDto>>(new Error(ex.Message).CausedBy(ex));
        }
        throw new NotImplementedException();
    }
}