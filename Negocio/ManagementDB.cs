using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ManagementDB
    {
		public void CrearSPCargarTablaDeTablas()
        {
			AccessDB access = new AccessDB();
            try
            {
				access.SetearQuery(@"
									if not exists(select * from sys.objects where name = 'CargarTablas')
									begin
									exec('create procedure CargarTablas
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
									')
									end");
				access.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
		}

		public void CrearVistaAdministradoresPorComplejo()
        {
			AccessDB access = new AccessDB();
            try
            {
				access.SetearQuery(@"
									if not exists(select * from sys.objects where name = 'VW_AdministradoresPorComplejo')
									begin
									exec('Create view VW_AdministradoresPorComplejo
										as
										select u.Id IDUsuario, Co.ID IDComplejo 
										from Usuarios u 
										inner join NivelesAcceso NA on NA.NivelAcceso = u.IdNivelAcceso
										inner join DatosPersonales Dat on Dat.IdUsuario = u.Id
										left join Administradores_x_Complejo AxC on AxC.IDUsuario = u.Id
										left join Complejos Co on Co.ID = AxC.IDComplejo
										where u.estado = 1 and NivelAcceso >= 20
									')
									end");
				access.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public void CrearSpAgregarReserva()
        {
			AccessDB acceso = new AccessDB();
			try
			{
				acceso.SetearQuery(@"if not exists(select * from sys.objects where name = 'spAgregarReserva')
									begin
									use Cacchione_Majdalani_DB
									exec('
									create pROCEDURE spAgregarReserva(
										@IdCabaña bigint,
										@IdUsuario bigint,
										@FechaIngreso date, 
										@FechaEgreso date, 
										@CantPersonas tinyint,
										@FechaReserva date,
										@Importe money,
										@Estado tinyint,
										@IdReservaOriginal bigint
										)
										AS
											BEGIN
											declare @resultado bit = 1
													BEGIN TRY
													if (select count(*) from Reservas where (((@FechaIngreso>fechaIngreso and @FechaIngreso < fechaEgreso) or
															(@FechaEgreso> fechaIngreso and @FechaEgreso < fechaEgreso) or
															(@FechaEgreso=fechaEgreso) or (@FechaIngreso=fechaIngreso)) and 
															estado<3 and IdCabaña = @IdCabaña))>0
													begin
													set @resultado = 0
													end
													else
													begin
													insert into reservas values(@IdCabaña, @IdUsuario, @FechaIngreso, @FechaEgreso, @CantPersonas, @FechaReserva, @Importe, @Estado, @IdReservaOriginal)
													end
													END TRY
												BEGIN CATCH
												set @resultado = 0
												END CATCH
												return @resultado
											END
											')
									end");
				acceso.EjecutarAccion();

			}
			catch (Exception ex)
			{

				throw ex;
			}


        }

		public void CrearSPIngresarUsuario()
        {
			AccessDB acceso = new AccessDB();
            try
            {
				acceso.SetearQuery(@"if not exists (select * from sys.objects where name = 'spAgregarUsuario')
									begin
									use Cacchione_Majdalani_DB
									exec('create PROCEDURE spAgregarUsuario(
									@nombreUsuario varchar(50),
									@contra varchar(200),
									@idNivelAcceso tinyint,
									@nombre varchar(50),
									@apellido varchar(50),
									@dni varchar(50),
									@email varchar(100),
									@telefono varchar(20),
									@URLimagen varchar(500),
									@idpais smallint,
									@domicilio varchar(150),
									@genero char
									)
									AS
										BEGIN
										declare @resultado bit = 1
											BEGIN TRANSACTION
												BEGIN TRY
												-- Generamos el usuario
												INSERT INTO Usuarios(nombreUsuario,contra,IdNivelAcceso,estado) VALUES (@nombreUsuario, @contra, @idNivelAcceso,1)
												-- Generamos la cuenta del usuario
												DECLARE @idUsuarioDatospersonales BIGINT
												SET @idUsuarioDatospersonales = SCOPE_IDENTITY()
	
												INSERT INTO DatosPersonales(IdUsuario, nombre, apellido,dni, email, telefono, URLimagen,IDpais,domicilio,genero) VALUES (@idUsuarioDatospersonales,@nombre,@apellido,@dni,@email,@telefono,@URLimagen,@idpais,@domicilio,@genero)
			
											COMMIT TRANSACTION
												END TRY
											BEGIN CATCH
											set @resultado = 0
											ROLLBACK TRANSACTION
	
											END CATCH 
										return @resultado
										END')
									end");
				acceso.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CrearTablasDB()
        {
            AccessDB acceso = new AccessDB();
            try
            {
                acceso.SetearQuery(@"Use master
									
									If not exists (Select * from sys.databases where name = 'Cacchione_Majdalani_DB')
									Begin
									Create database Cacchione_Majdalani_DB
									End
									
									Use Cacchione_Majdalani_DB
									
									Set Dateformat 'DMY'
									
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
                                    add constraint UNI_Mail unique (email)

									alter table DatosPersonales
									add constraint UNI_dni unique (dni)


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
									
									---------------------------------------
									

									create table Tablas(
										IDTabla bigint not null,
										Nombre varchar(100) not null
									)
									
									alter table Tablas
									add constraint PK_Tablas primary key (IDTabla)
									
									alter table Tablas
									add constraint UNI_Nombre_Tablas unique(Nombre)

									')
									end");
                acceso.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SetTRInsteadOfDELComplejos()
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
        public void SetTRInsteadOfDELCabañas()
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
        public void CargaPaises()
        {
            AccessDB acceso = new AccessDB();
            try
            {
                acceso.SetearQuery(@"use Cacchione_Majdalani_DB
									if(select count(*) from Paises)=0
									begin
									insert into Paises(nombre) values 
										('Afganistán'),
										('Islas Gland'),
										('Albania'),
										('Alemania'),
										('Andorra'),
										('Angola'),
										('Anguilla'),
										('Antártida'),
										('Antigua y Barbuda'),
										('Antillas Holandesas'),
										('Arabia Saudí'),
										('Argelia'),
										('Argentina'),
										('Armenia'),
										('Aruba'),
										('Australia'),
										('Austria'),
										('Azerbaiyán'),
										('Bahamas'),
										('Bahréin'),
										('Bangladesh'),
										('Barbados'),
										('Bielorrusia'),
										('Bélgica'),
										('Belice'),
										('Benin'),
										('Bermudas'),
										('Bhután'),
										('Bolivia'),
										('Bosnia y Herzegovina'),
										('Botsuana'),
										('Isla Bouvet'),
										('Brasil'),
										('Brunéi'),
										('Bulgaria'),
										('Burkina Faso'),
										('Burundi'),
										('Cabo Verde'),
										('Islas Caimán'),
										('Camboya'),
										('Camerún'),
										('Canadá'),
										('República Centroafricana'),
										('Chad'),
										('República Checa'),
										('Chile'),
										('China'),
										('Chipre'),
										('Isla de Navidad'),
										('Ciudad del Vaticano'),
										('Islas Cocos'),
										('Colombia'),
										('Comoras'),
										('República Democrática del Congo'),
										('Congo'),
										('Islas Cook'),
										('Corea del Norte'),
										('Corea del Sur'),
										('Costa de Marfil'),
										('Costa Rica'),
										('Croacia'),
										('Cuba'),
										('Dinamarca'),
										('Dominica'),
										('República Dominicana'),
										('Ecuador'),
										('Egipto'),
										('El Salvador'),
										('Emiratos Árabes Unidos'),
										('Eritrea'),
										('Eslovaquia'),
										('Eslovenia'),
										('España'),
										('Islas ultramarinas de Estados Unidos'),
										('Estados Unidos'),
										('Estonia'),
										('Etiopía'),
										('Islas Feroe'),
										('Filipinas'),
										('Finlandia'),
										('Fiyi'),
										('Francia'),
										('Gabón'),
										('Gambia'),
										('Georgia'),
										('Islas Georgias del Sur y Sandwich del Sur'),
										('Ghana'),
										('Gibraltar'),
										('Granada'),
										('Grecia'),
										('Groenlandia'),
										('Guadalupe'),
										('Guam'),
										('Guatemala'),
										('Guayana Francesa'),
										('Guinea'),
										('Guinea Ecuatorial'),
										('Guinea-Bissau'),
										('Guyana'),
										('Haití'),
										('Islas Heard y McDonald'),
										('Honduras'),
										('Hong Kong'),
										('Hungría'),
										('India'),
										('Indonesia'),
										('Irán'),
										('Iraq'),
										('Irlanda'),
										('Islandia'),
										('Israel'),
										('Italia'),
										('Jamaica'),
										('Japón'),
										('Jordania'),
										('Kazajstán'),
										('Kenia'),
										('Kirguistán'),
										('Kiribati'),
										('Kuwait'),
										('Laos'),
										('Lesotho'),
										('Letonia'),
										('Líbano'),
										('Liberia'),
										('Libia'),
										('Liechtenstein'),
										('Lituania'),
										('Luxemburgo'),
										('Macao'),
										('ARY Macedonia'),
										('Madagascar'),
										('Malasia'),
										('Malawi'),
										('Maldivas'),
										('Malí'),
										('Malta'),
										('Islas Malvinas'),
										('Islas Marianas del Norte'),
										('Marruecos'),
										('Islas Marshall'),
										('Martinica'),
										('Mauricio'),
										('Mauritania'),
										('Mayotte'),
										('México'),
										('Micronesia'),
										('Moldavia'),
										('Mónaco'),
										('Mongolia'),
										('Montserrat'),
										('Mozambique'),
										('Myanmar'),
										('Namibia'),
										('Nauru'),
										('Nepal'),
										('Nicaragua'),
										('Níger'),
										('Nigeria'),
										('Niue'),
										('Isla Norfolk'),
										('Noruega'),
										('Nueva Caledonia'),
										('Nueva Zelanda'),
										('Omán'),
										('Países Bajos'),
										('Pakistán'),
										('Palau'),
										('Palestina'),
										('Panamá'),
										('Papúa Nueva Guinea'),
										('Paraguay'),
										('Perú'),
										('Islas Pitcairn'),
										('Polinesia Francesa'),
										('Polonia'),
										('Portugal'),
										('Puerto Rico'),
										('Qatar'),
										('Reino Unido'),
										('Reunión'),
										('Ruanda'),
										('Rumania'),
										('Rusia'),
										('Sahara Occidental'),
										('Islas Salomón'),
										('Samoa'),
										('Samoa Americana'),
										('San Cristóbal y Nevis'),
										('San Marino'),
										('San Pedro y Miquelón'),
										('San Vicente y las Granadinas'),
										('Santa Helena'),
										('Santa Lucía'),
										('Santo Tomé y Príncipe'),
										('Senegal'),
										('Serbia y Montenegro'),
										('Seychelles'),
										('Sierra Leona'),
										('Singapur'),
										('Siria'),
										('Somalia'),
										('Sri Lanka'),
										('Suazilandia'),
										('Sudáfrica'),
										('Sudán'),
										('Suecia'),
										('Suiza'),
										('Surinam'),
										('Svalbard y Jan Mayen'),
										('Tailandia'),
										('Taiwán'),
										('Tanzania'),
										('Tayikistán'),
										('Territorio Británico del Océano Índico'),
										('Territorios Australes Franceses'),
										('Timor Oriental'),
										('Togo'),
										('Tokelau'),
										('Tonga'),
										('Trinidad y Tobago'),
										('Túnez'),
										('Islas Turcas y Caicos'),
										('Turkmenistán'),
										('Turquía'),
										('Tuvalu'),
										('Ucrania'),
										('Uganda'),
										('Uruguay'),
										('Uzbekistán'),
										('Vanuatu'),
										('Venezuela'),
										('Vietnam'),
										('Islas Vírgenes Británicas'),
										('Islas Vírgenes de los Estados Unidos'),
										('Wallis y Futuna'),
										('Yemen'),
										('Yibuti'),
										('Zambia'),
										('Zimbabue'),
										('Otros Paises NCP');
									end");
                acceso.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void BorrarTablas()
        {
            AccessDB accessDB = new AccessDB();
            try
            {
                accessDB.SetearQuery(@"Use Cacchione_Majdalani_DB
									
									if exists (select * from sys.objects where name = 'Solicitudes')
									Begin
									Drop Table Tablas
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
									end");
                accessDB.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetearSPContarAccNiveles()
        {
            AccessDB accessDB = new AccessDB();
            try
            {
                accessDB.SetearQuery(@"use Cacchione_Majdalani_DB
										--drop procedure if exists SPContarNivelesAcceso
										if not exists (Select * from sys.objects where name = 'SPContarNivelesAcceso')
										begin
										exec('create procedure SPContarNivelesAcceso
										as
										begin
										return (select count (*) from NivelesAcceso)
										end
										')
										end");
                accessDB.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void SetearSPContarUsuarios()
        {
            AccessDB accessDB = new AccessDB();
            try
            {
                accessDB.SetearQuery(@"use Cacchione_Majdalani_DB
										--drop procedure if exists SPContarUsuarios
										if not exists (Select * from sys.objects where name = 'SPContarUsuarios')
										begin
										exec('create procedure SPContarUsuarios
										as
										begin
										return (select count (*) from Usuarios)
										end
										')
										end");
                accessDB.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private int EjecutarSPContarUsuarios()
        {
            AccessDB accessDB = new AccessDB();
            int ret;
            try
            {
                ret = accessDB.EjecutarStoredProcedureIntReturn("SPContarUsuarios");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accessDB.CerrarConexion();
            }
            return ret;
        }

        private int EjecutarSPContarAccNiveles()
        {
            AccessDB accessDB = new AccessDB();
            int ret;
            try
            {
                ret = accessDB.EjecutarStoredProcedureIntReturn("SPContarNivelesAcceso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accessDB.CerrarConexion();
            }
            return ret;
        }
        private void InsertarnivelesAcceso()
        {
            AccessDB accessDB = new AccessDB();
            try
            {
                accessDB.SetearQuery(@"insert into NivelesAcceso(NivelAcceso, nombre) values('10','Cliente'), ('20','Administrador'), ('30','Dueño');");
                accessDB.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertarUsuarios()
        {
            AccessDB accessDB = new AccessDB();
            try
            {
                accessDB.SetearQuery(@"insert into Usuarios values('Dueño','4da32e2f1eeef7bc7fe7b51110eacb016dc05155b8c704d602efc888933b2017',30,1) ");
                accessDB.EjecutarAccion();
                accessDB.SetearQuery(@"insert into DatosPersonales values(1,'Dueño','Dueño','000000000','Dueño@dueño.com','00000000','1',13,'Dueño','o')");
                accessDB.EjecutarAccion();

                accessDB.SetearQuery(@"insert into Usuarios values('Admin','794ac92b117ed5eacaee3c6706c9024b2e44ce68d2d4b297c9ed8767a7015ca7',20,1) ");
                accessDB.EjecutarAccion();
                accessDB.SetearQuery(@"insert into DatosPersonales values(2,'Admin','Admin','1111111111','response.redirect@hotmail.com','00000000','1',12,'Admin','o')");
                accessDB.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargarNiveles()
        {
            SetearSPContarAccNiveles();
            if (EjecutarSPContarAccNiveles() == 0)
            {
                InsertarnivelesAcceso();
            }
        }

        public void CargarUsuarios()
        {
            SetearSPContarUsuarios();
            if (EjecutarSPContarUsuarios() == 0)
            {
                InsertarUsuarios();
            }
        }
    }
}
