<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="TPC_CacchioneMajdalani.Reservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<asp:TextBox ID="txtCalendarExtender" runat="server"></asp:TextBox> 

<asp:UpdatePanel runat="server">
<ContentTemplate>
    <asp:Calendar OnDayRender="Calendar1_DayRender" ID="Calendar1" OnSelectionChanged="Calendar1_SelectionChanged" runat="server" BackColor="#FFCCCC" BorderColor="Black" BorderStyle="Double" CellSpacing="2" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="258px" NextPrevFormat="ShortMonth" Width="915px" BorderWidth="2px" CaptionAlign="Top" CellPadding="10" FirstDayOfWeek="Monday" SelectionMode="DayWeekMonth" ShowGridLines="True">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" HorizontalAlign="Center" VerticalAlign="Middle" />
        <DayStyle BackColor="#66FF66" HorizontalAlign="Center" VerticalAlign="Middle" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <SelectorStyle Font-Bold="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" Font-Strikeout="False" HorizontalAlign="Center" VerticalAlign="Middle" />
        <TodayDayStyle BackColor="#999999" ForeColor="SkyBlue" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Middle" />
        <WeekendDayStyle HorizontalAlign="Center" VerticalAlign="Middle" />  
    </asp:Calendar>

</ContentTemplate>
</asp:UpdatePanel>


    <asp:Button Text="Borrar selección" ID="BotonBorrarSeleccion" OnClick="BotonBorrarSeleccion_Click" runat="server" />



    
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputFechaIngreso">Fecha de Ingreso</label>
            <input type="date" class="form-control" id="FechaIngreso" placeholder="DD/MM/AAAA" required runat="server">
        </div>
        <div class="form-group col-md-6">
            <label for="inputFechaEgreso">Fecha de Egreso</label>
            <input type="date" class="form-control" id="FechaEgreso" placeholder="DD/MM/AAAA" required runat="server">
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputCantPersonas">Cantidad de personas</label>
            <input type="number" class="form-control" id="CantidadPersonas" placeholder="Cantidad" required runat="server">
        </div>

        <div class="form-group col-md-6">
            <label for="inputFechaReserva">Fecha de reserva</label>
            <%--         <input type="date" class="form-control" id="FechaReserva" placeholder="DD/MM/AAAA" required runat="server">
            --%>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputImporte">Importe </label>
            <%--         <input type="number" class="form-control" id="Importe" placeholder="$1.000.000" required runat="server" />
            --%>
        </div>
        <div class="form-group col-md-6">
            <label for="inputEstado">Estado </label>
            <%--        <input type="text" class="form-control" id="Estado" placeholder="Estado" required runat="server" />
            --%>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputIdReservaOriginal">ID reserva original</label>
            <%--       <input type="number" class="form-control" id="IDReservaOriginal" placeholder="ID Reserva Original" required runat="server" />
            --%>
        </div>
    </div>
    <asp:Button ID="Reservar" OnClick="Reservar_Click" Text="Reservar" class="btn btn-success mr-auto ml-auto" runat="server" />
</asp:Content>
