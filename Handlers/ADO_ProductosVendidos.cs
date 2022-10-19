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
        public List<Producto> ProductosVendidosPorUsuario(string NombreUsuario)
        {
            List<Producto> ListaProductosVendidos = new List<Producto>();

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

                cmd.CommandText = "SELECT pr.* FROM Producto pr INNER JOIN ProductoVendido pv ON pr.Id = pv.IdProducto INNER JOIN Venta vnt ON vnt.Id = pv.IdVenta INNER JOIN Usuario us ON Us.Id = vnt.IdUsuario WHERE Us.NombreUsuario = @NombreUsuario;";
                cmd.Parameters.Add(new SqlParameter("@NombreUsuario", NombreUsuario));
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var produc = new Producto();
                    produc.Id = Convert.ToInt32(reader.GetValue(0));
                    produc.Descripciones = reader.GetValue(1).ToString();
                    produc.Costo = Convert.ToInt32(reader.GetValue(2));
                    produc.PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                    produc.Stock = Convert.ToInt32(reader.GetValue(4));
                    produc.IdUsuario = Convert.ToInt32(reader.GetValue(5));
                    ListaProductosVendidos.Add(produc);
                }

                foreach (var produc in ListaProductosVendidos)
                {
                    Console.WriteLine("Productos vendidos por el usuario");
                    Console.WriteLine("Id = " + produc.Id);
                    Console.WriteLine("Stock = " + produc.Descripciones);
                    Console.WriteLine("IdProducto = " + produc.Costo);
                    Console.WriteLine("IdVenta = " + produc.PrecioVenta);
                    Console.WriteLine("IdProducto = " + produc.Stock);
                    Console.WriteLine("IdVenta = " + produc.IdUsuario);
                    Console.WriteLine("\n ---------------- \n");
                }
                reader.Close();
                connection.Close();
            }
            return ListaProductosVendidos;
        }
    }
}
