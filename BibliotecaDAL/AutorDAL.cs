using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BibliotecaEntidades;


namespace BibliotecaDAL
{
    public class AutorDAL
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString);
        SqlDataReader reader;

        #region sin DataBaseHelper

        // LISTAR AUTORES
        public DataTable CargarTablaAutores()
        {
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ALL_AUTORES", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tabladatos = new DataTable();
            sda.Fill(tabladatos);
            conexion.Close();
            return tabladatos;
        } 

        // CARGAR COMBOBOX 
        public DataSet CargarComboBoxAutores()
        {
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ALL_AUTORES", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            conexion.Close();
            return ds;
        }

        // CREAR AUTOR
        public void CrearAutor(AutorEntidad autor)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_AUTOR", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@NOMBRE", autor.Nombre);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // EDITAR AUTOR
        public void EditarAutor(AutorEntidad autor)
        {
            SqlCommand cmd = new SqlCommand("SP_UPDATE_AUTOR", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@id", autor.IdAutor);
            cmd.Parameters.AddWithValue("@nombre", autor.Nombre);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // ELIMINAR AUTOR 
        public void EliminarAutor(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_AUTOR", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // BUSCAR AUTOR
        public AutorEntidad BuscarAutor(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ID_AUTOR", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@id", id);
            reader = cmd.ExecuteReader();
            AutorEntidad autor = new AutorEntidad(); 
            while (reader.Read())
            {
                autor.IdAutor = reader.GetInt32(0);
                autor.Nombre = reader.GetString(1); 
            }
            conexion.Close();
            return autor;
        }

        // VERIFICAR EXISTENCIA CATEGORIA EN TABLA LIBROS
        public int buscarExistenciaAutor(int idAutor)
        {
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_LIBRO_AUTOR", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@CodigoAutor", idAutor);
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

        public DataSet CargarDDAutores()
        {
            DataSet ds;
            using (var oDataBaseHelper = new DataBaseHelper())
            {
                bool executionState = false;

                ds = oDataBaseHelper.ExecuteDataSet("SP_CONSULTAR_ALL_AUTORES", ref executionState);
            }
            return ds.Tables.Count > 0 ? ds : null;
        }

        // CREAR CATEGORIA
        public void dbhInsertarAutores(AutorEntidad autor)
        {
            using (var oDataBaseHelper = new DataBaseHelper())
            {
                bool executionState = false;
                oDataBaseHelper.AddParameter("@nombre", autor.Nombre); 
                oDataBaseHelper.ExecuteNonQuery("SP_INSERTAR_AUTOR", ref executionState);
            }
        }

        // ELIMINAR CATEGORIA
        public void dbhEliminarAutor(int id)
        {
            using (var oDataBaseHelper = new DataBaseHelper())
            {
                bool executionState = false;

                oDataBaseHelper.AddParameter("@id", id);
                oDataBaseHelper.ExecuteNonQuery("SP_ELIMINAR_AUTOR", ref executionState);
            }
        }

        // CARGAR GRILLA
        public DataSet dbhCargarTabla()
        {
            DataSet ds;

            using (var oDataBaseHelper = new DataBaseHelper())
            {
                bool executionState = false;

                ds = oDataBaseHelper.ExecuteDataSet("SP_CONSULTAR_ALL_AUTORES", ref executionState);
            }
            return ds;
        }

        #endregion

    }
}
