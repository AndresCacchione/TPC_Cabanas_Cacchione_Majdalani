<%@ Page Title="VerReservas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerReservas.aspx.cs" Inherits="TPC_CacchioneMajdalani.VerReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <asp:DropDownList OnSelectedIndexChanged="DDLReservaEstados_SelectedIndexChanged" ID="DDLReservaEstados" runat="server">
        <asp:ListItem Text="Pendientes" Value="1" />
        <asp:ListItem Text="Confirmadas" Value="2" />
        <asp:ListItem Text="Canceladas" Value="3" />
    </asp:DropDownList>

    <asp:DropDownList OnSelectedIndexChanged="DDLReservaVigencia_SelectedIndexChanged" ID="DDLReservaVigencia" runat="server">
        <asp:ListItem Text="Vigente" Value="1" />
        <asp:ListItem Text="Caduca" Value="2" />
    </asp:DropDownList>


    <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col" style="width: 120px">Imagen de Cabaña</th>
                            <th scope="col" style="width: 100px">Nombre de Usuario </th>
                            <th scope="col" style="width: 100px">Fecha Reserva</th>
                            <th scope="col" style="width: 100px">Nombre Complejo</th>
                            <th scope="col" style="width: 60px">Ubicación del Complejo </th>
                            <th scope="col" style="width: 100px">Mail del Administrador </th>
                            <th scope="col" style="width: 100px">Fecha Ingreso</th>
                            <th scope="col" style="width: 100px">Fecha Egreso</th>
                            <th scope="col" style="width: 60px">Cantidad huespedes</th>
                            <th scope="col" style="width: 60px">Coste reserva</th>
                            <th scope="col" style="width: 100px">Estado de Reserva</th>
                        </tr>
                    </thead>
                    <% if (ListaDeReservas.Count() != 0)
                            foreach (Dominio.Reserva item in ListaDeReservas)
                            { %>
                    <tr>
                        <td style="width: 140px">

                            <img src="<% = item.Cabaña.Imagen %>" style="width: 100px; height: inherit;" alt="No posee imagen cargada">

                            <th scope="row" style="width: 100px"><% = item.Cliente.NombreUsuario %></th>

                            <th scope="row" style="width: 120px"><% = item.FechaCreacionReserva %></th>

                            <th scope="row" style="width: 100px"><% = item.Cabaña.complejo.Nombre %></th>

                            <th scope="row" style="width: 60px"><% = item.Cabaña.complejo.Ubicacion %></th>

                            <th scope="row" style="width: 100px"><% = item.Cabaña.complejo.Mail %></th>

                            <th scope="row" style="width: 100px"><% = item.FechaIngreso.ToShortDateString() %> HS : <%=item.Cabaña.CheckIn.TimeOfDay %> </th>

                            <th scope="row" style="width: 100px"><% = item.FechaEgreso.ToShortDateString() %> HS : <%=item.Cabaña.CheckOut.TimeOfDay %> </th>

                            <th scope="row" style="width: 100px"><% = item.CantPersonas %></th>

                            <th scope="row" style="width: 60px"><% = item.Importe%></th>

                            <th scope="row" style="width: 60px"><% = DDLReservaEstados.SelectedItem.Text%></th>

                        </td>
                    </tr>

                    <% }
                        else
                        {
                    %>
                    <asp:Label Text="Sin resultados, intente con otra opción de las listas" runat="server" />
                    <%} %>
                </table>
            </div>
        </div>
    </div>







</asp:Content>
