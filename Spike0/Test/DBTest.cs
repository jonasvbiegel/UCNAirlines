namespace Test;

using API.DataAccess;
using API.Model;
using Microsoft.AspNetCore.Components.RenderTree;
public class DBTest
{

    readonly AirplaneDB adb = AirplaneDB.Instance;

    [Fact]
    public void GetAirplanesTest()
    {
        // Arrange

        // Act
        List<Airplane> list = adb.GetAirplanes();

        // Assert
        Assert.NotNull(list);
    }

    [Fact]
    public void GetAirplaneTest()
    {
        // Arrange
        string airplane_model = "Boeing 747";
        string airplane_id = "AA747";

        // Act
        Airplane? airplaneDb = adb.GetAirplane(airplane_id);

        // Assert
        Assert.Equal(airplaneDb.Model, airplane_model);
    }
}
