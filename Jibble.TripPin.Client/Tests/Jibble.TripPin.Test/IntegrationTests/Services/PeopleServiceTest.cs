using Jibble.TripPin.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Jibble.TripPin.Test.IntegrationTests.Services;

public class PeopleServiceTest : IntegrationTestBase
{
    private readonly IPeopleService _service;
    public PeopleServiceTest(ConfigurationFixtures fixtures) : base(fixtures)
    {
        _service = ServiceProvider.GetService<IPeopleService>();
    }

    [Theory(DisplayName = "Get Person by UserName" )]
    [InlineData("userName", false)]
    [InlineData("russellwhyte", true)]
    [InlineData("ronaldmundy", true)]
    [InlineData("javieralfred", true)]
    public async Task Get_Person_By_UserName(string userName, bool expected) {
        //Arrange
        bool actual = false;
        
        //Acts
        var sut = await _service.GetPersonByUserNameAsync(userName);
        actual = sut != null;

        //Asserts
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Get Person by UserName should retrive data")]
    [InlineData("ryantheriault", "Ryan", "Theriault", "Male", true)]
    [InlineData("salliesampson", "Sallie", "Sampson", "Female", true)]
    [InlineData("jonirosales", "Joni", "Rosales",  "Female", true)]
    public async Task Get_Person_By_UserName_Should_Retrive_The_Data_Successfully(string userName, string firstName, string lastName, string gender, bool expected) {
        //Arrange
        
        //Acts
        var sut = await _service.GetPersonByUserNameAsync(userName);
       
        //Asserts
        Assert.NotNull(sut);
        Assert.Equal(userName == sut.UserName, expected);
        Assert.Equal(lastName == sut.LastName, expected); 
        Assert.Equal(firstName == sut.FirstName, expected);
        Assert.Equal(gender == sut.Gender, expected);
    }

    [Theory(DisplayName = "Try searching for people based on different criteria.")]
    [InlineData("ryantheriault", true)]
    [InlineData("Ryan",  true)]
    [InlineData("Sallie",  true)]
    [InlineData("Sampson", true)]
    [InlineData("Rosales", true)]
    [InlineData("Elaine@example.com", true)]
    [InlineData("unnamed", false)]
    [InlineData("nameless", false)]
    [InlineData("nonexistent.email@fake.com", false)]
    public async Task Search_People_Should_Be_Successful(string criteria, bool expected) {
         //Arrange
        bool actual = false;
        
        //Acts
        var sut = await _service.SearchAsync(criteria);

        //Asserts
        Assert.NotNull(sut);
        actual = sut.Any();
        Assert.Equal(expected, actual);

    }

    [Theory(DisplayName = "People listing test.")]
    [InlineData(1, 10, true)]
    [InlineData(2, 10, true)]
    [InlineData(3, 10, false)]
    [InlineData(-1, 10, true)]
    [InlineData(-1, -1, true)]
    public async Task Get_People_Should_Be_Successful(int pageNumber, int pageSize, bool expected) {
         //Arrange
        bool actual = false;
        
        //Acts
        var sut = await _service.GetPeopleAsync(pageNumber, pageSize);

        //Asserts
        Assert.NotNull(sut);
        actual = sut.Data.Count > 0;
        Assert.Equal(expected, actual);
    }
}
