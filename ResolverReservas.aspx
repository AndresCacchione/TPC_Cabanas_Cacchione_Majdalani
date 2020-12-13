<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResolverReservas.aspx.cs" Inherits="TPC_CacchioneMajdalani.ResolverReservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                  
                    <tr>
                        <td style="width: 140px">

                            <img src="<% = Reserva.Cabaña.Imagen %>" style="width: 100px; height: inherit;" alt="No posee imagen cargada">

                            <th scope="row" style="width: 100px"><% =Reserva.Cliente.NombreUsuario %></th>
                                                                     
                            <th scope="row" style="width: 120px"><% =Reserva.FechaCreacionReserva %></th>
                                                                     
                            <th scope="row" style="width: 100px"><% =Reserva.Cabaña.complejo.Nombre %></th>
                                                                     
                             <th scope="row" style="width: 60px"><% =Reserva.Cabaña.complejo.Ubicacion %></th>
                                                                     
                            <th scope="row" style="width: 100px"><% =Reserva.Cabaña.complejo.Mail %></th>
                                                                     
                            <th scope="row" style="width: 100px"><% =Reserva.FechaIngreso.ToShortDateString() %> HS : <%=Reserva.Cabaña.CheckIn.TimeOfDay %> </th>
                                                                     
                            <th scope="row" style="width: 100px"><% =Reserva.FechaEgreso.ToShortDateString() %> HS : <%=Reserva.Cabaña.CheckOut.TimeOfDay %> </th>
                                                                     
                            <th scope="row" style="width: 100px"><% =Reserva.CantPersonas %></th>
                                                                     
                             <th scope="row" style="width: 60px"><% =Reserva.Importe%></th>
                         
                            </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="form-group">
        <label for="txtBoxMotivoCambio">Motivo cambio de estado:</label>
        <asp:TextBox CssClass="form-control" runat="server" id="txtBoxMotivoCambio" MaxLength="255" required=""/>
    </div>
               <%if(Convert.ToByte(Request.QueryString["Estado"])==1){ %>
    <asp:Button ID="btnConfirmada" Onclick="btnConfirmada_Click" class="btn btn-success mr-auto ml-auto" Text="Confirmada" runat="server" />
    <asp:Button ID="btnCancelada" OnClick="btnCancelada_Click" class="btn btn-danger mr-auto ml-auto" Text="Cancelada" runat="server" />
                  <%} %>
            <%if(Convert.ToByte(Request.QueryString["Estado"])==2){ %>
    <asp:Button ID="Button2" OnClick="btnCancelada_Click" class="btn btn-danger mr-auto ml-auto" Text="Cancelada" runat="server" />
                  <%} %>
                   <%if(Convert.ToByte(Request.QueryString["Estado"])==3){ %>
    <p>No se puede modificar el Estado de la Reserva </p>
    <%} %>


</asp:Content>
