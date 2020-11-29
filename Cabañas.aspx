<%@ Page Title="Cabañas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cabañas.aspx.cs" Inherits="TPC_CacchioneMajdalani.Cabañas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <hr />
    
    <div>
       <%--METER TODO EN LA MISMA LINEA --%>
    <h2><%: Title %>.</h2>
     <%--   <%if (Convert.ToInt64(Session["ComplejoActual"]) != 0)
              { %>
                <ul>
                    <li><h3> Complejo: <%=ListaCabañasLocal.First().complejo.Nombre %></h3></li>
                    <li><h3> Ubicacion: <%=ListaCabañasLocal.First().complejo.Ubicacion %> </h3></li>
                </ul>
            <%} %>--%>
    <asp:TextBox ID="TxtBuscarCabaña" runat="server" CssClass="d-inline-flex, border-light" MaxLength="120"></asp:TextBox>
    <asp:Button Class="btn btn-primary mr-auto ml-auto" ID="BtnBuscarCabaña" runat="server" Text="Buscar" />
    <%if (Convert.ToInt64(Request.QueryString["idComplejo"]) != 0)
        { %>
        <a href="AgregarModificarCabaña.aspx?idComplejo=<%=Convert.ToInt64(Request.QueryString["idComplejo"]).ToString()%>" class="btn btn-success mr-auto ml-auto">Agregar Cabaña</a>
        <%
        } %>
    </div>
    
         <%--  <div class="row align-content-md-between">
           <%foreach (Dominio.Cabaña item in ListaCabañasLocal)
                       {%>  
                          <div class="col-md-4">
                        <div class="card mt-4" style="width:20rem;" >
                             <img src="<%=item.Imagen%>" class="card-img-top" alt="...">
                            <div class="card-body" style="background-color:#6E9038;">
                                <ul>
                                    
                                    <li><h5 class="card-title">Complejo : <%=item.complejo.Nombre%></h5></li>                                                                                                     <li><h5 class="card-title">Ubicacion: <%=item.complejo.Ubicacion%></h5></li>
                                    <li><h5 class="card-title">Por dia  : $ <%=item.PrecioDiario%></h5></li>
                                    <li><h5 class="card-title">Personas : <%=item.Capacidad%></h5> </li>
                                
                                </ul>
                                <a href="DetalleCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-primary mr-auto ml-auto"> Detalle </a>
                                <a href="#" class="btn btn-success mr-auto ml-auto">Reservar</a>
                                <a href="AgregarModificarCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-secondary mr-auto ml-auto">Modificar</a>
                                <a href="EliminarCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-danger mr-auto ml-auto">Eliminar</a>
                                <%-- <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p> --%>
              <%--              </div>
                        </div>
                    </div>
               <%}
                 %>
           
           </div>--%>


    <%foreach (Dominio.Cabaña item in ListaCabañasLocal)
        {%>

    <table class="table">
        <tr>
            <td><img src="<%=item.Imagen%>" class="card-img-top" alt="..." style="width:300px;"></td>
            <td><%=item.complejo.Nombre%></td> 
            <td><%=item.PrecioDiario%> </td>
            <td><%=item.Capacidad%> </td>
            <td><a href="DetalleCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-primary mr-auto ml-auto">Detalle </a></td>
            <td><a href="Reservas.aspx?idCabaña=<%=item.Id.ToString()%>&idUsuario=<%=Session[Session.SessionID+"userSession"]%>" class="btn btn-success mr-auto ml-auto">Reservar</a> </td>
            <td><a href="AgregarModificarCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-secondary mr-auto ml-auto">Modificar</a> </td>
            <td><a href="EliminarCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-danger mr-auto ml-auto">Eliminar</a> </td>
        </tr>
    </table>
    <%}
    %>






</asp:Content>
