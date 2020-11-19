<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarCabaña.aspx.cs" Inherits="TPC_CacchioneMajdalani.EliminarCabaña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <h2>
         ELIMINAR
    </h2>
                      <div class="col-md-4">
                        <div class="card mt-4" style="width:20rem;" >
                             <img src="<%=Aux.Imagen%>" class="card-img-top" alt="...">
                            <div class="card-body" style="background-color:#6E9038;">
                          
                                <ul>
                                    <li><h5 class="card-title"><%=Aux.complejo.Nombre%></h5></li> 
                                    <li><h5 class="card-title"><%=Aux.complejo.Ubicacion%></h5></li>
                                </ul>
                                
                                <fieldset class="group">
                                    <a href="Complejos.aspx" class="btn btn-primary mr-auto ml-auto">Volver</a>
                                    <asp:CheckBox ID="check_eliminar" Text="Eliminar" runat="server" required=""/>
                                    <asp:Button class="btn btn-danger mr-auto ml-auto" Text="Eliminar Cabaña" runat="server" OnClick="Unnamed_Click"/>                          
                                </fieldset>
                             </div>
                        </div>
                    </div>  





</asp:Content>
