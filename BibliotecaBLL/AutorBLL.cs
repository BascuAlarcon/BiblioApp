using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BibliotecaDAL;
using BibliotecaEntidades;

namespace BibliotecaBLL
{
    public class AutorBLL
    {
        AutorDAL objAutor = new AutorDAL();

        public DataSet CargarComboBoxAutores()
        {
            return objAutor.CargarComboBoxAutores();
        }

        public DataTable CargarTablaAutor()
        {
            return objAutor.CargarTablaAutores();
        }

        public void CrearAutor(AutorEntidad autor)
        {
            objAutor.CrearAutor(autor);
        }

        public void EditarAutor(AutorEntidad autor)
        {
            objAutor.EditarAutor(autor);
        }

        public void EliminarAutor(int id)
        {
            objAutor.EliminarAutor(id);
        }

        public AutorEntidad BuscarAutor(int id)
        {
            return objAutor.BuscarAutor(id);
        }

        public int BuscarExistenciaAutor(int id)
        {
            return objAutor.buscarExistenciaAutor(id);
        }

        
    }
}
