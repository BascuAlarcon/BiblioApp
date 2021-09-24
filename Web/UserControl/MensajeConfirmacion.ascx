<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MensajeConfirmacion.ascx.cs" Inherits="Web.UserControl.MensajeConfirmacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
 
<asp:Panel runat="server" ID="PanelPopUpConfirmar" CssClass="PanelPopUp bg-white">  
        <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLongTitle">¿Desea comprar el libro?</h5> 
        </div>

        <div class="modal-body">
            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. </p>
        </div>

        <div class="modal-footer"> 
            <asp:Button runat="server" ID="BtnComprar" CssClass="btn btn-success" Text="Comprar" OnClick="BtnComprar_Click"/>
            <asp:Button runat="server" ID="BtnCancelar" CssClass="btn btn-success" Text="Cancelar" OnClick="BtnCancelar_Click"/> 
        </div>
</asp:Panel>

<cc1:ModalPopupExtender runat="server" ID="ModalPopupMensaje" TargetControlID="UC_BUTTON_TEST" PopupControlID="PanelPopUpConfirmar" 
        BackgroundCssClass="modalBackground" Y="250" CancelControlID="cancelar"/> 

<asp:Button runat="server" ID="UC_BUTTON_TEST" CssClass="btn-test" style="display: none" Text="PopUp" Height="32px" Width="107px"/>