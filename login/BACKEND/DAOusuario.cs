using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using login.POJOS;


namespace login.BACKEND
{
    class DAOusuario
    {
        public bool validarUsuario(usuario usuario)
        {
            bool g = false;
            MySqlCommand comando = new MySqlCommand(
             @"select NombreUsuario, Contrasenia, Nombre, Apellido " +
                "from USUARIO where NombreUsuario =@nombreUsuario and " +
                "Contrasenia = SHA1(@contrasenia)");
            comando.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
            comando.Parameters.AddWithValue("@contrasenia", usuario.Contrasenia);

            DataTable resultado = conexion.ejecutarConsulta(comando);


            if (resultado != null && resultado.Rows.Count > 0)
            {
                DataRow fila = resultado.Rows[0];
                usuario.Nombre = fila["Nombre"].ToString();
                usuario.Apellido = fila["Apellido"].ToString();
                g = true;
                return true;
            }
            else
            {
                return false;
            }
            

          
        }

        public bool registro(usuario user)
        {
            try
            {
                MySqlCommand insert = new
                MySqlCommand(@"INSERT INTO USUARIO VALUES (@nombreUsuario, " +
                " @nombre, @apellido, SHA1(@contrasenia))");
                insert.Parameters.AddWithValue("@nombreUsuario", user.NombreUsuario);
                insert.Parameters.AddWithValue("@nombre", user.Nombre);
                insert.Parameters.AddWithValue("@apellido", user.Apellido);
                insert.Parameters.AddWithValue("@contrasenia", user.Contrasenia);

                conexion.ejecutarSentencia(insert);
                return true;
            }
            catch (Exception e) { return false; }
            
        }

       
    }
}
