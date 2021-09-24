using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaDAL;
using BibliotecaEntidades;
using System.Data;

namespace BibliotecaBLL
{
    public class CategoriaBLL
    {
        CategoriaDAL objCategoria = new CategoriaDAL();

        public List<CategoriaEntidad> ListarCategorias()
        {
            return objCategoria.ListarCategoria();
        }

        public DataTable CargarTablaCategoria()
        {
            return objCategoria.CargarCategoria();
        }
         
        public DataSet CargarComboBox()
        {
            return objCategoria.CargarComboboxCategoria();
        } 
         
        public void CrearCategoria(CategoriaEntidad categoria)
        {
            objCategoria.InsertarCategoria(categoria);
        }

        public void EditarCategoria(CategoriaEntidad categoria)
        {
            objCategoria.EditarCategoria(categoria);
        }

        public void EliminarCategoria(int id)
        {
            objCategoria.EliminarCategoria(id);
        }

        public CategoriaEntidad BuscarCategoria(int id)
        {
            return objCategoria.BuscarCategoria(id);
        }

        public int BuscarExistenciaCategoria(int id)
        {
            return objCategoria.buscarExistenciaCategoria(id);
        }

        // USO DE DATABASEHELPER

        public void dbhCrearCategoria(CategoriaEntidad categoria)
        {
            objCategoria.dbhInsertarCategoria(categoria);
        }
        
        public DataSet CargarDD()
        {
            return objCategoria.CargarDDCategoria();
        }
         
        public DataSet dbhCargarTabla()
        {
            return objCategoria.dbhCargarTabla();
        }

        public void dbhEliminarCategoria(int id)
        {
            objCategoria.dbhEliminarCategoria(id);
        }

    }
}
