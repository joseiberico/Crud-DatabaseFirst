Create database DBCRUDADO
use DBCRUDADO

Create table Contacto (
IdContacto int primary key identity(1,1),
Nombre varchar(50),
Telefono varchar(50),
Correo varchar(150)
)

select * from Contacto