<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master.Master" CodeBehind="register.aspx.cs" Inherits="Web.Views.Usuario.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
   <div class="row mt-2">
    <div class="col-4 offset-3 mx-auto ">
        <div class="card align-items-center justify-content-center">
            <div class="card-header bg-dark text-white">Crear una Cuenta</div>
            <div class="card-body"> 
                <div class="form-group m-2">
                    <label for="correo" class="text-style-2" style="display:block; text-align:center">Correo Electronico</label> 
                    <asp:TextBox runat="server" ID="TxtCorreo" style="display: block;"/>
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Correo" ForeColor="Red" ErrorMessage="Debe ingresar su correo" 
                        ControlToValidate="TxtCorreo"  ValidationGroup="form_usuario"/>
                </div>
                <div class="form-group m-2">
                    <label for="nombre" class="text-style-2" style="display: block; text-align:center">Nombre</label>
                    <asp:TextBox runat="server" ID="TxtNombre" style="display: block; text-align:center"/> 
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Nombre" ForeColor="Red" ErrorMessage="Debe ingresar su nombre" 
                        ControlToValidate="TxtNombre"  ValidationGroup="form_usuario"/>
                </div>
                <div class="form-group m-2">
                    <label for="rut" class="text-style-2" style="display: block; text-align:center">Rut</label>
                    <asp:TextBox runat="server" ID="txtRut" style="display: block; text-align:center"/> 
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Rut" ForeColor="Red" ErrorMessage="Debe ingresar su rut" 
                        ControlToValidate="TxtRut"  ValidationGroup="form_usuario"/>
                </div> 
                <div class="form-group m-2">
                    <label for="password" class="text-style-2" style="display: block; text-align:center">Contraseña</label>
                    <asp:TextBox runat="server" ID="txtPassword" type="password" style="display: block; text-align:center"/> 
                    <asp:RequiredFieldValidator runat="server" ID="RFV_Password" ForeColor="Red" ErrorMessage="Debe ingresar su contraseña" 
                        ControlToValidate="TxtPassword"  ValidationGroup="form_usuario"/>
                </div> 
                <div class="form-group mt-2">
                    <asp:Button runat="server" ID="btnCrear" cssclass="btn btn-primary" Text="Crear Cuenta" OnClick="btn_crear_Click" ValidationGroup="form_usuario"/> 
                    <a href="/Views/Usuario/login.aspx" class="btn btn-danger">Volver</a>
                </div> 
            </div>
        </div>
    </div>
</div>
</asp:Content> 