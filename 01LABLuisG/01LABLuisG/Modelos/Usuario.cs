using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01LABLuisG.Modelos
{
    public class Usuario
    {
        private string json;



    private string name;
        private string dpi;
        private DateTime datebirth;
        private string address;
        public Usuario(string json)
        {
            this.json = json;
        }



        public Usuario() { }

        public Usuario(string name, string dpi, DateTime datebirth, string address)
        {
            this.name = name;
            this.dpi = dpi;
            this.datebirth = datebirth;
            this.address = address;
        }

        //public string name { get; set; }
        //public string dpi { get; set; }
        //public DateTime datebirth { get; set; }
        //public string address { get; set; }

        public string getNombre()
        {
            return name;
        }
        public void setNombre(string nombre)
        {
            this.name = name;
        }





        public string getDpi()
        {
            return dpi;
        }

        public void setDpi(string dpi)
        {
            this.dpi = dpi;
        }




        public DateTime getDate()
        {
            return datebirth;
        }

        public void setDate(DateTime datebirth)
        {
            this.datebirth = datebirth;
        }





        public string getaddress()
        {
            return address;
        }

        public void setaddress(string address)
        {
            this.address = address;
        }
    }
}
