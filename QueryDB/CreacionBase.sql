Use master
go
If not exists (Select * from sys.databases where name = 'Cacchione_Majdalani_DB')
Begin
Create database Cacchione_Majdalani_DB
End
go
Use Cacchione_Majdalani_DB
go
Set Dateformat 'DMY'
go
IF NOT EXISTS (select * from sys.objects where name = 'PK_Paises')
begin
	EXEC('
Create Table Paises(
	ID smallint not null identity (1,1),
	nombre varchar(50) not null 
) 

alter table Paises
add constraint PK_Paises primary key (ID)

alter table Paises
add constraint UNI_nombre unique (nombre)


---------------------------------------


Create Table NivelesAcceso(
	NivelAcceso tinyint not null,
	nombre varchar(50) not null
)


alter table NivelesAcceso
add constraint PK_NivelesAcceso primary key (NivelAcceso)


alter table NivelesAcceso
add constraint UNI_nombre_NivelesAcceso unique(nombre)

-------------------------------------


Create Table Complejos(
	ID bigint not null identity(1,1),
	ImagenPortada Varchar(200) not null,
	nombre varchar(50) not null,
	telefono varchar(20) not null,
	ubicacion varchar(200) not null,
	email varchar(100) not null,
	estado bit not null,
	diferenciaFeriado decimal not null
)



alter table Complejos
add constraint PK_Complejos primary key (ID)

alter table Complejos
add constraint UNI_nombre_Complejos unique (nombre)

alter table Complejos
add constraint CHK_diferenciaFeriado check(diferenciaFeriado>=0)


-----------------------------------------------------------------------


Create Table Usuarios(
Id Bigint not null identity(1,1),
nombreUsuario varchar(50) not null,
contra varchar (200) Not null,
IdNivelAcceso tinyint not null,
estado bit not null
)


alter Table Usuarios
Add Constraint Pk_Id_Usuarios Primary key (Id)


alter Table Usuarios
Add Constraint U_NombreUsuario_Usuarios Unique (NombreUsuario)

Alter Table Usuarios
add Constraint Fk_IdNivelAcceso_Usuarios Foreign key (IdNivelAcceso) References NivelesAcceso(NivelAcceso) 

------------------------------------------------------------------------------------------


Create Table DatosPersonales(
IdUsuario bigint not null,
nombre Varchar(50)not null,
apellido Varchar(50)not null,
dni Varchar(50)not null,
email varchar(100) not null,
telefono varchar(20) not null,
URLimagen varchar(500) null,
IDpais smallint not null,
domicilio varchar(150) not null,
genero char null
)


Alter table DatosPersonales
add Constraint PK_DatosPersonales primary key (IdUsuario)


Alter Table DatosPersonales
add Constraint Fk_IdUsuario_DatosPersonales Foreign key (IdUsuario) References Usuarios(id)


alter table DatosPersonales
add constraint FK_IDpais_DatosPersonales foreign key (IDpais) references Paises(id)


alter table DatosPersonales
add constraint UNI_dni unique (dni)

alter table DatosPersonales
add constraint UNI_Mail unique (email)


alter table DatosPersonales
add constraint CHK_genero check (upper(genero) in (''F'',''M'',''O''))

-------------------------------------------------------


Create Table CuentasCorrientes(
ID bigint not null identity(1,1),
IDUsuario bigint not null,
CBUBancario varchar(23) not null
)


alter table CuentasCorrientes
add constraint PK_CuentasCorrientes primary key (ID)


alter table CuentasCorrientes
add constraint UNI_IDUsuario_CuentasCorrientes unique(IDUsuario)


alter table CuentasCorrientes
add constraint FK_IDUsuario_CuentasCorrientes foreign key (IDUsuario) references Usuarios(id)

--------------------------------------------------------


Create Table Creditos(
ID bigint not null identity(1,1),
IDcuentaCorriente bigint not null,
validado bit not null,
importe money not null,
fecha date not null
)


alter table Creditos
add constraint PK_Creditos primary key (ID)


alter table Creditos
add constraint FK_IDcuentaCorriente_Creditos foreign key (IDcuentaCorriente) references CuentasCorrientes(id)


alter table Creditos
add constraint CHK_importe_Creditos check (importe>=0)


alter table Creditos
add constraint CHK_fecha_Creditos check (fecha <= getdate())

--------------------------------------------------------


Create Table Administradores_x_Complejo(
IDUsuario bigint not null,
IDComplejo bigint not null,
estado bit not null
)


alter table Administradores_x_Complejo
add constraint PK_Administradores_x_Complejo primary key (IDUsuario, IDComplejo)


alter table Administradores_x_Complejo
add constraint FK_IDUsuario_Administradores_x_Complejo foreign key (IDUsuario) references Usuarios(id)


alter table Administradores_x_Complejo
add constraint FK_IDComplejo_Administradores_x_Complejo foreign key (IDComplejo) references Complejos(id)

--------------------------------------------------------


Create Table ImagenesComplejos(
ID bigint not null identity(1,1),
IDComplejo bigint not null,
URLImagen varchar(500) not null
)


alter table ImagenesComplejos
add constraint PK_ImagenesComplejos primary key (ID)


alter table ImagenesComplejos
add constraint FK_IDComplejo_ImagenesComplejos foreign key (IDComplejo) references Complejos(id)

--------------------------------------------------------


Create Table Temporadas(
ID bigint not null identity(1,1),
IDcomplejo bigint not null,
fechaInicio date not null,
fechaFin date not null,
nombre varchar(40) not null,
diferenciaPorcentaje decimal not null
)


alter table Temporadas
add constraint PK_Temporadas primary key (ID)


alter table Temporadas
add constraint FK_IDcomplejo_Temporadas foreign key (IDcomplejo) references Complejos(id)


alter table Temporadas
add constraint CHK_fechasTemporadas_Temporadas check(fechaInicio<fechaFin)


alter table Temporadas
add constraint UNI_nombre_Temporadas unique(nombre)


alter table Temporadas
add constraint CHK_diferenciaPorcentaje_Temporadas check (diferenciaPorcentaje>=0)

---------------------------------------------------------


Create Table Cabañas(
ID bigint not null identity(1,1),
ImagenPortada varchar(200) not null,
IDComplejo bigint not null,
precioDiario money not null,
capacidad tinyint not null,
cantidadAmbientes tinyint null,
tiempoEntreReservas datetime not null,
horaCheckIn datetime not null,
horaCheckOut datetime not null,
estado bit not null
)


alter table Cabañas
add constraint PK_Cabañas primary key (ID)


alter table Cabañas
add constraint FK_IDComplejo_Cabañas foreign key (IDComplejo) references Complejos(id)


alter table Cabañas
add constraint CHK_precioDiario_Cabañas check (precioDiario>0)


alter table Cabañas
add constraint CHK_capacidad_Cabañas check (capacidad>0)


alter table Cabañas
add constraint CHK_cantidadAmbientes_Cabañas check (cantidadAmbientes>=0)


alter table Cabañas
add constraint CHK_tiempoEntreReservas_Cabañas check (tiempoEntreReservas>=0)

---------------------------------------------------------


Create Table ImagenesCabañas(
ID bigint not null identity(1,1),
IDCabaña bigint not null,
URLImagen varchar(500) not null
)


alter table ImagenesCabañas
add constraint PK_ImagenesCabañas primary key (ID)


alter table ImagenesCabañas
add constraint FK_IDCabaña_ImagenesCabañas foreign key (IDCabaña) references Cabañas(id)

---------------------------------------------------------


Create Table Reservas(
ID bigint not null identity (1,1),
IDCabaña bigint not null,
IDUsuario bigint not null,
fechaIngreso date not null,
fechaEgreso date not null,
cantidadPersonas tinyint not null,
fechaReserva date not null,
importe money not null,
estado tinyint not null,
IDReservaOriginal bigint null
)


alter table Reservas
add constraint PK_Reservas primary key (ID)


alter table Reservas
add constraint FK_IDCabaña_Reservas foreign key (IDCabaña) references Cabañas(id)


alter table Reservas
add constraint FK_IDUsuario_Reservas foreign key (IDUsuario) references Usuarios(id)


alter table Reservas
add constraint CHK_fechas_Reservas check (fechaIngreso<fechaEgreso)


alter table Reservas
add constraint CHK_cantidadPersonas_Reservas check (cantidadPersonas>0)


alter table Reservas
add constraint CHK_importe_Reservas check (importe>=0)

---------------------------------------------------------


Create Table Debitos(
ID bigint not null identity(1,1),
IDCuentaCorriente bigint not null,
IDReserva bigint not null,
importe money not null,
fecha date not null
)


alter table Debitos
add constraint PK_Debitos primary key (ID)


alter table Debitos
add constraint FK_IDCuentaCorriente_Debitos foreign key (IDCuentaCorriente) references CuentasCorrientes(id)


alter table Debitos
add constraint FK_IDReserva_Debitos foreign key (IDReserva) references Reservas(id)


alter table Debitos
add constraint CHK_importe_Debitos check (importe>=0)


alter table Debitos
add constraint CHK_fecha_Debitos check (day(fecha)=day(getdate()))

---------------------------------------------------------


Create Table Solicitudes(
ID bigint not null identity (1,1),
IDReservaoriginal bigint not null,
fechaCreacion date not null,
estado tinyint not null,
IDReservaNueva bigint not null
)


alter table Solicitudes
add constraint PK_Solicitudes primary key (ID)


alter table Solicitudes
add constraint FK_IDReservaoriginal_Solicitudes foreign key (IDReservaoriginal) references Reservas(id)


alter table Solicitudes
add constraint FK_IDReservaNueva_Solicitudes foreign key (IDReservaNueva) references Reservas(id)

')
end
---------------------------------------------------------

/*
Drop Table Solicitudes
Drop Table Debitos
Drop Table Reservas
Drop Table ImagenesCabañas
Drop table Cabañas
Drop Table Temporadas
Drop Table Administradores_x_Complejo
Drop Table ImagenesComplejos
Drop Table Creditos
Drop Table CuentasCorrientes
Drop Table DatosPersonales
Drop Table Usuarios
Drop Table Complejos
Drop Table NivelesAcceso
Drop Table Paises
*/

/*DECLARE @HashThis NVARCHAR(4000);
SELECT @HashThis = N'456';
SELECT  HASHBYTES('SHA2_256', CONVERT(VARCHAR(4000),@HashThis,0));*/

