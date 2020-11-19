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
		update Caba�as set estado = 0 where IDComplejo = @IDComplejos

		commit transaction
	end try
	begin catch
	rollback transaction
	end catch

end

create trigger tr_eliminar_caba�a on caba�as
instead of delete
as
begin 
begin try 
begin transaction 
declare @IdCaba�a bigint 
select @IdCaba�a = Id from deleted
update Caba�as set estado = 0 where Id=@IdCaba�a
commit transaction
end try 
begin catch
rollback transaction 
end catch
end 


