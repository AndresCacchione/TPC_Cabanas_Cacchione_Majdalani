use Cacchione_Majdalani_DB

Select *from complejos

insert into Complejos
values('https://www.cabanias.com.ar/fotos/la-gloria.020.b5.jpg','Brasa que Arde', 1542365245, 'Tigre', 'Brazaquearde@hotmail.com', 1, 0);

insert into Complejos
values('https://www.cabanias.com.ar/fotos/la-gloria.020.b9.jpg','La gloria', 1526598544, 'Tigre, La isla', 'LaGloria@hotmail.com', 1, 0);

-------------------------------------------------------------------------------------------------------------------------------
Select *from ImagenesComplejos

insert into ImagenesComplejos
Values(1,'https://www.cabanias.com.ar/fotos/la-gloria.020.b10.jpg')

insert into ImagenesComplejos
Values(1,'https://www.cabanias.com.ar/fotos/la-gloria.020.b3.jpg')

insert into ImagenesComplejos
Values(2,'https://www.cabanias.com.ar/fotos/la-gloria.020.b1.jpg')

insert into ImagenesComplejos
Values(2,'https://www.cabanias.com.ar/fotos/la-gloria.020.b6.jpg')
--------------------------------------------------------------------------------------------------------------------------------
Select *from Cabañas

Insert into Cabañas
values(1,100,2,3,120,'2020-01-01 10:30:00','2020-01-01 9:00:00',1)

Insert into Cabañas
values(1,120,3,4,150,'2020-01-02 10:30:00','2020-01-02 9:00:00',1)

Insert into Cabañas
values(2,1000,5,4,1200,'2020-01-03 11:30:00','2020-01-03 9:00:00',1)

Insert into Cabañas
values(2,1300,6,5,1500,'2020-01-04 11:30:00','2020-01-04 9:00:00',1)


insert into ImagenesCabañas
values(2,'https://www.cabanias.com.ar/fotos/la-gloria.020.b2.jpg')

insert into ImagenesCabañas
values(3,'https://www.cabanias.com.ar/fotos/la-gloria.020.b2.jpg')

insert into ImagenesCabañas
values(4,'https://www.cabanias.com.ar/fotos/la-gloria.020.b2.jpg')

insert into ImagenesCabañas
values(5,'https://www.cabanias.com.ar/fotos/la-gloria.020.b2.jpg')
