<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="TPC_CacchioneMajdalani.Reservas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <asp:Label runat="server" ID="LblCalendario"></asp:Label>

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

            <asp:Button Text="Borrar selección" ID="BotonBorrarSeleccion" OnClick="BotonBorrarSeleccion_Click" runat="server" />

            <div class="form-row">
                <div class="form-group col-md-6">
                    <label>Fecha de Ingreso</label>
                    <asp:TextBox MaxLength="10" AutoPostBack="true" ReadOnly="true" type="text" class="form-control" ID="FechaDeIngreso" runat="server" />
                    <label>Hora de Checkin</label>
                    <asp:TextBox ReadOnly="true" AutoPostBack="true" ID="HoraIngreso" class="form-control" type="text" runat="server" />
                </div>
                <div class="form-group col-md-6">
                    <label>Fecha de Egreso</label>
                    <asp:TextBox MaxLength="10" AutoPostBack="true" ReadOnly="true" runat="server" type="text" class="form-control" ID="FechaDeEgreso" />
                    <label>Hora de Checkout</label>
                    <asp:TextBox ReadOnly="true" AutoPostBack="true" ID="HoraEgreso" class="form-control" type="text" runat="server" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label>Cantidad de personas</label>
                    <asp:TextBox AutoPostBack="true" runat="server" type="number" class="form-control" ID="CantidadDePersonas" placeholder="Cantidad" required="" />
                    <asp:RangeValidator ErrorMessage="Ingreso inválido" MinimumValue="1" Type="Integer" MaximumValue="250" ControlToValidate="CantidadDePersonas" ForeColor="Red" runat="server" />
                </div>
                <div class="form-group col-md-6">
                    <label>Importe</label>
                    <asp:TextBox ReadOnly="true" AutoPostBack="true" ID="importes" class="form-control" type="text" runat="server" />

                </div>
            </div>

            <asp:Button ID="Reservar" OnClick="Reservar_Click" Text="Reservar" class="btn btn-success mr-auto ml-auto" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
