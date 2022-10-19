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
                    produc.Costo = Convert.ToInt32(reader.GetValue(2));
                    produc.PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                    produc.Stock = Convert.ToInt32(reader.GetValue(4));
                    produc.IdUsuario = Convert.ToInt32(reader.GetValue(5));
                    ListaProducto.Add(produc);
                }

                foreach (var produc in ListaProducto)
                {
                    Console.WriteLine("Id = " + produc.Id);
                    Console.WriteLine("Descripciones = " + produc.Descripciones);
                    Console.WriteLine("Costo = " + produc.Costo);
                    Console.WriteLine("PrecioVenta = " + produc.PrecioVenta);
                    Console.WriteLine("Stock = " + produc.Stock);
                    Console.WriteLine("IdUsuario = " + produc.IdUsuario);
                    Console.WriteLine("\n ---------------- \n");
                }
                reader.Close();
                connection.Close();
            }
            return ListaProducto;
        }

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
                    var produc2 = new Producto();
                    produc2.Id = Convert.ToInt32(reader.GetValue(0));
                    produc2.Descripciones = reader.GetValue(1).ToString();
                    produc2.Costo = Convert.ToInt32(reader.GetValue(2));
                    produc2.PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                    produc2.Stock = Convert.ToInt32(reader.GetValue(4));
                    produc2.IdUsuario = Convert.ToInt32(reader.GetValue(5));
                    ListaProductosVendidos.Add(produc2);
                }

                foreach (var produc in ListaProductosVendidos)
                {
                    Console.WriteLine("Id = " + produc.Id);
                    Console.WriteLine("Descripciones = " + produc.Descripciones);
                    Console.WriteLine("Costo = " + produc.Costo);
                    Console.WriteLine("PrecioVenta = " + produc.PrecioVenta);
                    Console.WriteLine("Stock = " + produc.Stock);
                    Console.WriteLine("IdUsuario = " + produc.IdUsuario);
                    Console.WriteLine("\n ---------------- \n");
                }
                reader.Close();
                connection.Close();
            }
            return ListaProductosVendidos;
        }
    }
}
