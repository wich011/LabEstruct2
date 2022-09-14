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
        
        private static string _path = @"C:\ClonRepo\NewInput.csv";
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

            Console.Title = "LuisGironHuffman";
            int Opciones;
            BitArray encode = null;
            //string decode = arbolHH.Decodificacion(encode);
            do
            {
                var infodd = "";
                var info1 = "";



                Console.WriteLine("Holiwis");

                        Console.WriteLine("Write him favorite companie");
                        string companie = Console.ReadLine();

                        if (GetUsuarios() != null && contador ==con)
                        {
                            try
                            {

                                string allFileData = File.ReadAllText(_path);
                                foreach (string lineaActual in allFileData.Split('\n'))
                                {
                                   
                                        if (!string.IsNullOrEmpty(lineaActual) && contador == con)
                                        {
                                            string[] informacion = lineaActual.Split(';');
                                            var u = JsonConvert.DeserializeObject(informacion[1]);
                                            
                                            info1 = informacion[1];


                                            string[] informacion1 = info1.Split(':');
                                            var info2 = informacion1[7];
                                            var infoN = informacion1[1];
                                            var infoD = informacion1[2];



                                            string[] informacionN = infoN.Split(',');
                                            var infonn = informacionN[0];


                                            string[] informacionD = infoD.Split(',');
                                            infodd = informacionD[0];


                                            string[] informacion2 = info2.Split('[');
                                            var info3 = informacion2[1];

                                            string[] informacion3 = info3.Split(']');
                                            var info4 = informacion3[0];
                                            if (info4.Contains(','))
                                            {
                                                string[] informacion4 = info4.Split(',');
                                                var info5 = informacion4[1];
                                            }

                                if (info4.Contains(companie) && informacion[0] == "PATCH")
                                {
                                    

                                    Console.Write(infonn + ": ");
                                    string input = infodd;
                                    ARBOLH arbolH = new ARBOLH();

                                    arbolH.Construccion(input);

                                    encode = arbolH.Codificacion(input);

                                    Console.Write("Codificacion: ");
                                    foreach (bool bit in encode)
                                    {

                                        Console.Write((bit ? 1 : 0) + "");
                                    }
                                    Console.WriteLine();
                                    
                                     deco = arbolH.Decodificacion(encode);

                                    streamWriter.WriteLine(deco);

                                   
                                        arreglo[i] = infodd;
                                    arreglo2[i] = u.ToString();

                                    i++;
                                    



                                    streamWriter.WriteLine(arreglo);
                                }


                                        }
                            if (string.IsNullOrEmpty(lineaActual))
                            {
                                con--;
                                Console.WriteLine("DPI a buscar");
                                string DPI = Console.ReadLine();
                                for (int j = 0; j < arreglo.Length; j++)
                                {
                                   
                                    if (DPI == arreglo[j])
                                    {
                                        Console.WriteLine("LSTO " + arreglo2[j]);
                                        break;
                                    }

                                }
                                

                            }

                        }

                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine("Error" + ex);
                            }

                        }//
               

                streamWriter.Close();
                        
                Console.WriteLine("Desea continuar: Si 1, No 0");
                decision = Convert.ToInt32(Console.ReadLine());

            } while (decision==1);
           
        }


        
    }
}

