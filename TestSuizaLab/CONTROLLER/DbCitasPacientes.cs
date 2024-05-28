using TestSuizaLab.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TestSuizaLab.CONTROLLER
{
    public class DbCitasPacientes
    {
    string cadenaConexion = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DbConn"]].ConnectionString;
    public List<CitaModel> ListarCitas(Int documentoPaciente)
        {
            SqlConnection conexion = null;
            List<CitaModel> listaResultado = new List<CitaModel>();
            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[1];
                    Parametro[0] = new SqlParameter("@doc_paciente", SqlDbType.VarChar);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = documentoPaciente;

                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SP_Listar_Cita", Parametro))
                    {
                        while (reader.Read())
                        {
                            CitaModel datos = new CitaModel();.
                            datos.Documento = DataUtil.ObjectToString(reader["Documento"]);
                            datos.Tipo_Documento = DataUtil.ObjectToString(reader["Tipo_Documento"]);
                            datos.Nombre = DataUtil.ObjectToInt32(reader["Nombre"]);
                            datos.Especialidad = DataUtil.ObjectToString(reader["Especialidad"]);
                            datos.Fecha_Cita = DataUtil.ObjectToString(reader["Fecha_Cita"]);
                            datos.datos = datos;
                            listaResultado.Add(datos);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaResultado.Clear();
            }

            return listaResultado;
        }

        public string RegistrarActualizarCita(int codOperacion, Int documentoPaciente,int tipodocP, string EspecialidadP,string fechaP)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[5];
                    Parametro[0] = new SqlParameter("@Cod_operacion", SqlDbType.int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = codOperacion;

                    Parametro[1] = new SqlParameter("@doc_paciente", SqlDbType.int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = documentoPaciente;

                    Parametro[2] = new SqlParameter("@tipodoc", SqlDbType.int);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = tipodocP;

                    Parametro[3] = new SqlParameter("@espec_paciente", SqlDbType.string);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = EspecialidadP;

                    Parametro[4] = new SqlParameter("@fecha_cita_paciente", SqlDbType.DateTime);
                    Parametro[4].Direction = ParameterDirection.Input;
                    Parametro[4].Value = DateTime.Parse(fechaP);


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SP_Registrar_Actualizar_Cita", Parametro))
                    {
                        while (reader.Read())

                        {
                            resultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
        public string EliminarCita(Int documentoPaciente,int tipodocP, string EspecialidadP,string fechaP)
        {
            string resultado = "";
            SqlConnection conexion = null;

            try
            {
                using (conexion = new SqlConnection(cadenaConexion))
                {
                    SqlParameter[] Parametro = new SqlParameter[4];
                    Parametro[0] = new SqlParameter("@doc_paciente", SqlDbType.int);
                    Parametro[0].Direction = ParameterDirection.Input;
                    Parametro[0].Value = documentoPaciente;

                    Parametro[1] = new SqlParameter("@tipodoc", SqlDbType.int);
                    Parametro[1].Direction = ParameterDirection.Input;
                    Parametro[1].Value = tipodocP;

                    Parametro[2] = new SqlParameter("@espec_paciente", SqlDbType.string);
                    Parametro[2].Direction = ParameterDirection.Input;
                    Parametro[2].Value = EspecialidadP;

                    Parametro[3] = new SqlParameter("@fecha_cita_paciente", SqlDbType.DateTime);
                    Parametro[3].Direction = ParameterDirection.Input;
                    Parametro[3].Value = DateTime.Parse(fechaP);


                    using (IDataReader reader = SqlHelper.ExecuteReader(conexion, CommandType.StoredProcedure, "SP_Eliminar_Cita", Parametro))
                    {
                        while (reader.Read())

                        {
                            resultado = DataUtil.ObjectToString(reader["Resultado"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
            }

            return resultado;
        }
    }
}