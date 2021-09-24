using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaEntidades
{
    public class DeudaEntidad
    {
        private int id;
        private int monto;
        private DateTime fecha;
        private int idUsuario; 

        public int Id { get => id; set => id = value; }
        public int Monto { get => monto; set => monto = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
