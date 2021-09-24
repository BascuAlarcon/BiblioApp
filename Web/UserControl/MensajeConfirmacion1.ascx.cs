using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class MensajeConfirmacion1 : System.Web.UI.UserControl
    {
        public delegate void DelegadoCambioValorRespuesta(object sender);
        public event DelegadoCambioValorRespuesta EventoChangedValueOption;

        public void CambioValorRespuesta(string opcion)
        {
            if (EventoChangedValueOption != null)
            {
                EventoChangedValueOption(opcion);
            }
        }

        public void MostrarPanel(string textoHeader, string textoBody, string textoBtn)
        {
            LabelHeader.Text = textoHeader;
            LabelBody.Text = textoBody;
            BtnAccepar.Text = textoBtn;
            lblOculto.Visible = true;
            ModalPopupMensaje.Show();
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            ModalPopupMensaje.Hide();
        }

        protected void BtnAccepar_Click(object sender, EventArgs e)
        {
            CambioValorRespuesta("Ok");
        }

        public void OcultarPanel()
        {
            ModalPopupMensaje.Hide();
        }
    }
}