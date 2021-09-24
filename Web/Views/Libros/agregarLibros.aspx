<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master.Master" CodeBehind="agregarLibros.aspx.cs" Inherits="Web.Views.Libros.agregarLibros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
        <div class="border p-2 bg-dark text-light"> 
            <div class="form-group">
                <label for="FormNombre">Nombre Libro</label> 
                <asp:TextBox runat="server" ID="TxtInputNombre" ></asp:TextBox>
            </div> 
            <div class="form-group">
                <label for="FormNombre">Precio</label> 
                <asp:TextBox runat="server" ID="TxtInputPrecio" ></asp:TextBox>
            </div>  

            <asp:DropDownList runat="server"  ID="ComboBoxCategoria" BackColor="Yellow"></asp:DropDownList>
            <asp:DropDownList runat="server" ID="ComboBoxAutores"></asp:DropDownList>

            <asp:TextBox runat="server" ID="TxtInputCategoria"></asp:TextBox>
            <asp:Button runat="server" ID="Btn_agregar" CssClass="btn btn-primary m-2" text="Agregar" OnClick="Btn_agregar_Click"/>
  
        </div>   
</asp:Content> 