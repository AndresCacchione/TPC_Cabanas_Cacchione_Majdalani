<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_CacchioneMajdalani.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h2><%: Title %>.</h2>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button Class="btn btn-primary mr-auto ml-auto" ID="Button1" runat="server" Text="Button" />
    </div>
</asp:Content>
