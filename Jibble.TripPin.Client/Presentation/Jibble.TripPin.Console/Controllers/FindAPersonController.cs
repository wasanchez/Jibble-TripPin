using FluentResults;
using Jibble.TripPin.Application.Features.People.Queries;
using Jibble.TripPin.Console.Controllers;
using Jibble.TripPin.Console.Views;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Jibble.TripPin.Console.Controllers;

public class FindAPersonController : IController
{
    private readonly MenuController _menuController;
    private readonly IFindAPersonView _view;
    private readonly IMediator _mediator;
    private readonly ILogger<FindAPersonController> _logger;

    public FindAPersonController(IFindAPersonView view, IMediator mediator, ILogger<FindAPersonController> logger, MenuController menuController)
    {
        _view = view;
        _mediator = mediator;
        _logger = logger;
        _menuController = menuController;
        _view.SetController(this);
    }

    public Task LoadViewAsync()
    {
        _view.Display();
        return Task.CompletedTask;
    }

    public async Task Find()
    {
        var result = await FindAPerson(_view.Model.Username);
        if (result.IsSuccess) {
            _view.Model.Person = result.Value;
            _view.LoadResult();
        }else {
            _view.DisplayMessage("An error has occurred!");
        }
    }

    private async Task<IResult<GetPersonByUserNameDto>> FindAPerson(string username) {
        var query = new GetPersonByUserNameQuery(username);
        return await _mediator.Send(query);
    }

    public async Task ExcuteInputOption() {
        switch (_view.InputOption)
        {
            case "N":
                _view.Display();
                break;
            case "M":
                await ReturnToMenu();
                break;
            default:
                _view.ReadInput();
                break;
        }
    }
    
    private async Task ReturnToMenu() {
        await _menuController.LoadViewAsync();
    }
}
