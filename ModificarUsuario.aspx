<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="TPC_CacchioneMajdalani.ModificarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label for="inputDomicilio">Nuevo Domicilio</label>
        <input type="text" class="form-control" id="Domicilio" placeholder="Domicilio" required runat="server" />
    </div>
    <div class="form-group">
        <label for="inputEmail">Nuevo Correo Electronico</label>
        <input type="email" class="form-control" id="Email" placeholder="Email@Email.com" required runat="server" />
    </div>
    <div class="form-group">
        <label for="inputTelefono">Nuevo Telefono</label>
        <input type="tel" class="form-control" id="Telefono" placeholder="Numero de Telefono" required runat="server" />
    </div>
    <div class="form-group">
        <label for="inputURLimagen">Nueva Imagen de Perfil</label>
        <input type="text" class="form-control" id="UrlImagen" placeholder="http/xxxx.jpg" runat="server" />
    </div>

    <asp:Button id="btnModificarDatos" Text="Actualizar mis datos" class="btn btn-success mr-auto ml-auto" onclick="" runat="server" />
</asp:Content>
