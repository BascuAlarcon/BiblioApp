using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BibliotecaBLL;
using BibliotecaEntidades;
using System.Drawing;

namespace Web.Views.Usuario
{
    public partial class listarUsuarios : System.Web.UI.Page
    { 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    CargarTablaUsuarios();
                    CargarDDRoles();
                }
                catch (Exception ex)
                {
                    MensajeError.MostrarPanel(ex);
                }
            }
        }

        public void CargarTablaUsuarios()
        {
            try
            {
                UsuarioBLL bbl = new UsuarioBLL();
                DataTable tabla = bbl.CargarTablaUsuarios();
                GridViewUsuarios.DataSource = tabla;
                GridViewUsuarios.DataBind();

            }
            catch(Exception ex)
            { 
                Console.Write(ex);
            } 
        }
        
        public void CargarDDRoles()
        {
            try
            {
                RolBLL bll = new RolBLL();
                DataSet datos = bll.CargarDDRoles();
                // COMBOBOX_ROLES.DataTextField = bll.CargarDDRoles().Tables[0].Columns["Nombre"].ToString();
                // COMBOBOX_ROLES.DataValueField = bll.CargarDDRoles().Tables[0].Columns["id"].ToString();
                // COMBOBOX_ROLES.DataSource = bll.CargarDDRoles().Tables[0];
                // COMBOBOX_ROLES.DataBind();
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }
        }

        protected void GridViewUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        { 
            int id = Convert.ToInt32(GridViewUsuarios.DataKeys[e.RowIndex].Values[0]);
            Application["rutGlobal"] = id.ToString();
            ModalPopupMensaje.Show(); 
        }

        protected void GridViewUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewUsuarios.EditIndex = e.NewEditIndex;
            CargarTablaUsuarios();
        }

        protected void GridViewUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = GridViewUsuarios.Rows[e.RowIndex];
            int id = Convert.ToInt32(GridViewUsuarios.DataKeys[e.RowIndex].Values[0]); 
            string email = (fila.FindControl("txtEMAIL") as TextBox).Text;
            string nombre = (fila.FindControl("txtNOMBRE") as TextBox).Text; 
            int rol = Convert.ToInt32((fila.FindControl("COMBOBOX_ROLES") as DropDownList).SelectedValue);
            UsuarioBLL bll = new UsuarioBLL();
            UsuarioEntidad oUsuario = new UsuarioEntidad();
            oUsuario.Id = id;
            oUsuario.RolID = rol;

            bll.EditarUsuario(oUsuario);
            GridViewUsuarios.EditIndex = -1;
            CargarTablaUsuarios();
        }
          
        protected void GridViewUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewUsuarios.EditIndex = -1;
            CargarTablaUsuarios();
        }

        protected void BTN_BORRAR_Click(object sender, EventArgs e)
        {
            string id = ((string)Application["rutGlobal"]);
            UsuarioBLL bll = new UsuarioBLL();
            bll.EliminarUsuario(Int32.Parse(id));
            GridViewUsuarios.EditIndex = -1;
            CargarTablaUsuarios();
        }

        protected void GridViewUsuarios_PreRender(object sender, EventArgs e)
        {
            var grilla = (GridView)sender; 
            foreach (TableRow row in grilla.Rows)
            {
                Label textCelda = (Label)row.Cells[0].FindControl("labelROL");
                if (textCelda != null)
                {
                    switch (textCelda.Text)
                    {
                        case "Administrador":
                            row.BackColor = Color.MediumVioletRed;
                            break;
                        default:
                            break;
                    }
                } 
            }
        }

        protected void GridViewUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == GridViewUsuarios.EditIndex)
            {
                DropDownList lista = e.Row.FindControl("COMBOBOX_ROLES") as DropDownList;
                RolBLL bll = new RolBLL();
                DataSet datos = bll.CargarDDRoles();
                lista.DataTextField = bll.CargarDDRoles().Tables[0].Columns["Nombre"].ToString();
                lista.DataValueField = bll.CargarDDRoles().Tables[0].Columns["id"].ToString();
                lista.DataSource = bll.CargarDDRoles().Tables[0];
                lista.DataBind();
            }
        }

         
    }
}