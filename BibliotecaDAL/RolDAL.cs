using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using BibliotecaEntidades;

namespace BibliotecaDAL
{
    public class RolDAL
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString);

        public void CrearRol(RolEntidad rol)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_ROL", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@NOMBRE", rol.Nombre);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarRol(RolEntidad rol)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_ROL", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", rol.Id);
            conexion.Close();
        }

        public DataSet CargarDDRol()
        {
            DataSet ds;
            using (var oDataBaseHelper = new DataBaseHelper())
            {
                bool executionState = false;

                ds = oDataBaseHelper.ExecuteDataSet("SP_CONSULTAR_ALL_ROLES", ref executionState);
            }

            return ds;
        }
    }
}
