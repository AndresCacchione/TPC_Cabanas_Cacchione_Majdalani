<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TPC_CacchioneMajdalani.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <form>
  <div class="form-group">
    <label for="InputMail">Dirección de email</label>
    <input type="email" class="form-control" id="InputMail" placeholder="name@example.com" required>
  </div>

  <div class="form-group">
    <label for="TextAreaCuerpoMail">Consulta o pedido</label>
    <textarea class="form-control" id="TextAreaCuerpoMail" rows="5"></textarea>
    <asp:Button ID="btnEnviarEmail" runat="server" OnClick="btnEnviarEmail_Click" Text="Enviar Mensaje" Width="132px" /><br />
  </div>
</form>
     
<asp:Label ID="Resultado" runat="server" Text="" />

</asp:Content>
