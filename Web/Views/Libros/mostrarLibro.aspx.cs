using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaBLL;
using BibliotecaEntidades;
using Web.UserControl;

namespace Web.Views.Libros
{
    public partial class mostrarLibro : System.Web.UI.Page 
    {
        #region Propiedades

        public string TipoUsuario
        {
            get
            {
                object o = ViewState["TipoUsuario"];
                return (o == null) ? string.Empty : (string)o;
            }
            set
            {
                ViewState["TipoUsuario"] = value;
            }
        }

        public string Evento
        {
            get
            {
                object o = ViewState["Evento"];
                return (o == null) ? string.Empty : (string)o;
            }
            set
            {
                ViewState["Evento"] = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    TipoUsuario = clsSession.clsTipoUsuario;
                    CargarDatos();
                }
                MensajeConfirmacion1.EventoChangedValueOption += DarTratamientoACambioValorRespuesta;
            }
            catch(Exception ex)
            {
                Console.Write(ex);
               // MensajeError.MostrarPanel(ex);
            } 
        }

        #region Cargar Datos

        protected void CargarDatos()
        {
            LibroBLL bll = new LibroBLL();
            string var = Session["idLibro"].ToString();
            LibroEntidad libro = bll.MostrarLibro(Convert.ToInt32(var));
            Label2.Text = libro.NombreLibro.ToString();
            Label3.Text = "Precio:  $" + libro.Precio.ToString();
            Label4.Text = "Autor: " + libro.NombreAutor.ToString();
            Label5.Text = "Categoria: " + libro.NombreCategoria.ToString();
        }

        #endregion

        #region Botones

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Evento = "Borrar";
                MensajeConfirmacion1.MostrarPanel("Borrar libro", "¿Desea eliminar el libro seleccionado?", "Eliminar"); 
            }
            catch (Exception ex)
            {
                Console.Write(ex);
               // MensajeError.MostrarPanel(ex);
            }
             
        }

        protected void BtnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                Evento = "Comprar";
                MensajeConfirmacion1.MostrarPanel("Confirmar Compra", "¿Desea comprar el libro seleccionado?", "Comprar");
                // Server.Transfer("listarLibros.aspx");
            }
            catch (Exception ex)
            {
                Console.Write(ex);
               // MensajeError.MostrarPanel(ex);
            }
        }

        #endregion

        #region Tratamientos y Respuestas

        protected void DarTratamientoACambioValorRespuesta(object sender)
        {
            try
            {
                var respuesta = (string)sender;
                if(Evento.Equals("Comprar") && respuesta.Equals("Ok"))
                {
                    UsuarioLibroEntidad UL = new UsuarioLibroEntidad();
                    int rut = Convert.ToInt32(Session["rutUsuario"].ToString()); 
                    int idLibro = Convert.ToInt32(Session["idLibro"].ToString());
                  
                    UsuarioLibroBLL bll = new UsuarioLibroBLL();
                    bll.CrearUsuarioLibro(rut, idLibro);
                    MensajeConfirmacion1.OcultarPanel();
                    Response.Redirect("listarLibros.aspx", false); 
                } 
                if(Evento.Equals("Borrar") && respuesta.Equals("Ok"))
                { 
                    LibroBLL bll = new LibroBLL();  
                    bll.EliminarLibros(Convert.ToInt32(Session["idLibro"].ToString()));
                    Server.Transfer("listarLibros.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
             //   MensajeError.MostrarPanel(ex);
            }
        }


        #endregion

        protected void PanelButtons_Load(object sender, EventArgs e)
        {
            try
            {
                if (TipoUsuario != "Casual" && TipoUsuario != "")
                {
                    PanelButtons.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
           //     MensajeError.MostrarPanel(ex);
            } 
        }
         
    }
}