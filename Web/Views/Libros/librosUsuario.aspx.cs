using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaBLL;
using BibliotecaEntidades;
using System.Data;

namespace Web.Views.Libros
{
    public partial class librosUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTablaLibrosComprados();
        }

        public void CargarTablaLibrosComprados()
        {
            UsuarioLibroBLL bll = new UsuarioLibroBLL();
            int rut = Convert.ToInt32(Session["rutUsuario"].ToString());
            GridViewLibrosUsuario.DataSource = bll.CrearTablaLibrosComprados(rut);
            GridViewLibrosUsuario.DataBind();
        }
    }
}