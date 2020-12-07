<%@ Page Title="Complejos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Complejos.aspx.cs" Inherits="TPC_CacchioneMajdalani.Complejo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <hr />

    <div>
        <h2><%: Title %>.</h2>
        <asp:TextBox ID="TxtBuscarComplejo" CssClass="d-inline-flex, border-light" MaxLength="120" runat="server"></asp:TextBox>
        <asp:Button Class="btn btn-primary mr-auto ml-auto" OnClick="BtnBuscarComplejo_Click" ID="BtnBuscarComplejo" runat="server" Text="Buscar" />
         <%if (Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20)
                { %>
        <a href="AgregarModificarComplejo.aspx" class="btn btn-success mr-auto ml-auto">Agregar</a>
      
            <% } %>
        <%if (UsuarioActual != null && UsuarioActual.NivelAcceso >= 20)
            {%>
        <a href="AdministradoresDeComplejos.aspx?IDUsuario=<%=UsuarioActual.Id.ToString() %>" class="btn btn-primary mr-auto ml-auto">Lista de Administradores</a>
        <%}%>
    </div>


    <%foreach (Dominio.Complejo item in ListaComplejosLocal)
        {%>

    <table class="table">
        <tr>
            <td>
                <img src="<%=item.Imagen%>" class="card-img-top" alt="..." style="width: 300px;"></td>
            <td><%=item.Nombre%></td>
            <td><%=item.Ubicacion%> </td>
            <td><a href="DetalleComplejo.aspx?idComplejo=<%=item.ID.ToString()%>" class="btn btn-primary mr-auto ml-auto">Detalle</a></td>
            <td><a href="Cabañas.aspx?idComplejo=<%=item.ID.ToString()%>" class="btn btn-primary mr-auto ml-auto">Cabañas</a></td>
            <%if (UsuarioActual != null && UsuarioActual.NivelAcceso >= 20 && ((List<Dominio.Complejo>)Session["listaComplejos"]).Count() != 0)
                { %>
            <td><a href="AgregarModificarComplejo.aspx?IdComplejo=<%=item.ID.ToString()%>" class="btn btn-secondary mr-auto ml-auto">Modificar</a></td>
            <td><a href="EliminarComplejo.aspx?idComplejo=<%=item.ID.ToString()%>" class="btn btn-danger mr-auto ml-auto">Eliminar</a></td>

            <% } %>
        </tr>
    </table>
    <%}
    %>
</asp:Content>
