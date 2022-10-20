using PrimeraPreEntregaDelProyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraPreEntregaDelProyecto.Handlers
{
    public class ADO_Usuario
    {
        public Usuario TraerUsuario(string NombreUsuario)
        {
            var user = new Usuario();

            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "MARCOSLEAL1\\MSSQLSERVER01";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                connection.Open();

                cmd.CommandText = "select * from Usuario where NombreUsuario = @user;";
                cmd.Parameters.Add(new SqlParameter("@user", NombreUsuario));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader.GetValue(0));
                    user.Nombre = reader.GetValue(1).ToString();
                    user.Apellido = reader.GetValue(2).ToString();
                    user.NombreUsuario = reader.GetValue(3).ToString();
                    user.Contraseña = reader.GetValue(4).ToString();
                    user.Mail = reader.GetValue(5).ToString();
                }
                reader.Close();
                connection.Close();
            }
            return user;
        }

        public Usuario InisioSesion(string NombreUsuario, string contraseña)
        {
            var user = new Usuario();

            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "MARCOSLEAL1\\MSSQLSERVER01";
            conecctionbuilder.InitialCatalog = "SistemaGestion";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.Connection = connection;
                connection.Open();

                cmd.CommandText = "select * from Usuario where NombreUsuario = @user and Contraseña = @password;";
                cmd.Parameters.Add(new SqlParameter("@user", NombreUsuario));
                cmd.Parameters.Add(new SqlParameter("@password", contraseña));
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Id = Convert.ToInt32(reader.GetValue(0));
                        user.Nombre = reader.GetValue(1).ToString();
                        user.Apellido = reader.GetValue(2).ToString();
                        user.NombreUsuario = reader.GetValue(3).ToString();
                        user.Contraseña = reader.GetValue(4).ToString();
                        user.Mail = reader.GetValue(5).ToString();
                    }
                }
                reader.Close();
                connection.Close();
            }
            return user;
        }
    }
}
