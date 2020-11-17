<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarComplejo.aspx.cs" Inherits="TPC_CacchioneMajdalani.AgregarComplejo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <input runat="server" placeholder="Nombre" id="TxtNombreAgregarComplejo" type="text" name="name" value="" required="" />
        <input runat="server" placeholder="1512345678" id="TxtTelefonoAgregarComplejo" type="tel" name="name" value="" required=""/>
        <input runat="server" placeholder="Url Imagen" id="TxtUrlImagenAgregarComplejo" type="url" name ="name" value="" required="" />
        <input runat="server" placeholder="Ubicacion" id="TxtUbicacionAgregarComplejo" type="text" name="name" value="" required="" />
        <input runat="server" placeholder="Provincia" id="TxtUbicacionProvinciaAgregarComplejo" type="text" name="name" value="" required="" />
        <input runat="server" placeholder="email@email.com" id="TxtEmailAgregarComplejo" type="email" name="name" value="" required="" />
        <input runat="server" placeholder="75" id="TxtPrecioFeriadoAgregarComplejo" type="tel" name="number" value="" required="" />
        <asp:Button  class="btn btn-success mr-auto ml-auto" id="BtnAgregarComplejo" OnClick="BtnAgregarComplejo_Click" Value="Agregar" runat="server" />
    </div>
    
    








</asp:Content>
