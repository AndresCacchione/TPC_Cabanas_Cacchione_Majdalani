<%@ Page Title="Iniciar Sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_CacchioneMajdalani.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <label for="inputNombreUsuario">Nombre usuario</label>
        <input type="text" class="form-control" id="NombreUsuario" placeholder="Nombre de Usuario" required runat="server">
    </div>
    <div class="form-group">
        <label for="inputContraseña">Contraseña</label>
        <input type="password" class="form-control" id="Contraseña" placeholder="Contraseña" required runat="server">
    </div>

    <asp:Button ID="btnLogin" Text="Iniciar Sesión" runat="server" class="btn btn-success mr-auto ml-auto" OnClick="btnLogin_Click" />
            <a href="RegistrarUsuario.aspx" class="btn btn-success mr-auto ml-auto">Registrarse</a>
</asp:Content>
