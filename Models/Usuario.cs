﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraPreEntregaDelProyecto.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

        public Usuario()
        {

            Id = 0;
            Nombre = String.Empty;
            Apellido = String.Empty;
            NombreUsuario = String.Empty;
            Contraseña = String.Empty;
            Mail = String.Empty;

        }

        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Mail = mail;
        }

    }
}
