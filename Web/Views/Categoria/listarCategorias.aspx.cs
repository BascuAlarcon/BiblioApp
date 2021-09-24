using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using Web.UserControl;
using BibliotecaBLL;
using BibliotecaEntidades;
using ClassLibrary;

namespace Web
{
    public partial class listarCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    cargarTablaCategorias();
                }
                catch (Exception ex)
                {
                    MensajeError.MostrarPanel(ex);
                }
            } 
        }
         
        protected void cargarTablaCategorias()
        {
            try
            {
                CategoriaBLL categoria = new CategoriaBLL();
                DataSet tablaDatos = categoria.dbhCargarTabla();
                GridViewCategorias.DataSource = tablaDatos;
                GridViewCategorias.DataBind();
            }
            catch (Exception ex)
            {
                MensajeError.MostrarPanel(ex);
            } 
        }  

        protected void GridViewCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(GridViewCategorias.DataKeys[e.RowIndex].Values[0]);
                bool existencia = Validations.BuscarExistenciaCategoria(id);
                if (!existencia)
                {
                    MensajeBorrar.mostrarPanel();
                    CategoriaBLL bll = new CategoriaBLL();
                    bll.dbhEliminarCategoria(id);
                    RecargarGrilla();
                }
                else
                {
                    MensajeError.MostrarPanel(null);
                }
            }
            catch(Exception ex)
            {
                MensajeError.MostrarPanel(ex);
            }
             
        }

        protected void GridViewCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow fila = GridViewCategorias.Rows[e.RowIndex];
                int id = Convert.ToInt32(GridViewCategorias.DataKeys[e.RowIndex].Values[0]);
                string nombre = (fila.FindControl("txtNombre") as TextBox).Text;
                string descripcion = (fila.FindControl("txtDescripcion") as TextBox).Text;
                CategoriaBLL bll = new CategoriaBLL();
                CategoriaEntidad categoria = bll.BuscarCategoria(id);
                categoria.NombreCategoria = nombre;
                categoria.DescripcionCategoria = descripcion;

                bll.EditarCategoria(categoria);
                RecargarGrilla();
            }
            catch (Exception ex)
            {
                MensajeError.MostrarPanel(ex);
            } 
        }

        protected void GridViewCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCategorias.EditIndex = e.NewEditIndex;
            cargarTablaCategorias();
        }

        protected void GridViewCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            RecargarGrilla();
        }

        protected void GridViewCategorias_PreRender(object sender, EventArgs e)
        {
            var grilla = (GridView)sender;
             
            foreach (TableRow row in grilla.Rows)
            { 
                Label textCelda = (Label)row.Cells[0].FindControl("label");
                switch (textCelda.Text)
                {
                    case "1":
                        row.CssClass = "Test1"; 
                        row.Cells[0].Style.Add("padding-left", "20px");
                        row.Cells[0].BackColor = Color.Red; 
                        break;
                    case "2":
                        row.CssClass = "Test"; 
                        row.Cells[0].Style.Add("padding-left", "20px");
                        row.Cells[0].BackColor = Color.Red; 
                        break;
                    case "3":
                        row.CssClass = "Test2"; 
                        row.Cells[0].Style.Add("padding-left", "20px");
                        row.Cells[0].BackColor = Color.Red; 
                        break;
                    default:
                        break;
                }
            } 
        }

        protected void Btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaEntidad categoriaEntidad = new CategoriaEntidad();
                categoriaEntidad.NombreCategoria = TxtInputNombre.Text;
                categoriaEntidad.DescripcionCategoria = TxtInputDescripcion.Text;

                CategoriaBLL categoriaBLL = new CategoriaBLL();
                categoriaBLL.dbhCrearCategoria(categoriaEntidad);
                GridViewCategorias.EditIndex = -1;
                cargarTablaCategorias();
                limpiar();
            }
            catch (Exception ex)
            {
                MensajeError.MostrarPanel(ex);
            }
        }
          
        protected void Btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void limpiar()
        {
            TxtInputNombre.Text = "";
            TxtInputDescripcion.Text = "";
        }

        protected void RecargarGrilla()
        {
            GridViewCategorias.EditIndex = -1;
            cargarTablaCategorias();
        }

        protected void RespuestaPopUpConfirmacion()
        {
            
        }
    }
}