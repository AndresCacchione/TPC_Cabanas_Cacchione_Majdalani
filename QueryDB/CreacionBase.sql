--Create Database Cacchione_Majdalani_DB
--go 
--use Cacchione_Majdalani_DB

--------------------------------------
go
Create Table Paises(
	ID smallint not null identity (1,1),
	nombre varchar(50) not null 
)

go
alter table Paises
add constraint PK_Paises primary key (ID)

go
alter table Paises
add constraint UNI_nombre unique (nombre)

---------------------------------------

go
Create Table NivelesAcceso(
	ID tinyint not null identity (1,1),
	nombre varchar(50) not null
)

go
alter table NivelesAcceso
add constraint PK_NivelesAcceso primary key (ID)

go
alter table NivelesAcceso
add constraint UNI_nombre_NivelesAcceso unique(nombre)

-------------------------------------

go
Create Table Complejos(
	ID bigint not null identity(1,1),
	Imagen Varchar(200) not null,
	nombre varchar(50) not null,
	telefono varchar(20) not null,
	ubicacion varchar(200) not null,
	email varchar(100) not null,
	estado bit not null,
	diferenciaFeriado decimal not null
)


go
alter table Complejos
add constraint PK_Complejos primary key (ID)
go
alter table Complejos
add constraint UNI_nombre_Complejos unique (nombre)
go
alter table Complejos
add constraint CHK_diferenciaFeriado check(diferenciaFeriado>=0)
go

-----------------------------------------------------------------------

go
Create Table Usuarios(
Id Bigint not null identity(1,1),
nombre varchar(50) not null,
contra varchar (200) Not null,
IdNivelAcceso tinyint not null,
estado bit not null
)

go
alter Table Usuarios
Add Constraint Pk_Id_Usuarios Primary key (Id)

go
alter Table Usuarios
Add Constraint U_Nombre_Usuarios Unique (Nombre)
go
Alter Table Usuarios
add Constraint Fk_IdNivelAcceso_Usuarios Foreign key (IdNivelAcceso) References NivelesAcceso(Id) 

------------------------------------------------------------------------------------------

go
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

go
Alter table DatosPersonales
add Constraint PK_DatosPersonales primary key (IdUsuario)

go
Alter Table DatosPersonales
add Constraint Fk_IdUsuario_DatosPersonales Foreign key (IdUsuario) References Usuarios(id)

go
alter table DatosPersonales
add constraint FK_IDpais_DatosPersonales foreign key (IDpais) references Paises(id)

go
alter table DatosPersonales
add constraint UNI_dni unique (dni)

go
alter table DatosPersonales
add constraint CHK_genero check (upper(genero) in ('F','M', 'O'))

-------------------------------------------------------

go
Create Table CuentasCorrientes(
ID bigint not null identity(1,1),
IDUsuario bigint not null,
CBUBancario varchar(23) not null
)

go
alter table CuentasCorrientes
add constraint PK_CuentasCorrientes primary key (ID)

go
alter table CuentasCorrientes
add constraint UNI_IDUsuario_CuentasCorrientes unique(IDUsuario)

go
alter table CuentasCorrientes
add constraint FK_IDUsuario_CuentasCorrientes foreign key (IDUsuario) references Usuarios(id)

--------------------------------------------------------

go
Create Table Creditos(
ID bigint not null identity(1,1),
IDcuentaCorriente bigint not null,
validado bit not null,
importe money not null,
fecha date not null
)

go
alter table Creditos
add constraint PK_Creditos primary key (ID)

go
alter table Creditos
add constraint FK_IDcuentaCorriente_Creditos foreign key (IDcuentaCorriente) references CuentasCorrientes(id)

go
alter table Creditos
add constraint CHK_importe_Creditos check (importe>=0)

go
alter table Creditos
add constraint CHK_fecha_Creditos check (fecha <= getdate())

--------------------------------------------------------

go
Create Table Administradores_x_Complejo(
IDUsuario bigint not null,
IDComplejo bigint not null,
estado bit not null
)

go
alter table Administradores_x_Complejo
add constraint PK_Administradores_x_Complejo primary key (IDUsuario, IDComplejo)

go
alter table Administradores_x_Complejo
add constraint FK_IDUsuario_Administradores_x_Complejo foreign key (IDUsuario) references Usuarios(id)

go
alter table Administradores_x_Complejo
add constraint FK_IDComplejo_Administradores_x_Complejo foreign key (IDComplejo) references Complejos(id)

--------------------------------------------------------

go
Create Table ImagenesComplejos(
ID bigint not null identity(1,1),
IDComplejo bigint not null,
URLImagen varchar(500) not null
)

go
alter table ImagenesComplejos
add constraint PK_ImagenesComplejos primary key (ID)

go
alter table ImagenesComplejos
add constraint FK_IDComplejo_ImagenesComplejos foreign key (IDComplejo) references Complejos(id)

--------------------------------------------------------

go
Create Table Temporadas(
ID bigint not null identity(1,1),
IDcomplejo bigint not null,
fechaInicio date not null,
fechaFin date not null,
nombre varchar(40) not null,
diferenciaPorcentaje decimal not null
)

go
alter table Temporadas
add constraint PK_Temporadas primary key (ID)

go
alter table Temporadas
add constraint FK_IDcomplejo_Temporadas foreign key (IDcomplejo) references Complejos(id)

go
alter table Temporadas
add constraint CHK_fechasTemporadas_Temporadas check(fechaInicio<fechaFin)

go
alter table Temporadas
add constraint UNI_nombre_Temporadas unique(nombre)

go 
alter table Temporadas
add constraint CHK_diferenciaPorcentaje_Temporadas check (diferenciaPorcentaje>=0)

---------------------------------------------------------

go
Create Table Cabañas(
ID bigint not null identity(1,1),
IDComplejo bigint not null,
precioDiario money not null,
capacidad tinyint not null,
cantidadAmbientes tinyint null,
tiempoEntreReservas smallint not null,
horaCheckIn time not null,
horaCheckOut time not null,
estado bit not null
)

go
alter table Cabañas
add constraint PK_Cabañas primary key (ID)

go
alter table Cabañas
add constraint FK_IDComplejo_Cabañas foreign key (IDComplejo) references Complejos(id)

go
alter table Cabañas
add constraint CHK_precioDiario_Cabañas check (precioDiario>0)

go
alter table Cabañas
add constraint CHK_capacidad_Cabañas check (capacidad>0)

go
alter table Cabañas
add constraint CHK_cantidadAmbientes_Cabañas check (cantidadAmbientes>=0)

go
alter table Cabañas
add constraint CHK_tiempoEntreReservas_Cabañas check (tiempoEntreReservas>=0)

---------------------------------------------------------

go
Create Table ImagenesCabañas(
ID bigint not null identity(1,1),
IDCabaña bigint not null,
URLImagen varchar(500) not null
)

go
alter table ImagenesCabañas
add constraint PK_ImagenesCabañas primary key (ID)

go
alter table ImagenesCabañas
add constraint FK_IDCabaña_ImagenesCabañas foreign key (IDCabaña) references Cabañas(id)

---------------------------------------------------------

go
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

go
alter table Reservas
add constraint PK_Reservas primary key (ID)

go
alter table Reservas
add constraint FK_IDCabaña_Reservas foreign key (IDCabaña) references Cabañas(id)

go
alter table Reservas
add constraint FK_IDUsuario_Reservas foreign key (IDUsuario) references Usuarios(id)

go
alter table Reservas
add constraint CHK_fechas_Reservas check (fechaIngreso<fechaEgreso)

go
alter table Reservas
add constraint CHK_cantidadPersonas_Reservas check (cantidadPersonas>0)

go
alter table Reservas
add constraint CHK_importe_Reservas check (importe>=0)

---------------------------------------------------------

go
Create Table Debitos(
ID bigint not null identity(1,1),
IDCuentaCorriente bigint not null,
IDReserva bigint not null,
importe money not null,
fecha date not null
)

go
alter table Debitos
add constraint PK_Debitos primary key (ID)

go
alter table Debitos
add constraint FK_IDCuentaCorriente_Debitos foreign key (IDCuentaCorriente) references CuentasCorrientes(id)

go
alter table Debitos
add constraint FK_IDReserva_Debitos foreign key (IDReserva) references Reservas(id)

go
alter table Debitos
add constraint CHK_importe_Debitos check (importe>=0)

go
alter table Debitos
add constraint CHK_fecha_Debitos check (day(fecha)=day(getdate()))

---------------------------------------------------------

go
Create Table Solicitudes(
ID bigint not null identity (1,1),
IDReservaoriginal bigint not null,
fechaCreacion date not null,
estado tinyint not null,
IDReservaNueva bigint not null
)

go
alter table Solicitudes
add constraint PK_Solicitudes primary key (ID)

go
alter table Solicitudes
add constraint FK_IDReservaoriginal_Solicitudes foreign key (IDReservaoriginal) references Reservas(id)

go
alter table Solicitudes
add constraint FK_IDReservaNueva_Solicitudes foreign key (IDReservaNueva) references Reservas(id)

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