using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class MensajeError : System.Web.UI.UserControl
    { 
        public void MostrarPanel(Exception error)
        {
            if(error != null)
            { 
                LabelBody.Text = "Error: " + error.Message;
            }
            else
            {
                LabelBody.Text = "No se pudo eliminar el registro. Error de restricción de clave primaria";
            }
            lblOculto.Visible = true; 
            ModalPopupMensaje.Show(); 
        } 

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            ModalPopupMensaje.Hide();
        }
         
    }
}