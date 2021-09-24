using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BibliotecaEntidades;
using BibliotecaBLL;

namespace Web.Views.Libros
{
    public partial class agregarLibros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
                Cargar_ComboBox_Categoria();
                Cargar_ComboBox_Autores(); 
            /* catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*/
             
        }

        protected void Cargar_ComboBox_Categoria()
        { 
                CategoriaBLL bll = new CategoriaBLL();
                ComboBoxCategoria.DataTextField = bll.CargarDD().Tables[0].Columns["Nombre"].ToString();
                ComboBoxCategoria.DataValueField = bll.CargarDD().Tables[0].Columns["id"].ToString();
                ComboBoxCategoria.DataSource = bll.CargarDD().Tables[0];
                ComboBoxCategoria.DataBind();
            
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
                Console.Write(ex);
            } 
        }

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
                TxtInputCategoria.Text = ComboBoxCategoria.SelectedValue;
                
                // bbl.InsertarLibros(libro);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
             
        }
         
    }
}