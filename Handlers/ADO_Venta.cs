using PrimeraPreEntregaDelProyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraPreEntregaDelProyecto.Handlers
{
    public class ADO_Venta
    {
        public List<Venta> Ventas(int IdUser)
        {
            List<Venta> Ventas = new List<Venta>();

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

                cmd.CommandText = "select * from Venta where IdUsuario = @iduser;";
                cmd.Parameters.Add(new SqlParameter("@iduser", IdUser));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var venta = new Venta();

                    venta.Id = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));
                    Ventas.Add(venta);
                }
                reader.Close();
                connection.Close();
            }
            return Ventas;
        }
    }
}
