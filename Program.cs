using PrimeraPreEntregaDelProyecto.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
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
                        userDatos.TraerUsuario(a);
                        break;
                    case "B":
                        Console.WriteLine("Traer Producto: Recibe un número de IdUsuario como parámetro, debe traer todos los productos cargados en la base de este usuario en particular.");
                        Console.WriteLine("Ingrese el IdUsuario para saber los productos que cargó al sistema: ");
                        int b = Convert.ToInt32(Console.ReadLine());
                        ADO_Producto TraerProductosIngresasPorId = new ADO_Producto();
                        TraerProductosIngresasPorId.TraerProductoPorId(b);
                        break;
                    case "C":
                        Console.WriteLine("Traer Productos Vendidos: Traer Todos los productos vendidos de un Usuario, cuya información está en su producto (Utilizar dentro de esta función el \"Traer Productos\" anteriormente hecho para saber que productosVendidos ir a buscar).");
                        Console.WriteLine("Ingrese el nombre del usuario para saber los productos que venddió: ");
                        var c = Console.ReadLine();
                        ADO_Producto ProductosVendidos = new ADO_Producto();
                        ProductosVendidos.ProductosVendidosPorUsuario(c);
                        break;
                    case "D":
                        Console.WriteLine("Traer Ventas: Recibe como parámetro un IdUsuario, debe traer todas las ventas de la base asignados al usuario particular.");
                        Console.WriteLine("Ingresa el id del usuario");
                        var d = Convert.ToInt32(Console.ReadLine());
                        ADO_Venta Venta = new ADO_Venta();
                        Venta.Ventas(d);
                        break;
                    case "E":
                        Console.WriteLine("Inicio de sesión: Se le pase como parámetro el nombre del usuario y la contraseña, buscar en la base de datos si el usuario existe y si coincide con la contraseña lo devuelve (el objeto Usuario), caso contrario devuelve uno vacío (Con sus datos vacíos y el id en 0).");
                        Console.WriteLine("Ingresa el usuario");
                        var e = Console.ReadLine();
                        Console.WriteLine("Ingresa la contraseña");
                        var f = Console.ReadLine();
                        ADO_Usuario InicioSesion = new ADO_Usuario();
                        InicioSesion.InisioSesion(e, f);
                        break;
                    default:
                        Console.WriteLine("La opción ingresada es incorrecta");
                        break;
                }
                Console.WriteLine("Elija el punto que desea testear. Las opciones son A, B, C, D y E ");
                test = Console.ReadLine().ToUpper();
            }

            //Console.WriteLine("Traer Usuario:  Recibe como parámetro un nombre del usuario, buscarlo en la base de datos y devolver el objeto con todos sus datos (Esto se hará para la página en la que se mostrara los datos del usuario y en la página para modificar sus datos)");
            //Console.WriteLine("Ingrese el usuario del que quiere saber sus datos: ");
            //string a = Console.ReadLine();
            //ADO_Usuario userDatos = new ADO_Usuario();
            //userDatos.TraerUsuario(a);

            // -----------------------------------------------

            //Console.WriteLine("Traer Producto: Recibe un número de IdUsuario como parámetro, debe traer todos los productos cargados en la base de este usuario en particular.\r\n");
            //Console.WriteLine("Ingrese el IdUsuario para saber los productos que cargó al sistema: ");
            //int b = Convert.ToInt32(Console.ReadLine());
            //ADO_Producto TraerProductosIngresasPorId = new ADO_Producto();
            //TraerProductosIngresasPorId.TraerProductoPorId(b);

            // -----------------------------------------------

            //Console.WriteLine("Traer Productos Vendidos: Traer Todos los productos vendidos de un Usuario, cuya información está en su producto (Utilizar dentro de esta función el \"Traer Productos\" anteriormente hecho para saber que productosVendidos ir a buscar).\r\n");
            //Console.WriteLine("Ingrese el nombre del usuario para saber los productos que venddió: ");
            //var c = Console.ReadLine();
            //ADO_Producto ProductosVendidos = new ADO_Producto();
            //ProductosVendidos.ProductosVendidosPorUsuario(c);

            // -----------------------------------------------

            //Console.WriteLine("Traer Ventas: Recibe como parámetro un IdUsuario, debe traer todas las ventas de la base asignados al usuario particular.");
            //Console.WriteLine("Ingresa el id del usuario");
            //var e = Convert.ToInt32(Console.ReadLine());
            //ADO_Venta Venta = new ADO_Venta();
            //Venta.Ventas(e);

            // -----------------------------------------------

            //Console.WriteLine("Inicio de sesión: Se le pase como parámetro el nombre del usuario y la contraseña, buscar en la base de datos si el usuario existe y si coincide con la contraseña lo devuelve (el objeto Usuario), caso contrario devuelve uno vacío (Con sus datos vacíos y el id en 0). \r\n");
            //Console.WriteLine("Ingresa el usuario");
            //var e = Console.ReadLine();
            //Console.WriteLine("Ingresa la contraseña");
            //var f = Console.ReadLine();
            //ADO_Usuario userDatos = new ADO_Usuario();
            //userDatos.InisioSesion(e,f);

        }
    }
}
