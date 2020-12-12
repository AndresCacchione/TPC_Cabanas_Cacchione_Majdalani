use Cacchione_Majdalani_DB
go
create table Tablas(
	IDTabla bigint not null,
	Nombre varchar(100) not null
)
go
alter table Tablas
add constraint PK_Tablas primary key (IDTabla)
go
alter table Tablas
add constraint UNI_Nombre_Tablas unique(Nombre)
go

create procedure CargarTablas
as
BEGIN
declare @IDtabla bigint
set @IDtabla = isnull((select top 1 IDTabla from Tablas order by IDTabla desc),0)
while((select COUNT(*) from sys.tables where object_id > @IDtabla)>0)
	begin
	declare @IdNuevaTabla bigint
	declare @NombreTabla varchar(100)
	select top 1 @IdNuevaTabla= object_id, @NombreTabla=name from sys.tables where object_id > @IDtabla
	insert into Tablas values (@IdNuevaTabla, @NombreTabla)
	set @IDtabla = @IdNuevaTabla
	end
END

exec CargarTablas