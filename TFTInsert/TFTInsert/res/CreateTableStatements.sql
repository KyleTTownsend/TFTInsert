
Create Table origin (
	origin_id int Primary Key IDENTITY NOT NULL,
	name varchar(40),
	origin_desc varchar(200),
	imd_id int
)



Create Table origin_bonus(
	origin_bonus_id int Primary Key Identity not null,
	origin_id int,
	Constraint fk_origin_id Foreign Key (origin_id) references origin(origin_id),
	needed smallint,
	effect varchar(200)
)



create table champion(
champion_id int not null primary key identity,
name varchar(50),
cost smallint,
)

create table champion_origin_link(
	champion_id int,
	origin_id int,
	Constraint pk_champion_origin_id Primary key(champion_id, origin_id),
	Constraint fk_champion Foreign key(champion_id) references champion(champion_id),
	Constraint fk_origin Foreign Key(origin_id) references origin(origin_id)
)

create table champion_class_link(
	champion_id int,
	class_id int,
	Constraint pk_champion_class_id Primary key(champion_id, class_id),
	Constraint fk_champion_class Foreign key(champion_id) references champion(champion_id),
	Constraint fk_class_champion Foreign Key(class_id) references class(class_id)
)

create table champion_stat(
	stat_id int not null primary key identity,
	champion_id int,
	damage smallint,
	attack_speed float,
	dps smallint,
	range smallint,
	health smallint,
	armor smallint,
	magic_resist smallint,
	Constraint fk_champion_id Foreign Key(champion_id) references champion(champion_id)
)
