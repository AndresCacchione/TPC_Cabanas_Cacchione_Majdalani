use cacchione_majdalani_DB
go

create table Seguimientos(
	IDSeguimiento bigint not null identity(1,1),
	IDAdmin bigint not null,
	IDCliente bigint not null,
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
add constraint FK_IDAdmin_Administradores_x_Complejo foreign key(IDAdmin) references Usuarios(ID)
go
alter table Seguimientos
add constraint FK_IDCliente_Usuarios foreign key(IDCliente) references Usuarios(ID)
go
alter table Seguimientos
add constraint FK_IDTabla_Tablas foreign key(IDTabla) references Tablas(IDTabla)
go
alter table Seguimientos
add constraint FK_IDTablaAnterior_Tablas foreign key(IDTablaAnterior) references Tablas(IDTabla)

go

create procedure spCargarSeguimiento(
	@IDAdmin bigint,
	@IDCliente bigint,
	@Fecha date,
	@IDTabla bigint,
	@IDTablaAnterior bigint,
	@IDTablaNuevo bigint,
	@Motivo varchar(255)
)
as
BEGIN
begin try
if @IDAdmin not in(select ID from Usuarios) or @IDAdmin is null
begin
raiserror('ID de administrador no válido', 16, 1)
end
if @IDCliente not in(select ID from Usuarios) or @IDCliente is null
begin
raiserror('ID de cliente no válido', 16, 1)
end
if @IDTabla not in(select IDTabla from Tablas) or @IDTabla is null
begin
raiserror('ID de tabla no válido', 16, 1)
end
if @IDTablaAnterior not in(select IDTabla from Tablas) or @IDTablaAnterior is null
begin
raiserror('ID de tabla anterior no válido', 16, 1)
end
insert into Seguimientos values (@IDAdmin,@IDCliente,@Fecha,@IDTabla,@IDTablaAnterior,@IDTablaNuevo,@Motivo)
end try

begin catch
print error_message()
end catch
END
