using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaEntidades
{
    public class UsuarioLibroEntidad
    {
        private int idUsuario;
        private int idLibro;
        private DateTime fechaInicio;
        private DateTime fechaFin;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public int IdLibro { get => idLibro; set => idLibro = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
    }
}
