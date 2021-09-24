using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class MensajeBorrar : System.Web.UI.UserControl
    { 

        public void mostrarPanel()
        {
            ModalPopupMensaje.Show();
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            ModalPopupMensaje.Hide();
        }

        protected void BtnAcceptar_Click(object sender, EventArgs e)
        {
            ModalPopupMensaje.Hide();
        }
    }
}