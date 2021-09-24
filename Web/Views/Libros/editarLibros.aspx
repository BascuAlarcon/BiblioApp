<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master.Master" CodeBehind="editarLibros.aspx.cs" Inherits="Web.Views.Libros.editarLibros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
        <div>
            <table class="m-2">
                <tr>
                    <td>
                        <asp:GridView ID="GridViewCategorias" runat="server"  EmptyDataText="Lista de Categorias" AutoGenerateColumns="False">
                            <EmptyDataRowStyle CssClass="encabTablaDatos" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" /> 
                                <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" /> 
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <a class="btn btn-primary" href="agregarCategorias.aspx">Agregar</a> 
        </div>   
</asp:Content> 