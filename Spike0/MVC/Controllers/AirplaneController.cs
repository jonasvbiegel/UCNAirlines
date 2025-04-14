using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.APIAccess;

namespace MVC.Controllers
{
    public class AirplaneController : Controller
    {
        // GET: AirplaneController
        public IActionResult Index()
        {
            List<Airplane> list = AirplaneAPI.Instance.GetAirplanes().Result;
            return View(list);
        }

    }
}
