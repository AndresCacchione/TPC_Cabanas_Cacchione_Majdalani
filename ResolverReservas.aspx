<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResolverReservas.aspx.cs" Inherits="TPC_CacchioneMajdalani.ResolverReservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="padding: 2% 0% 0% 0%">
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
    </div>
    <%if (Convert.ToByte(Request.QueryString["Estado"]) == 1)
        { %>
    <asp:Button ID="btnConfirmada" OnClick="btnConfirmada_Click1" class="btn btn-success mr-auto ml-auto" Text="Confirmada" runat="server" />
    <asp:Button ID="btnCanceladaPendiente" data-toggle="modal" data-target="#modalCancelar" class="btn btn-danger mr-auto ml-auto" Text="Cancelada" runat="server" />
    <%} %>
    <%if (Convert.ToByte(Request.QueryString["Estado"]) == 2)
        { %>
    <asp:Button ID="btnCanceladaConfirmada" data-toggle="modal" data-target="#modalCancelar" class="btn btn-danger mr-auto ml-auto" Text="Cancelada" runat="server" />
    <%} %>
    <%if (Convert.ToByte(Request.QueryString["Estado"]) == 3)
        { %>
    <p>No se puede modificar el Estado de la Reserva </p>
    <%} %>

    <div class="modal fade" id="modalCancelar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Motivo de la cancelación </h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="txtMotivo" />
                    <asp:RequiredFieldValidator ErrorMessage="Motivo requerido" ControlToValidate="txtMotivo" ForeColor="Red" runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="Describir motivo entre 20 y 100 caracteres" ControlToValidate="txtMotivo" ValidationExpression=".{20,100}$" runat="server" />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCancelarReserva" runat="server" type="button" class="btn btn-primary" Text="Confirmar cancelación" OnClick="btnCancelarReserva_Click" />
                    <asp:Button ID="btnCancelar" runat="server" type="button" class="btn btn-secondary" data-dismiss="modal" Text="Volver" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>
