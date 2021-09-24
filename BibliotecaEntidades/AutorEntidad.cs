using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaEntidades
{
    public class AutorEntidad
    {
        private int idAutor;
        private string nombre;

        public int IdAutor { get => idAutor; set => idAutor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
