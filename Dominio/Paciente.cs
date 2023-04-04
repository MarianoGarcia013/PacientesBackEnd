using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndPacientes.Dominio
{
    public class Paciente
    {
        public int nroHS { get; set; }
        public string nombre { get; set; }
        public int ObraSocial { get; set; }
        public int Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Paciente(int nroHS, string nombre, int ObraSocial, int Sexo, DateTime FechaNacimiento)
        {
            this.nroHS = nroHS;
            this.nombre = nombre;
            this.ObraSocial = ObraSocial;
            this.Sexo = Sexo;
            this.FechaNacimiento= FechaNacimiento;
        }

        public Paciente()
        {

        }

        public override string ToString()
        {
            return nroHS+ ": " + nombre+", FechaNac: "+ FechaNacimiento;
        }

    }
}
