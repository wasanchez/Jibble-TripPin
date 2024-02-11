using FluentResults;
using Jibble.TripPin.Application.Features.People.Queries;
using Jibble.TripPin.Console.Views;
using Jibble.TripPin.Shared;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Jibble.TripPin.Console.Controllers;

public class ListPeopleController : IController
{
    private readonly MenuController _menuController;
    private readonly IListPeopleView _view;
    private readonly IMediator _mediator;
    private readonly ILogger<ListPeopleController> _logger;

    public ListPeopleController(IListPeopleView view, IMediator mediator, ILogger<ListPeopleController> logger, MenuController menuController )
    {
        _view = view;
        _mediator = mediator;
        _logger = logger;
        _menuController = menuController;
        _view.SetController(this);
    }

    public async Task LoadViewAsync()
    {
       _view.Model.CurrentPage = 1;
       await ListAsync();
    }

    public async Task ListAsync() {

        var result = await GetPeople(_view.Model.MoveToPage, 10);
       if (result.IsSuccess) {
            _view.Model.Items = result.Value.Data;
            _view.Model.HasPreviousPage = result.Value.HasPreviousPage;
            _view.Model.HasNextPage = result.Value.HasNextPage;
            _view.Model.CurrentPage = result.Value.CurrentPage;
            _view.Model.TotalPages = result.Value.TotalPages;
       }
       _view.Display();
    }
    
    private async Task<IResult<PaginatedResult<GetPeopleWithPaginationDto>>> GetPeople(int pageNumber, int pageSize) {
        var query = new GetPeopleWithPaginationQuery(pageNumber, pageSize);
        return await _mediator.Send(query);
    }

    public async Task ExcuteInputOption() {
        switch (_view.InputOption)
        {
            case "N":
                await NextPage();
                break;
            case "P":
                await PreviousPageAsync();
                break;
            case "M":
                ReturnToMenu();
                break;
            default:
                _view.ReadInput();
                break;
        }
    }

    private async Task NextPage() {
        if (_view.Model.HasNextPage){
            _view.Model.MoveToPage = _view.Model.CurrentPage + 1;
        }
        await ListAsync();

    }

    private async Task PreviousPageAsync() {
        if (_view.Model.HasPreviousPage){
            _view.Model.MoveToPage = _view.Model.CurrentPage - 1;
        }
         await ListAsync();
    }

    private void ReturnToMenu() {
        _menuController.LoadViewAsync();
    }
}
