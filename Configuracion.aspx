<%@ Page Title="Vaciar la Base de Datos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="TPC_CacchioneMajdalani.Configuracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="padding: 20% 0% 0% 45%">
            <button type="button" class="btn btn-danger mr-auto ml-auto" data-toggle="modal" data-target="#exampleModal">
        Borrar Datos</button>
    <!-- Button trigger modal -->
    </div>


    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Reestablecer configuración</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Está seguro de borrar todos los datos? Esta acción es <b>IRREVERSIBLE</b>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnBorrar" runat="server" type="button" class="btn btn-primary" Text="Confirmar" OnClick="btnBorrar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" type="button" class="btn btn-secondary" data-dismiss="modal" Text="Cancelar" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
