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

        //servicios de filro

        [HttpGet("search/{id}")]
        public String ide(int id)
        {
            Simulador sim = new Simulador();
            return sim.search(id);
        }

        [HttpGet("ID/{id}")]
        public String ID(string id_paciente)
        {
            Simulador sim = new Simulador();
            return sim.getPacienteData(id_paciente);
        }

        [HttpGet("sexo/{Sexo}")]
        public String sexo(int sexo)
        {
            Simulador sim = new Simulador();
            return sim.sexo(sexo);
        }

        //servicios de conteo

        [HttpGet("contar_pacientes")]
        public String contar_pacientes()
        {
            Simulador sim = new Simulador();
            return sim.contar_pacientes();
        }

        [HttpGet("contar_sexo/{Sexo}")]
        public String contar_sexo(int sexo)
        {
            Simulador sim = new Simulador();
            return sim.contar_sexo(sexo);
        }

        //servicios de estadistica

        [HttpGet("media_rpm")]
        public String media_rpm()
        {
            Simulador sim = new Simulador();
            return sim.media_rpm();
        }

        [HttpGet("media_pulse")]
        public String media_pulse()
        {
            Simulador sim = new Simulador();
            return sim.media_pulse();
        }

        [HttpGet("media_pres")]
        public String media_pres()
        {
            Simulador sim = new Simulador();
            return sim.media_pres();
        }

        [HttpGet("media_temp")]
        public String media_temp()
        {
            Simulador sim = new Simulador();
            return sim.media_temp();
        }

        [HttpGet("moda_sexo")]
        public String moda_sexo()
        {
            Simulador sim = new Simulador();
            return sim.moda_sexo();
        }
    }
}
