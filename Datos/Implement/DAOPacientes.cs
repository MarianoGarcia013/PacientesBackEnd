using BackEndPacientes.Datos.Interfaz;
using BackEndPacientes.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BackEndPacientes.Datos.Implement
{
     internal class DAOPacientes : IDAOPacientes
    {
        public bool CargarPaciente(Paciente paciente) //Listo para mandarlo
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@numeroHC", paciente.nroHS));
            list.Add(new SqlParameter("@nombre", paciente.nombre));
            list.Add(new SqlParameter("@idOS", paciente.ObraSocial));
            list.Add(new SqlParameter("@sexo", paciente.Sexo));
            list.Add(new SqlParameter("@fechaNacimiento", paciente.FechaNacimiento));
            
            return Helper.ObtenerInstancia().EjecutarSQLParam("SP_INSERT_PACIENTE", list);
        }

        public List<Paciente> ConsultarPacientes() //Listo para mandarlo
        {
            List<Paciente> list = new List<Paciente>();
            DataTable dt = Helper.ObtenerInstancia().ConsultarDB("SELECT * FROM PACIENTES");
            foreach (DataRow dr in dt.Rows) 
            {
                Paciente paciente = new Paciente();
                paciente.nroHS = Convert.ToInt32(dr[0].ToString());
                paciente.nombre = dr[1].ToString();
                paciente.ObraSocial = Convert.ToInt32(dr[2].ToString());
                paciente.Sexo = Convert.ToInt32(dr[3].ToString());
                paciente.FechaNacimiento = Convert.ToDateTime(dr[4].ToString());

                
                list.Add(paciente);
            }
            return list;          
                       
        }

        public bool EliminarPaciente(int id)
        {
            List<SqlParameter> sp = new List<SqlParameter>();
            sp.Add(new SqlParameter("@numeroHC", id));

            return Helper.ObtenerInstancia().EjecutarSQLParam("SP_DELETE_PACIENTE", sp);
        }

        public bool ModificarPaciente(Paciente paciente) //Listo para mandarlo
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@numeroHC", paciente.nroHS));
            list.Add(new SqlParameter("@nombre", paciente.nombre));
            list.Add(new SqlParameter("@idOS", paciente.ObraSocial));
            list.Add(new SqlParameter("@sexo", paciente.Sexo));
            list.Add(new SqlParameter("@fechaNacimiento", paciente.FechaNacimiento));

            return Helper.ObtenerInstancia().EjecutarSQLParam("SP_UPDATE_PACIENTE", list);
        }
    }
}
