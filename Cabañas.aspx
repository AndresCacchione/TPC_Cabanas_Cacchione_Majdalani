<%@ Page Title="Cabañas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cabañas.aspx.cs" Inherits="TPC_CacchioneMajdalani.Cabañas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <hr />

    <div>

        <h2><%: Title %>.</h2>

        <asp:TextBox ID="TxtBuscarCabaña" runat="server" CssClass="d-inline-flex, border-light" MaxLength="120"></asp:TextBox>
        <asp:Button Class="btn btn-primary mr-auto ml-auto" ID="BtnBuscarCabaña" runat="server" Text="Buscar" />
     <%--   <%if (Convert.ToInt64(Request.QueryString["idComplejo"]) != 0)
            { %>--%>
                <%if (Convert.ToInt64(Request.QueryString["idComplejo"]) != 0 && Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20 )
                { %>
        <a href="AgregarModificarCabaña.aspx?idComplejo=<%=Convert.ToInt64(Request.QueryString["idComplejo"]).ToString()%>" class="btn btn-success mr-auto ml-auto">Agregar Cabaña</a>
          
            <% } %>   
       <%-- <%
            } %>--%>
    </div>


    <%foreach (Dominio.Cabaña item in ListaCabañasLocal)
        {%>

    <table class="table">
        <tr>
            <td>
                <img src="<%=item.Imagen%>" class="card-img-top" alt="..." style="width: 300px;"></td>
            <td><%=item.complejo.Nombre%></td>
            <td><%=item.PrecioDiario%> </td>
            <td><%=item.Capacidad%> </td>
            <td><a href="DetalleCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-primary mr-auto ml-auto">Detalle </a></td>
            <td><a href="Reservas.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-success mr-auto ml-auto">Reservar</a> </td>
            <%if (Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20 )
                { %>
            <td><a href="AgregarModificarCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-secondary mr-auto ml-auto">Modificar</a> </td>
            <td><a href="EliminarCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-danger mr-auto ml-auto">Eliminar</a> </td>

            <% } %>
        </tr>
    </table>
    <%}
    %>
</asp:Content>
