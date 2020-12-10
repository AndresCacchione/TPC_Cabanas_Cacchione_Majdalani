<%@ Page Title="Cabañas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cabañas.aspx.cs" Inherits="TPC_CacchioneMajdalani.Cabañas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                <hr />

    <div>

        <h2><%: Title %>.</h2>

        <asp:TextBox ID="TxtBuscarCabaña" runat="server" CssClass="d-inline-flex, border-light" MaxLength="120"></asp:TextBox>
        <asp:Button Class="btn btn-primary mr-auto ml-auto" ID="BtnBuscarCabaña" runat="server" Text="Buscar" />
        <%if (Convert.ToInt64(Request.QueryString["idComplejo"]) != 0 && Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20)
            { %>
        <a href="AgregarModificarCabaña.aspx?idComplejo=<%=Convert.ToInt64(Request.QueryString["idComplejo"]).ToString()%>" class="btn btn-success mr-auto ml-auto">Agregar Cabaña</a>

        <% } %>
    </div>




     <div class="container">
        <div class="row">
            <div class="col">
                <table class="table">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col" style="width: 300px">Imagen Cabaña</th>
                            <th scope="col" style="width: 100px">Complejo</th>
                            <th scope="col" style="width: 100px">Precio por dia</th>
                            <th scope="col" style="width: 100px">Capacidad</th>
                            <th scope="col" style="width: 100px"></th>
                            <th scope="col" style="width: 60px"></th>
                            <th scope="col" style="width: 60px"></th>
                            <th scope="col" style="width: 60px"></th>
                        </tr>
                    </thead>
                    <%foreach (Dominio.Cabaña item in ListaCabañasLocal)
                        { %>
                    <tr>
                        <td style="width: 300px">
                            <img src="<% = item.Imagen %>" style="width: 300px; height: inherit;" alt="No posee imagen cargada">

                            <th scope="row" style="width: 120px"><% = item.complejo.Nombre %></th>

                            <th scope="row" style="width: 100px"><% = item.PrecioDiario %></th>

                            <th scope="row" style="width: 100px"><% = item.Capacidad %></th>

                            <th scope="row" style="width: 100px"><a href="DetalleCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-primary mr-auto ml-auto">Detalle </a></th>

                            <th scope="row" style="width: 100px"><a href="Reservas.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-success mr-auto ml-auto">Reservar</a></th>
                                <%if (Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20)
                { %>
                       <th scope="row" style="width: 60px"><a href="AgregarModificarCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-secondary mr-auto ml-auto">Modificar</a> </th>

                            <th scope="row" style="width: 60px"><a href="EliminarCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-danger mr-auto ml-auto">Eliminar</a> </th>



            <% } %>
                       
                       

                        </td>
                    </tr>

                    <% } %>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
