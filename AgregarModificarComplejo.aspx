<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarModificarComplejo.aspx.cs" Inherits="TPC_CacchioneMajdalani.AgregarModificarComplejo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form action="/Home/Index" method="post">
  <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputNombre">Nombre</label>
         <input type="text" class="form-control" id="Nombre" placeholder="Nombre" required runat="server">
    </div>
    <div class="form-group col-md-6">
      <label for="inputImagen">URL de la Imagen</label>
<<<<<<< HEAD
      <input type="text" class="form-control" id="Imagen" placeholder="InserteUrl" required runat="server">
=======
      <input type="url" class="form-control" id="Imagen" name="Imagen" placeholder="URL de la imagen" required runat="server">
>>>>>>> 29b9eecb80bba6c1db466b9107b74c3daa4a4fc9
    </div>
  </div>
         <div class="form-row">
    <div class="form-group col-md-6">
      <label for="inputTelefono">Teléfono</label>
      <input type="number" class="form-control" id="Telefono" placeholder="Telefono" required runat="server">
     </div>
    <div class="form-group col-md-6">
      <label for="inputDireccion">Dirección</label>
                <input type="text" class="form-control" id="Direccion" placeholder="Direccion" required runat="server">
    </div>
  </div>
        <div class="form-row">
  <div class="form-group col-md-6">
    <label for="inputEmail">Email</label>
                     <input type="email" class="form-control" id="Email" placeholder="Email@email.com" required runat="server">
  </div>
  <div class="form-group col-md-6">
    <label for="inputAumentoFeriado">Aumento Feriado (%)</label>
<<<<<<< HEAD
       <input type="number" class="form-control" id="AumentoFeriado" placeholder="xx%" required runat="server">                   
      </div>
  </div>
=======
    <input type="number" class="form-control" id="AumentoFeriado" placeholder="XXX (%)" required runat="server">
  </div>
 
        </div>
>>>>>>> 29b9eecb80bba6c1db466b9107b74c3daa4a4fc9
  <div class="form-group">
  </div>

  <asp:Button type="submit" class="btn btn-success mr-auto ml-auto" id="BtnAgregarComplejo" OnClick="BtnAgregarComplejo_Click" Text="Agregar" runat="server" />
  <a href="Complejos.aspx" class="btn btn-primary mr-auto ml-auto">Volver</a>
    
</form>
</asp:Content>  
    
    
    
    
    
    
 
