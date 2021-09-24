using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BibliotecaEntidades
{
    public class UsuarioEntidad
    {
        private int id;
        private int rut;
        private int rolID;
        private string email;
        private string nombre;
        private string password;

        public int Id { get => id; set => id = value; }
        public int Rut { get => rut; set => rut = value; }
        public int RolID { get => rolID; set => rolID = value; }
        public string Email { get => email; set => email = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
    }
}
