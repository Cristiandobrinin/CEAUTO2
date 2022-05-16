


use ceauto 

set dateformat dmy



insert into conf_auto values 

('218i Coupe(3)','rosie','3/4 cilindri, 136 CP','coupe','auto','',''),
('M240i xDrive Coupe(3)','verde','6/4 cilindri,340 CP','coupe','auto','',''),
('128ti','alba','4 cilindri,195 CP','hatchback','auto','',''),
('Luxure Line Seria 1','neagra','4 cilindri,195 CP','hatchback','auto','',''),
('M135i xDrive','albastru Misano','4 cilindri, 306 CP','hatchback','auto','',''),
('Advantage','alba','4 cilindri, 184 CP','coupe','auto','',''),
('Pachet M Sport PRO','alba','4 cilindri, 184 CP','coupe','auto','',''),
('223i Active Tourer','Gri Sparkling Copper','Hybrid, 326 CP','crossover','auto','',''),
('230e xDrive Active Tourer','Alb Mineral','Hybrid, 326 CP','crossover','auto','',''),
('Plug-in Hybrid','Roşu Melbourne','Hybrid','sedan','auto','',''),
('M3 Competition Sedan cu xDrive M','BMW Individual Alb Frozen Brilliant','510 CP, 650Nm','sedan','auto','',''),
('M340d xDrive Sedan','BMW Individual Gri Dravit','340 CP, 700 Nm','sedan','auto','',''),
('LE','MIDNIGHT BLACK METALLIC','1.8-Liter 4-cylinder, 121 hp','hatchback','auto','',''),
('Limited Prime','SUPERSONIC RED','1.8-Liter 4-cylinder, 121 hp','hatchback','auto','',''),
('L Eco','SEA GLASS PEARL','1.8-Liter 4-cylinder, 121 hp','hatchback','auto','',''),
('Limited Prius','WIND CHILL PEARL','1.8-Liter 4-cylinder, 121 hp','hatchback','auto','',''),
('SR','WHITE','V6: 278 hp; 265','truck','auto','',''),
('TRD PRO','WHITE','V6: 278 hp; 265','truck','auto','',''),
('XLE','WIND CHILL PEARL','AC synchronous electric motor(s), 201 hp (FWD), 214  hp (AWD)','crossover','auto','',''),
('Limited bZ4X','HEAVY METAL','AC synchronous electric motor(s), 201 hp (FWD), 214  hp (AWD)','crossover','auto','','')
 go

insert into deal_auto	values 
--BMW
('543524','BMW','Seria 1',				'218i Coupe(3)', 30000,'no'),
('545432','BMW','Seria 1',				'218i Coupe(3)', 30000,'no'),
('976831','BMW','Seria 1',				'218i Coupe(3)', 30000,'no'),
('545231','BMW','Seria 1',				'218i Coupe(3)', 30000,'no'),
('675763','BMW','Seria 1',				'218i Coupe(3)', 30000,'no'),
('678749','BMW','Seria 1',				'M240i xDrive Coupe(3)', 35000,'no'),
('989906','BMW','Seria 1',				'M240i xDrive Coupe(3)', 35000,'no'),
('008767','BMW','Seria 1',				'M240i xDrive Coupe(3)', 35000,'no'),
('888321','BMW','Seria 1',				'128ti', 40000, 'no'),
('432346','BMW','Seria 1',				'Luxure Line Seria 1', 44000, 'no'),
('763443','BMW','M135i xDrive',			'M135i xDrive', 50000,'no'),
('873783','BMW','Seria 2 Coupe',		'Advantage',50000,'no'),
('838322','BMW','Seria 2 Coupe',		'Pachet M Sport PRO',55000,'no'),
('864443','BMW','Seria 2 Active Tourer','223i Active Tourer',60000,'no'),
('423424','BMW','Seria 2 Active Tourer','230e xDrive Active Tourer',64000,'no'),
('838382','BMW','Seria 3 Sedan',		'Plug-in Hybrid',60000,'no'),
('797655','BMW','Seria 3 Sedan',		'Plug-in Hybrid',60000,'no'),
('000012','BMW','Seria 3 Sedan',		'Plug-in Hybrid',60000,'no'),
('086456','BMW','Seria 3 Sedan',		'Plug-in Hybrid',60000,'no'),
('554311','BMW','Seria 3 Sedan',		'M3 Competition Sedan cu xDrive M',60000,'no'),
('988771','BMW','Seria 3 Sedan',		'M3 Competition Sedan cu xDrive M',60000,'no'),
('886551','BMW','Seria 3 Sedan',		'M3 Competition Sedan cu xDrive M',60000,'no'),
('142141','BMW','Seria 3 Sedan',		'M3 Competition Sedan cu xDrive M',60000,'no'),
('052311','BMW','Seria 3 Sedan',		'M340d xDrive Sedan',55000,'no'),
('424666','BMW','Seria 3 Sedan',		'M340d xDrive Sedan',55000,'no'),
('045553','BMW','Seria 3 Sedan',		'M340d xDrive Sedan',55000,'no'),
('098897','BMW','Seria 3 Sedan',		'M340d xDrive Sedan',55000,'no'),
--Toyota
('914141','Toyota','Prius Prime',		'LE',28670,'no'),
('088654','Toyota','Prius Prime',		'LE',28670,'no'),
('575544','Toyota','Prius Prime',		'LE',28670,'no'),
('098645','Toyota','Prius Prime',		'LE',28670,'no'),
('678679','Toyota','Prius Prime',		'Limited Prime',34450,'no'),
('324211','Toyota','Prius Prime',		'Limited Prime',34450,'no'),
('646342','Toyota','Prius Prime',		'Limited Prime',34450,'no'),
('937124','Toyota','Prius',				'L Eco',25075,'no'),
('964352','Toyota','Prius',				'L Eco',25075,'no'),
('143231','Toyota','Prius',				'L Eco',25075,'no'),
('543221','Toyota','Prius',				'L Eco',25075,'no'),
('543563','Toyota','Prius',				'L Eco',25075,'no'),
('577612','Toyota','Prius',				'Limited Prius',33370,'no'),
('099092','Toyota','Prius',				'Limited Prius',33370,'no'),
('643626','Toyota','Tacoma',			'SR',27150,'no'),
('423322','Toyota','Tacoma',			'SR',27150,'no'),
('655522','Toyota','Tacoma',			'SR',27150,'no'),
('655453','Toyota','Tacoma',			'SR',27150,'no'),
('989631','Toyota','Tacoma',			'TRD PRO',46585,'no'),
('000993','Toyota','Tacoma',			'TRD PRO',46585,'no'),
('623561','Toyota','bZ4X',				'XLE',42000,'no'),
('682634','Toyota','bZ4X',				'XLE',42000,'no'),
('775422','Toyota','bZ4X',				'XLE',42000,'no'),
('236341','Toyota','bZ4X',				'Limited bZ4X',46700,'no'),
('543225','Toyota','bZ4X',				'Limited bZ4X',46700,'no')

go

insert into arenda_auto values

--BMW
('852352','BMW','Seria 3 Sedan',		'Plug-in Hybrid',60000),
('856422','BMW','Seria 3 Sedan',		'Plug-in Hybrid',60000),
('009977','BMW','Seria 3 Sedan',		'Plug-in Hybrid',60000),
('686741','BMW','Seria 3 Sedan',		'Plug-in Hybrid',60000),
('552111','BMW','Seria 1',				'218i Coupe(3)', 30000),
('525256','BMW','Seria 1',				'218i Coupe(3)', 30000),
('888994','BMW','Seria 1',				'218i Coupe(3)', 30000),
('000888','BMW','Seria 1',				'218i Coupe(3)', 30000),
('453452','BMW','Seria 2 Active Tourer','230e xDrive Active Tourer',64000),
('089988','BMW','Seria 2 Active Tourer','230e xDrive Active Tourer',64000),
('078233','BMW','Seria 2 Coupe',		'Pachet M Sport PRO',55000),
('826265','BMW','Seria 2 Coupe',		'Pachet M Sport PRO',55000),
('314551','BMW','Seria 2 Active Tourer','223i Active Tourer',60000),
('653632','BMW','Seria 1',				'128ti', 40000),
('753237','BMW','Seria 1',				'128ti', 40000),
--Toyota
('632325','Toyota','Prius Prime',		'LE',28670),
('887711','Toyota','Prius Prime',		'LE',28670),
('876664','Toyota','Prius Prime',		'LE',28670),
('635212','Toyota','Prius Prime',		'LE',28670),
('546322','Toyota','Prius',				'L Eco',25075),
('765765','Toyota','Prius',				'L Eco',25075),
('097787','Toyota','Prius',				'L Eco',25075),
('111122','Toyota','Prius',				'L Eco',25075),
('654642','Toyota','bZ4X',				'XLE',42000),
('645744','Toyota','bZ4X',				'XLE',42000)

go 

insert into employee(nume,prenume,tell) values

('Ivanov','Alexandru','078333455'),
('Boico','Andrei','08551125'),
('Levov','Nicolae','078431665'),
('Catov','Victor','067312552'),
('Puficovici','Pufic','068452666'),
('Trohin','Jana','093555121'),
('Denkova','Victoria','089444153'),
('Solita','Ioana','078321553'),
('Petrovici','Maxim','078321555'),
('Postachi','Andrei','07845661')

go

insert into empl_data values

(1,4502414653702,'12-2-2020',6000,'Alexandru Demo 12/2'),
(2,8591679078055,'23-12-2015',10000,'Bucuresti 23/14'),
(3,5439184532203,'30-5-2012',14000,'Alexandru Demo 23/1'),
(4,1255127161045,'31-1-2022',5000,'Vencrund 45/1'),
(5,7926880869652,'24-12-2022',5000,'Viilor 2'),
(6,8639973297476,'21-1-2020',6500,'Levov 21'),
(7,5654068338975,'12-1-2018',8000,'Ciorescu 8/3'),
(8,7721618446798,'4-3-2020',6000,'Catova 9'),
(9,5815720368162,'20-12-2022',4000,'Aldea-Teodorovici 12'),
(10,3750069975157,'7-12-2018',7000,'Moscova 2')

go 

insert into client (IDNP, nume, prenume, email, tell, adressa) values

(8917474978300,'Vladov','Cristina','Vladov@gmail.com','078444112','Aldea-Teodorovici 20'),
(7863334497566,'Chin','Chu','ChinChu21@gmail.com','078412563','Moldova 1'),
(5938224403609,'Gazon','Ainuru','Aninu43@mail.ru','078321123','Moldova 23'),
(1852610852982,'Lavrov','Maxim','Lavrov@gmail.com','078654321','Bucuresti 21'),
(8922157999166,'Yuki','Yuki','Yukiyu@mail.ru','067321555','Aldea-Teodorovici 43'),
(4062483231699,'Ivanov','Cristinel','IvanovCris@mail.ru','078321556','Ciorescu 32'),
(1502783950221,'Indiana','Jones','Indiana@gmail.com','078566432','Ciorescu 9'),
(6069129365758,'Nastasiev','Josev','Nastasii@gmail.com','068565867','Viilor 20'),
(3977680714074,'Laric','Numi','Laric@mail.ru','078513774','Catova 9'),
(9680618328706,'Hanokawa','Yumi','Hanokawayumi@gmail.com','078341265','Moscova 1')

go

