<%@ Page Title="Eliminar Cabaña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarCabaña.aspx.cs" Inherits="TPC_CacchioneMajdalani.EliminarCabaña" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Eliminar Cabaña</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Está seguro de borrar esta cabaña? Esta acción es <b>IRREVERSIBLE</b>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnBorrar" runat="server" type="button" class="btn btn-primary" Text="Confirmar" OnClick="btnBorrar_Click"  />
                    <asp:Button ID="btnCancelar" runat="server" type="button" class="btn btn-secondary" data-dismiss="modal" Text="Cancelar" />
                </div>
            </div>
        </div>
    </div>

    <h2>ELIMINAR
    </h2>
    <div class="col-md-4">
        <div class="card mt-4" style="width: 20rem;">
            <img src="<%=Aux.Imagen%>" class="card-img-top" alt="...">
            <div class="card-body" style="background-color: #6E9038;">

                <ul>
                    <li>
                        <h5 class="card-title"><%=Aux.complejo.Nombre%></h5>
                    </li>
                    <li>
                        <h5 class="card-title"><%=Aux.complejo.Ubicacion%></h5>
                    </li>
                </ul>

                <fieldset class="group">
                    <a href="Complejos.aspx" class="btn btn-primary mr-auto ml-auto">Volver</a>
                    <asp:CheckBox ID="check_eliminar" Text="Eliminar" runat="server" required="" />
                    <button type="button" class="btn btn-danger mr-auto ml-auto" data-toggle="modal" data-target="#exampleModal">
        Eliminar</button>
                </fieldset>
            </div>
        </div>
    </div>





</asp:Content>
