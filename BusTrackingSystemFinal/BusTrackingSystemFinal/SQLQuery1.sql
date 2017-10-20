/* problems were in route_trip,driver,drives,bus_trip*/
create table company (company_id int primary key identity, company_name varchar(20), company_address varchar(50),company_phone_number varchar(12));
create table bus_type (bus_type_id int primary key  IDENTITY, bus_type_name varchar(10));
create table bus (bus_id INT primary key IDENTITY, bus_type_id INT foreign key references bus_type(bus_type_id) on delete cascade, company_id INT foreign key references company(company_id)on delete cascade);
create table location (location_id INT primary key IDENTITY, location_name varchar(20), latitude float, longitude float);
create table route (route_id INT primary key IDENTITY, source varchar(15), destination varchar(15));
create table passes_through (passes_through_id INT primary key IDENTITY, route_id INT foreign key references route(route_id)on delete cascade, location_id INT foreign key references location(location_id)on delete cascade, order_no smallint, time_to_reach time);

create table route_trip (route_trip_id INT primary key IDENTITY, route_id INT foreign key references route(route_id)on delete cascade, number_of_trips smallint, arrival_time time, departure_time time);
create table driver (driver_id int  primary key IDENTITY, driver_name varchar(20), phone_number varchar(12), driver_address varchar(50), gender varchar(6), date_of_birth date);
create table drives (drives_id INT primary key IDENTITY, driver_id INT foreign key references driver(driver_id)on delete cascade, bus_id INT foreign key references bus(bus_id)on delete cascade);

create table bus_trip (bus_trip_id int primary key IDENTITY, bus_trip_date date,start_time time, end_time time, route_trip_id int foreign key references route_trip(route_trip_id)on delete cascade, bus_id int foreign key references bus(bus_id)on delete cascade,driver_id int foreign key references driver(driver_id) on delete cascade);
insert into passes_through values(1,1,1,'02:03:00');
select * from passes_through