<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master.Master" CodeBehind="listarLibros.aspx.cs" Inherits="Web.Views.Libros.listarLibros" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  
<%@ Register Src="~/UserControl/MensajeError.ascx" TagName="MensajeError" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <asp:ScriptManager ID="ScriptManager" runat="server"/>
      
    <div class="row">
        <div class="col-lg-8">
            <table class="m-2">
                <tr>
                    <td>
                        <div style="border: solid; border-radius: 6px; border-color: grey; margin-bottom:3px">
                            <asp:Label Text="Buscar Libro" CssClass="text-dark p-1" style="display:block; margin-left: 6px;" runat="server" />
                            <asp:TextBox runat="server" ID="TxtSearch" CssClass="m-2" Width="576px" ToolTip="Ingrese el nombre del libro" 
                            OnTextChanged="TxtSearch_TextChanged"/>
                            <asp:Button runat="server" CssClass="btn btn-success mb-1" Text="Buscar"/>  
                        </div> 
                        <div style="width: 100%; height: 400px; overflow: auto; border:solid; border-width:1px;">
                            <asp:GridView ID="GridViewLibros" runat="server"  EmptyDataText="Lista de Libros" AutoGenerateColumns="False" 
                                CssClass="tablaLibros" Height="110px" Width="700px" CellPadding="5" 
                                HeaderStyle-BackColor="#BEAEE2" HeaderStyle-BorderStyle="Outset" HeaderStyle-Font-Size="Large" HeaderStyle-Font-Bold="false"
                                DataKeyNames="id" OnSelectedIndexChanged="GridViewLibros_SelectedIndexChanged">
                            <EmptyDataRowStyle CssClass="encabTablaDatos" Wrap="true"/>
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE"/>  
                                <asp:BoundField DataField="PRECIO" HeaderText="PRECIO" />  
                                <asp:BoundField DataField="AUTOR" HeaderText="AUTOR" /> 
                                <asp:BoundField DataField="CATEGORIA" HeaderText="CATEGORIA" />  
                                <asp:CommandField ButtonType="Button" ShowSelectButton="true" ControlStyle-CssClass="btn btn-success text-light" SelectText="Mostrar"/>
                            </Columns>
                        </asp:GridView>
                        </div>
                              
                    </td>
                </tr>
            </table> 
        </div> 

        
        <div runat="server" class="col col-lg-4 mx-auto"> 
            <asp:Panel runat="server" ID="PanelFormularioAgregar" OnLoad="PanelFormularioAgregar_Load" visible="false" >
                <div class="container m-2 bg-dark"> 
                    <h2 class="text-light text-center">Agregar Libros</h2>
                    <div class="form-group mr-2 mb-1 text-center">
                        <label for="FormNombre" class="text-light">Nombre del Libro</label> 
                        <asp:TextBox runat="server" ID="TxtInputNombre" style="display: block; margin: auto;"></asp:TextBox> 
                        <asp:RequiredFieldValidator runat="server" ID="RFV_Nombre" ControlToValidate="TxtInputNombre" ErrorMessage="Debe ingresar un nombre" 
                            ForeColor="Red" ValidationGroup="form_libros"/>
                    </div> 
                    <div class="form-group mr-1 mb-1 text-center">
                        <label for="FormPrecio" class="text-light">Precio</label>
                        <asp:TextBox runat="server" ID="TxtInputPrecio" style="display: block; margin: auto;"/>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_Precio" ControlToValidate="TxtInputPrecio"
                            ErrorMessage="Debe ingresar un precio" ForeColor="Red" ValidationGroup="form_libros"/>
                    </div>   
                    <asp:DropDownList runat="server"  ID="ComboBoxCategoria" CssClass="DDLibros"></asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ComboBoxAutores" CssClass="DDLibros"></asp:DropDownList>
                    <div class="BtnForms">
                        <asp:Button runat="server" ID="Btn_limpiar" CssClass="btn btn-outline-warning m-2" text="Limpiar" OnClick="Btn_limpiar_Click"/>
                        <asp:Button runat="server" ID="Btn_agregar" CssClass="btn btn-outline-success m-2" type="submit" text="Agregar" 
                        ValidationGroup="form_libros" OnClick="Btn_agregar_Click"/> 
                    </div> 
                </div> 
            </asp:Panel>
        </div> 
         
        <asp:Panel runat="server" ID="PanelPopUp" CssClass="PanelPopUp bg-white">   
            <div class="modal-footer">
                <button type="button" id="exit" class="btn btn-secondary" aria-hidden="true" data-dismiss="modal">Acceptar</button> 
            </div>
    </asp:Panel>  

    <cc1:ModalPopupExtender runat="server" ID="ModalPopupMensaje" TargetControlID="BUTTON_TEST" PopupControlID="PanelPopUp" 
            BackgroundCssClass="modalBackground" Y="250" CancelControlID="exit"/> 

    <asp:Button runat="server" ID="BUTTON_TEST" CssClass="btn-test" style="display: none" Text="PopUp" Height="32px" Width="107px"/>

        <asp:UpdatePanel runat="server" ID="UP2">
            <ContentTemplate>
                <uc1:MensajeError runat="server" ID="MensajeError"/>
            </ContentTemplate>
        </asp:UpdatePanel>
         
    </div>   
</asp:Content> 