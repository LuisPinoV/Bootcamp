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

        [HttpGet("contar_bebes")]
        public String contar_bebes()
        {
            Simulador sim = new Simulador();
            return sim.contar_bebes();
        }

        [HttpGet("contar_niños")]
        public String contar_niños()
        {
            Simulador sim = new Simulador();
            return sim.contar_niños();
        }

        [HttpGet("contar_jovenes")]
        public String contar_jovenes()
        {
            Simulador sim = new Simulador();
            return sim.contar_jovenes();
        }

        [HttpGet("contar_adultos")]
        public String contar_adultos()
        {
            Simulador sim = new Simulador();
            return sim.contar_adultos();
        }

        [HttpGet("contar_ancianos")]
        public String contar_ancianos()
        {
            Simulador sim = new Simulador();
            return sim.contar_ancianos();
        }
        //servicios de estadistica

        //medias

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

        //varianzas

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

        //desviaciones estandares

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
