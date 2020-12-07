create view VW_AdministradoresPorComplejo
as
select u.Id IDUsuario, Co.ID IDComplejo 
from Usuarios u 
inner join NivelesAcceso NA on NA.NivelAcceso = u.IdNivelAcceso
inner join DatosPersonales Dat on Dat.IdUsuario = u.Id
left join Administradores_x_Complejo AxC on AxC.IDUsuario = u.Id
left join Complejos Co on Co.ID = AxC.IDComplejo
where u.estado = 1 and NivelAcceso >= 20