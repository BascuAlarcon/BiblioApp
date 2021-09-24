<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MensajeError.ascx.cs" Inherits="Web.UserControl.MensajeError" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
  
<asp:Label ID="lblOculto" runat="server" Text="Label" Style="display: none;" />
<div id="PanelError"    >
    <asp:Panel ID="panel" runat="server" CssClass="modalPopUpError bg-light" Height="200px" Width="400px">
        <div class="modal-header" style="display: block; margin: auto;">
            <h5 class="modal-title text-center" id="exampleModalLongTitle">Ha ocurrido un error...</h5> 
        </div>

        <div class="modal-body"> 
            <asp:Label runat="server" ID="LabelBody" CssClass="text text-center"/>
        </div>

        <div class="modal-footer"> 
            <asp:Button runat="server" ID="BtnCerrar" CssClass="btn btn-warning" OnClick="BtnCerrar_Click" Text="Cerrar"/>
        </div>
    </asp:Panel>
</div>

<ajaxToolkit:ModalPopupExtender runat="server" ID="ModalPopupMensaje" TargetControlID="lblOculto" PopupControlID="PanelError" PopupDragHandleControlID="PanelError" 
    BackgroundCssClass="modalBackground" Y="250" CancelControlID="exit"/> 
 