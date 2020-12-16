use cacchione_majdalani_DB
go

create table Seguimientos(
	IDSeguimiento bigint not null identity(1,1),
	IDAdmin bigint null,
	IDCliente bigint null,
	Fecha date not null,
	IDTabla bigint not null,
	IDTablaAnterior bigint not null,
	IDTablaNuevo bigint null,
	Motivo varchar(255) not null
)
go
alter table Seguimientos
add constraint PK_Seguimientos primary key(IDSeguimiento)
go
alter table Seguimientos
add constraint FK_IDAdmin_Usuarios foreign key(IDAdmin) references Usuarios(ID)
go
alter table Seguimientos
add constraint FK_IDCliente_Usuarios foreign key(IDCliente) references Usuarios(ID)
go
alter table Seguimientos
add constraint FK_IDTabla_Tablas foreign key(IDTabla) references Tablas(IDTabla)
go
alter table seguimientos
add constraint CHK_SEGUIMIENTOS_IDNULL check (IDAdmin is not null or IDCliente is not null)
go

if not exists(select * from sys.objects where name='spTablaEnTabla')
begin
exec('create procedure spTablaEnTabla(
			@IDTablaAnterior bigint,
			@IDTabla bigint)
			as
			declare @retorno bit=0
			begin

			if(@IDTablaAnterior is null)
				begin
				set @retorno = 1
				end

			else
			begin
				if((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Reservas'')
				begin
					if (@IDTablaAnterior in(select ID from Reservas))
					begin
					set @retorno = 1
					end
				end

				else
				BEGIN
					if((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Complejos'')
					begin
						if(@IDTablaAnterior in(select ID from Complejos))
						begin
						set @retorno = 1
						end
					end

					else

					begin
						if((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Cabañas'')
						begin
							if(@IDTablaAnterior in(select ID from Cabañas))
							begin
							set @retorno = 1
							end
						end

						else

						begin
							if((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Clientes'')
							begin
								if(@IDTablaAnterior in(select Id from Usuarios where IdNivelAcceso < 20))
								begin
								set @retorno = 1
								end
							end 
						end
					end
				END
			end
			return @retorno
			end

			--DEVUELVE 0 SI NO ENCUENTRA @IDTablaAnterior EN LAS PK DE LA TABLA CON ID=@IDTabla')
end
go
if not exists(select * from sys.objects where name='spCargarSeguimiento')
begin
exec('create procedure [dbo].[spCargarSeguimiento](
	@IDAdmin bigint,
	@IDCliente bigint,
	@IDTabla bigint,
	@IDTablaAnterior bigint,
	@IDTablaNuevo bigint,
	@Motivo varchar(255)
)
as
BEGIN
begin try
declare @resultadoTablaAnterior bit 
declare @resultadoTablaNueva bit
exec @resultadoTablaAnterior = spTablaEnTabla @IDTablaAnterior, @IDTabla
exec @resultadoTablaNueva = spTablaEnTabla @IDTablaNuevo, @IDTabla

if (@resultadoTablaAnterior=0
or @IDTablaAnterior is null
or @resultadoTablaNueva=0)

begin
raiserror(''ID de tabla anterior no válido'', 16, 1)
end

insert into Seguimientos values (@IDAdmin,@IDCliente,GETDATE(),@IDTabla,@IDTablaAnterior,@IDTablaNuevo,@Motivo)
end try

begin catch
print error_message()
end catch
END')
end
