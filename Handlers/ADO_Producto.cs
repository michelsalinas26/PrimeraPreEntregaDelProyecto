using PrimeraPreEntregaDelProyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraPreEntregaDelProyecto.Handlers
{
    public class ADO_Producto
    {
        public List<Producto> TraerProductoPorId(int IdUser)
        {
            List<Producto> ListaProducto = new List<Producto>();

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

                cmd.CommandText = "select * from Producto join Usuario on Producto.idUsuario = Usuario.id where Usuario.id = @iduser;";
                cmd.Parameters.Add(new SqlParameter("@iduser", IdUser));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var produc = new Producto();
                    produc.Id = Convert.ToInt32(reader.GetValue(0));
                    produc.Descripciones = reader.GetValue(1).ToString();
                    produc.Costo = Convert.ToDouble(reader.GetValue(2));
                    produc.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    produc.Stock = Convert.ToInt32(reader.GetValue(4));
                    produc.IdUsuario = Convert.ToInt32(reader.GetValue(5));
                    ListaProducto.Add(produc);
                }
                reader.Close();
                connection.Close();
            }
            return ListaProducto;
        }
    }
}
