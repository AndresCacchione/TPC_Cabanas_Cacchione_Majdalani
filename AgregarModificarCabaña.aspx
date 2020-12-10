<%@ Page Title="Agregar/Modificar Cabaña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarModificarCabaña.aspx.cs" Inherits="TPC_CacchioneMajdalani.AgregarModificarCabaña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputPrecioDiario">Precio por dia</label>
            <input type="number" class="form-control" id="PrecioDiario" placeholder="$ 1.000.000.000" required runat="server">
            <asp:CompareValidator ErrorMessage="El precio debe ser positivo" Operator="GreaterThan" ValueToCompare="0"
              Type="Double" Display="Dynamic" ControlToValidate="PrecioDiario" runat="server" ForeColor="Red" />
        </div>
        <div class="form-group col-md-6">
            <label for="inputTiempoEntreReservas">Tiempo entre reservas (%)</label>
            <input type="time" class="form-control" id="TiempoEntreReservas" placeholder="HH-MM-SS" required runat="server">
            <asp:CustomValidator ID="ValidadorTiempoEntre" OnServerValidate="ValidadorTiempoEntre_ServerValidate" ErrorMessage="El tiempo entre reservas debe ser positivo" ControlToValidate="TiempoEntreReservas" runat="server" />
        </div>

    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputCapacidad">Capacidad</label>
            <input type="number" class="form-control" id="Capacidad" placeholder="Cantidad de personas" required runat="server">
            <asp:comparevalidator errormessage="La cantidad debe ser positiva" Operator="GreaterThan" Type="Integer" Display="Dynamic"
                ValueToCompare="0" controltovalidate="Capacidad" ForeColor="Red" runat="server" />

        </div>
        <div class="form-group col-md-6">
            <label for="inputCheckIn">Hora Recepcion</label>
            <input type="time" class="form-control" id="CheckIn" placeholder="HH-MM-SS" required runat="server">
<%--            <asp:CustomValidator ID="ValidadorHrRecepcion" ErrorMessage="La hora de recepción debe ser positiva" ControlToValidate="CheckIn" OnServerValidate="" runat="server" />--%>

        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputAmbientes">Ambientes</label>
            <input type="number" class="form-control" id="Ambientes" placeholder="Cantidad de Ambientes" required runat="server">
            <asp:CompareValidator ErrorMessage="La cantidad de ambientes debe ser positiva" ControlToValidate="Ambientes"
                Operator="GreaterThan" ValueToCompare="0" Type="Integer" Display="Dynamic" ForeColor="Red" runat="server" />
        </div>
        <div class="form-group col-md-6">
            <label for="inputCheckOut">Hora Salida</label>
            <input type="time" class="form-control" id="CheckOut" placeholder="HH-MM-SS" required runat="server">
<%--            <asp:CustomValidator ID="ValidadorHrSalida" ErrorMessage="errormessage" ControlToValidate="CheckOut" OnServerValidate="" runat="server" />--%>
        </div>
    </div>

    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputImagen">URL de la Imagen</label>
            <input type="url" pattern="https?://.+" class="form-control" id="Imagen" placeholder="URL de la imagen" required runat="server">
        </div>
    </div>

    <asp:Button class="btn btn-success mr-auto ml-auto" id="BtnAgregarCabaña" onclick="BtnAgregarCabaña_Click" Text="Agregar" runat="server" />
    <a href="DetalleCabaña?idCabaña=<%=Auxiliar.Id.ToString()%>" class="btn btn-primary mr-auto ml-auto">Volver</a>

</asp:Content>
