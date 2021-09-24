<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="librosUsuario.aspx.cs" Inherits="Web.Views.Libros.librosUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-8">
            <table class="m-2">
                <tr>
                    <td> 
                        <div style="width: 100%; height: 400px; overflow: auto; border:solid; border-width:1px;">
                            <asp:GridView ID="GridViewLibrosUsuario" runat="server"  EmptyDataText="Libros comprados" AutoGenerateColumns="False" 
                            CssClass="tablaLibros" Height="110px" Width="700px" CellPadding="5" 
                            HeaderStyle-BackColor="#BEAEE2" HeaderStyle-BorderStyle="Outset" HeaderStyle-Font-Size="Large" HeaderStyle-Font-Bold="false"
                            DataKeyNames="NOMBRE">
                            <EmptyDataRowStyle CssClass="encabTablaDatos" Wrap="true"/>
                            <Columns> 
                                <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" />  
                                <asp:BoundField DataField="PRECIO" HeaderText="PRECIO" />   
                                <asp:BoundField DataField="AUTOR" HeaderText="AUTOR" /> 
                                <asp:BoundField DataField="CATEGORIA" HeaderText="CATEGORIA" />   
                            </Columns>
                        </asp:GridView>
                        </div>
                              
                    </td>
                </tr>
            </table> 
        </div>  
    </div>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
