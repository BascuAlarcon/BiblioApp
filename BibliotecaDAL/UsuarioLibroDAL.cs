using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using BibliotecaEntidades;

namespace BibliotecaDAL
{
    public class UsuarioLibroDAL
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString);

        public void CrearUsuarioLibro(int rut, int idLibro)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_USUARIO_LIBRO_POR_RUT", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@idLibro", idLibro);
            cmd.Parameters.AddWithValue("@rut", rut); 
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public DataSet CargarTablaLibrosComprados(int rut)
        {
            DataSet ds;
            using (var oDataBaseHelper = new DataBaseHelper())
            {
                bool executionState = false;
                oDataBaseHelper.AddParameter("@rut", rut);
                ds = oDataBaseHelper.ExecuteDataSet("SP_LIBROS_COMPRADOS", ref executionState);
            }
            return ds;
        }

    }
}
