<%@ Page Title="Modificar Datos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="TPC_CacchioneMajdalani.ModificarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputNombreUsuario">Nombre de Usuario</label>
            <input type="text" class="form-control" id="NombreUsuario" placeholder="Nombre de Usuario" required runat="server">
        </div>
        <div class="form-group col-md-6">
            <label for="inputContraseña">Contraseña</label>
            <input type="password" class="form-control" id="Contraseña" placeholder="Contraseña" required runat="server">
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <asp:Label ID="LblNivelAcceso" runat="server" Text="Nivel de Acceso"></asp:Label>
            <asp:DropDownList CssClass="form-control" ID="DDLNivelAcceso" runat="server">
            </asp:DropDownList>
        </div>

        <div class="form-group col-md-6">
            <asp:Label ID="LblEstado" runat="server" Text="Estado"></asp:Label>
            <asp:DropDownList CssClass="form-control" ID="DDLEstado" runat="server">
                <asp:ListItem Text="Bloqueado" Value="0" />
                <asp:ListItem Text="Activo" Value="1" />
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputNombre">Nombre </label>
            <input type="text" class="form-control" id="Nombre" placeholder="Nombre" required runat="server" />
        </div>
        <div class="form-group col-md-6">
            <label for="inputApellido">Apellido </label>
            <input type="text" class="form-control" id="Apellido" placeholder="Apellido" required runat="server" />
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputDni">DNI</label>
            <input type="number" class="form-control" id="DNI" placeholder="DNI" required runat="server" />
            <asp:CompareValidator ErrorMessage="El DNI ingresado no es válido" ControlToValidate="DNI" Operator="GreaterThanEqual" ValueToCompare="1000000" ForeColor="Red" runat="server" />
        </div>
        <div class="form-group col-md-6">
            <label for="inputEmail">Correo Electrónico</label>
            <input type="email" class="form-control" id="Email" placeholder="Email@Email.com" required runat="server" />
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputTelefono">Telefono</label>
            <input type="tel" class="form-control" id="Telefono" placeholder="Numero de Telefono" required runat="server" />
        </div>
        <div class="form-group col-md-6">
            <label for="inputURLimagen">Imagen de Perfil</label>
            <input type="text" class="form-control" id="UrlImagen" placeholder="http/xxxx.jpg" runat="server" />
        </div>
    </div>
    <div class="form-row ">
        <div class="form-group col-md-6">
            <asp:Label ID="lblPais" runat="server" Text="Pais de Origen" />
            <asp:DropDownList CssClass="form-control" ID="DDLPaises" runat="server">
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-6">
            <asp:Label ID="LblGenero" runat="server" Text="Genero"></asp:Label>
            <asp:DropDownList CssClass="form-control" ID="DDLGenero" runat="server">
                <asp:ListItem Text="Femenino" Value="F" />
                <asp:ListItem Text="Masculino" Value="M" />
                <asp:ListItem Text="Otros" Value="O" />
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputDomicilio">Domicilio</label>
            <input type="text" class="form-control" id="Domicilio" placeholder="Domicilio" required runat="server" />
        </div>
    </div>

    <asp:Button ID="btnModificarDatos" OnClick="btnModificarDatos_Click" Text="Actualizar datos" class="btn btn-success mr-auto ml-auto" runat="server" />
</asp:Content>
