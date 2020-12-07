<%@ Page Title="VerReservas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerReservas.aspx.cs" Inherits="TPC_CacchioneMajdalani.VerReservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



           
    <asp:DropDownList runat="server">
        <asp:ListItem Text="Pendiente" Value="1" />
        <asp:ListItem Text="Confirmada" Value="2"/>
        <asp:ListItem Text="Cancelada" Value="3"/>
    </asp:DropDownList>






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
                    <%foreach (Dominio.Reserva item in ListaDeReservas)
                        { %>
                    <tr>
                        <td style="width: 140px">

                            <img src="<% = item.Cabaña.Imagen %>" style="width: 100px; height: inherit;" alt="No posee imagen cargada">

                           
                            <th scope="row" style="width: 120px"><% = item.FechaCreacionReserva %></th>

                            <th scope="row" style="width: 100px"><% = item.FechaIngreso %></th>

                            <th scope="row" style="width: 100px"><% = item.FechaEgreso %></th>

                            <th scope="row" style="width: 100px"><% = item.Cabaña.complejo.Nombre %></th>

                            <th scope="row" style="width: 100px"><% = item.CantPersonas %></th>

                            <th scope="row" style="width: 60px"><% = %></th>

                            <th scope="row" style="width: 60px"><% = item.Importe%></th>

                            <th scope="row"><a class="btn btn-secondary" href="ModificarUsuario.aspx?idUsuario=<% = item.Id.ToString() %>">Modificar</a></th>

                        </td>
                    </tr>

                    <% } %>
                </table>
            </div>
        </div>
    </div>







</asp:Content>
