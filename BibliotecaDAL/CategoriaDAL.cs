using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration; 
using BibliotecaEntidades; 
using System.Data;
using System.Web;

namespace BibliotecaDAL
{ 
    public class CategoriaDAL
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString);
        SqlDataReader reader;

        #region sin DataBaseHelper

        // LISTAR CATEGORIA
        public List<CategoriaEntidad> ListarCategoria()
        { 
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ALL_CATEGORIAS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open(); 
            reader = cmd.ExecuteReader();
            List<CategoriaEntidad> listar = new List<CategoriaEntidad>(); 

            while (reader.Read())
            {
                listar.Add(new CategoriaEntidad
                {
                    IdCategoria = reader.GetInt32(0),
                    NombreCategoria = reader.GetString(1),
                    DescripcionCategoria = reader.GetString(2)
                });
            }
            conexion.Close();
            reader.Close();    
            return listar;
        }

        // CARGAR TABLA CATEGORIA
        public DataTable CargarCategoria()
        { 
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ALL_CATEGORIAS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tablaDatos = new DataTable(); 
            sda.Fill(tablaDatos); 
            conexion.Close(); 
            return tablaDatos;
        }

        // CARGAR COMBO BOX
        public DataSet CargarComboboxCategoria()
        {
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ALL_CATEGORIAS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            conexion.Close();
            return ds;
        }
         
        // MOSTRAR CATEGORIA (ARREGLAR)
        public List<CategoriaEntidad> MostrarCategoria(int idCategoria)
        {
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ID_CATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", idCategoria);
            reader = cmd.ExecuteReader();
            List<CategoriaEntidad> listar = new List<CategoriaEntidad>();
            while (reader.Read())
            {
                listar.Add(new CategoriaEntidad {
                    IdCategoria = reader.GetInt32(0),
                    NombreCategoria = reader.GetString(1),
                    DescripcionCategoria = reader.GetString(2)
                });
            }
            conexion.Close();
            reader.Close();
            return listar;
        }
    
        // CREATE CATEGORIA
        public void InsertarCategoria(CategoriaEntidad categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_CATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@nombre", categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("@descripcion", categoria.DescripcionCategoria);
            cmd.ExecuteNonQuery();
            conexion.Close(); 
        }
         
        // UPDATE CATEGORIA
        public void EditarCategoria(CategoriaEntidad categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_UPDATE_ID_CATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@id", categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@nombre", categoria.NombreCategoria);
            cmd.Parameters.AddWithValue("@descripcion", categoria.DescripcionCategoria);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // DELETE CATEGORIA
        public void EliminarCategoria(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_CATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // BUSCAR CATEGORIA
        public CategoriaEntidad BuscarCategoria(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ID_CATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@id", id);
            reader = cmd.ExecuteReader(); 
            CategoriaEntidad categoria = new CategoriaEntidad();
            while (reader.Read())
            { 
                categoria.IdCategoria = reader.GetInt32(0);
                categoria.NombreCategoria = reader.GetString(1);
                categoria.DescripcionCategoria = reader.GetString(2);
            }
            conexion.Close();
            return categoria;
        }

        // VERIFICAR EXISTENCIA CATEGORIA EN TABLA LIBROS
        public int buscarExistenciaCategoria(int idCategoria)
        {
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_LIBRO_CATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@CodigoCategoria", idCategoria);
            reader = cmd.ExecuteReader();
            int cont = 0;
            while (reader.Read())
            {
                cont++;
            }
            reader.Close();
            conexion.Close();
            return cont;
        }

        #endregion 
          
        #region uso de DataBaseHelper

        // CARGAR COMBO BOX 
        public DataSet CargarDDCategoria()
        {
            DataSet ds;
            using (var oDataBaseHelper = new DataBaseHelper())
            {
                bool executionState = false;

                ds = oDataBaseHelper.ExecuteDataSet("SP_CONSULTAR_ALL_CATEGORIAS", ref executionState);
            }
            return ds.Tables.Count > 0 ? ds : null;
        }

        // CREAR CATEGORIA
        public void dbhInsertarCategoria(CategoriaEntidad categoria)
        {
            using (var oDataBaseHelper = new DataBaseHelper())
            {
                bool executionState = false;
                oDataBaseHelper.AddParameter("@nombre", categoria.NombreCategoria);
                oDataBaseHelper.AddParameter("@descripcion", categoria.DescripcionCategoria);
                oDataBaseHelper.ExecuteNonQuery("SP_INSERTAR_CATEGORIA", ref executionState);
            }
        }

        // ELIMINAR CATEGORIA
        public void dbhEliminarCategoria(int id)
        {
            using(var oDataBaseHelper = new DataBaseHelper())
            {
                bool executionState = false;

                oDataBaseHelper.AddParameter("@id", id);
                oDataBaseHelper.ExecuteNonQuery("SP_ELIMINAR_CATEGORIA", ref executionState);
            }
        }

        // CARGAR GRILLA
        public DataSet dbhCargarTabla()
        {
            DataSet ds;

            using (var oDataBaseHelper = new DataBaseHelper())
            {
                bool executionState = false;
                 
                ds = oDataBaseHelper.ExecuteDataSet("SP_CONSULTAR_ALL_CATEGORIAS", ref executionState);
            }
            return ds;
        }

        #endregion
    }
}
