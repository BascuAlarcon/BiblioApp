using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaEntidades
{
    public class LibroEntidad
    {
        private int idLibro;
        private string nombreLibro;
        private int precio;
        private int autorID;
        private int categoriaID;
        private string nombreAutor;
        private string nombreCategoria;

        public int IdLibro { get => idLibro; set => idLibro = value; }
        public string NombreLibro { get => nombreLibro; set => nombreLibro = value; }
        public int Precio { get => precio; set => precio = value; }
        public int AutorID { get => autorID; set => autorID = value; }
        public int CategoriaID { get => categoriaID; set => categoriaID = value; }
        public string NombreAutor { get => nombreAutor; set => nombreAutor = value; }
        public string NombreCategoria { get => nombreCategoria; set => nombreCategoria = value; }
    }
}
