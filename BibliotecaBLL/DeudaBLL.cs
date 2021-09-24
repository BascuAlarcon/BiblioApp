using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BibliotecaDAL;
using BibliotecaEntidades;

namespace BibliotecaBLL
{
    public class DeudaBLL
    {
        DeudaDAL objDeuda = new DeudaDAL();

        public DataTable CargarTablaDeuda()
        {
            return objDeuda.CargarTablaDeudas();
        }

        public void CrearDeuda(DeudaEntidad deuda)
        {
            objDeuda.CrearDeuda(deuda);
        }

        public void EditarDeuda(DeudaEntidad deuda)
        {
            objDeuda.EditarDeuda(deuda);
        }
    }
}
