<%@ Page Title="Contáctenos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TPC_CacchioneMajdalani.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form>
        <div class="container" style="padding: 2%">
            <div class="form-group">
                <label style="font-size: medium; font-weight: 600;" for="InputMail">Tu dirección de email de respuesta</label>
                <input type="email" class="form-control" id="InputMail" placeholder="mail@mail.com" runat="server" required>
            </div>
            <div class="form-group">
                <label style="font-size: medium; font-weight: 600;" for="txtBoxAsuntoMail">Motivo de contacto</label>
                <asp:TextBox class="form-control" runat="server" ID="txtBoxAsunto" MaxLength="100" required="" />
            </div>
            <div class="form-group">
                <label style="font-size: medium; font-weight: 600;" for="TextAreaCuerpoMail">Redactar mensaje</label>
                <textarea class="form-control" id="TextAreaCuerpoMail" rows="5" runat="server" required></textarea>
                <div class="container" style="margin: 3% 0% 0% 0%">
                    <asp:Button ID="btnEnviarEmail" class="btn btn-success mr-auto ml-auto" runat="server" OnClick="btnEnviarEmail_Click" Text="Enviar Mensaje" Width="132px" /><br />

                </div>
            </div>
    </form>

    </div>

    <asp:Label Style="font-size: medium; font-weight: 600;" ID="Resultado" runat="server" Text="" />

</asp:Content>
