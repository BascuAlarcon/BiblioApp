using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BibliotecaDAL;
using BibliotecaEntidades;

namespace BibliotecaBLL
{
    public class LibroBLL
    {
        LibroDAL objlibro = new LibroDAL();

        public DataTable CargarLibros()
        {
            return objlibro.CargarTablaLibros();
        }

        public void InsertarLibros(LibroEntidad libro)
        {
            objlibro.CrearLibro(libro);
        }

        public void EditarLibro(LibroEntidad libro)
        {
            objlibro.EditarLibro(libro);
        }

        public void EliminarLibros(int id)
        {
            objlibro.EliminarLibro(id);
        }

        public LibroEntidad MostrarLibro(int id)
        {
            return objlibro.MostrarLibro(id);
        }

        public DataSet SearchLibros(string nombre)
        {
            return objlibro.SearchLibros(nombre);
        }
    }
}
