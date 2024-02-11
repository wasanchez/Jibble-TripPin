using FluentValidation;
using Jibble.TripPin.Application.Common;
using Jibble.TripPin.Application.Features.People.Queries;

namespace Jibble.TripPin.Application.Validators;

public class GetPeopleByFilterQueryValidator : AbstractValidator<GetPeopleByFilterQuery>
{
    public GetPeopleByFilterQueryValidator()
    {
        RuleFor(query => query.FilterValue).NotNull().NotEmpty().WithMessage(MessageConstants.SearchParameterIsRequired);
        RuleFor(query => query.PageNamber).GreaterThanOrEqualTo(1).WithMessage(MessageConstants.PageNumberIsRequired);
        RuleFor(query => query.PageSize).GreaterThanOrEqualTo(1).WithMessage(MessageConstants.PageSizeIsRequired);  
    }
}
