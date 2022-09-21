create database if not exists dbRickandMorty;
use dbRickandMorty;

create table Localizacao
(
idLocal integer primary key auto_increment,
nomeLocal varchar(100) not null,
dimensao varchar(100) not null
);

create table Personagem
(
idPersonagem integer primary key auto_increment,
nomePersonagem varchar(100) not null,
statusPersonagem varchar(50) not null,
especie varchar(100) not null,
genero varchar (50) not null,
localizacao int not null,
foreign key (localizacao) references Localizacao(idLocal)
);

create table Administrador
(
username varchar(100) primary key,
senha varchar(100) not null
);

drop database dbRickandMorty;
insert into Localizacao values(default, 'PLaneta Terra', 'Via Lactea');
insert into Personagem values (default, 'Otávio', 'morto', 'humano', 'masculino', 1);

select * from Localizacao;
select * from Personagem;
