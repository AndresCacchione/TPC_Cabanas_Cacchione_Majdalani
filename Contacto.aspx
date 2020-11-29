<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TPC_CacchioneMajdalani.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form>
        <div class="form-group">
            <label for="InputMail">Tu dirección de email de respuesta</label>
            <input type="email" class="form-control" id="InputMail" placeholder="mail@mail.com" runat="server" required>
        </div>
        <div class="form-group">
            <label for="txtBoxAsuntoMail">Motivo de contacto</label>
            <asp:TextBox class="form-control" runat="server" id="txtBoxAsunto" MaxLength="100" required=""/>
        </div>
        <div class="form-group">
            <label for="TextAreaCuerpoMail">Redactar mensaje</label>
            <textarea class="form-control" id="TextAreaCuerpoMail" rows="5" runat="server" required></textarea>
            <asp:Button ID="btnEnviarEmail" class="btn btn-success mr-auto ml-auto" runat="server" OnClick="btnEnviarEmail_Click" Text="Enviar Mensaje" Width="132px" /><br />
        </div>
    </form>

    <asp:Label ID="Resultado" runat="server" Text="" />

</asp:Content>
