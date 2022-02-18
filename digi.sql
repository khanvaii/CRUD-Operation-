use DigiData
Create table emptable(
ID int primary key identity(1,1),
Name varchar(50),
Eaddress varchar(50),
Department varchar(50),
Salary int
)

create procedure sp_insert
@name varchar(50),
@eaddress varchar(50),
@department varchar(50),
@salary int
as
begin
	insert into emptable values(@name,@eaddress,@department,@salary)
end

create procedure sp_update
@name varchar(50),
@eaddress varchar(50),
@department varchar(50),
@salary int,
@id int
as
begin
	update  emptable set Name=@name,Eaddress=@eaddress,Department=@department,Salary=@salary where ID=@id
end

create procedure sp_delete
@id int
as
begin
	delete from emptable where ID=@id
end

create procedure sp_select

as
begin
	select * from emptable
end