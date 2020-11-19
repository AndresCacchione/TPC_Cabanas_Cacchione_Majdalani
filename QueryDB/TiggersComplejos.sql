--En lugar del delete Complejos

create trigger tr_eliminar_complejo on complejos
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

end

create trigger tr_eliminar_cabaña on cabañas
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
end 


