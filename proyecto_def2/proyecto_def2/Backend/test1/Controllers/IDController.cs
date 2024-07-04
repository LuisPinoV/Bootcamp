using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using test1.Classes;


//servicios de actualizar el datos del paciente
namespace test1.Controllers
{
    public class IDController : Controller
    {
        public String Index()   //get all data
        {
            Simulador sim = new Simulador();
            return sim.getAllData();
        }

        [HttpGet("{id_pa}")]
        public String GetData(string id_pa)
        {
            Simulador sim = new Simulador();
            return sim.getPacienteData(id_pa);

        }








    }
}
