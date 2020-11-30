<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarReserva.aspx.cs" Inherits="TPC_CacchioneMajdalani.ModificarReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputFechaIngreso">Fecha de Ingreso</label>
            <input type="date" class="form-control" id="FechaIngreso" placeholder="DD/MM/AAAA" required runat="server">
        </div>
        <div class="form-group col-md-6">
            <label for="inputFechaEgreso">Fecha de Egreso</label>
            <input type="date" class="form-control" id="FechaEgreso" placeholder="DD/MM/AAAA" required runat="server">
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputCantPersonas">Cantidad de personas</label>
            <input type="number" class="form-control" id="CantidadPersonas" placeholder="Cantidad" required runat="server">

        </div>

        <div class="form-group col-md-6">
            <label for="inputFechaReserva">Fecha de reserva</label>
            <input type="date" class="form-control" id="FechaReserva" placeholder="DD/MM/AAAA" required runat="server">
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputImporte">Importe </label>
            <input type="number" class="form-control" id="Importe" placeholder="$1.000.000" required runat="server" />
        </div>
        <div class="form-group col-md-6">
            <label for="inputEstado">Estado </label>
            <input type="text" class="form-control" id="Estado" placeholder="Estado" required runat="server" />
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputIdReservaOriginal">ID reserva original</label>
            <input type="number" class="form-control" id="IDReservaOriginal" placeholder="ID Reserva Original" required runat="server" />
        </div>    
    </div>
    <asp:Button ID="btnModificarDatos" OnClick="btnModificarDatos_Click" Text="Actualizar datos" class="btn btn-success mr-auto ml-auto" runat="server" />
</asp:Content>
