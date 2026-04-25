using System.Diagnostics;
using System.Threading.Tasks;
using HigginsP3.Models;
using HigginsP3.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace HigginsP3.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            DataRetrieval dataR = new DataRetrieval();
            var loadedAbout = await dataR.GetData("about/");
            AboutModel data = JsonConvert.DeserializeObject<AboutModel>(loadedAbout)!;
            return View(data);
        }
       public async Task<IActionResult> People()
            {
                DataRetrieval dataR = new DataRetrieval();
                var json = await dataR.GetData("people/");
                PeopleModel data = JsonConvert.DeserializeObject<PeopleModel>(json)!;
                return View(data);
            }
       public async Task<IActionResult> Degrees()
            {
                DataRetrieval dataR = new DataRetrieval();
                // Get degrees
                var degreesJson = await dataR.GetData("degrees/");
                DegreesModel data = JsonConvert.DeserializeObject<DegreesModel>(degreesJson)!;
                return View(data);
            }
        public async Task<IActionResult> Employment()
            {
                DataRetrieval dataR = new DataRetrieval();
                var json = await dataR.GetData("employment/");
                EmploymentModel data = JsonConvert.DeserializeObject<EmploymentModel>(json)!;
                return View(data);
            }
        public async Task<IActionResult> Minors()
            {
                DataRetrieval dataR = new DataRetrieval();
                var json = await dataR.GetData("minors/");
                MinorsModel data = JsonConvert.DeserializeObject<MinorsModel>(json)!;
                return View(data);
            }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}