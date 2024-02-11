using FluentValidation;
using Jibble.TripPin.Application.Common;
using Jibble.TripPin.Application.Features.People.Queries;

namespace Jibble.TripPin.Application.Validators;

public class GetPersonByUserNameQueryValidator : AbstractValidator<GetPersonByUserNameQuery>
{
    public GetPersonByUserNameQueryValidator()
    {
        RuleFor(query => query.UserName).NotNull().NotEmpty().WithMessage(MessageConstants.UsernameIsRequired);
    }
}
