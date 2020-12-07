<%@ Page Title="Detalle Cabaña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCabaña.aspx.cs" Inherits="TPC_CacchioneMajdalani.DetalleCabaña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-4">
        <div class="card mt-4" style="width: 20rem;">
            <img src="<%=CabañaAuxiliar.Imagen%>" class="card-img-top" alt="...">
            <div class="card-body" style="background-color: #6E9038;">
                <ul>
                    <li>
                        <h5 class="card-title">Complejo: <%=CabañaAuxiliar.complejo.Nombre %></h5>
                    </li>
                    <li>
                        <h5 class="card-title">Ubicación: <%=CabañaAuxiliar.complejo.Ubicacion%></h5>
                    </li>
                    <li>
                        <h5 class="card-title">Cant. ambientes: <%=CabañaAuxiliar.Ambientes%></h5>
                    </li>
                    <li>
                        <h5 class="card-title">Cant. personas: <%=CabañaAuxiliar.Capacidad%></h5>
                    </li>
                    <li>
                        <h5 class="card-title">Precio por día: <%=CabañaAuxiliar.PrecioDiario%></h5>
                    </li>
                    <li>
                        <h5 class="card-title">Hora CheckIn: <%=CabañaAuxiliar.CheckIn.TimeOfDay%></h5>
                    </li>
                    <li>
                        <h5 class="card-title">Hora Checkout: <%=CabañaAuxiliar.CheckOut.TimeOfDay%></h5>
                    </li>
                </ul>


                <a href="<%=StringBotonVolver%>" class="btn btn-secondary mr-auto ml-auto">Volver</a>
                <a href="CabañasFavoritas.aspx?idCabaña=<%=CabañaAuxiliar.Id.ToString()%>" class="btn btn-secondary mr-auto ml-auto">Agregar a Favoritas</a>
                <%if ((Dominio.Usuario)Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20 && ((List<Dominio.Cabaña>)base.Session["listaCabañas"]).Count() != 0)
                    { %>
                <a href="AgregarModificarCabaña.aspx?IdCabaña=<%=CabañaAuxiliar.Id.ToString()%>" class="btn btn-secondary mr-auto ml-auto">Modificar</a>
                <a href="EliminarCabaña.aspx?idCabaña=<%=CabañaAuxiliar.Id.ToString()%>" class="btn btn-danger mr-auto ml-auto">Eliminar</a>
                <% } %>
            </div>
        </div>
    </div>
    <hr />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="form-group col-md-6">
                  <%if (Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20 && ((List<Dominio.Cabaña>)Session["listaCabañas"]).Count() != 0)
                { %>
           
                <label for="inputURLImagen">URL de Nueva Imagen: </label>
                <input type="url" class="form-control" id="URLImagen" placeholder="Ingrese URL de Imagen" runat="server">
                <asp:Button Text="Agregar Imagen" class="btn btn-success mr-auto ml-auto" OnClick="AgregarImagen" runat="server" AutoPostBack="true" />

            <% } %>
            </div>

            <div class="row align-content-md-between">
                <%foreach (Dominio.Imagen item in CabañaAuxiliar.ListaImagenes)
                    {%>
                <div class="col-md-4">
                    <div class="card mt-4" style="width: 20rem;">
                        <img src="<%=item.URLImagen%>" class="card-img-top" alt="...">

                        <div class="card-body" style="background-color: #6E9038;">
                              <%if (Session[Session.SessionID + "userSession"] != null && ((Dominio.Usuario)Session[Session.SessionID + "userSession"]).NivelAcceso >= 20 && ((List<Dominio.Cabaña>)Session["listaCabañas"]).Count() != 0)
                { %>
                            <a href="DetalleCabaña?idCabaña=<%=CabañaAuxiliar.Id.ToString()%>&idImagen=<%=item.ID.ToString() %>" class="btn btn-danger mr-auto ml-auto">Eliminar Imagen</a>
            
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
