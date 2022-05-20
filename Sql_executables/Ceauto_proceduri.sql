--Procedurele de stocare 


use ceauto


-- conf_auto
go


go

create procedure addconf --adauga configuratie auto

@config char(50),
@color char(50),
@engine char(70),
@body char(20),
@box char(20),
@extras char(200),
@photo char(30)

as

insert into conf_auto(config,color,engine,body,box,extras,photo) values
(@config,@color,@engine,@body,@box,@extras,@photo)

go

create procedure editconf --modifica conf

@config char(50),
@color char(50),
@engine char(70),
@body char(20),
@box char(20),
@extras char(200),
@photo char(30)

as

update conf_auto set color = @color, engine = @engine, box = @box, extras = @extras, photo = @photo where conf_auto.config = @config


go

create procedure rmconf --sterge conf

@config char(50)

as

delete conf_auto where config = @config

go

-- Deal auto

create procedure adddeal

@serial int ,
@producer char(30),
@model char(30),
@config char(50),
@price money,
@used char(3)

as

insert into deal_auto values (@serial,@producer,@model,@config,@price,@used)

go

create procedure editdeal


@serial int ,
@producer char(30),
@model char(30),
@config char(50),
@price money,
@used char(3)

as

update deal_auto set  producer = @producer, model = @model, config = @config, price = @price, used = @used

go

create procedure rmdeal

@serial int

as

delete deal_auto where serial = @serial

go

-- Arenda auto

create procedure addarenda --adauga configuratie auto

@serial int ,
@producer char(30),
@model char(50),
@config char(50),
@tarif_min money

as

insert into arenda_auto values 
(@serial,@producer,@model,@config,@tarif_min)

go


create procedure editarenda --editeaza arenda


@serial int ,
@producer char(30),
@model char(50),
@config char(50),
@tarif_min money

as

update arenda_auto set  serial = @serial, producer = @producer, model = @model, config = @config, tarif_min = @tarif_min

go

create procedure rmarenda -- sterga arenda

@serial int

as

delete arenda_auto where serial = @serial

go


-- employeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee

create procedure addemplfulll  -- adauga empl  F odfsbngi oujbeuijobgiokusdg

@id_empl int,
@nume char(10),
@prenume char(10),
@tell char(9),
@IDNP char(13),
@data_ang date,
@salariu money,
@addresa char(40)


as

SET IDENTITY_INSERT employee ON

insert into employee(id_empl,nume,prenume,tell) values
(@id_empl,@nume,@prenume,@tell)

insert into empl_data values 
(@id_empl,@IDNP,@data_ang,@salariu,@addresa)


SET IDENTITY_INSERT employee OFF
GO

go

create procedure editemplfull --modifica angajati

@id_empl int,
@nume char(10),
@prenume char(10),
@tell char(9),
@IDNP char(13),
@data_ang date,
@salariu money,
@addresa char(40)

as

update employee set nume = @nume,prenume = @prenume,tell = @tell where id_empl = @id_empl;

update empl_data set IDNP = @IDNP, data_ang = @data_ang, salariu = @salariu, addresa = @addresa;

go

create procedure rmempl  --sterge angajat dupa ID

@id_empl int


as

delete empl_data where id_empl = @id_empl;

delete employee where id_empl = @id_empl;

go

--Client

go
create procedure addclient  --adauga client



 @IDNP char(13),
 @nume char(20),
 @prenume char(20),
 @email char(30),
 @tell char(9),
 @adressa char(40)
 
 as

 Insert into client(IDNP,nume,prenume,email,tell,adressa) values
 (@IDNP,@nume,@prenume,@email,@tell,@adressa)
 go

 create procedure editclient  --editeaza client


 @id int,
 @IDNP char(13),
 @nume char(20),
 @prenume char(20),
 @email char(30),
 @tell char(9),
 @adressa char(40)
 
 as

 update client set IDNP = @IDNP, nume = @nume, prenume = @prenume, email = @email , tell = @tell, adressa = @adressa where id_client = @id;
 go

 Create procedure rmclient --sterge client

 @id int

 as

 Delete client where id_client = @id
 go


 -- AMENO CREDIT

 go
 create procedure addcredit 

 

@id_client int,
@banca char(20),
@Suma_sol money,
@DAE float,
@suma_achitata money,
@suna_spre_achitare money,
@data_intocmirii date,
@data_scadentei date

as

insert into credit(id_client,banca,Suma_sol,DAE,suma_achitata,suna_spre_achitare,data_intocmirii,data_scadentei)
values (@id_client,@banca,@Suma_sol,@DAE,@suma_achitata,@suna_spre_achitare,@data_intocmirii,@data_scadentei)

go

 create procedure editcredit 

 
@id int,
@id_client int,
@banca char(20),
@Suma_sol money,
@DAE float,
@suma_achitata money,
@suna_spre_achitare money,
@data_intocmirii date,
@data_scadentei date

as

update credit set 
id_client = @id_client,banca = @banca, Suma_sol = @suma_achitata, DAE = @DAE, suma_achitata = @suma_achitata,suna_spre_achitare= @suna_spre_achitare,data_intocmirii = @data_intocmirii, data_scadentei = @data_scadentei 
where id_credit = @id;

go

create procedure rmcredit 

@id int

as

delete credit where id_credit = @id

go

--Contracte

create procedure addcont


@id_client int,
@serial int,
@id_empl int,
@data_intocmirii date,
@id_credit int,
@suma money

as

insert into deal_cont(id_client,serial,id_empl,data_intocmirii,id_credit,suma)
values(@id_client,@serial,@id_empl,@data_intocmirii,@id_credit,@suma)

go

create procedure editcont

@id int,
@id_client int,
@serial int,
@id_empl int,
@data_intocmirii date,
@id_credit int,
@suma money

as

update deal_cont set 
id_client = @id_client,serial = @serial,id_empl= @id_empl,data_intocmirii = @data_intocmirii, id_credit = @id_credit, suma = @suma
where id_contract = @id;


go

create procedure rmcont

@id int

as

delete deal_cont where id_contract = @id

go

--ownership

create procedure addowner

@id_client int,
@id_contract int,
@serial int,
@producer char(20),
@model char(20),
@config char(30)

as

insert into ownerauto values
(@id_client,@id_contract,@serial,@producer,@model,@config)

go

create procedure editowner  -- Nu atinge este cringe ( se leaga dupa serial number care se introduce cam in centru)

@id_client int,
@id_contract int,
@serial int,
@producer char(20),
@model char(20),
@config char(30)

as

update ownerauto set id_client = @id_client,id_contract = @id_contract , producer = @producer, model = @model where serial = @serial

go

create procedure rmowner

@id int

as

delete ownerauto where serial = @id

go

--contract arenda

create procedure addcontarenda

@serial int ,
@id_client int,
@data_intocmirii date,
@data_start date,
@data_end date,
@tarif_per_zi money,
@spre_plata money

as

insert into arenda_cont(serial,id_client,data_intocmirii,data_start,data_end,tarif_per_zi,spre_plata) values
(@serial,@id_client,@data_intocmirii,@data_start,@data_end,@tarif_per_zi,@spre_plata)

go

create procedure editcontractarenda 

@serial int ,
@id_client int,
@data_intocmirii date,
@data_start date,
@data_end date,
@tarif_per_zi money,
@spre_plata money

as

update arenda_cont set
id_client = @id_client, data_intocmirii= @data_intocmirii, data_start =@data_start, data_end = data_end, tarif_per_zi = @tarif_per_zi, spre_plata = @spre_plata where serial = @serial;

go

create procedure rmcontractarenda

@id int

as


delete arenda_cont where id_contract = @id

go

--logins

create procedure addlogin

@Logins char(30),
@Passwd char(64),
@Privileges char(5)


as

insert into logins values (@Logins,@Passwd,@Privileges)

go

create procedure editlogin --fine for  now

@Logins char(30),
@Passwd char(64)


as

update logins set Passwd = @Passwd where Logins = @Logins

go

create procedure rmlogin

@login char(20)

as

delete logins where Logins = @login

go


create procedure loginto --Logare ca un utilizator (###)

@login char(20),
@passd char(64)

as

select * from logins where Logins = @login and Passwd = @passd

go
