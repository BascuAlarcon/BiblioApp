<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="listarAutores.aspx.cs" Inherits="Web.Views.autores.listarAutores" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<%@ Register Src="~/UserControl/MensajeError.ascx" TagName="ErrorMessage" TagPrefix="uc1"%>
<%@ Register Src="~/UserControl/MensajeBorrar.ascx" TagName="DeleteMessage" TagPrefix="uc2"%> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row mt-2">
        <div class="col-6">
            <asp:GridView ID="GridViewAutores" runat="server" EmptyDataText="Lista de Autores" AutoGenerateColumns="False" 
                OnRowCancelingEdit="GridViewAutores_RowCancelingEdit"
                CssClass="tablaLibros" Height="110px" Width="500px" CellPadding="5" 
                HeaderStyle-BackColor="#BEAEE2" HeaderStyle-BorderStyle="Outset" HeaderStyle-Font-Size="Large" HeaderStyle-Font-Bold="false"
                OnRowEditing="GridViewAutores_RowEditing" DataKeyNames="id"
                OnRowDeleting="GridViewAutores_RowDeleting" OnRowUpdating="GridViewAutores_RowUpdating">
                <EmptyDataRowStyle CssClass="encabTablaDatos" />
                <Columns>
                    <asp:TemplateField HeaderText="ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelID" AssociatedControlID="labelID" Text='<% # Bind("id") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="TxtID" Text='<% # Bind("id") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOMBRE">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="LabelNOMBRE" AssociatedControlID="labelNOMBRE" Text='<% # Bind("nombre") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="TxtNOMBRE" Text='<% # Bind("nombre") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Link" ShowCancelButton="true" CancelText="Cancelar" ShowDeleteButton="true" DeleteText="Eliminar" 
                        ShowEditButton="true" EditText="Editar" UpdateText="Guardar" />
                </Columns>
            </asp:GridView> 
        </div> 

        <asp:Panel runat="server" ID="PanelPopUp" CssClass="PanelPopUp bg-white">  
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLongTitle">Ha ocurrido un error</h5> 
            </div> 
            <div class="modal-body">
                <p>No se pudo borrar el autor, por que esta asignada a un libro</p>
            </div> 
            <div class="modal-footer">
                <button type="button" id="exit" class="btn btn-secondary" aria-hidden="true" data-dismiss="modal">Acceptar</button> 
            </div>
        </asp:Panel>   
        <cc1:ModalPopupExtender runat="server" ID="ModalPopupMensaje" TargetControlID="BUTTON_TEST" PopupControlID="PanelPopUp" 
            BackgroundCssClass="modalBackground" Y="250" CancelControlID="exit"/>  
        <asp:Button runat="server" ID="BUTTON_TEST" CssClass="btn-test" style="display: none" Text="PopUp" Height="32px" Width="107px"/>

        <div class="col col-lg-4 mx-auto"> 
            <div class="container m-2 bg-dark"> 
             <h2 class="text-light text-center">Agregar Autores</h2>
                <div class="form-group mr-2 mb-1 text-center">
                    <label for="FormNombre" class="text-light">Nombre Autor</label>  
                    <asp:TextBox runat="server" ID="TxtInputNombre" style="display: block; margin: auto;"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Autor" ForeColor="Red" ValidationGroup="form-autor" 
                        ControlToValidate="TxtInputNombre" ErrorMessage="Ingrese un nombre" />  
                </div>  
                <asp:Button runat="server" ID="Btn_limpiar" CssClass="btn btn-outline-warning m-2" text="Limpiar" OnClick="Btn_limpiar_Click"/>
                <asp:Button runat="server" ID="Btn_agregar" CssClass="btn btn-outline-success m-2" type="submit" text="Agregar" ValidationGroup="form-autor" OnClick="Btn_agregar_Click"/> 
            </div> 
        </div> 
    </div> 
    
    <asp:UpdatePanel runat="server" ID="UP1">
        <ContentTemplate>
            <uc1:ErrorMessage runat="server" ID="ErrorMessage"/>
        </ContentTemplate> 
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="UP2">
        <ContentTemplate>
            <uc2:DeleteMessage runat="server" ID="DeleteMessage" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
