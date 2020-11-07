<%@ Page Title="Complejos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Complejos.aspx.cs" Inherits="TPC_CacchioneMajdalani.Complejos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <hr />
    <h2><%: Title %>.</h2>
       
           <div class="row align-content-md-between">
           <%foreach (Dominio.Complejo item in ListaComplejosLocal)
               {%>
                    <div class="col-md-4">
                        <div class="card mt-4" style="width:20rem;" >
                             <img src="<%=item.Imagen%>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%=item.Nombre%></h5>
                                <h5 class="card-title">Telefono <%=item.Telefono%></h5>
                                 <a href="Cabañas.aspx?idComplejo=<%=item.ID.ToString()%>" class="btn btn-primary mr-auto ml-auto"> Ver Cabañas </a>
                                <%-- <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p> --%>
                            </div>
                        </div>
                    </div>        
                <%
               }%>  
        </div>
   
</asp:Content>
