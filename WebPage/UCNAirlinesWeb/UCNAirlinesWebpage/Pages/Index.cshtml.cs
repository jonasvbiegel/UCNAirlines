using Microsoft.AspNetCore.Mvc.RazorPages;
using UCNAirlineApp.Models;
using UCNAirlinesWebpage.Models;

namespace UCNAirlineApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Flight> Flights { get; set; } = new();

        public void OnGet()
        {
            var airplane1 = new Airplane("NotBoringA");
            var airplane2 = new Airplane("NotBoringB");

            var route1 = new Flightroute("Aalborg", "Nuuk");
            var route2 = new Flightroute("Aalborg", "Nuuk");

            string time1 = "10:00";
            string time2 = "22:00";


            Flights = new List<Flight>
            {
                new Flight(route1, airplane1, time1),
                new Flight(route2, airplane2, time2)
            };
        }
    }
}


