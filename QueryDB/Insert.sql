use Cacchione_Majdalani_DB
go
--Select *from complejos

insert into Complejos
values('https://www.cabanias.com.ar/fotos/la-gloria.020.b5.jpg','Brasa que Arde', 1542365245, 'Tigre', 'Brazaquearde@hotmail.com', 1, 0);
go
insert into Complejos
values('https://www.cabanias.com.ar/fotos/la-gloria.020.b9.jpg','La gloria', 1526598544, 'Tigre, La isla', 'LaGloria@hotmail.com', 1, 0);
go
insert into Complejos
values('https://www.cabanias.com.ar/fotos/la-gloria.020.b9.jpg','Catupecumachu', 1526598544, 'Tigre, La isla, En la selva Amazonas donde los mosquitos son del tamaño de un bondi', 'LaGloria@hotmail.com', 1, 0);
go
-------------------------------------------------------------------------------------------------------------------------------
--Select *from ImagenesComplejos

insert into ImagenesComplejos
Values(1,'https://www.cabanias.com.ar/fotos/la-gloria.020.b10.jpg')
go
insert into ImagenesComplejos
Values(1,'https://www.cabanias.com.ar/fotos/la-gloria.020.b3.jpg')
go
insert into ImagenesComplejos
Values(2,'https://www.cabanias.com.ar/fotos/la-gloria.020.b1.jpg')
go
insert into ImagenesComplejos
Values(2,'https://www.cabanias.com.ar/fotos/la-gloria.020.b6.jpg')
--------------------------------------------------------------------------------------------------------------------------------
--Select *from Cabañas
go

Insert into Cabañas
values('https://media-cdn.tripadvisor.com/media/photo-s/12/1c/26/7b/cabanas-del-oso.jpg',2,100,2,3,120,'2020-01-01 10:30:00','2020-01-01 9:00:00',1)
go
Insert into Cabañas
values('https://cf.bstatic.com/images/hotel/max1024x768/136/136112818.jpg',2,120,3,4,150,'2020-01-02 10:30:00','2020-01-02 9:00:00',1)
go
Insert into Cabañas
values('https://images.adsttc.com/media/images/56fd/b861/e58e/ce2e/3200/000a/newsletter/sergio_rapanui_morerava_518.jpg?1459468366',2,1000,5,4,1200,'2020-01-03 11:30:00','2020-01-03 9:00:00',1)
go
Insert into Cabañas
values('https://i.pinimg.com/originals/1c/e2/24/1ce224df6062e9655f4ebffedbae109b.gif',2,1300,6,5,1500,'2020-01-04 11:30:00','2020-01-04 9:00:00',1)
go

insert into ImagenesCabañas
values(2,'https://i.pinimg.com/originals/1c/e2/24/1ce224df6062e9655f4ebffedbae109b.gif')
go
insert into ImagenesCabañas
values(3,'https://images.adsttc.com/media/images/56fd/b861/e58e/ce2e/3200/000a/newsletter/sergio_rapanui_morerava_518.jpg?1459468366')
go
insert into ImagenesCabañas
values(4,'https://cf.bstatic.com/images/hotel/max1024x768/136/136112818.jpg')
go
insert into ImagenesCabañas
values(1,'https://media-cdn.tripadvisor.com/media/photo-s/12/1c/26/7b/cabanas-del-oso.jpg')
go

insert into Paises
values('Argentina')
go
insert into Paises
values('Brasil')
go
insert into Paises
values('Colombia')
go
insert into Paises
values('Uruguay')
go
insert into Paises
values('Perú')
go
insert into Paises
values('Chile')
go
insert into Paises
values('Francia')
go
insert into Paises
values('Italia')
go
insert into Paises
values('Holanda')
go
insert into Paises
values('Inglaterra')
go
insert into Paises
values('Estados Unidos')
go
insert into Paises
values('Venezuela')
go
insert into Paises
values('Australia')
go
insert into Paises
values('Nueva Zelanda')
go
insert into Paises
values('Sudáfrica')
go
insert into Paises
values('Canadá')
go

insert into NivelesAcceso
values('Cliente')
go
insert into NivelesAcceso
values('Administrador')
go
insert into NivelesAcceso
values('Visitante')
go
