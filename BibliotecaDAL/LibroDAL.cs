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
    public class LibroDAL
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString); 

        // LISTAR LIBROS
        public DataTable CargarTablaLibros()
        {
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ALL_LIBROS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tablaDatos = new DataTable();
            sda.Fill(tablaDatos);
            conexion.Close();
            return tablaDatos;
        }

        // SEARCH LIBROS
        public DataSet SearchLibros(string nombre)
        {
            DataSet ds;
            using (var oDataBaseHelper = new DataBaseHelper())
            {
                bool executionState = false;

                oDataBaseHelper.AddParameter("@nombre", nombre);
                ds = oDataBaseHelper.ExecuteDataSet("SP_SEARCH_LIBROS", ref executionState);
            }
            return ds.Tables.Count > 0 ? ds : null;
        }
           
        // CREAR LIBRO
        public void CrearLibro(LibroEntidad libro)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_LIBRO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@NOMBRE", libro.NombreLibro );
            cmd.Parameters.AddWithValue("@PRECIO", libro.Precio);
            cmd.Parameters.AddWithValue("@categoriaID", libro.CategoriaID);
            cmd.Parameters.AddWithValue("@autorID", libro.AutorID);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // EDITAR LIBRO
        public void EditarLibro(LibroEntidad libro)
        {
            SqlCommand cmd = new SqlCommand("SP_UPDATE_LIBRO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@NOMBRE", libro.NombreLibro);
            cmd.Parameters.AddWithValue("@PRECIO", libro.Precio);
            cmd.Parameters.AddWithValue("@categoriaID", libro.CategoriaID);
            cmd.Parameters.AddWithValue("@autorID", libro.AutorID);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // ELIMINAR LIBRO
        public void EliminarLibro(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_LIBROS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // MOSTRAR LIBRO
        public LibroEntidad MostrarLibro(int id)
        {
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ID_LIBRO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@id", id);
            reader = cmd.ExecuteReader();
            LibroEntidad libro = new LibroEntidad();

            while (reader.Read())
            {
                libro.IdLibro = reader.GetInt32(0);
                libro.NombreLibro = reader.GetString(1);
                libro.Precio = reader.GetInt32(2);
                libro.NombreAutor = reader.GetString(3);
                libro.NombreCategoria = reader.GetString(4);
            }
            conexion.Close();
            reader.Close();
            return libro;
        }
    }
}
