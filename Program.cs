using PrimeraPreEntregaDelProyecto.Handlers;
using PrimeraPreEntregaDelProyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraPreEntregaDelProyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Punto A: Traer Usuario:  Recibe como parámetro un nombre del usuario, buscarlo en la base de datos y devolver el objeto con todos sus datos (Esto se hará para la página en la que se mostrara los datos del usuario y en la página para modificar sus datos)");
            Console.WriteLine("Punto B: Traer Producto: Recibe un número de IdUsuario como parámetro, debe traer todos los productos cargados en la base de este usuario en particular.");
            Console.WriteLine("Punto C: Traer Productos Vendidos: Traer Todos los productos vendidos de un Usuario, cuya información está en su producto (Utilizar dentro de esta función el \"Traer Productos\" anteriormente hecho para saber que productosVendidos ir a buscar).");
            Console.WriteLine("Punto D: Traer Ventas: Recibe como parámetro un IdUsuario, debe traer todas las ventas de la base asignados al usuario particular.");
            Console.WriteLine("Punto E: Inicio de sesión: Se le pase como parámetro el nombre del usuario y la contraseña, buscar en la base de datos si el usuario existe y si coincide con la contraseña lo devuelve (el objeto Usuario), caso contrario devuelve uno vacío (Con sus datos vacíos y el id en 0).");
            Console.WriteLine("Elija el punto que desea testear. Las opciones son A, B, C, D y E ");
            string test = Console.ReadLine().ToUpper();

            while(test != "F")
            {
                switch (test)
                {
                    case "A":
                        Console.WriteLine("Traer Usuario:  Recibe como parámetro un nombre del usuario, buscarlo en la base de datos y devolver el objeto con todos sus datos (Esto se hará para la página en la que se mostrara los datos del usuario y en la página para modificar sus datos)");
                        Console.WriteLine("Ingrese el usuario del que quiere saber sus datos: ");
                        string a = Console.ReadLine();
                        ADO_Usuario userDatos = new ADO_Usuario();
                        var user = userDatos.TraerUsuario(a);
                        Console.WriteLine(user.NombreUsuario);
                        Console.WriteLine("---- USUARIO ----");
                        if (user.NombreUsuario == user.NombreUsuario)
                        {
                            Console.WriteLine("NombreUsuario = " + user.NombreUsuario);
                            Console.WriteLine("Id = " + user.Id);
                            Console.WriteLine("Nombre = " + user.Nombre);
                            Console.WriteLine("Mail = " + user.Mail);
                            Console.WriteLine("Apellido = " + user.Apellido);
                            Console.WriteLine("Contraseña = " + user.Contraseña);
                        }
                        else
                        {
                            Console.WriteLine("El nombre del usuario es incorrecto");
                        }
                        break;
                    case "B":
                        Console.WriteLine("Traer Producto: Recibe un número de IdUsuario como parámetro, debe traer todos los productos cargados en la base de este usuario en particular.");
                        Console.WriteLine("Ingrese el IdUsuario para saber los productos que cargó al sistema: ");
                        int b = Convert.ToInt32(Console.ReadLine());
                        ADO_Producto TraerProductosIngresasPorId = new ADO_Producto();
                        var listaProductos = TraerProductosIngresasPorId.TraerProductoPorId(b);
                        foreach (var produc in listaProductos)
                        {
                            Console.WriteLine("Id = " + produc.Id);
                            Console.WriteLine("Descripciones = " + produc.Descripciones);
                            Console.WriteLine("Costo = " + produc.Costo);
                            Console.WriteLine("PrecioVenta = " + produc.PrecioVenta);
                            Console.WriteLine("Stock = " + produc.Stock);
                            Console.WriteLine("IdUsuario = " + produc.IdUsuario);
                            Console.WriteLine("\n ---------------- \n");
                        }
                        break;
                    case "C":
                        Console.WriteLine("Traer Productos Vendidos: Traer Todos los productos vendidos de un Usuario, cuya información está en su producto (Utilizar dentro de esta función el \"Traer Productos\" anteriormente hecho para saber que productosVendidos ir a buscar).");
                        Console.WriteLine("Ingrese el id del usuario para saber los productos que se vendió: ");
                        var c = Convert.ToInt32(Console.ReadLine());
                        ADO_ProductosVendidos ProductosVendidos = new ADO_ProductosVendidos();
                        var ListaProductosVendidos = ProductosVendidos.ProductosVendidosPorUsuario(c);
                        foreach (var produc in ListaProductosVendidos)
                        {
                            Console.WriteLine("Productos vendidos del usuario");
                            Console.WriteLine("Id = " + produc.Id);
                            Console.WriteLine("Stock = " + produc.Stock);
                            Console.WriteLine("IdProducto = " + produc.IdProducto);
                            Console.WriteLine("IdVenta = " + produc.IdVenta);
                            Console.WriteLine("\n ---------------- \n");
                        }
                        break;
                    case "D":
                        Console.WriteLine("Traer Ventas: Recibe como parámetro un IdUsuario, debe traer todas las ventas de la base asignados al usuario particular.");
                        Console.WriteLine("Ingresa el id del usuario");
                        var d = Convert.ToInt32(Console.ReadLine());
                        ADO_Venta Venta = new ADO_Venta();
                        var Ventass = Venta.Ventas(d);
                        foreach (var vent in Ventass)
                        {
                            Console.WriteLine("Id = " + vent.Id);
                            Console.WriteLine("Stock = " + vent.Comentarios);
                            Console.WriteLine("IdProducto = " + vent.IdUsuario);
                            Console.WriteLine("\n ---------------- \n");
                        }
                        break;
                    case "E":
                        Console.WriteLine("Inicio de sesión: Se le pase como parámetro el nombre del usuario y la contraseña, buscar en la base de datos si el usuario existe y si coincide con la contraseña lo devuelve (el objeto Usuario), caso contrario devuelve uno vacío (Con sus datos vacíos y el id en 0).");
                        Console.WriteLine("Ingresa el usuario");
                        var e = Console.ReadLine();
                        Console.WriteLine("Ingresa la contraseña");
                        var f = Console.ReadLine();
                        ADO_Usuario InicioSesion = new ADO_Usuario();
                        var login = InicioSesion.InisioSesion(e, f);
                        if (login.NombreUsuario == login.NombreUsuario)
                        {
                            Console.WriteLine("---- USUARIO ----");
                            Console.WriteLine("NombreUsuario = " + login.NombreUsuario);
                            Console.WriteLine("Id = " + login.Id);
                            Console.WriteLine("Nombre = " + login.Nombre);
                            Console.WriteLine("Mail = " + login.Mail);
                            Console.WriteLine("Apellido = " + login.Apellido);
                            Console.WriteLine("Contraseña = " + login.Contraseña);
                        }
                        else
                        {
                            Usuario vacio = new Usuario();
                            Console.WriteLine("El nombre del usuario es incorrecto");
                            Console.WriteLine("NombreUsuario = " + vacio.NombreUsuario);
                            Console.WriteLine("Id = " + vacio.Id);
                            Console.WriteLine("Nombre = " + vacio.Nombre);
                            Console.WriteLine("Mail = " + vacio.Mail);
                            Console.WriteLine("Apellido = " + vacio.Apellido);
                            Console.WriteLine("Contraseña = " + vacio.Contraseña);
                        }
                        break;
                    default:
                        Console.WriteLine("La opción ingresada es incorrecta");
                        break;
                }
                Console.WriteLine("Elija el punto que desea testear. Las opciones son A, B, C, D y E o elija F para salir.");
                test = Console.ReadLine().ToUpper();
            }
        }
    }
}
