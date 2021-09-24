<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MensajeBorrar.ascx.cs" Inherits="Web.UserControl.MensajeBorrar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 

<asp:Panel runat="server" ID="PanelPopUp" CssClass="PanelPopUp bg-light" Width="500px">  
    <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle" style="display: block; margin: auto;">¿Desea borrar el registro?</h5> 
    </div>

    <div class="modal-body">
        <p>No se podrá recuperar el elemento seleccionado.</p>
    </div>

    <div class="modal-footer"> 
        <asp:Button runat="server" ID="BtnCerrar" CssClass="btn btn-warning" OnClick="BtnCerrar_Click" Text="Cancelar"/>
        <asp:Button runat="server" ID="BtnAcceptar" CssClass="btn btn-danger" OnClick="BtnAcceptar_Click" Text="Borrar"/>
    </div>
</asp:Panel>  

<cc1:ModalPopupExtender runat="server" ID="ModalPopupMensaje" TargetControlID="BUTTON_TEST" PopupControlID="PanelPopUp" 
    BackgroundCssClass="modalBackground" Y="250" CancelControlID="exit"/> 

<asp:Button runat="server" ID="BUTTON_TEST" CssClass="btn-test" style="display: none" Text="PopUp" Height="32px" Width="107px"/>

