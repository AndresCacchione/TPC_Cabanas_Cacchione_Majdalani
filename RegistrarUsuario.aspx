<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="TPC_CacchioneMajdalani.RegistrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputNombreUsuario">Nombre usuario</label>
            <input type="text" class="form-control" id="NombreUsuario" placeholder="Nombre de Usuario" required runat="server">
        </div>
        <div class="form-group col-md-6">
            <label for="inputContraseña">Contraseña</label>
            <input type="password" class="form-control" id="Contraseña" placeholder="Contraseña" required runat="server">
            <asp:RegularExpressionValidator ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$" ErrorMessage="La contraseña debe contener mínimo 8 caracteres, incluidos una mayuscula, una miníscula, y al menos un número" 
                ControlToValidate="Contraseña" ForeColor="Red" runat="server" />
        </div>

    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputNombre">Nombre</label>
            <input type="text" class="form-control" id="Nombre" placeholder="Nombre" required runat="server">
            <asp:RegularExpressionValidator ErrorMessage="El nombre debe contener solo letras" 
                ValidationExpression="^[0-9A-Za-z ]+$" ForeColor="Red" ControlToValidate="Nombre" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="Completar campo" forecolor="Red" ControlToValidate="Nombre" runat="server" />
        </div>
        <div class="form-group col-md-6">
            <label for="inputApellido">Apellido</label>
            <input type="text" class="form-control" id="Apellido" placeholder="Apellido" required runat="server">
            <asp:RegularExpressionValidator ErrorMessage="El apellido debe contener solo letras" 
                ValidationExpression="^[0-9A-Za-z ]+$" ForeColor="Red" ControlToValidate="Apellido" runat="server" />
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputDni">Dni</label>
            <input type="number" class="form-control" id="DNI" placeholder="Numero DNI" required runat="server">
<%--            <asp:RegularExpressionValidator ErrorMessage="DNI longitud minima 6 caracteres, solo numeros" ValidationExpression="(^[1-9]\d).{6,}$" ForeColor="Red" ControlToValidate="DNI" runat="server" />--%>
        </div>
        <div class="form-group col-md-6">
            <label for="inputEmail">Correo Electronico</label>
            <input type="email" class="form-control" id="email" placeholder="Email@Email.com" required runat="server">
            <%-- <asp:TextBox class="form-control" id="txtemail" placeholder="Email@Email.com" required="" runat="server" />  --%>
        </div>
    </div>

    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputTelefono">Telefono</label>
            <input type="tel" class="form-control" id="Telefono" placeholder="Numero de Telefono" required runat="server">
        </div>
        <div class="form-group">
            <asp:Label ID="LblGenero" runat="server" Text="Genero"></asp:Label>
            <asp:DropDownList CssClass="form-control" ID="DDLGenero" runat="server">
                <asp:ListItem Text="" />
                <asp:ListItem Text="Masculino" Value="M" />
                <asp:ListItem Text="Femenino" Value="F" />
                <asp:ListItem Text="Otros" Value="O" />
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputURLimagen">Imagen de Perfil(Opcional)</label>
            <input type="text" class="form-control" id="UrlImagen" placeholder="http/xxxx.jpg" runat="server">
        </div>
        <div class="form-group col-md-6">
            <label for="inputDomicilio">Domicilio</label>
            <input type="text" class="form-control" id="Domicilio" placeholder="Domicilio" required runat="server">
        </div>
    </div>
    <div class="form-group">
        <asp:Label ID="lblPais" runat="server" Text="Pais de origen"></asp:Label>
        <asp:DropDownList CssClass="form-control" ID="DDLPaises" runat="server">
        </asp:DropDownList>
    </div>
    <asp:Button ID="btnAltaUsuario" Text="Darme de alta" class="btn btn-success mr-auto ml-auto" OnClick="btnAltaUsuario_Click" runat="server" />

</asp:Content>
