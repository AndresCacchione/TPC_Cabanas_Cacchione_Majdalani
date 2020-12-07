<%@ Page Title="Administradores de Complejos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministradoresDeComplejos.aspx.cs" Inherits="TPC_CacchioneMajdalani.AdministradoresDeComplejos" %>

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
                            <th scope="col" style="width: 100px">Complejo que Administra</th>
                            <th scope="col" style="width: 60px">Email</th>
                            <th scope="col" style="width: 60px">Nivel de permisos (de 20 a 30) </th>
                     
                        </tr>
                    </thead>
                    <%foreach (Dominio.Administrador item in ListaAdministradores)
                        { %>
                    <tr>
                        <td style="width: 140px">
                            <img src="<% = item.usuario.DatosPersonales.UrlImagen %>" style="width: 100px; height: inherit;" alt="No posee imagen cargada">

                            <th scope="row" style="width: 120px"><% = item.usuario.NombreUsuario %></th>

                            <th scope="row" style="width: 100px"><% = item.usuario.DatosPersonales.Nombre %></th>

                            <th scope="row" style="width: 100px"><% = item.usuario.DatosPersonales.Apellido %></th>

                            <%if (Convert.ToInt64(item.IDComplejo) != 0)
                                {%>
              
                            <th scope="row" style="width: 100px"><% = (ComplejoNegocio.BuscarComplejoPorId(item.IDComplejo)).Nombre %></th>
                           
                            <%}
                                else
                                {%>
                               <th scope="row" style="width: 100px">Sin complejo</th>
                            <%} %>
                            
                            <th scope="row" style="width: 100px"><% = item.usuario.DatosPersonales.Email %></th>
                                                                           

                            <th scope="row" style="width: 60px"><% = item.usuario.NivelAcceso %></th>

                          

                            <%if (((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso > item.usuario.NivelAcceso)
                                { %>
                            <th scope="row"><a class="btn btn-secondary" href="ModificarUsuario.aspx?idUsuario=<% = item.usuario.Id.ToString() %>">Modificar</a></th>
                            <% } %> 

                        </td>
                    </tr>

                    <% } %>
                </table>
            </div>
        </div>
    </div>







</asp:Content>
