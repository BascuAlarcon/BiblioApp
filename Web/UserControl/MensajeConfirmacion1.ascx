<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MensajeConfirmacion1.ascx.cs" Inherits="Web.UserControl.MensajeConfirmacion1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Label ID="lblOculto" runat="server" Text="Label" Style="display: none;" />
<div id="PanelError"    >
    <asp:Panel ID="panel" runat="server" CssClass="modalPopUpError bg-light" Height="200px" Width="400px"  >
        <div class="modal-header"> 
            <asp:Label runat="server" class="text" style="display: block; margin: auto;" ID="LabelHeader"/>
        </div>

        <div class="modal-body">
            <asp:Label runat="server" class="text text-primary" ID="LabelBody"/>
        </div>

        <div class="modal-footer"> 
            <asp:Button runat="server" ID="BtnCerrar" CssClass="btn btn-warning" OnClick="BtnCerrar_Click" Text="Cancelar"/>
            <asp:Button runat="server" ID="BtnAccepar" CssClass="btn btn-success" OnClick="BtnAccepar_Click"/>
        </div>
    </asp:Panel>
</div>

<ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupMensaje" TargetControlID="lblOculto" PopupControlID="PanelError" PopupDragHandleControlID="PanelError" 
    BackgroundCssClass="modalBackground" Y="250" CancelControlID="exit"/> 
 