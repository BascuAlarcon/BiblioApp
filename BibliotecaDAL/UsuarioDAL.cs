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
    public class UsuarioDAL
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString);
        SqlDataReader reader;

        // CARGAR TABLA USUARIOS
        public DataTable CargarTablaUsuarios()
        {
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ALL_USUARIOS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tablaUsuarios = new DataTable();
            sda.Fill(tablaUsuarios);
            conexion.Close();
            return tablaUsuarios;
        }

        // LOGIN USUARIO 
        public int LoginUsuario(UsuarioEntidad usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_LOGIN_USUARIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@RUT", usuario.Rut);
            cmd.Parameters.AddWithValue("@PASSWORD", usuario.Password); 
            reader = cmd.ExecuteReader();
            int idUsuario = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    idUsuario = reader.GetInt32(0);
                }
            }
            conexion.Close(); 
            return idUsuario; 
        }

        // REGISTRAR USUARIO
        public void RegistrarUsuario(UsuarioEntidad usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_USUARIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@NOMBRE", usuario.Nombre);
            cmd.Parameters.AddWithValue("@RUT", usuario.Rut);
            cmd.Parameters.AddWithValue("@PASSWORD", usuario.Password);
            cmd.Parameters.AddWithValue("@EMAIL", usuario.Email);
            cmd.Parameters.AddWithValue("@ROL", usuario.RolID);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // EDITAR USUARIO
        public void EditarUsuario(UsuarioEntidad usuario)
        {
            SqlCommand cmd = new SqlCommand("SP_UPDATE_ROL_USUARIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", usuario.Id);
            cmd.Parameters.AddWithValue("@ROLID", usuario.RolID);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // ELIMINAR USUARIO
        public void EliminarUsuario(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_USUARIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // COMPROBAR SI EXISTE EL USUARIO
        public int buscarExistenciaUsuario(int rut)
        {
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_RUT_USUARIOS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@rut", rut);
            reader = cmd.ExecuteReader();
            UsuarioEntidad usuario = new UsuarioEntidad();
            int cont = 0;
            while (reader.Read())
            {
                cont++;
            }
            conexion.Close();
            return cont;
        }

        // BUSCAR EL ROL DEL USUARIO 
        public string BuscarRolUsuario(int rut)
        { 
            string rol;
            using (var oDataBaseHelper = new DataBaseHelper())
            {
                DataSet ds;
                bool executionState = false;
                oDataBaseHelper.AddParameter("@rut", rut);
                
                ds = oDataBaseHelper.ExecuteDataSet("SP_CONSULTAR_ROL_USUARIO", ref executionState);
                rol = ds.Tables[0].Rows[0]["rol"].ToString();
            }
            return rol;
        }
    }
}
