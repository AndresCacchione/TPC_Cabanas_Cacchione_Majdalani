<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="TPC_CacchioneMajdalani.Mail" %>

<!DOCTYPE html>
<link href="Estilos.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="head1" runat="server">
    <title>
        Página de envío de Email
    </title>
</head>
<body>
    <form id="form1" runat="server">
        Emisor del mensaje: <asp:TextBox ID="txtEmisor" runat="server" /><br />
        Destinatario: <asp:TextBox ID="txtDestinatario" runat="server" /><br />
        Asunto: <asp:TextBox ID="txtAsunto" runat="server" /><br />
        Cuerpo del mensaje:<br />
        <asp:TextBox ID="txtBody" runat="server" Height="150px" TextMode="MultiLine" />
        <asp:Button ID="btnEnviarMail" runat="server" OnClick="btnEnviarMail_Click" Text="Enviar Mensaje" /><br />
        <asp:Label ID="Resultado" runat="server" Text="" />
    </form>
</body>
</html>
