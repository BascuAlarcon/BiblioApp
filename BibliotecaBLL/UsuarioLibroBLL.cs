using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaDAL;
using BibliotecaEntidades;
using System.Data;

namespace BibliotecaBLL
{
    public class UsuarioLibroBLL
    {
        UsuarioLibroDAL objeto = new UsuarioLibroDAL();

        public void CrearUsuarioLibro(int rut, int idLibro)
        {
            objeto.CrearUsuarioLibro(rut, idLibro);
        }

        public DataSet CrearTablaLibrosComprados(int rut)
        {
            return objeto.CargarTablaLibrosComprados(rut);
        }
    }
}
