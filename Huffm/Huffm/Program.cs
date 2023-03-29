using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAb02
{

    class Test
    {
        
        private static string _path = @"C:\Ciclo 5\Estruct\input_challenge.txt";
        public static string _path2 = @"C:\ClonRepo\FILES\DPIS.txt";
        public static string GetUsuarios()
        {

            string usu;
            using (var reader = new StreamReader(_path))
            {
                usu = reader.ReadToEnd();

            }


            return usu;
        }
        static void Main(string[] args)
        {
            string filename = @"C:\ClonRepo\FILES\DPIS.txt";
            string content;
            int decision;
            StreamWriter streamWriter = new StreamWriter(filename);
            int contador=0;
            int con = 0;
            int i = 0;
            string deco="";
            string[] arreglo = new string[1000];
            string[] arreglo2 = new string[1000];
            int conT = 0;
            int conP = 1;
            Console.Title = "LuisGironHuffman";
            int Opciones;
            BitArray encode = null;
            //string decode = arbolHH.Decodificacion(encode);
           
                var infodd = "";
                var info1 = "";
            var infoN = "";
            var infoD = "";
            var infoG = "";
            string[] informacion1 = { };
            string[] informacionP3 = { };
            string[] informacionP2 = { };
            string[] separI22 = { };
            int c = 0, b=0,a=0;



                Console.WriteLine("Lab_Mady_Donis");

                        

                        if (GetUsuarios() != null && contador ==con)
                        {
                            try
                            {

                                string allFileData = File.ReadAllText(_path);
                                foreach (string lineaActual in allFileData.Split('\n'))
                                {
                                   
                                        if (!string.IsNullOrEmpty(lineaActual) && contador == con)
                                        {
                                 conT = 0;
                                string[] informacion = lineaActual.Split("input1"+'"');
                                            var u = (informacion[1]);
                            string[] comp = u.Split('"');
                            var comp1 = comp[0];
                            var comp2 = comp[0];

                            if (comp[0] == ":[{")
                            {
                                info1 = informacion[1];
                                informacion1 = info1.Split(':' + "[{");
                                infoN = informacion1[1];
                                infoD = informacion1[1];
                            }else
                            {
                                info1 = informacion[1];
                                informacion1 = info1.Split(':' + "[{}" + ',');
                                infoN = informacion1[1];
                                infoD = informacion1[1];
                            }
                                            
                                            



                                            



                                            string[] informacionN = infoN.Split('{');
                                            var infonn = informacionN[1];


                                            string[] informacionD = infoD.Split("],");
                                            infodd = informacionD[1];
                                            var info3 = informacionD[0];
                            
                            string[] informacionP = info3.Split(","+'"');
                            
                            informacionP2 = info3.Split("},{");
                           
                           

                            string[] separI2 = infodd.Split('[');
                            var info4 = separI2[1];

                            string[] separI21 = info4.Split(']');
                            var info5 = separI21[0];

                            separI22 = info5.Split(',');
                            for (c = 0; c < informacionP2.Length; c++)
                            {
                                infoG = informacionP2[c];
                                informacionP3 = infoG.Split(',');
                                while (b < informacionP3.Length)
                                {
                                    while (a < separI22.Length)
                                    {
                                        if (informacionP3[b].Contains(separI22[a] + ":true") && informacionP3[b].Contains(separI22[a]) && separI22[a] != null)
                                        {
                                            conT++;
                                           
                                        }

                                        a++;
                                    }
                                    b++;
                                    a = 0;
                                }
                                b = 0;

                            }
                           



                            //for (int b = 0; b < informacionP.Length; b++)
                            //{
                            //    for (int a = 0; a < separI22.Length; a++)
                            //    {
                            //        if (informacionP[b].Contains(separI22[a]+":true") && informacionP[b].Contains(separI22[a]) && separI22[a] != null)
                            //        {
                            //            conT++;
                            //        }
                                    
                                    
                            //    }
                            //}

                            Console.WriteLine("puntuacion de usuario " + conP + " fue de: " + conT);
                            conP++;
                            b = 0;
                            a = 0;

                        }
                          

                        }

                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine("Error" + ex);
                            }

                        }//

            
                streamWriter.Close();
                        
                
           
        }


        
    }
}

