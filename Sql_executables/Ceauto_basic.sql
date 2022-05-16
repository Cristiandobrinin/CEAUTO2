
set dateformat dmy
use master



go

If exists (select'True' from sys.databases where name ='ceauto')
		begin 
	drop database ceauto
		end;

	CREATE database ceauto

	go


	use ceauto


create table conf_auto(

config char(50) primary key,
color char(50) not null,
engine char(70) not null,
body char(20) not null,
box char(20) not null,
extras char(200),
photo char(30)

)

create table deal_auto(

serial int primary key,
producer char(30)not null,
model char(30) not null,
config char(50)not null,
price money not null,
used char(3)not null,
foreign key (config) references conf_auto(config)
)

create table arenda_auto(

serial int primary key,
producer char(30)not null,
model char(50)not null,
config char(50)not null,
tarif_min money,

foreign key (config) references conf_auto(config)

)

create table employee(

id_empl int IDENTITY(1,1) primary key,
nume char(10)not null,
prenume char(10)not null,
tell char(9)not null

)

create table empl_data(

id_empl int ,
IDNP char(13)not null,
data_ang date not null,
salariu money not null,
addresa char(40) ,


foreign key (id_empl) references employee(id_empl)

)


 create table client(

 id_client int IDENTITY(1,1) primary key,
 IDNP char(13) not null,
 nume char(20) not null,
 prenume char(20) not null,
 email char(30)not null,
 tell char(9) not null,
 adressa char(40) not null

 )


create table credit(

id_credit int IDENTITY(1,1) primary key,
id_client int,
banca char(20) not null,
Suma_sol money not null,
DAE float not null,
suma_achitata money not null,
suna_spre_achitare money not null,
data_intocmirii date not null,
data_scadentei date not null

foreign key (id_client) references client(id_client)

)

create table deal_cont(

id_contract int IDENTITY(1,1) primary key,
id_client int,
serial int,
id_empl int,
data_intocmirii date not null,
id_credit int,
suma money not null,

foreign key (id_client) references client(id_client),
foreign key (id_empl) references employee(id_empl),
foreign key (id_credit) references credit(id_credit),
foreign key (serial) references deal_auto(serial)
)

create table ownerauto(

id_client int,
id_contract int,
serial int not null,
producer char(20) not null,
model char(20) not null,
config char(30) not null,

foreign key (id_contract) references deal_cont(id_contract),
foreign key (id_client) references client(id_client)
)

create table arenda_cont(

id_contract  int IDENTITY(1,1),
serial int primary key,
id_client int,
data_intocmirii date not null,
data_start date not null,
data_end date not null,
tarif_per_zi money not null,
spre_plata money not null,


foreign key (serial) references arenda_auto(serial),
foreign key (id_client) references client(id_client)

)


create table logins(

Logins char(30) unique,
Passwd char(64) not null,
Privileges char(5) not null

)

go

