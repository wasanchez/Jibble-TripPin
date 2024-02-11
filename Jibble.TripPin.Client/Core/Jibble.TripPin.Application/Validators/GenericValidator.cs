using FluentResults;
using FluentValidation;

namespace Jibble.TripPin.Application.Validators;

public abstract class GenericValidator<T> where T : class
{
    private const string Message = "There are problems with the data provided. Please check the error messages.";
    private readonly IValidator<T> _validator;

    protected GenericValidator(IValidator<T> validator)
    {
        ArgumentNullException.ThrowIfNull(validator, nameof(validator));
        _validator = validator;
    }

    protected async Task<Result> Validate(T request) 
    {
        var validationResult = await _validator.ValidateAsync(request);

        return Result.FailIf(!validationResult.IsValid, () => {
            var errors = new List<Error>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new Error(error.ErrorMessage));   
            }
            var validationError = new Error(Message).CausedBy(errors);
            return validationError;
        });
    }

}
