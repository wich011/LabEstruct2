using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LAb02
{
    public class ARBOLH
    {
        private List<Node> nodes = new List<Node>();
        public Node Root { get; set; }
        public Dictionary<char, int> Frecuencias = new Dictionary<char, int>();

        public void Construccion(string source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (!Frecuencias.ContainsKey(source[i]))
                {
                    Frecuencias.Add(source[i], 0);
                }

                Frecuencias[source[i]]++;
            }

            foreach (KeyValuePair<char, int> simbol in Frecuencias)
            {
                nodes.Add(new Node() { simbolo = simbol.Key, Frequency = simbol.Value });
            }

            while (nodes.Count > 1)
            {
                List<Node> Ordenamiento = nodes.OrderBy(node => node.Frequency).ToList<Node>();

                if (Ordenamiento.Count >= 2)
                {
                   
                    List<Node> tok = Ordenamiento.Take(2).ToList<Node>();

                    Node parent = new Node()
                    {
                        simbolo = '*',
                        Frequency = tok[0].Frequency + tok[1].Frequency,
                        izquierda = tok[0],
                        derecha = tok[1]
                    };

                    nodes.Remove(tok[0]);
                    nodes.Remove(tok[1]);
                    nodes.Add(parent);
                }

                this.Root = nodes.FirstOrDefault();

            }

        }

        
        public bool Hoja(Node node)
        {
            return (node.izquierda == null && node.derecha == null);
        }
        public BitArray Codificacion(string source)
        {
            List<bool> OriginCodi = new List<bool>();

            for (int i = 0; i < source.Length; i++)
            {
                List<bool> SimCodi = this.Root.Cruce(source[i], new List<bool>());
                OriginCodi.AddRange(SimCodi);
            }

            BitArray bytes = new BitArray(OriginCodi.ToArray());

            return bytes;
        }

        public string Decodificacion(BitArray baytess)
        {
            Node Actu = this.Root;
            string decodificacion = "";

            foreach (bool bytee in baytess)
            {
                if (bytee)
                {
                    if (Actu.derecha != null)
                    {
                        Actu = Actu.derecha;
                    }
                }
                else
                {
                    if (Actu.izquierda != null)
                    {
                        Actu = Actu.izquierda;
                    }
                }

                if (Hoja(Actu))
                {
                    decodificacion += Actu.simbolo;
                    Actu = this.Root;
                }
            }

            return decodificacion;
        }

       

    }
}