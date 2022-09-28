using _01LABLuisG.Modelos;
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



namespace _01LABLuisG
{
    
    public partial class Form1 : Form
    {

        //PROPIEDADES
        //static AVL ArbolVL = new AVL();
        //static List<Usuario> pacientesList;
        //List<Usuario> pacientesDeArchivo;
        //DateTime hoy = DateTime.Now;
        //public string dpi;
        //public string nombre;







        List<Variables> personaList2 = new List<Variables>();
        List<Separacion> personaList = new List<Separacion>();
        private static string _path = @"C:\Users\Oscar José\Downloads\NN.csv";

        public static string GetUsuarios()
        {

            string usu;
            using (var reader = new StreamReader(_path))
            {
                usu = reader.ReadToEnd();

            }


            return usu;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            //label1.Text = listBox1.Items.Count();
            textBox1.Text = GetUsuarios();




            //Lectura JSON
            
            if (GetUsuarios() != null)
            {
                try
                {
                   
                    //Leer Archivo
                    string allFileData = System.IO.File.ReadAllText(_path);
                    //Recorrer Archivo
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual))
                        {
                            //Separar
                            string[] informacion = lineaActual.Split(';');
                            var u = JsonConvert.DeserializeObject(informacion[1]);
                             
                            if(informacion[0] == "INSERT" || informacion[0] == "DELETE")
                            {
                                
                                listBox1.Items.Add(u.ToString());
                                listBox2.Items.Add(u.ToString());
                                listBox3.Items.Add(u.ToString());

                            }




                            //Guardar informacion
                            personaList.Add(new Separacion()  
                            {
                            
                                ini = informacion[0],
                               archjson = informacion[1]
                             
                              
                               
                            });
                          
                            
                        }
                    }

                }
                catch (Exception ex)
                {

                   MessageBox.Show("Error" + e);
                }
                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (GetUsuarios() != null)
            {
                try
                {

                    //Leer Archivo
                    string allFileData = System.IO.File.ReadAllText(_path);
                    //Recorrer Archivo
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual))
                        {
                            //Separar
                            string[] informacion = lineaActual.Split(';');
                            var u = JsonConvert.DeserializeObject(informacion[1]);

                            if (informacion[0] == "DELETE")
                            {
                                listBox2.Items.Add(u.ToString());
                            }




                            //Guardar informacion
                          


                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error" + e);
                }

            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            if (GetUsuarios() != null)
            {
                try
                {

                    //Leer Archivo
                    string allFileData = System.IO.File.ReadAllText(_path);
                    //Recorrer Archivo
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual))
                        {
                            //Separar
                            string[] informacion = lineaActual.Split(';');
                            var u = JsonConvert.DeserializeObject(informacion[1]);

                            if (informacion[0] == "INSERT")
                            {
                                listBox3.Items.Remove(u.ToString());
                            }
                            if (informacion[0] == "PATCH")
                            {
                                listBox3.Items.Add(u.ToString());
                            }



                            //Guardar informacion
                            personaList.Add(new Separacion()
                            {

                                ini = informacion[0],
                                archjson = informacion[1]



                            });


                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error" + e);
                }

            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            if (GetUsuarios() != null)
            {
                try
                {

                    
                    string allFileData = System.IO.File.ReadAllText(_path);
                   
                    //--------------------------------------------------PARTE2-------------------------------------------------------
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual))
                        {
                            //Separar
                            string[] informacion2 = lineaActual.Split(';');
                            var u = JsonConvert.DeserializeObject(informacion2[1]);


                            string[] informacion3 = informacion2[1].Split(',');
                            var i = (informacion3[0]);

                            string[] informacion4 = informacion3[0].Split('{');
                            var o = (informacion4[1]);

                            string[] informacion5 = informacion4[1].Split(':');
                            var a = (informacion5[1]);

                            if (textBox2.Text == (informacion5[1]) && informacion2[0] == "PATCH")
                            {
                                listBox4.Items.Add(informacion2[1]);
                            }
                            


                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error" + e);
                }

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();

            if (GetUsuarios() != null)
            {
                try
                {


                    string allFileData = System.IO.File.ReadAllText(_path);

                    //--------------------------------------------------PARTE2-------------------------------------------------------
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual))
                        {
                            //Separar
                            string[] informacion2 = lineaActual.Split(';');
                            var u = JsonConvert.DeserializeObject(informacion2[1]);


                            string[] informacion3 = informacion2[1].Split(',');
                            var i = (informacion3[1]);

                            string[] informacion4 = informacion3[1].Split('{');
                            var o = (informacion4[0]);

                            string[] informacion5 = informacion4[0].Split(':');
                            var a = (informacion5[1]);

                            if (textBox3.Text == (informacion5[1]) && informacion2[0] == "PATCH")
                            {
                                listBox4.Items.Add(informacion2[1]);
                            }



                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error" + e);
                }

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();

            if (GetUsuarios() != null)
            {
                try
                {


                    string allFileData = System.IO.File.ReadAllText(_path);

                    //--------------------------------------------------PARTE2-------------------------------------------------------
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual))
                        {
                            //Separar
                            string[] informacion2 = lineaActual.Split(';');
                            var u = JsonConvert.DeserializeObject(informacion2[1]);


                            string[] informacion3 = informacion2[1].Split(',');
                            var i = (informacion3[0]);

                            string[] informacion4 = informacion3[0].Split('{');
                            var o = (informacion4[1]);

                            string[] informacion5 = informacion4[1].Split(':');
                            var a = (informacion5[1]);

                            if (textBox4.Text == (informacion5[1]) && informacion2[0] == "INSERT")
                            {
                                listBox4.Items.Add(informacion2[1]);
                            }



                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error" + e);
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();

            if (GetUsuarios() != null)
            {
                try
                {


                    string allFileData = System.IO.File.ReadAllText(_path);

                    //--------------------------------------------------PARTE2-------------------------------------------------------
                    foreach (string lineaActual in allFileData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(lineaActual))
                        {
                            //Separar
                            string[] informacion2 = lineaActual.Split(';');
                            var u = JsonConvert.DeserializeObject(informacion2[1]);


                            string[] informacion3 = informacion2[1].Split(',');
                            var i = (informacion3[1]);

                            string[] informacion4 = informacion3[1].Split('{');
                            var o = (informacion4[0]);

                            string[] informacion5 = informacion4[0].Split(':');
                            var a = (informacion5[1]);

                            if (textBox5.Text == (informacion5[1]) && informacion2[0] == "INSERT")
                            {
                                listBox4.Items.Add(informacion2[1]);
                            }



                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error" + e);
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
    