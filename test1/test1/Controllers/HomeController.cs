using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using test1.Classes;

namespace test1.Controllers
{
    public class HomeController : Controller
    {
        public String Index()
        {
            Simulador sim = new Simulador();
            return sim.getAllData();
        }

        [HttpPost]
        public String Create()
        {
            Simulador sim = new Simulador();
            return sim.generateData();
        }
    }
}
