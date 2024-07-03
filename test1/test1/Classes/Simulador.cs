
using DatabaseWrapper.Core;
using ExpressionTree;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;
using test1.Models;
using System;
using Watson.ORM.Sqlite;
using Watson.ORM;
using Watson.ORM.Core;
using System.Collections.Generic;
using System.Drawing.Printing;
using Microsoft.Extensions.Options;
using MathNet.Numerics.Statistics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Timers;


//aqui se ponen los servicios

//TO DO:
//1) hacer el post, get (check)
//  1.1) delete
//2) con eso hecho, entender los servicios q tiene el profe
//  2.1) /home es el Controller
// /Create es el servicio post

namespace test1.Classes
{
    class Mediciones
    {
        //datos paciente: ID, edad, Sexo
        public string? id_paciente { get; set; } //null
        public int sexo { get; set; }
        public int edad { get; set; }
        //signos vitales
        public int rpm { get; set; }
        public int pulse { get; set; }
        public int pres { get; set; }
        public double? temp { get; set; }
    }
    public class Simulador
    {
        private Watson.ORM.WatsonORM orm { get; set; }
        private System.Timers.Timer updateTimer;

        public Simulador()
        {
            DatabaseSettings settings = new DatabaseSettings("./test1.db");
            this.orm = new Watson.ORM.WatsonORM(settings);
            this.orm.InitializeDatabase();
            this.orm.InitializeTable(typeof(PacienteModel));

            updateTimer = new System.Timers.Timer(5000);
            updateTimer.Elapsed += OnUpdateEvent;
            updateTimer.AutoReset = true; // Esto hará que se repita
            updateTimer.Enabled = true; // Inicia el Timer

        }

        private void Insert(Mediciones obj) //fx insertar
        {
            PacienteModel entidad = new PacienteModel
            {
                Id_paciente = obj.id_paciente,
                Edad = obj.edad,
                Sexo = obj.sexo,
                //signosvitales
                Rpm = obj.rpm,
                Pulse = obj.pulse,
                Pres = obj.pres,
                Temp = obj.temp,

            };
            PacienteModel inserted = this.orm.Insert<PacienteModel>(entidad);
        }


        public string generateData() //post
        {
            Random random = new Random();  //supongo q es el seed(time(0))
            List<Mediciones> lista = new List<Mediciones>();
            int i = 0;
            //foreach (var e in Estaciones)
            //{
            Mediciones obj = new Mediciones();
            //generacion datos
            int id_num = random.Next(100000, 999999);
            string id_p = "ID" + id_num.ToString(); //funcion genera ID

            int sex = random.Next(0, 2);
            int edad = random.Next(0, 131);
            //sv
            int rpm = random.Next(8, 41);
            int pulse = random.Next(0, 181);
            int pres = random.Next(70, 141);
            double temp = random.Next(33, 43) + (random.Next(0, 11) * 0.1);

            //asignacion
            obj.id_paciente = id_p;
            obj.edad = edad;
            obj.sexo = sex;
            obj.rpm = rpm;
            obj.pres = pres;
            obj.pulse = pulse;
            obj.temp = temp;

            lista.Add(obj);
            this.Insert(obj);
            i++;
            //}
            return JsonConvert.SerializeObject(lista); ;
        }
        //servicios 
        public string getAllData() //get
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data);
        }
        //servicio de update
        public string actualizar()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            Random random = new Random();

            foreach (var paciente in data)
            {
                paciente.Rpm = random.Next(12, 25);
                paciente.Pulse = random.Next(60, 100);
                paciente.Pres = random.Next(90, 140);
                paciente.Temp = Math.Round(random.NextDouble() * (39.0 - 36.0) + 36.0, 1);

                orm.Update(paciente);
            }
            return JsonConvert.SerializeObject(data);
        }

        // Método que será llamado por el Timer

        private void OnUpdateEvent(object source, ElapsedEventArgs e)
        {
            actualizar();
        }

        //servicios de filtro

        public string getPacienteData(string id_pa) //deberia devoler los datos de solo ese paciente!!
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Where(item => (item.Id_paciente == id_pa)));
        }

        public string sexo(int sexo)
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Where(item => (item.Sexo == sexo)));
        }

        //servicios de conteo

        public string contar_bebes()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Count(p => p.Edad >= 0 && p.Edad <= 4));
        }

        public string contar_niños()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Count(p => p.Edad >= 5 && p.Edad <= 12));
        }

        public string contar_jovenes()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Count(p => p.Edad >= 13 && p.Edad <= 18));
        }

        public string contar_adultos()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Count(p => p.Edad >= 18 && p.Edad <= 60));
        }

        public string contar_ancianos()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Count(p => p.Edad >= 61));
        }

        public string contar_pacientes()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Count());

        }

        public string contar_sexo(int sexo)
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Count(item => (item.Sexo == sexo)));

        }

        //servicios de estadistica

        //medias
        public string media_rpm()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Average(item => item.Rpm));
        }

        public string media_pulse()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Average(item => item.Pulse));
        }

        public string media_pres()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Average(item => item.Pres));
        }

        public string media_temp()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(data.Average(item => item.Temp));
        }

        //varianzas
        public string var_rpm()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(Statistics
                                .Variance(data.Where(item => item.Rpm.HasValue)
                                .Select(item => (double)item.Rpm.Value)
                                .ToArray()));
        }

        public string var_pulse()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(Statistics
                                .Variance(data.Where(item => item.Pulse.HasValue)
                                .Select(item => (double)item.Pulse.Value)
                                .ToArray()));
        }

        public string var_pres()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(Statistics
                                .Variance(data.Where(item => item.Pres.HasValue)
                                .Select(item => (double)item.Pres.Value)
                                .ToArray()));
        }

        public string var_temp()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(Statistics
                                .Variance(data.Where(item => item.Temp.HasValue)
                                .Select(item => (double)item.Temp.Value)
                                .ToArray()));
        }

        //desviaciones estandar

        public string std_rpm()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(Statistics
                                .StandardDeviation(data.Where(item => item.Rpm.HasValue)
                                .Select(item => (double)item.Rpm.Value)
                                .ToArray()));
        }

        public string std_pulse()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(Statistics
                                .StandardDeviation(data.Where(item => item.Pulse.HasValue)
                                .Select(item => (double)item.Pulse.Value)
                                .ToArray()));
        }

        public string std_pres()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(Statistics
                                .StandardDeviation(data.Where(item => item.Pres.HasValue)
                                .Select(item => (double)item.Pres.Value)
                                .ToArray()));
        }

        public string std_temp()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            return JsonConvert.SerializeObject(Statistics
                                .StandardDeviation(data.Where(item => item.Temp.HasValue)
                                .Select(item => (double)item.Temp.Value)
                                .ToArray()));
        }

        //modas
        public string moda_sexo()
        {
            List<PacienteModel> data = orm.SelectMany<PacienteModel>();
            var sexValues = data.Where(item => item.Sexo.HasValue)
                .Select(item => item.Sexo.Value)
                .ToArray();
            return JsonConvert.SerializeObject(sexValues.GroupBy(x => x)
                                   .OrderByDescending(g => g.Count())
                                   .Select(g => g.Key)
                                   .FirstOrDefault());
        }
    }
}