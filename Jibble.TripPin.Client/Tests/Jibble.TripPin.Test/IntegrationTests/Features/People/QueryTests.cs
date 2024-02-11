using Jibble.TripPin.Application.Features.People.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Jibble.TripPin.Test.IntegrationTests.Features.People;

public class QueryTests : IntegrationTestBase
{
    private readonly IMediator _mediator;
    public QueryTests(ConfigurationFixtures fixtures) : base(fixtures)
    {
        _mediator = ServiceProvider.GetService<IMediator>();
    }

    [Theory(DisplayName = "Fetch person by username" )]
    [InlineData("userName", false)]
    [InlineData("russellwhyte", true)]
    [InlineData("ronaldmundy", true)]
    [InlineData("javieralfred", true)]
    public async Task GetPersonByUserNameQuery_Should_Be_Executed_Successfully(string userName, bool expected) {
        //Arrange
        var query = new GetPersonByUserNameQuery(userName);

        //Acts
        var sut = await _mediator.Send(query);

        //Asserts
        Assert.NotNull(sut);
        Assert.True(sut.IsSuccess);
        Assert.Equal(sut.Value != null, expected);
    }

    [Theory(DisplayName = "People listing test.")]
    [InlineData(1, 10, true)]
    [InlineData(2, 10, true)]
    [InlineData(3, 10, false)]
    [InlineData(-1, 10, false)]
    [InlineData(-1, -1, false)]
    public async Task GetPeopleWithPaginationQuery_Should_Be_Successful(int pageNumber, int pageSize, bool expected) {
         //Arrange
        var actual = false;
        var query = new GetPeopleWithPaginationQuery(pageNumber, pageSize);
        
        //Acts
        var sut = await _mediator.Send(query);

        //Asserts
        Assert.NotNull(sut);
        actual = sut.IsSuccess && sut.Value.Data.Count > 0;
        Assert.Equal(expected, actual);
    }
     
    [Theory(DisplayName = "Search for people according to different criteria.")]
    [InlineData("ryantheriault", true)]
    [InlineData("Ryan",  true)]
    [InlineData("Sallie",  true)]
    [InlineData("Sampson", true)]
    [InlineData("Rosales", true)]
    [InlineData("Elaine@example.com", true)]
    [InlineData("unnamed", false)]
    [InlineData("nameless", false)]
    [InlineData("nonexistent.email@fake.com", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    public async Task Search_People_Should_Be_Successful(string filterValue, bool expected) {
         //Arrange
        bool actual = false;
        var query = new GetPeopleByFilterQuery(filterValue, 1, 10);
        //Acts
        var sut = await _mediator.Send(query);

       //Asserts
        Assert.NotNull(sut);
        actual = sut.IsSuccess && sut.Value.Count > 0;
        Assert.Equal(expected, actual);
    }
}
