<%@ Page Title="Cabañas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cabañas.aspx.cs" Inherits="TPC_CacchioneMajdalani.Cabañas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <hr />
    <h2><%: Title %>.</h2>
       
           <div class="row align-content-md-between">
           <%foreach (Dominio.Cabaña item in ListaCabañasLocal)
                       {%>  
                          <div class="col-md-4">
                        <div class="card mt-4" style="width:20rem;" >
                             <%--<img src="<%=item.Imagen%>" class="card-img-top" alt="...">--%>
                            <div class="card-body" style="background-color:#6E9038;">
                                <h5 class="card-title">Ambientes: <%=item.Ambientes%></h5>
                                <h5 class="card-title">Capacidad: <%=item.Capacidad%></h5>
                                 <a href="DetalleCabaña.aspx?idCabaña=<%=item.Id.ToString()%>" class="btn btn-primary mr-auto ml-auto"> Detalle </a>
                                <%-- <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p> --%>
                            </div>
                        </div>
                    </div>
               <%}
                 %>
           
           </div>






</asp:Content>
