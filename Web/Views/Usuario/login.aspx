<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Master.Master" CodeBehind="login.aspx.cs" Inherits="Web.Views.Usuario.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: #A9E4D7; height: 540px; width: auto">
        <div class="row my-auto">
          <div class="col-4 offset-3 mx-auto" >
              <div class="card mt-5 align-items-center justify-content-center" style="border:solid; background-color: #BB8760; height: 440px">
                  <div class="card-header bg-dark text-white">Inicio de Sesión</div>
                  <div class="card-body " style="margin-top:50px">
                    <h5 class="card-title text-center">Inicio de sesion</h5> 
                    <div class="form-group m-1 text-center">
                        <label for="Rut"  style="display: block; text-align:center">Rut</label> 
                        <asp:TextBox runat="server" ID="inputRut" style="display: block; margin:auto;"/>
                        <asp:RequiredFieldValidator runat="server" ID="RFV_Rut" ForeColor="Red" ValidationGroup="form_login" 
                            ControlToValidate="inputRut" ErrorMessage="Ingrese su Rut"/>
                    </div>
                    <div class="form-group m-1 text-center">
                        <label for="password"  style="display: block; text-align:center">Contraseña</label>
                        <asp:TextBox runat="server" ID="inputPassword"  style="display: block; margin:auto; "/> 
                        <asp:RequiredFieldValidator runat="server" ID="RFV_Password" ForeColor="Red" ValidationGroup="form_login" 
                            ControlToValidate="inputPassword" ErrorMessage="Ingrese su contraseña"/>
                    </div>
                    <div class="form-group text-right mt-2"> 
                        <a href="/Views/Usuario/register.aspx" class="btn btn-secondary">Crear Cuenta</a> 
                        <asp:Button runat="server" ID="BTN_INICIAR" CssClass="btn btn-primary" Text="Iniciar Sesion" OnClick="BTN_INICIAR_Click" ValidationGroup="form_login"/>
                    </div> 
                  </div>
              </div>
          </div>
      </div>  
    </div> 
</asp:Content> 