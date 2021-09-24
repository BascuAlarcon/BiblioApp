using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaBLL;
using BibliotecaEntidades;
using ClassLibrary;
using System.Text.RegularExpressions;
using System.Net.Mail; 

namespace Web.Views.Usuario
{
    public partial class register : System.Web.UI.Page
    {
        UsuarioBLL bll = new UsuarioBLL();  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                }
                catch(Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        protected void btn_crear_Click(object sender, EventArgs e)
        {
            try
            {
                bool esValido = true;
                esValido = Validations.validarUsuario(txtRut.Text, TxtCorreo.Text ,ref esValido);
                if (esValido)
                {
                    UsuarioEntidad usuario = new UsuarioEntidad();
                    usuario.Nombre = TxtNombre.Text;
                    usuario.Password = txtPassword.Text;
                    // convertir el string 19665635-9 a int, causa un error por el -   
                    usuario.Rut = Convert.ToInt32(txtRut.Text.Replace("-", ""));
                    usuario.Email = TxtCorreo.Text;
                    usuario.RolID = 2;
                    bll.RegistrarUsuario(usuario);
                    string direccion = "login.aspx";
                    Server.Transfer(direccion);
                }

                //UsuarioEntidad usuario = new UsuarioEntidad();
                //if (Validations.IsValid(TxtCorreo.Text)) 
                //{
                //    if (Validations.ValidaRut(txtRut.Text))
                //    {
                //        usuario.Nombre = TxtNombre.Text;
                //        usuario.Password = txtPassword.Text;
                //        // convertir el string 19665635-9 a int, causa un error por el -  
                //        usuario.Rut = Convert.ToInt32(txtRut.Text);
                //        usuario.Email = TxtCorreo.Text;
                //        usuario.RolID = 2;
                //        bll.RegistrarUsuario(usuario);
                //        string direccion = "login.aspx";
                //        Server.Transfer(direccion);
                //    } 
                //} 
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            } 
        }

         
    }
}