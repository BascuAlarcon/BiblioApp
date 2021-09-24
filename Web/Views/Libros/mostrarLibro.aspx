<%@ Page Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="mostrarLibro.aspx.cs" Inherits="Web.Views.Libros.mostrarLibro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
  
<%@ Register Src="~/UserControl/MensajeBorrar.ascx" TagName="MensajeBorrar" TagPrefix="uc3" %>
<%@ Register Src="~/UserControl/MensajeConfirmacion1.ascx" TagName="MensajeConfirmacion1" TagPrefix="uc4" %>
<%@ Register Src="~/UserControl/MensajeError.ascx" TagName="MensajeError" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

    <div class="container-libro p-2">
        <div class="row p-2"> 
            <div class="col-lg-8 m-3 mx-auto">  
                <asp:Label runat="server" ID="Label2" CssClass="tituloLibro"/>     
            </div> 
        </div> 
        <div class="row">
            <div class="col-5"> 
                <img src="../../Images/nilo.jpg" style="height: 300px"/>  
            </div>
            <div class="col-lg-7">
                <asp:Label runat="server" ID="Label3" CssClass="labelLibro" ToolTip="Precio"/>   
                <asp:Label runat="server" ID="Label4" CssClass="labelLibro" ToolTip="Categoria"/>    
                <asp:Label runat="server" ID="Label5" CssClass="labelLibro" ToolTip="Autor"/>   
            </div>
        </div>
    </div> 
    
    <asp:Panel runat="server" ID="PanelButtons" OnLoad="PanelButtons_Load" Visible="false">
        <div class="row justify-content-end">
            <div class="col-lg-5"> 
                <asp:Button runat="server" ID="BtnEliminar" Text="Eliminar" CssClass="btn btn-danger m-1" OnClick="BtnEliminar_Click"/>
                <asp:Button runat="server" ID="BtnComprar" Text="Comprar" CssClass="btn btn-success m-1" OnClick="BtnComprar_Click"/> 
             </div>
        </div>  
    </asp:Panel>
     

    <asp:Panel runat="server" ID="PanelPopUp" CssClass="PanelPopUp bg-white">   
            <div class="modal-footer">
                <button type="button" id="exit" class="btn btn-secondary" aria-hidden="true" data-dismiss="modal">Acceptar</button> 
            </div>
    </asp:Panel>    
    <cc1:ModalPopupExtender runat="server" ID="ModalPopupMensaje" TargetControlID="BUTTON_TEST" PopupControlID="PanelPopUp" 
            BackgroundCssClass="modalBackground" Y="250" CancelControlID="exit"/>   

    <asp:Button runat="server" ID="BUTTON_TEST" CssClass="btn-test" style="display: none" Text="PopUp" Height="32px" Width="107px"/> 
     
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate> 
            <uc4:MensajeConfirmacion1 runat="server" ID="MensajeConfirmacion1" />
        </ContentTemplate> 
    </asp:UpdatePanel>     
  
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
