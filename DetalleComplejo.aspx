<%@ Page Title="Detalle Complejo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleComplejo.aspx.cs" Inherits="TPC_CacchioneMajdalani.DetalleComplejo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <div class="col-md-4">
                        <div class="card mt-4" style="width:20rem;" >
                             <img src="<%=Aux.Imagen%>" class="card-img-top" alt="...">
                            <div class="card-body" style="background-color:#6E9038;">
                          
                                <ul>
                                    <li><h5 class="card-title"><%=Aux.Nombre%></h5></li> 
                                    <li><h5 class="card-title"><%=Aux.Mail%></h5></li>
                                    <li><h5 class="card-title"><%=Aux.Telefono%></h5></li> 
                                    <li><h5 class="card-title"><%=Aux.Ubicacion%></h5></li>
                                    <li><h5 class="card-title"><%=Aux.PrecioFeriado%></h5></li>
                                </ul>

                                <a href="Complejos.aspx" class="btn btn-secondary mr-auto ml-auto">Volver</a>
                                 <%if (Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20)
                { %>
           
                                <a href="AgregarModificarComplejo.aspx?IdComplejo=<%=Aux.ID.ToString()%>" class="btn btn-secondary mr-auto ml-auto">Modificar</a>
                                <a href="EliminarComplejo.aspx?idComplejo=<%=Aux.ID.ToString()%>" class="btn btn-danger mr-auto ml-auto">Eliminar</a>

            <% } %>
                            


                            </div>
                        </div>                                    
                    </div>     
       <hr />
                  <asp:UpdatePanel runat="server">
                      <ContentTemplate>

                          <div class="form-group col-md-6">
                        <%if (Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20 )
                { %>
                              <label for="inputURLImagen">URL de Nueva Imagen: </label>
                              <input type="url" class="form-control" id="URLImagen" placeholder="Ingrese URL de Imagen" runat="server">
                          </div>
                          <asp:Button Text="Agregar Imagen" class="btn btn-success mr-auto ml-auto" OnClick="AgregarImagen" runat="server" autopostback="true" />

            

            <% } %>
                          <div class="row align-content-md-between">
                              <%foreach (Dominio.Imagen item in Aux.ListaImagenes)
                                  {%>
                              <div class="col-md-4">
                                  <div class="card mt-4" style="width: 20rem;">
                                      <img src="<%=item.URLImagen%>" class="card-img-top" alt="...">
                                      
                                      <div class="card-body"  style="background-color: #6E9038;">
                                            <%if (Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20)
                { %>
                                          <a href="DetalleComplejo?idComplejo=<%=Aux.ID.ToString()%>&idImagen=<%=item.ID.ToString() %>" class="btn btn-danger mr-auto ml-auto" >Eliminar Imagen</a> 
            <% } %>
                                          <%--<asp:HyperLink NavigateUrl="DetalleCabaña?idCabaña=<%=CabañaAuxiliar.Id.ToString()%>&idImagen=<%=item.ID.ToString()%>" class="btn btn-danger mr-auto ml-auto" Text="Eliminar Imagen" autopostback="true" runat="server" />
                                          <asp:Button Text="Eliminar Imagen" runat="server" CommandArgument="<%=item.ID.ToString()%>" class="btn btn-danger mr-auto ml-auto" autopostback="true"/>--%>
                                          <%-- <asp:LinkButton Text="Eliminar Imagen" autopostback="true" PostBackUrl="DetalleCabaña?idCabaña=<%=CabañaAuxiliar.Id.ToString()%>&idImagen=<%=item.ID.ToString() %>" class="btn btn-danger mr-auto ml-auto" runat="server" />--%>
                                      </div>
                                  </div>
                              </div>
                              <%}
                              %>
                          </div>
                      </ContentTemplate>
                  </asp:UpdatePanel>

              


</asp:Content>
