namespace Test;

using MVC.Models;
using MVC.APIAccess;

public class MVCAPIAccess
{
    [Fact]
    public async void GetAirplanesFromApiTest()
    {
        //Arrange
        AirplaneAPI airplaneAPI = new();

        //Act
        List<Airplane> list = await airplaneAPI.GetAirplanes();

        //Assert
        Assert.NotNull(list);

    }
}
