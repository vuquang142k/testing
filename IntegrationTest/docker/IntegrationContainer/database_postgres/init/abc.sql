drop table if exists "Accounts" ;
drop table if exists "Books";
drop table if exists "BusyBooks";
drop table if exists "PlaceBooks";
drop table if exists "Bookstores";

create table "Accounts"
(
	"Id" int  primary key,
	"Name" varchar(100) not null,
	"Login" varchar(100) not null,
	"Password" varchar(100) not null,
	"Type" int not null
);
insert into "Accounts" ("Id", "Name", "Login", "Password", "Type") values
	(1, 'user', 'user', 'user', 0),
	(2, 'admin', 'admin', 'admin', 1);

create table "Books"
(
	"Id" int  primary key,
	"Name" varchar(100) not null,
	"Dateproduct" varchar(100) not null
);
insert into "Books" ("Id", "Name", "Dateproduct") values
	(1, 'Alex', '03-01-2001'),
	(2, 'Tom', '06-12-2005'),
	(3, 'Tim', '16-08-2006');

create table "BusyBooks"
(
	"Id" int  primary key,
	"Idbook" int not null,
	"Date_received" varchar(100) not null,
	"Date_return" varchar(100) not null,
	"Idaccount" int not null
);
insert into "BusyBooks" ("Id", "Idbook", "Date_received", "Date_return", "Idaccount") values
	(1, 2, '06-07-2010', '07-07-2010', 1),
	(2, 3, '22-01-2012', '23-01-2012', 1);

create table "PlaceBooks"
(
	"Id" int  primary key,
	"Shelf" int not null,
	"Shelving" int not null,
	"Size_shelf" int not null
);
insert into "PlaceBooks" ("Id", "Shelf", "Shelving", "Size_shelf") values
	(1, 3, 4, 3),
	(2, 2, 5, 2),
	(3, 6, 4, 4);

create table "Bookstores"
(
	"Id" int  primary key,
	"Idbook" int not null,
	"Idplace" int not null,
	"Count" int not null
);
insert into "Bookstores" ("Id", "Idbook", "Idplace", "Count") values
	(1, 2, 2, 4),
	(2, 3, 1, 3);