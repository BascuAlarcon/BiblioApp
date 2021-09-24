using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using BibliotecaEntidades;
using BibliotecaBLL;
using System.Data;

namespace Web.Views.Usuario
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                }catch(Exception ex)
                {
                    Console.Write(ex);
                }
            }
        } 

        protected void ClearFields()
        {
            inputRut.Text = "";
            inputPassword.Text = "";
        }

        protected void BTN_INICIAR_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioEntidad usuario = new UsuarioEntidad();
                usuario.Rut = Convert.ToInt32(inputRut.Text);
                usuario.Password = inputPassword.Text;
                UsuarioBLL bbl = new UsuarioBLL();
                int id = bbl.LoginUsuario(usuario);
                if (id != 0)
                {
                    Session["rolUsuario"] = bbl.BuscarRolUsuario(Convert.ToInt32(inputRut.Text)); 
                    Session["rutUsuario"] = inputRut.Text;
                    clsSession.clsTipoUsuario = bbl.BuscarRolUsuario(Convert.ToInt32(inputRut.Text));
                    string direccion = "../index.aspx";
                    Server.Transfer(direccion);
                }
                else
                {
                    // ToDo
                    // Hacerle saber al usuario que se equivoco en sus credenciales
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}