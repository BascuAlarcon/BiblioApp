using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.UserControl;

namespace Web
{
    public partial class Master : System.Web.UI.MasterPage
    {

        #region public props

        public string RolUser
        {
            get
            {
                object o = ViewState["RolUser"];
                return (o == null) ? string.Empty : (string)o;
            }
            set
            {
                ViewState["RolUser"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RolUser = clsSession.clsTipoUsuario;
                VisibilidadInterfaz();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            } 
        }

        protected void Navegar(string url)
        {
            try
            {
                Server.Transfer(url); 
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            } 
        }

        protected void BTN_CONECTARSE_Click(object sender, EventArgs e)
        {
            try
            {
                string direccion = "/Views/Usuario/login.aspx";
                Server.Transfer(direccion);
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected void VisibilidadInterfaz()
        {
            if(Session["rolUsuario"] != null)
            {
                if (Session["rolUsuario"].ToString() != "Casual")
                {
                    BTN_CONECTARSE.Visible = false;
                    BTN_DESCONECTARSE.Visible = true;
                    LinkBtnCategorias.Visible = true;
                    LinkBtnAutores.Visible = true;
                    LinkBtnUsuarios.Visible = false;
                    LinkBtnComprados.Visible = true;
                }

                if (Session["rolUsuario"].ToString() == "Administrador")
                {
                    LinkBtnUsuarios.Visible = true;
                }
                LabelRol.Text = "Usuario " + Session["rolUsuario"].ToString();
                LabelRol.Visible = true;
            } 
        }

        protected void BTN_DESCONECTARSE_Click(object sender, EventArgs e)
        {
            Session.Clear(); 
            Navegar("/Views/index.aspx");
        }

        protected void LinkBtnCategorias_Click(object sender, EventArgs e)
        {
            Navegar("/Views/Categoria/listarCategorias.aspx");
        }

        protected void LinkBtnAutores_Click(object sender, EventArgs e)
        {
            Navegar("/Views/Autores/listarAutores.aspx");
        }

        protected void LinkBtnLibros_Click(object sender, EventArgs e)
        {
            Navegar("/Views/Libros/listarLibros.aspx");
        }

        protected void LinkBtnUsuarios_Click(object sender, EventArgs e)
        {
            Navegar("/Views/Usuario/listarUsuarios.aspx");
        } 

        protected void LinkBtnComprados_Click(object sender, EventArgs e)
        {
            Navegar("/Views/Libros/librosUsuario.aspx");
        }
         
    }
}