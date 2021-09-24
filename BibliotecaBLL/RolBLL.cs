using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaEntidades;
using BibliotecaDAL;
using System.Data;

namespace BibliotecaBLL
{
    public class RolBLL
    {
        RolDAL objetoRol = new RolDAL();

        public void CrearRol(RolEntidad rol)
        {
            objetoRol.CrearRol(rol);
        }

        public void Eliminar(RolEntidad rol)
        {
            objetoRol.EliminarRol(rol);
        }

        public DataSet CargarDDRoles()
        {
            return objetoRol.CargarDDRol();
        }
    }
}
