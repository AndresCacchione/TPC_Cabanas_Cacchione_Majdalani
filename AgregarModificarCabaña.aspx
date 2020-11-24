    <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarModificarCabaña.aspx.cs" Inherits="TPC_CacchioneMajdalani.AgregarModificarCabaña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
  <div class="form-row">
      <div class="form-group col-md-6">
    <label for="inputPrecioDiario">Precio por dia</label>
    <input type="number" class="form-control" id="PrecioDiario" placeholder="$ 1.000.000.000" required runat="server">
     </div>
              <div class="form-group col-md-6">
    <label for="inputTiempoEntreReservas">Tiempo entre reservas (%)</label>
    <input type="time" class="form-control" id="TiempoEntreReservas" placeholder="HH-MM-SS" required runat="server">
  </div>
  
  </div>
         <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputCapacidad">Capacidad</label>
      <input type="number" class="form-control" id="Capacidad" placeholder="Cantidad de personas" required runat="server">
    </div>
        <div class="form-group col-md-6">
    <label for="inputCheckIn">Hora Recepcion</label>
    <input type="time" class="form-control" id="CheckIn" placeholder="HH-MM-SS" required runat="server">
  </div>
          </div>
        <div class="form-row">
  <div class="form-group col-md-6">
    <label for="inputAmbientes">Ambientes</label>
    <input type="number" class="form-control" id="Ambientes" placeholder="Cantidad de Ambientes" required runat="server">
  </div>
   <div class="form-group col-md-6">
    <label for="inputCheckOut">Hora Salida</label>
    <input type="time" class="form-control" id="CheckOut" placeholder="HH-MM-SS" required runat="server">
  </div> 
  </div>

    <div class="form-row">
     <div class="form-group col-md-6">
      <label for="inputImagen">URL de la Imagen</label>
      <input type="url" class="form-control" id="Imagen" placeholder="URL de la imagen" required runat="server">
    </div>
    </div>

  <asp:Button class="btn btn-success mr-auto ml-auto" id="BtnAgregarCabaña" onclick="BtnAgregarCabaña_Click" Text="Agregar" runat="server" />
  <a href="DetalleCabaña?idCabaña=<%=Auxiliar.Id.ToString()%>" class="btn btn-primary mr-auto ml-auto">Volver</a>
    
</asp:Content>
