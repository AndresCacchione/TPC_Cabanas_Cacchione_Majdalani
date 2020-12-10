<%@ Page Title="VerReservas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerReservas.aspx.cs" Inherits="TPC_CacchioneMajdalani.VerReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:DropDownList AutoPostBack="true" OnTextChanged="DDLReservaEstados_TextChanged" ID="DDLReservaEstados" runat="server">
                <asp:ListItem Text="Pendientes" Value="1" />
                <asp:ListItem Text="Confirmadas" Value="2" />
                <asp:ListItem Text="Canceladas" Value="3" />
            </asp:DropDownList>

            <asp:DropDownList AutoPostBack="true" OnTextChanged="DDLReservaVigencia_TextChanged" ID="DDLReservaVigencia" runat="server">
                <asp:ListItem Text="Vigente" Value="1" />
                <asp:ListItem Text="Caduca" Value="2" />
            </asp:DropDownList>
        </ContentTemplate>
    </asp:UpdatePanel>

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
                              <%if (Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20)
                            { %>
                                      <%if (item.Estado == 1) { %><th scope="row" style="width: 60px"> <a href="ModificarReserva.aspx?idReserva=<%=item.ID.ToString()%>&Estado<%=item.Estado %>" class="btn btn-warning mr-auto ml-auto">Pendiente</a>  </th><%} %>
                                      <%if (item.Estado == 2) { %><th scope="row" style="width: 60px"> <a href="ModificarReserva.aspx?idReserva=<%=item.ID.ToString()%>&Estado<%=item.Estado %>" class="btn btn-success mr-auto ml-auto">Confirmada</a> </th><%} %>
                                      <%if (item.Estado == 3) { %><th scope="row" style="width: 60px"> <a href="ModificarReserva.aspx?idReserva=<%=item.ID.ToString()%>&Estado<%=item.Estado %>" class="btn btn-danger mr-auto ml-auto">Cancelada</a>  </th><%} %>
                                 <th scope="row" style="width: 60px"> <a href="ModificarReserva.aspx?idReserva=<%=item.ID.ToString()%>" class="btn btn-secondary mr-auto ml-auto">Modificar</a>  </th>
                            <%} %>

                              <%if (Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso == 10)
                                  { %>
                                      <%if (item.Estado == 1) { %><th scope="row" style="width: 60px">      <asp:Button  class="btn btn-warning mr-auto ml-auto" Text="Pendiente" runat="server" /> </th><%} %>
                                      <%if (item.Estado == 2) { %><th scope="row" style="width: 60px">      <asp:Button  class="btn btn-success mr-auto ml-auto" Text="Confirmada" runat="server" /> </th><%} %>
                                      <%if (item.Estado == 3) { %><th scope="row" style="width: 60px">      <asp:Button  class="btn btn-danger mr-auto ml-auto" Text="Cancelada" runat="server" />  </th><%} %>
                     
                           
                            <%} %>
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
