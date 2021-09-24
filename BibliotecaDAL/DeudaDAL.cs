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
    public class DeudaDAL
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionSQL"].ConnectionString);

        // CARGAR TABLA DEUDA
        public DataTable CargarTablaDeudas()
        {
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_ALL_DEUDAS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable listaDatos = new DataTable();
            sda.Fill(listaDatos);
            conexion.Close();
            return listaDatos;
        }

        // CREAR DEUDA
        public void CrearDeuda(DeudaEntidad deuda)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_DEUDA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open(); 
            cmd.Parameters.AddWithValue("@MONTO", deuda.Monto);
            cmd.Parameters.AddWithValue("@FECHA", deuda.Fecha);
            cmd.Parameters.AddWithValue("@USUARIO_ID", deuda.IdUsuario); 
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // EDITAR DEUDA
        public void EditarDeuda(DeudaEntidad deuda)
        {
            SqlCommand cmd = new SqlCommand("SP_UPDATE_DEUDA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@MONTO", deuda.Monto); 
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        // TODO
        // EDITAR DEUDA, SÓLO EL CAMPO ESTADO

    }
}
