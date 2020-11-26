use Cacchione_Majdalani_DB
go
--drop procedure if exists SPContarNivelesAcceso
if not exists (Select * from sys.objects where name = 'SPContarNivelesAcceso')
begin
exec('create procedure SPContarNivelesAcceso
as
begin
return (select count (*) from NivelesAcceso)
end
')
end

go

if not exists(Select * from sys.objects where name = 'SPContarUsuarios')
begin 
exec(
'create procedure SPContarUsuarios
as
begin 
return (select count (*)from Usuarios)
end'
)
end