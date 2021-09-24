using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaBLL;
using BibliotecaEntidades;
using ClassLibrary;
using System.Data;


namespace Web.Views.autores
{
    public partial class listarAutores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                try
                {
                    CargarGrillaAutores();
                }
                catch(Exception ex)
                {
                    Console.Write(ex);
                }
                 
            } 
        }

        protected void CargarGrillaAutores()
        {
            try
            {
                AutorBLL autor = new AutorBLL();
                DataTable tabla = autor.CargarTablaAutor();
                GridViewAutores.DataSource = tabla;
                GridViewAutores.DataBind();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            } 
        }

        protected void GridViewAutores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                RecargarGrilla();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        } 

        protected void GridViewAutores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridViewAutores.EditIndex = e.NewEditIndex;
                CargarGrillaAutores();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected void GridViewAutores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow fila = GridViewAutores.Rows[e.RowIndex];
                int id = Convert.ToInt32(GridViewAutores.DataKeys[e.RowIndex].Values[0]);
                string nombre = (fila.FindControl("txtNombre") as TextBox).Text;
                AutorBLL bll = new AutorBLL();
                AutorEntidad autor = bll.BuscarAutor(id);
                autor.Nombre = nombre;
                bll.EditarAutor(autor);
                RecargarGrilla();
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }    
        }

        protected void GridViewAutores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(GridViewAutores.DataKeys[e.RowIndex].Values[0]);
                bool existencia = Validations.BuscarExistenciaAutor(id);
                if (!existencia)
                { 
                    AutorBLL bll = new AutorBLL();
                    bll.EliminarAutor(id);
                    RecargarGrilla();
                }
                //else
                //{
                //    ModalPopupMensaje.Show();
                //} 
            }
            catch (Exception ex)
            {
                ErrorMessage.MostrarPanel(ex);
            }
        }

        protected void RecargarGrilla()
        {
            GridViewAutores.EditIndex = -1;
            CargarGrillaAutores();
        }

        protected void Btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void limpiar()
        {
            TxtInputNombre.Text = ""; 
        }

        protected void Btn_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                AutorEntidad autor = new AutorEntidad();
                autor.Nombre = TxtInputNombre.Text;
                AutorBLL bbl = new AutorBLL();
                bbl.CrearAutor(autor);
                RecargarGrilla();
                limpiar();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}