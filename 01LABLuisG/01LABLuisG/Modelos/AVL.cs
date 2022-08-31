using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01LABLuisG.Modelos;


namespace _01LABLuisG.Modelos
{
    public class AVL
    {
        public Nodo<Usuario> raiz;
        public AVL()
        {
            this.raiz = null;
        }

        //Arbol a lista
        public List<Usuario> toList(List<Usuario> lista, Nodo<Usuario> r)
        {
            if (r != null)
            {
                if (r.subIzq != null)
                {
                    toList(lista, r.subIzq);
                }
                lista.Add(r.paciente);
                if (r.subDer != null)
                {
                    toList(lista, r.subDer);
                }

                return lista;
            }
            else
            {
                return null;
            }


        }
        //Busqueda
        public Nodo<Usuario> BuscarID(string dpi, Nodo<Usuario> r)
        {
            if (r == null)
            {
                return null;
            }
            else if (r.paciente.getDpi() == dpi)
            {
                return r;
            }
            else if (string.Compare(r.paciente.getDpi(), dpi) < 0)
            {
                return BuscarID(dpi, r.subDer);
            }
            else if (string.Compare(r.paciente.getDpi(), dpi) > 0)
            {
                return BuscarID(dpi, r.subIzq);
            }
            else
            {
                return null;
            }

        }
        public Usuario BuscarNombre(string nombre, Nodo<Usuario> r, Usuario p)
        {
            if (r.subIzq != null)
            {
                BuscarNombre(nombre, r.subIzq, p);
            }
            if (r.paciente.getNombre() == nombre)
            {
                p = r.paciente;
            }
            if (r.subDer != null)
            {
                BuscarNombre(nombre, r.subDer, p);
            }
            return p;

        }

        //Obtener factor de equilibrio
        int FE(Nodo<Usuario> arbol)
        {
            if (arbol == null)
            {
                return -1;
            }
            else
            {
                return arbol.FactorEquilibrio;
            }
        }
        //Rotaciones simples
        Nodo<Usuario> rotIzq(Nodo<Usuario> arbol)
        {
            Nodo<Usuario> aux = arbol.subIzq;
            arbol.subIzq = aux.subDer;
            aux.subDer = arbol;
            arbol.FactorEquilibrio = Math.Max(FE(arbol.subIzq), FE(arbol.subDer)) + 1;
            aux.FactorEquilibrio = Math.Max(FE(aux.subIzq), FE(aux.subDer)) + 1;
            return aux;
        }
        Nodo<Usuario> rotDer(Nodo<Usuario> arbol)
        {
            Nodo<Usuario> aux = arbol.subDer;
            arbol.subDer = aux.subIzq;
            aux.subIzq = arbol;
            arbol.FactorEquilibrio = Math.Max(FE(arbol.subIzq), FE(arbol.subDer)) + 1;
            aux.FactorEquilibrio = Math.Max(FE(aux.subIzq), FE(aux.subDer)) + 1;
            return aux;
        }
        // Rotaciones dobles
        Nodo<Usuario> DrotIzq(Nodo<Usuario> arbol)
        {
            Nodo<Usuario> aux;
            arbol.subIzq = rotDer(arbol.subIzq);
            aux = rotIzq(arbol);
            return aux;
        }
        Nodo<Usuario> DrotDer(Nodo<Usuario> arbol)
        {
            Nodo<Usuario> aux;
            arbol.subDer = rotIzq(arbol.subDer);
            aux = rotDer(arbol);
            return aux;
        }

        //insertar segun el orden
        public void Insertar(Usuario nuevo)
        {
            Nodo<Usuario> nuevoArbol = new Nodo<Usuario>(nuevo);
            if (raiz == null)
            {
                raiz = nuevoArbol;
            }
            else
            {
                raiz = InsertarID(nuevoArbol, raiz);
            }
        }
        Nodo<Usuario> InsertarID(Nodo<Usuario> nuevo, Nodo<Usuario> subArbol)
        {
            //nuevo = nuevo dato a ingresar
            //subArbol = raiz actual del AVL
            //nuevoPadre = raiz del AVL despues de las rotaciones

            Nodo<Usuario> nuevoPadre = subArbol;
            // si es menor
            if (string.Compare(nuevo.paciente.getDpi(), subArbol.paciente.getDpi()) < 0)
            {
                // si la raiz no tiene hijo izquiedo, se asigna en esa posicion
                if (subArbol.subIzq == null)
                {
                    subArbol.subIzq = nuevo;
                }
                // si se tiene un hijo izquierdo se utiliza la recursion para revisar los hijos del subArbol izquierdo
                else
                {
                    subArbol.subIzq = InsertarID(nuevo, subArbol.subIzq);
                    //Si el arbol entra en un desbalance, se utilizan rotaciones
                    if ((FE(subArbol.subIzq) - FE(subArbol.subDer) == 2))
                    {
                        if (string.Compare(nuevo.paciente.getDpi(), subArbol.subIzq.paciente.getDpi()) < 0)
                        {
                            nuevoPadre = rotIzq(subArbol);
                        }
                        else
                        {
                            nuevoPadre = DrotIzq(subArbol);
                        }
                    }
                }
            }
            //si es mayor
            else if (string.Compare(nuevo.paciente.getDpi(), subArbol.paciente.getDpi()) >= 0)
            {
                // si la raiz no tiene hijo derecho, se asigna en esa posicion
                if (subArbol.subDer == null)
                {
                    subArbol.subDer = nuevo;
                }
                else
                {
                    // si se tiene un hijo derecho se utiliza la recursion para revisar los hijos del subArbol derecho
                    subArbol.subDer = InsertarID(nuevo, subArbol.subDer);
                    //Si el arbol entra en un desbalance, se utilizan rotaciones
                    if ((FE(subArbol.subDer) - FE(subArbol.subIzq) == 2))
                    {
                        if (string.Compare(nuevo.paciente.getDpi(), subArbol.subDer.paciente.getDpi()) >= 0)
                        {
                            nuevoPadre = rotDer(subArbol);
                        }
                        else
                        {
                            nuevoPadre = DrotDer(subArbol);
                        }
                    }
                }
            }
            if ((subArbol.subIzq == null) && (subArbol.subDer != null))
            {
                subArbol.FactorEquilibrio = subArbol.subDer.FactorEquilibrio + 1;
            }
            else if ((subArbol.subDer == null) && (subArbol.subIzq != null))
            {
                subArbol.FactorEquilibrio = subArbol.subIzq.FactorEquilibrio + 1;
            }
            else
            {
                subArbol.FactorEquilibrio = Math.Max(FE(subArbol.subIzq), FE(subArbol.subDer)) + 1;
            }
            return nuevoPadre;

        }

        //edicion de paciente
        //public void Editar(Usuario p, DateTime fecha)
        //{
        //    p.ProxConsult = fecha;
        //}
        //public void EditarD(Paciente p, string diagnostico)
        //{
        //    p.Diagnostico = diagnostico;
        //}
        public bool YaEsta(string dpi, Nodo<Usuario> r)
        {
            Nodo<Usuario> temp = BuscarID(dpi, r);
            if (temp == null)
            {
                return false;
            }
            else return true;
        }
    }
}
