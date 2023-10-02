# codigo sql server 

create database practica;
use practica;

create table usuario(
	idusuario int primary key identity(1,1),
	usuario varchar(50) not null,
	clave varchar(100) not null
);

select * from usuario;
insert into usuario values ('usuario1', 'usuario1');
update usuario set usuario = 'usuario', clave = 'usuario' where idusuario = 1;
delete from usuario where idusuario = 1;
select * from usuario where usuario like '%usuario%';
