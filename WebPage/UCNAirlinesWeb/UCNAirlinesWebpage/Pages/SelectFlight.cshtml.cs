using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UCNAirlineApp.Models;
using UCNAirlinesWebpage.Models;

namespace UCNAirlineApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Flight> Flights { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? From { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? To { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Date { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Passenger { get; set; }



        public void OnGet()
        {
            var airplane1 = new Airplane("NotBoeingA");
            var airplane2 = new Airplane("NotBoeingB");

            var route1 = new Flightroute("Aalborg", "Nuuk");
            var route2 = new Flightroute("Aalborg", "Nuuk");

            DateTime departure1 = DateTime.Today.AddHours(10);
            DateTime departure2 = DateTime.Today.AddHours(22);


            Flights = new List<Flight>
                {
                    new Flight(route1, airplane1,departure1),
                    new Flight(route2, airplane2, departure2)
                };
        }
    }
}


