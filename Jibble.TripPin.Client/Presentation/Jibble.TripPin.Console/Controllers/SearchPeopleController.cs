using FluentResults;
using Jibble.TripPin.Application.Features.People.Queries;
using Jibble.TripPin.Console.Controllers;
using Jibble.TripPin.Console.Views;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Jibble.TripPin.Console;

public class SearchPeopleController : IController
{
    private readonly MenuController _menuController;
    private readonly ISearchPeopleView _view;
    private readonly IMediator _mediator;
    private readonly ILogger<SearchPeopleController> _logger;

    public SearchPeopleController(ISearchPeopleView view, IMediator mediator, ILogger<SearchPeopleController> logger, MenuController menuController)
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

    public async Task Search()
    {
        var result = await SearchPeople(_view.Model.Filter);
        if (result.IsSuccess) {
            _view.Model.Items = result.Value;
            _view.LoadResult();
        }else {
            _view.DisplayMessage("An error has occurred!");
        }
    }

    
    private async Task<IResult<List<GetPeopleByFilterDto>>> SearchPeople(string filter) {
        var query = new GetPeopleByFilterQuery(filter);
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
