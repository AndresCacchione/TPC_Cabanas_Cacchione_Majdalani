<%@ Page Title="Cabañas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cabañas.aspx.cs" Inherits="TPC_CacchioneMajdalani.Cabañas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <hr />
    
    <div>
       <%--METER TODO EN LA MISMA LINEA --%>
        <h2><%: Title %>.</h2>
    <asp:TextBox ID="TxtBuscarCabaña" runat="server"></asp:TextBox>
    <asp:Button Class="btn btn-primary mr-auto ml-auto" ID="BtnBuscarCabaña" runat="server" Text="Buscar" />
    <%if (Convert.ToInt64(Request.QueryString["idComplejo"]) != 0)
        { %>
        <a href="AgregarModificarCabaña.aspx?idComplejo=<%=Convert.ToInt64(Request.QueryString["idComplejo"]).ToString()%>" class="btn btn-success mr-auto ml-auto">Agregar Cabaña</a>
        <%
        } %>
  
        </div>
    
           <div class="row align-content-md-between">
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
                                <a href="#" class="btn btn-secondary mr-auto ml-auto">Modificar</a>
                                <a href="#" class="btn btn-danger mr-auto ml-auto">Eliminar</a>
                                <%-- <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p> --%>
                            </div>
                        </div>
                    </div>
               <%}
                 %>
           
           </div>






</asp:Content>
