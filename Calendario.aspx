<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendario.aspx.cs" Inherits="TPC_CacchioneMajdalani.Calendario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc3" %>
<asp:TextBox ID="txtCalendarExtender" runat="server"></asp:TextBox> 

<asp:UpdatePanel runat="server">
<ContentTemplate>
    <asp:Calendar ID="Calendar1" OnSelectionChanged="Calendar1_SelectionChanged" runat="server" BackColor="#FFCCCC" BorderColor="Black" BorderStyle="Double" CellSpacing="2" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="258px" NextPrevFormat="ShortMonth" Width="915px" BorderWidth="2px" CaptionAlign="Top" CellPadding="10" FirstDayOfWeek="Monday" SelectionMode="DayWeekMonth" ShowGridLines="True">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" HorizontalAlign="Center" VerticalAlign="Middle" />
        <DayStyle BackColor="#CCCCCC" HorizontalAlign="Center" VerticalAlign="Middle" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <SelectorStyle Font-Bold="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" Font-Strikeout="False" HorizontalAlign="Center" VerticalAlign="Middle" />
        <TodayDayStyle BackColor="#999999" ForeColor="White" Font-Bold="False" HorizontalAlign="Center" VerticalAlign="Middle" />
        <WeekendDayStyle HorizontalAlign="Center" VerticalAlign="Middle" />  
    </asp:Calendar>

</ContentTemplate>
</asp:UpdatePanel>

    <asp:Button Text="Borrar selección" ID="BotonBorrarSeleccion" OnClick="BotonBorrarSeleccion_Click" runat="server" />



</asp:Content>
