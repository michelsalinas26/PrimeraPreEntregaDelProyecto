using PrimeraPreEntregaDelProyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraPreEntregaDelProyecto.Handlers
{
    public class ADO_ProductosVendidos
    {
        public List<ProductoVendido> ProductosVendidosPorUsuario(int Iduser)
        {
            List<ProductoVendido> ListaProductosVendidos = new List<ProductoVendido>();

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

                cmd.CommandText = "select pv.* from ProductoVendido as pv join Producto on pv.IdProducto = Producto.Id where Producto.IdUsuario = @iduser;";
                cmd.Parameters.Add(new SqlParameter("@iduser", Iduser));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var produc = new ProductoVendido();
                    produc.Id = Convert.ToInt32(reader.GetValue(0));
                    produc.Stock = Convert.ToInt32(reader.GetValue(1));
                    produc.IdProducto = Convert.ToInt32(reader.GetValue(2));
                    produc.IdVenta = Convert.ToInt32(reader.GetValue(3));
                    ListaProductosVendidos.Add(produc);
                }
                reader.Close();
                connection.Close();
            }
            return ListaProductosVendidos;
        }
    }
}
