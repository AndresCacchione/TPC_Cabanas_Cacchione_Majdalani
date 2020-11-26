
Use Cacchione_Majdalani_DB
go
if exists (select * from sys.objects where name = 'Solicitudes')
Begin
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
end