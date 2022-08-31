using Lab01.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01
{
    public partial class Form1 : Form
    {
        public string UsuariosFile;
        private static string _path = @"C:\ClonRepo\arch.csv";
       
        //-----------------------------------------OBTENCION--------------------------------
        public static string GetUsuarios()
        {

            string usu;
            using (var reader = new StreamReader(_path))
            {
                usu = reader.ReadToEnd();

            }


            return usu;
        }

        //------------------------------------------ESCRITURA---------------------------------
      




             
        public Form1()
        {
            InitializeComponent();

            var usu2 = GetUsuarios();
          
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = GetUsuarios().ToString();
            var usu2 = JsonConvert.DeserializeObject<List<Usuario>>(GetUsuarios());

        }
        //public static void DesJsonFile(string UsuariosFile)
        //{
        //    var usu2 = JsonConvert.DeserializeObject<List<Usuario>>(UsuariosFile);

        //}
    }
}
