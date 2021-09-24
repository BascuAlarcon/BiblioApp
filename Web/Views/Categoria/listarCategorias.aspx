<%@ Page Language="C#" MasterPageFile="~/Views/Master.Master"  AutoEventWireup="true" CodeBehind="listarCategorias.aspx.cs" Inherits="Web.listarCategorias" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 

<%@ Register Src="~/UserControl/MensajeError.ascx" TagName="MensajeError" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/MensajeBorrar.ascx" TagName="MensajeBorrar" TagPrefix="uc2" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
        <div class="row">
            <div class="col-lg-7">
                <table class="m-2">
                <tr>
                    <td>  
                        <asp:GridView ID="GridViewCategorias" runat="server" EmptyDataText="Lista de Categorias" AutoGenerateColumns="False"
                            OnRowDeleting="GridViewCategorias_RowDeleting" 
                            CssClass="tablaLibros" Height="110px" Width="700px" CellPadding="5" 
                            HeaderStyle-BackColor="#BEAEE2" HeaderStyle-BorderStyle="Outset" HeaderStyle-Font-Size="Large" HeaderStyle-Font-Bold="false"
                            OnRowEditing="GridViewCategorias_RowEditing" OnRowCancelingEdit="GridViewCategorias_RowCancelingEdit" 
                            OnRowUpdating="GridViewCategorias_RowUpdating" DataKeyNames="id">
                            <EmptyDataRowStyle CssClass="encabTablaDatos" />
                            <Columns>  
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="label" runat="server" AssociatedControlID="label" Text='<% # Bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtID" runat="server" Text='<% # Bind("id") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField> 

                                <asp:TemplateField HeaderText="NOMBRE">
                                    <ItemTemplate>
                                        <asp:Label ID="label1" runat="server" AssociatedControlID="label1" Text='<% # Bind("nombre") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtNombre" runat="server" Text='<% # Bind("nombre") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField> 

                                <asp:TemplateField HeaderText="DESCRIPCION">
                                    <ItemTemplate>
                                        <asp:Label ID="label3" runat="server" Text='<% # Bind("descripcion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtDescripcion" runat="server" Text='<% # Bind("descripcion") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField> 

                                <asp:CommandField ButtonType="Link" ShowCancelButton="true" CancelText="Cancelar" ShowDeleteButton="true" DeleteText="Eliminar" 
                                 ShowEditButton="true" EditText="Editar" UpdateText="Guardar" />
                                 
                            </Columns>
                        </asp:GridView>  
                    </td>
                </tr>
            </table> 
        </div>      

        <div class="col col-lg-4 mx-auto"> 
            <div class="container m-2 bg-dark "> 
             <h2 class="text-light text-center">Agregar Categorias</h2>
                <div class="form-group mr-2 mb-1 text-center">
                    <label for="FormNombre" class="text-light text-center">Nombre Categoria</label> 
                    <asp:TextBox runat="server" ID="TxtInputNombre" style="display: block; margin: auto;" ></asp:TextBox> 
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Nombre" ControlToValidate="TxtInputNombre" ErrorMessage="Debe ingresar un nombre" 
                        ForeColor="Red" ValidationGroup="form_categoria"/>
                </div> 
                <div class="form-group mr-1 mb-1 text-center">
                    <label for="FormDescripcion" class="text-light" style="display:block">Descripción</label>
                    <asp:TextBox runat="server" ID="TxtInputDescripcion" style="display: block; margin: auto;"/>
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Descripcion" ControlToValidate="TxtInputDescripcion"
                        ErrorMessage="Debe ingresar una descripcion" ForeColor="Red" ValidationGroup="form_categoria"/>
                </div>
                <div class="form-group text-right mt-2 " >
                    <asp:Button runat="server" ID="Btn_limpiar" CssClass="btn btn-outline-warning ml-4" text="Limpiar" OnClick="Btn_limpiar_Click"/>
                    <asp:Button runat="server" ID="Btn_agregar" CssClass="btn btn-outline-success m-2" type="submit" text="Agregar" 
                    OnClick="Btn_agregar_Click" ValidationGroup="form_categoria"/> 
                </div> 
            </div> 
        </div> 
    </div>

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
            <uc1:MensajeError runat="server" ID="MensajeError"/>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
        <ContentTemplate>
            <uc2:MensajeBorrar runat="server" ID="MensajeBorrar"/>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content> 

<asp:Content ID="Content3"  ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        $(document).ready(function () { 
            $(document).on("click", ".Test", function () {
                if ($('.Test2').is(':visible')) {
                    OcultarElemento("Test2"); 
                }
                else {
                    MostrarElemento("Test2");
                }
            }); 
        });   

        function OcultarElemento(clase) {
            $('.' + clase).hide();
        }

        function MostrarElemento(clase) {
            $('.' + clase).show();
        }
    </script>
</asp:Content>