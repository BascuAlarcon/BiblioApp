using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaEntidades;
using BibliotecaDAL;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaBLL
{
    public class UsuarioBLL
    {
        UsuarioDAL usuarioObjeto = new UsuarioDAL();

        public int LoginUsuario(UsuarioEntidad usuario) {
            return usuarioObjeto.LoginUsuario(usuario);
        }

        public DataTable CargarTablaUsuarios()
        {
            return usuarioObjeto.CargarTablaUsuarios();
        } 

        public void RegistrarUsuario(UsuarioEntidad usuario)
        {
            usuarioObjeto.RegistrarUsuario(usuario);
        }

        public void EditarUsuario(UsuarioEntidad usuario)
        {
            usuarioObjeto.EditarUsuario(usuario);
        }

        public void EliminarUsuario(int id)
        {
            usuarioObjeto.EliminarUsuario(id);
        }

        public int BuscarExistenciaUsuario(int rut)
        {
            return usuarioObjeto.buscarExistenciaUsuario(rut);
        }

        public string BuscarRolUsuario(int rut)
        {
            return usuarioObjeto.BuscarRolUsuario(rut);
        }
    }
}
