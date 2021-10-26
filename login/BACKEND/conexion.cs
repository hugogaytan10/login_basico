using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace login.BACKEND
{
    class conexion
    {
        static MySqlConnection conect;
        public static bool conectar()
        {
            string parametrosconect; //ESTA VARIABLETIENE TUS PARAMETROS PARA LA CONEXION A LA DB
            try
            {
                conect = new MySqlConnection(parametrosconect);
                conect.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Libera la conexión para no ocupar recursos innecesarios del servidor de BD
        /// </summary>
        public static void desconectar()
        {
            if (conect != null && conect.State == ConnectionState.Open)
                conect.Close();
        }
        //SELECT
        public static DataTable ejecutarConsulta( MySqlCommand comando )
        {
            if (conectar())
            {
                try
                {
                    comando.Connection = conect;
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                    DataTable resultado_consulta = new DataTable();
                    adaptador.Fill(resultado_consulta);
                    return resultado_consulta;
                }
                catch (Exception e) {
                    return null;
                }
                finally
                {
                    desconectar();
                }

            }
            else
            {
                return null;
            } 
            
        }
        //update, alter cosas que modifiquen la BD
        public static void ejecutarSentencia(MySqlCommand sentencia)
        {
            try
            {
                conectar();
                sentencia.Connection = conect;
                sentencia.ExecuteNonQuery();

            }
            catch (Exception e) { Console.WriteLine("oh no"); }
            finally
            {
                desconectar();
            }
        }




    }
}
