using MVC.Models;
namespace MVC.APIAccess;

public class AirplaneAPI
{

    private AirplaneAPI()
    {

    }

    private static readonly AirplaneAPI? _instance;

    public static AirplaneAPI Instance
    {
        get
        {
            return _instance ?? new AirplaneAPI();
        }
    }

    HttpClient client = new();

    public async Task<List<Airplane>> GetAirplanes()
    {
        List<Airplane>? airplanes = new();

        string url = "http://localhost:5262/api/Airplane";

        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            airplanes = await response.Content.ReadFromJsonAsync<List<Airplane>>();
        }

        return airplanes;
    }
}
