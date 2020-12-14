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

if not exists(select * from sys.objects where name = 'CargarTablas')
									begin
									exec('create procedure spCargarSeguimiento(
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
if @IDTablaAnterior not in(case when ((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Reservas'') then  
							(select ID from Reservas)
							when ((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Complejos'') then  
							(select ID from Complejos)
							when ((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Cabañas'') then  
							(select ID from Cabañas)
							when ((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Clientes'') then
							(select Id from Usuarios where IdNivelAcceso < 20)
							end)
or @IDTablaAnterior is null
or @IDTablaNuevo not in(case when ((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Reservas'') then  
							(select ID from Reservas)
							when ((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Complejos'') then  
							(select ID from Complejos)
							when ((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Cabañas'') then  
							(select ID from Cabañas)
							when ((select t.Nombre from Tablas t where @IDTabla=t.IDTabla)=''Clientes'') then
							(select Id from Usuarios where IdNivelAcceso < 20)
							end)
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



exec spCargarSeguimiento 2, 2, 1378819974, 1, null, 'Motivo: safdasdfasdfasdfasdfasdfCambio en Reserva.Estado anterior: 1Estado actualizado: 3 .- Administrador:Admin, Cliente:Admin,  ID Tabla Anterior:1'

select * from Seguimientos

select * from tablas
