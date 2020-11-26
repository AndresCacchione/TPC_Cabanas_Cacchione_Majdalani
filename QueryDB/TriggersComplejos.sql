--Antes de Insert Usuarios

create trigger tr_insert_usuarios on usuarios
instead of insert
as
begin
	begin try
		begin transaction
		declare @IDPais smallint 

		--Consultar si existe ya un administrador de nivel 3.
		if((select count(*) from Usuarios where Usuarios.IdNivelAcceso=3) =0)
		begin
			-- Insertar un Pais genérico si no hay paises cargados
			if((select count (*) from Paises)=0)
			begin
			insert into Paises(Nombre) values ('Pais por defecto')
			@IDPais = select top 1 Paises.ID from Paises order by ID ---por que no me deja asignar??
			end 
			else begin
			end

			insert into Paises
			-- Insertar el Dueño de nivel 3
			insert into DatosPersonales(apellido,dni,domicilio,email,genero,IDpais,IdUsuario,nombre,telefono,URLimagen) 
			values ('Apellido','123456789','Av. Generica 1234, Provincia','email@mail.com','O',@IDPais,---)  ---falta completar el insert
			insert into Usuarios () values () -- completar datos genericos de usuario dueño.
			
			-- Insertar el primer usuario enviado 
			insert into DatosPersonales(apellido,dni,domicilio,email,genero,IDpais,IdUsuario,nombre,telefono,URLimagen) values () -- insertar las variables de la tabla inserted
			insert into Usuarios () values ()  -- insertar las variables de la tabla inserted

		end
		else begin
			-- Insertar el usuario enviado
			insert into DatosPersonales(apellido,dni,domicilio,email,genero,IDpais,IdUsuario,nombre,telefono,URLimagen) values () -- insertar las variables de la tabla inserted
			insert into Usuarios () values ()  -- insertar las variables de la tabla inserted

		end




--En lugar del delete Complejos
use Cacchione_Majdalani_DB
go
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
END;

go
use Cacchione_Majdalani_DB
go

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
END;
