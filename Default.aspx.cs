using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPC_CacchioneMajdalani
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetTRInsteadOfDELComplejos();
            SetTRInsteadOfDELCabañas();

        }

        private void SetTRInsteadOfDELCabañas()
        {
            AccessDB acceso = new AccessDB();
            
			try
            {
				acceso.SetearTrigger(@" use Cacchione_Majdalani_DB
                                    
                                    IF NOT EXISTS (select * from sys.objects where name = 'tr_eliminar_cabaña')
                                    BEGIN
                                        EXEC ('create trigger tr_eliminar_cabaña on cabañas
		                                    instead of delete
		                                    as
		                                    begin 
		                                    begin try 
		                                    begin transaction 
		                                    declare @IdCabaña bigint 
		                                    select @IdCabaña = Id from deleted
		                                    update Cabañas set estado = 0 where Id=@IdCabaña
		                                    commit transaction
		                                    end try 
		                                    begin catch
		                                    rollback transaction 
		                                    end catch
		                                    end ');
                                    END;");
			}
            catch (Exception ex)
            {
                throw ex;
            }

			finally
            {
				acceso.CerrarConexion();
			}        
        }

        private void SetTRInsteadOfDELComplejos()
        {
            AccessDB acceso = new AccessDB();

            try
            {
				acceso.SetearTrigger(@" use Cacchione_Majdalani_DB
									
									IF NOT EXISTS (select * from sys.objects where name = 'tr_eliminar_complejo')
									BEGIN
										EXEC ('create trigger tr_eliminar_complejo on complejos
										instead of delete
										as 
										begin
											begin try
												begin transaction
												--Cambiar estado de Complejos a 0 (inactivos o baja).
												declare @IDComplejos bigint
		
												select @IDComplejos = Id from deleted

												update Complejos set estado = 0 where id = @IDComplejos
												update Cabañas set estado = 0 where IDComplejo = @IDComplejos

												commit transaction
											end try
											begin catch
											rollback transaction
											end catch
										end');
									END;");
			}
            catch (Exception ex)
            {

                throw ex;
            }
			finally
            {
				acceso.CerrarConexion();
            }
        }
    }
}