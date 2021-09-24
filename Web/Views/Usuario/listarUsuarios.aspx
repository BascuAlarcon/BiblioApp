<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master.Master" CodeBehind="listarUsuarios.aspx.cs" Inherits="Web.Views.Usuario.listarUsuarios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<%@ Register Src="~/UserControl/MensajeError.ascx" TagName="MensajeError" TagPrefix="u1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:Label runat="server" ID="LblCorreo"/>
            <table class="m-2">
                <tr>
                    <td>
                        <asp:GridView ID="GridViewUsuarios" runat="server" EmptyDataText="Lista de Usuarios" AutoGenerateColumns="False" 
                            OnRowDeleting="GridViewUsuarios_RowDeleting" OnRowCancelingEdit="GridViewUsuarios_RowCancelingEdit" 
                            DataKeyNames="id" OnRowEditing="GridViewUsuarios_RowEditing" OnRowUpdating="GridViewUsuarios_RowUpdating"
                            CssClass="tablaLibros" Height="110px" Width="700px" CellPadding="5" 
                            HeaderStyle-BackColor="#BEAEE2" HeaderStyle-BorderStyle="Outset" HeaderStyle-Font-Size="Large" HeaderStyle-Font-Bold="false"
                            OnRowDataBound="GridViewUsuarios_RowDataBound" OnPreRender="GridViewUsuarios_PreRender">
                            <EmptyDataRowStyle CssClass="encabTablaDatos" />
                            <Columns>  
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="labelID" AssociatedControlID="labelID" Text='<% # Bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtID" Text='<% # Bind("id") %>' Enabled="false"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="RUT">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="labelRUT" AssociatedControlID="labelRUT" Text='<% # Bind("rut") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtRUT" Text='<% # Bind("rut") %>' Enabled="false"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="EMAIL">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="labelEMAIL" AssociatedControlID="labelEMAIL" Text='<% # Bind("email") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtEMAIL" Text='<% # Bind("email") %>' Enabled="false"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="NOMBRE">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="labelNOMBRE" AssociatedControlID="labelNOMBRE" Text='<% # Bind("nombre") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtNOMBRE" Text='<% # Bind("nombre") %>' Enabled="false"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ROL">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="labelROL" AssociatedControlID="labelROL" Text='<% # Bind("rol") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>   
                                        <asp:DropDownList runat="server" ID="COMBOBOX_ROLES" BackColor="#FF95C5"></asp:DropDownList> 
                                    </EditItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:CommandField buttonType="link" ShowDeleteButton="true" DeleteText="Eliminar" ShowEditButton="true" 
                                    EditText="Editar" UpdateText="Guardar" CancelText="Cancelar"/>
                            </Columns>
                        </asp:GridView>


                        <asp:Panel runat="server" ID="PanelPopUp" CssClass="PanelPopUp bg-white">  
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLongTitle">¿Desea borrar al usuario?</h5> 
                            </div>

                            <div class="modal-body">
                                <p>Si guarda los cambios, no se podrán revertir.</p>
                            </div>

                            <div class="modal-footer">
                                <button type="button" id="exit" class="btn btn-secondary" aria-hidden="true" data-dismiss="modal">Cancelar</button>
                                <asp:Button runat="server" ID="BTN_BORRAR" Text="Borrar" CssClass="btn btn-danger" OnClick="BTN_BORRAR_Click"/>  
                            </div>
                        </asp:Panel>  

                        <cc1:ModalPopupExtender runat="server" ID="ModalPopupMensaje" TargetControlID="BUTTON_TEST" PopupControlID="PanelPopUp" 
                            BackgroundCssClass="modalBackground" Y="250" CancelControlID="exit"/> 

                         
                        <asp:Button runat="server" ID="BUTTON_TEST" CssClass="btn-test" style="display: none" Text="PopUp" Height="32px" Width="107px"/>  
                    </td>
                </tr>
            </table> 
        </div>
    <asp:UpdatePanel runat="server" ID="UP1">
        <ContentTemplate>
            <u1:MensajeError runat="server" ID="MensajeError"/>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content> 