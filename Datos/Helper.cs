using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BackEndPacientes.Dominio;

namespace BackEndPacientes.Datos
{
    internal class Helper
    {
        public SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-SFDA7AL\MSSQLSERVER2;Initial Catalog=Clinica;Integrated Security=True");
        public static Helper instancia;

        public static Helper ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new Helper();
            return instancia;
        }

        public DataTable ConsultarDB(string consultaSQL)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = consultaSQL;
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public bool InsertarPaciente(Paciente paciente)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SP_INSERT_PACIENTE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numeroHC", paciente.nroHS);
            cmd.Parameters.AddWithValue("@nombre", paciente.nombre);
            cmd.Parameters.AddWithValue("@idOS", paciente.ObraSocial);
            cmd.Parameters.AddWithValue("@sexo", paciente.Sexo);
            cmd.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaNacimiento);
            int filas = cmd.ExecuteNonQuery();
            cnn.Close();
            if (filas > 0)
                return true;
            return false;
        }

        public bool UpdatePaciente(Paciente paciente) //Listo para ser mandado al DAO pero le falta el filtro de la clase parametro
        {
            cnn.Open();                              //Ahora la carga se hace toda en el DAO, y esta forma no se usa mas.
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SP_UPDATE_PACIENTE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@numperoHS", paciente.nroHS);
            cmd.Parameters.AddWithValue("@nombre", paciente.nombre);
            cmd.Parameters.AddWithValue("@idOS", paciente.ObraSocial);
            cmd.Parameters.AddWithValue("@sexo", paciente.Sexo);
            cmd.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaNacimiento);
            int filas = cmd.ExecuteNonQuery();
            cnn.Close();
            if (filas > 0)
                return true;
            return false;
        }

        public DataTable querySQL(string SQL, List<Parametros> value) //Para meter la clase parametro en el DAO
        {
            cnn.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = SQL;
            cmd.CommandType = CommandType.Text;
            if (value != null)
            {
                foreach (Parametros param in value)
                {
                    cmd.Parameters.AddWithValue(param.key, param.value);
                }
            }

            dt.Load(cmd.ExecuteReader());

            cnn.Close();

            return dt;
        }

        public bool EjecutarSQLParam(string strSql, List<SqlParameter> values) //Para mandar la clase parametro en el DAO
        {
            bool ok = true;
            SqlTransaction t = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = strSql;
                cmd.Transaction = t;

                if (values != null)
                {
                    foreach (SqlParameter param in values)
                    {
                        cmd.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                }

                cmd.ExecuteNonQuery();
                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                {
                    t.Rollback();
                    ok = false;
                }
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();

            }

            return ok;
        }
    }
}
