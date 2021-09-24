using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.UserControl
{
    public partial class MensajeConfirmacion : System.Web.UI.UserControl
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

        public void MostrarPanel()
        {
            ModalPopupMensaje.Show();
        }

        protected void BtnComprar_Click(object sender, EventArgs e)
        {
            ModalPopupMensaje.Hide();
            CambioValorRespuesta("Ok");
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            ModalPopupMensaje.Hide();
        }
    }
}