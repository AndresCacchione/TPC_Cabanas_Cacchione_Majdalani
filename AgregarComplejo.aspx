<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarComplejo.aspx.cs" Inherits="TPC_CacchioneMajdalani.AgregarComplejo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>

    <input placeholder="Nombre" id="TxtNombreAgregarComplejo" type="text"   name="name" value="" required="" />
    <input placeholder="1512345678" id="TxtTelefonoAgregarComplejo" type="tel"    name="name" value="" required="" />
    <input placeholder="Url Imagen" id="TxtUrlImagenAgregarComplejo"type="url"    name ="name" value="" required=""  />
    <input placeholder="Ubicacion" id="TxtUbicacionAgregarComplejo"type="text"   name="name" value="" required="" />
    <input placeholder="Provincia" id="TxtUbicacionProvinciaAgregarComplejo"type="text"   name="name" value="" required="" />
    <input placeholder="email@email.com" id="TxtEmailAgregarComplejo"type="email"  name="name" value="" required="" />
    <input placeholder="75" id="TxtPrecioFeriadoAgregarComplejo" type="tel" name="number" value="" required="" />
        <asp:Button  class="btn btn-success mr-auto ml-auto" id="BtnAgregarComplejo" Value="Agregar" runat="server" />
    </div>
    
    








</asp:Content>
