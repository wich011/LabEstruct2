using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Media;

namespace PruLZ
{
    public partial class Form1 : Form
    {
        public static string GetUsuarios()
        {

            string usu = "";
            DirectoryInfo cartas = new DirectoryInfo(@rutaa);

            foreach (var item in cartas.GetFiles())
            {
                usu = item.Name;
            }


            return usu;
        }

        public Form1()
        {
            InitializeComponent();
        }
        string[] cartasCarg = new string[1000];
        static string rutaa = "";
        string text = "";
        string nextChar = "";
        int pointer = 0;
         string gg = "";
        

        FolderBrowserDialog fbb = new FolderBrowserDialog();
        List<string> dic = new List<string>();
        SoundPlayer Player = new SoundPlayer();
        
        
        


        private void button1_Click(object sender, EventArgs e)
        {

            string CompChar = "";
            int index = 0, retrn = 0 ;
            text = screen.Text;
            screen.Text = "0 " + text[0] + "\n"; 
            dic.Add(""); 
            dic.Add(text[0] + "");

            for (int indexText = 1; indexText < text.Length; indexText++)
            {

                CompChar += text[indexText];

                if (dic.IndexOf(CompChar) != -1)
                {
                    index = dic.IndexOf(CompChar);

                    retrn = 1;
                    if (indexText + 1 == text.Length)
                        screen.Text += index + " null\n";

                }
                else
                {
                    if (retrn == 1)
                        screen.Text += index + " " + CompChar[CompChar.Length - 1] + "\n";

                    else
                        screen.Text += "0 " + CompChar + "\n";

                    dic.Add(CompChar);
                    CompChar = "";


                    retrn = 0;

                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            text = screen.Text;
            string[] CompRslt = screen.Text.Split();
            screen.Text = "";
            int cont = 0;
            int i =0;
            while (i<CompRslt.Length)
            {



                for (i = 0; i < text.Length; i += 2)
                {
                    if (cont < (((text.Length) / 2) + 2)-1 && i<CompRslt.Length)
                    {
                        cont += 2;
                        if ((CompRslt[i].Length) == 0)
                        {
                            if (nextChar != "null")
                            {
                                screen.Text += dic[pointer] + nextChar;
                            }
                            else
                            {
                                break;
                            }

                        }

                        if (i < (CompRslt.Length - 1) && nextChar != "null")
                        {
                            while (CompRslt[i] == "")
                            {
                                i++;
                            }
                            pointer = int.Parse(CompRslt[i]);
                            nextChar = CompRslt[i + 1];

                        }



                        if (nextChar != "null")
                            screen.Text += dic[pointer] + nextChar;
                        else
                            screen.Text += dic[pointer];




                        pointer = 0;
                        nextChar = "";

                    }


                }
            }
            
             
            pointer = 0;
            nextChar = "";
            dic.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

            if (fbb.ShowDialog() == DialogResult.OK)
            {
                rutaa = fbb.SelectedPath;
            }
            DirectoryInfo cartas = new DirectoryInfo(@rutaa);
            int i = 0;
            foreach (var item in cartas.GetFiles())
            {

                listBox1.Items.Add(rutaa + "\\"+item.Name);
                cartasCarg[i] = item.Name;
                i++;
            }
            screen.Text = rutaa;
            int h = listBox1.Items.Count;
            label3.Text = h.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int i = -1;

            if (i<=653)
            {
                i++;
                try
                {

                    //Leer Archivo
                    //Recorrer Archivo
                    for (int a = 0; a < 654; a++)
                    {
                        i++;
                        foreach (string lineaActual in cartasCarg[a].Split('\n'))
                        {

                            if (!string.IsNullOrEmpty(lineaActual))
                            {
                                //Separar
                                
                                string[] informacion = lineaActual.Split('-');
                                var u = (informacion[1]);
                                


                                if (informacion[1] ==textBox1.Text)
                                {

                                    listBox2.Items.Add(rutaa + "\\" + cartasCarg[a].ToString());


                                }







                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error " + e);
                }

            }
            int h = listBox2.Items.Count;
            label2.Text = h.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gg = listBox2.SelectedItem.ToString();
            textBox2.Text=gg;


        }

        private void label2_Click(object sender, EventArgs e)
        {
            string allFileData = System.IO.File.ReadAllText(gg);
            //Recorrer Archivo
            foreach (string lineaActual in allFileData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(lineaActual))
                {
                    //Separar
                    string[] informacion = lineaActual.Split(' ');
                    var u = (informacion[1]);

                    if (informacion[0] != "INSERT")
                    {

                        textBox1.Text = u.ToString();
                       

                    }




                   

                
            }

        }
    }

        private void button7_Click(object sender, EventArgs e)
        {
            string allFileData = System.IO.File.ReadAllText(gg);
            screen.Text = allFileData;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(saveFileDialog1.FileName))
                    {
                        string guardamiento = saveFileDialog1.FileName;
                        StreamWriter textSave = File.CreateText(guardamiento);

                        textSave.Write(screen.Text);
                        textSave.Flush();
                        textSave.Close();
                    }
                    else
                    {
                        string guardamiento = saveFileDialog1.FileName;
                        StreamWriter textSave = File.CreateText(guardamiento);

                        textSave.Write(screen.Text);
                        textSave.Flush();
                        textSave.Close();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar :c");
            }





        }

        private void button9_Click(object sender, EventArgs e)
        {
            Player.SoundLocation = @"C:\ClonRepo\NGGYU.wav";
            Player.Play();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Player.SoundLocation = @"C:\ClonRepo\NGGYU.wav";
            Player.Stop();
        }
    }
}