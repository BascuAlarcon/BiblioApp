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
    public partial class listarLibros : System.Web.UI.Page
    {

        #region Variables Publicas

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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    TipoUsuario = clsSession.clsTipoUsuario; 
                    CargarGrillaLibros();
                    Cargar_ComboBox_Autores();
                    Cargar_ComboBox_Categoria(); 
                }
                catch(Exception ex)
                {
                    MensajeError.MostrarPanel(ex);
                }
            }
        }

        #region Manejo de Interfaz

        protected void PanelFormularioAgregar_Load(object sender, EventArgs e)
        {
            try
            {
                if (TipoUsuario != "Casual" && TipoUsuario != "")
                {
                    PanelFormularioAgregar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MensajeError.MostrarPanel(ex);
            } 
        }

        #endregion

        #region Cargar Datos

        public void CargarGrillaLibros()
        {
            try
            {
                LibroBLL libro = new LibroBLL();
                DataTable tabla = libro.CargarLibros();
                GridViewLibros.DataSource = tabla;
                GridViewLibros.DataBind();
            }
            catch (Exception ex)
            {
                MensajeError.MostrarPanel(ex);
            }
        }

        protected void Cargar_ComboBox_Categoria()
        {
            try
            {
                CategoriaBLL bll = new CategoriaBLL();
                ComboBoxCategoria.DataTextField = bll.CargarDD().Tables[0].Columns["Nombre"].ToString();
                ComboBoxCategoria.DataValueField = bll.CargarDD().Tables[0].Columns["id"].ToString();
                ComboBoxCategoria.DataSource = bll.CargarDD().Tables[0];
                ComboBoxCategoria.DataBind();
                 
            }
            catch (Exception ex)
            {
                MensajeError.MostrarPanel(ex);
            }   
        }

        protected void Cargar_ComboBox_Autores()
        {
            try
            {
                AutorBLL bll = new AutorBLL();
                ComboBoxAutores.DataTextField = bll.CargarComboBoxAutores().Tables[0].Columns["Nombre"].ToString();
                ComboBoxAutores.DataValueField = bll.CargarComboBoxAutores().Tables[0].Columns["Id"].ToString();
                ComboBoxAutores.DataSource = bll.CargarComboBoxAutores().Tables[0];
                ComboBoxAutores.DataBind();
                 
            }
            catch (Exception ex)
            {
                MensajeError.MostrarPanel(ex);
            }
        }

        #endregion

        #region Botones

        protected void Btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                LibroEntidad libro = new LibroEntidad();
                libro.NombreLibro = TxtInputNombre.Text;
                libro.Precio = Int32.Parse(TxtInputPrecio.Text);
                libro.CategoriaID = Int32.Parse(ComboBoxCategoria.SelectedValue);
                libro.AutorID = Int32.Parse(ComboBoxAutores.SelectedValue);
                LibroBLL bbl = new LibroBLL();

                bbl.InsertarLibros(libro);
                limpiar();
                RecargarGrilla();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

        }

        protected void Btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        #endregion

        #region Eventos
           
        protected void GridViewLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string id = GridViewLibros.SelectedRow.Cells[0].Text;
                Session["idLibro"] = id;
                Server.Transfer("mostrarLibro.aspx");
            }
            catch (Exception ex)
            {
                MensajeError.MostrarPanel(ex);
            } 
        }

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LibroBLL bll = new LibroBLL();
                DataSet ds = bll.SearchLibros(TxtSearch.Text);
                GridViewLibros.DataSource = ds;
                GridViewLibros.DataBind();
            }
            catch (Exception ex)
            {
                MensajeError.MostrarPanel(ex);
            } 
        }

        protected void RecargarGrilla()
        {
            GridViewLibros.EditIndex = -1;
            CargarGrillaLibros();
        }

        protected void limpiar()
        {
            TxtInputNombre.Text = "";
            TxtInputPrecio.Text = "";
        } 
         
        #endregion
         
    }
}
