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
values('https://www.cabanias.com.ar/fotos/la-gloria.020.b9.jpg','Catupecumachu', 1526598544, 'Tigre, La isla, En la selva Amazonas donde los mosquitos son del tama�o de un bondi', 'LaGloria@hotmail.com', 1, 0);
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
--Select *from Caba�as
go

Insert into Caba�as
values('https://media-cdn.tripadvisor.com/media/photo-s/12/1c/26/7b/cabanas-del-oso.jpg',2,100,2,3,120,'2020-01-01 10:30:00','2020-01-01 9:00:00',1)
go
Insert into Caba�as
values('https://cf.bstatic.com/images/hotel/max1024x768/136/136112818.jpg',2,120,3,4,150,'2020-01-02 10:30:00','2020-01-02 9:00:00',1)
go
Insert into Caba�as
values('https://images.adsttc.com/media/images/56fd/b861/e58e/ce2e/3200/000a/newsletter/sergio_rapanui_morerava_518.jpg?1459468366',2,1000,5,4,1200,'2020-01-03 11:30:00','2020-01-03 9:00:00',1)
go
Insert into Caba�as
values('https://i.pinimg.com/originals/1c/e2/24/1ce224df6062e9655f4ebffedbae109b.gif',2,1300,6,5,1500,'2020-01-04 11:30:00','2020-01-04 9:00:00',1)
go

insert into ImagenesCaba�as
values(2,'https://i.pinimg.com/originals/1c/e2/24/1ce224df6062e9655f4ebffedbae109b.gif')
go
insert into ImagenesCaba�as
values(3,'https://images.adsttc.com/media/images/56fd/b861/e58e/ce2e/3200/000a/newsletter/sergio_rapanui_morerava_518.jpg?1459468366')
go
insert into ImagenesCaba�as
values(4,'https://cf.bstatic.com/images/hotel/max1024x768/136/136112818.jpg')
go
insert into ImagenesCaba�as
values(1,'https://media-cdn.tripadvisor.com/media/photo-s/12/1c/26/7b/cabanas-del-oso.jpg')
