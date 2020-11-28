<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoDeUsuarios.aspx.cs" Inherits="TPC_CacchioneMajdalani.ListadoDeUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col" style="width: 120px">Imagen de Perfil</th>
                            <th scope="col" style="width: 100px">Nombre de usuario</th>
                            <th scope="col" style="width: 100px">Nombre</th>
                            <th scope="col" style="width: 100px">Apellido</th>
                            <th scope="col" style="width: 100px">Email</th>
                            <th scope="col" style="width: 60px">Teléfono</th>
                            <th scope="col" style="width: 60px">Nivel de permisos</th>
                            <th scope="col" style="width: 60px">Estado</th>
                        </tr>
                    </thead>
                    <%foreach (Dominio.Usuario item in UsuariosLista)
                        { %>
                    <tr>
                        
                        
                            
                        
                        <td style="width: 140px">
                            <img src="<% = item.DatosPersonales.UrlImagen %>" style="width: 100px; height: inherit;" alt="...">

                            <th scope="row" style="width: 120px"><% = item.NombreUsuario %></th> 

                            <th scope="row" style="width: 100px"><% = item.DatosPersonales.Nombre %></th>

                            <th scope="row" style="width: 100px"><% = item.DatosPersonales.Apellido %></th>

                            <th scope="row" style="width: 100px"><% = item.DatosPersonales.Email %></th>

                            <th scope="row" style="width: 100px"><% = item.DatosPersonales.Telefono %></th>

                            <th scope="row" style="width: 60px"><% = item.NivelAcceso %></th>

                            <th scope="row" style="width: 60px"><% = item.Estado %></th>

                            <th scope="row"><a class="btn btn-secondary" href="ModificarUsuario.aspx?idUsuario=<% = item.Id.ToString() %>">Modificar</a></th>

                        </td>
                    </tr>

                    <% } %>

                </table>
            </div>
        </div>
    </div>

</asp:Content>
