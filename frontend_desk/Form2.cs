using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frontend_desk
{
    public partial class Form2 : Form
    {
        private String id;
        private String profesion;
        public Form2()
        {
            InitializeComponent();
            // esto se cambia con los datos del simulador
            label1.Text = "pulso";
            label2.Text = "RPM";
            label3.Text = "Presión";
            label4.Text = "Temperatura";
            label5.Text = "Luis";
            label6.Text = 20.ToString();
            label7.Text = "Masculino";
            label8.Text = this.profesion;
            label9.Text = this.id;
        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Pulso ventana = new Pulso();
            ventana.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            RPM ventana = new RPM();
            ventana.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Presion ventana = new Presion();
            ventana.ShowDialog();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Temperatura ventana = new Temperatura();
            ventana.ShowDialog();
        }
        public void setId(String id)
        {
            this.id = id;
        }
        public void setProfesion(String profesion)
        {
            this.profesion = profesion;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
