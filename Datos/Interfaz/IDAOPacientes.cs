using BackEndPacientes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndPacientes.Datos.Interfaz
{
    internal interface IDAOPacientes
    {
        List<Paciente> ConsultarPacientes();

        bool CargarPaciente(Paciente paciente);

        bool ModificarPaciente(Paciente paciente);
        bool EliminarPaciente(int id);
    }
}
