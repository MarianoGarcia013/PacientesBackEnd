using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndPacientes.Datos
{
    internal class Parametros
    {
        public string key { get; set; }
        public object value { get; set; }

        public Parametros(string key, object value)
        {
            this.key = key;
            this.value = value;
        }

        public Parametros()
        {

        }
    }
}
