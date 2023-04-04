using BackEndPacientes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndPacientes.Negocio
{
    public interface IDataApi // Listo
    {
        public List<Paciente> GetPacientes();

        public bool InsertarPacientes(Paciente paciente);
        public bool UpdatePacientes(Paciente paciente);
        public bool DeletePacientes(int id);
    }
}
