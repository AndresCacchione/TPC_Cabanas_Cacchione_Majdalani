<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="TPC_CacchioneMajdalani.ModificarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputNombreUsuario">Nuevo Username</label>
            <input type="text" class="form-control" id="NombreUsuario" placeholder="Nombre de Usuario" runat="server">
        </div>
        <div class="form-group col-md-6">
            <label for="inputContraseña">Nueva Password</label>
            <input type="password" class="form-control" id="Contraseña" placeholder="Contraseña" runat="server">
        </div>
    </div>
   <%--  <div class="form-row">
       <div class="form-group col-md-6">
            <asp:Label ID="LblNivelAcceso" runat="server" Text="Nivel de Acceso"></asp:Label>
            <asp:DropDownList CssClass="form-control" ID="DDLNivelAcceso" runat="server">
                <asp:ListItem Text="" />
                <asp:ListItem Text="De la base de datos" />
                <asp:ListItem Text="Femenino" />
                <asp:ListItem Text="Otros"/>
            </asp:DropDownList>
        </div>
  
     <div class="form-group col-md-6">
            <asp:Label ID="LblEstado" runat="server" Text="Estado"></asp:Label>
            <asp:DropDownList CssClass="form-control" ID="DDLEstado" runat="server">
                <asp:ListItem Text="" />
                <asp:ListItem Text="Bloquear" Value="0" />
                <asp:ListItem Text="Activo" Value="1"/>
            </asp:DropDownList>
        </div>
           </div>--%>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputNombre">Nuevo Nombre</label>
            <input type="text" class="form-control" id="Nombre" placeholder="Nombre" runat="server" />
        </div>
        <div class="form-group col-md-6">
            <label for="inputApellido">Nuevo Apellido</label>
            <input type="text" class="form-control" id="Apellido" placeholder="Apellido" runat="server" />
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputDni">Nuevo Dni</label>
            <input type="number" class="form-control" id="DNI" placeholder="DNI" runat="server" />
        </div>
        <div class="form-group col-md-6">
            <label for="inputEmail">Nuevo Correo Electrónico</label>
            <input type="email" class="form-control" id="Email" placeholder="Email@Email.com" runat="server" />
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputTelefono">Nuevo Telefono</label>
            <input type="tel" class="form-control" id="Telefono" placeholder="Numero de Telefono" runat="server" />
        </div>
        <div class="form-group col-md-6">
            <label for="inputURLimagen">Nueva Imagen de Perfil</label>
            <input type="text" class="form-control" id="UrlImagen" placeholder="http/xxxx.jpg" runat="server" />
        </div>
    </div>
     <div class="form-row ">
    <div class="form-group col-md-6">
        <asp:Label ID="lblPais" runat="server" Text="Nuevo Pais de Origen" />
        <asp:DropDownList CssClass="form-control" ID="DDLPaises" runat="server">
        </asp:DropDownList>
    </div>
     <div class="form-group col-md-6">
            <asp:Label ID="LblGenero" runat="server" Text="Genero"></asp:Label>
            <asp:DropDownList CssClass="form-control" ID="DDLGenero" runat="server">
                <asp:ListItem Text="" />
                <asp:ListItem Text="Masculino" Value="M" />
                <asp:ListItem Text="Femenino" Value="F"/>
                <asp:ListItem Text="Otros" Value="O"/>
            </asp:DropDownList>
        </div>
             </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputDomicilio">Nuevo Domicilio</label>
            <input type="text" class="form-control" id="Domicilio" placeholder="Domicilio" runat="server" />
        </div>
    </div>

    <asp:Button ID="btnModificarDatos" Text="Actualizar datos" class="btn btn-success mr-auto ml-auto" runat="server" />
</asp:Content>
