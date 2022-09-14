using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAb02
{
    public class Node
    {
        public char simbolo { get; set; }
        public int Frequency { get; set; }
        public Node derecha { get; set; }
        public Node izquierda { get; set; }

        public List<bool> Cruce(char simbolos, List<bool> DT)
        {
            //--------hoja------------------
            if (derecha == null && izquierda == null)
            {
                if (simbolos.Equals(this.simbolo))
                {
                    return DT;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                List<bool> izi = null;
                List<bool> der = null;

                if (izquierda != null)
                {
                    List<bool> ElIzq = new List<bool>();
                    ElIzq.AddRange(DT);
                    ElIzq.Add(false);
                    
                    izi = izquierda.Cruce(simbolos, ElIzq);
                }

                if (derecha != null)
                {
                    List<bool> PaDer = new List<bool>();
                    PaDer.AddRange(DT);
                    PaDer.Add(true);
                    der = derecha.Cruce(simbolos, PaDer);
                }

                if (izi != null)
                {
                    return izi;
                }
                else
                {
                    return der;
                }
            }
        }
    }
}
