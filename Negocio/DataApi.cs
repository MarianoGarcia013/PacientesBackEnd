using BackEndPacientes.Datos.Implement;
using BackEndPacientes.Datos.Interfaz;
using BackEndPacientes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndPacientes.Negocio
{
    public class DataApi : IDataApi // Listo
    {
        private IDAOPacientes DAO;

        public DataApi()
        {
            DAO = new DAOPacientes();
        }

        public bool DeletePacientes(int id)
        {
            return DAO.EliminarPaciente(id);
        }

        public List<Paciente> GetPacientes()
        {
            return DAO.ConsultarPacientes();
        }

        public bool InsertarPacientes(Paciente paciente)
        {
            return DAO.CargarPaciente(paciente);
        }

        public bool UpdatePacientes(Paciente paciente)
        {
            return DAO.ModificarPaciente(paciente);
        }
    }
}
