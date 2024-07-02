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
            return sim.ID(id_paciente);
        }

        [HttpGet("sexo/{Sexo}")]
        public String sexo(int sexo)
        {
            Simulador sim = new Simulador();
            return sim.sexo(sexo);
        }
        //servicio de update

        [HttpGet("actualizar")]
        public string actualizar()
        {
            Simulador sim = new Simulador();
            return sim.actualizar();
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

        //servicios de alertas

        [HttpGet("alertas_rpm")]
        public String alerta_rpm()
        {
            Simulador sim = new Simulador();
            return sim.alerta_rpm();
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

        [HttpGet("var_rpm")]
        public String var_rpm()
        {
            Simulador sim = new Simulador();
            return sim.var_rpm();
        }

        [HttpGet("var_pulse")]
        public String var_pulse()
        {
            Simulador sim = new Simulador();
            return sim.var_pulse();
        }

        [HttpGet("var_pres")]
        public String var_pres()
        {
            Simulador sim = new Simulador();
            return sim.var_pres();
        }

        [HttpGet("var_temp")]
        public String var_temp()
        {
            Simulador sim = new Simulador();
            return sim.var_temp ();
        }

        [HttpGet("std_rpm")]
        public String std_rpm()
        {
            Simulador sim = new Simulador();
            return sim.std_rpm();
        }

        [HttpGet("std_pulse")]
        public String std_pulse()
        {
            Simulador sim = new Simulador();
            return sim.std_pulse();
        }

        [HttpGet("std_pres")]
        public String std_pres()
        {
            Simulador sim = new Simulador();
            return sim.std_pres();
        }

        [HttpGet("std_temp")]
        public String std_temp()
        {
            Simulador sim = new Simulador();
            return sim.std_temp();
        }

        [HttpGet("moda_sexo")]
        public String moda_sexo()
        {
            Simulador sim = new Simulador();
            return sim.moda_sexo();
        }
    }
}
