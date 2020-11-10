<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleComplejo.aspx.cs" Inherits="TPC_CacchioneMajdalani.DetalleComplejo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <div class="col-md-4">
                        <div class="card mt-4" style="width:20rem;" >
                             <img src="<%=item.Imagen%>" class="card-img-top" alt="...">
                            <div class="card-body" style="background-color:#6E9038;">
                          
                                <ul>
                                    <li><h5 class="card-title"><%=item.Nombre%></h5></li> 
                                    <li><h5 class="card-title"><%=item.Ubicacion%></h5></li>
                                </ul>
                                
                                
                                
                                
                                <a href="Cabañas.aspx?idComplejo=<%=item.ID.ToString()%>" 
                                <a href="#" class="btn btn-secondary mr-auto ml-auto">Modificar</a>
                                <a href="EliminarComplejo.aspx?idComplejo=<%=item.ID.ToString()%>" class="btn btn-danger mr-auto ml-auto">Eliminar</a>
                                <%-- <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p> --%>
                            </div>
                        </div>
                    </div>       

</asp:Content>
