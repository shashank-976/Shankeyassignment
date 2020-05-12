create database webapp;
use webapp;
create table students(Name varchar(20),Marks int,Dept varchar(20),credit int);
select * from students;
create Procedure setstudents as begin
select * from students end;
setstudents;

sp_helptext setstudents

create procedure setInsert(@Name varchar(30),@Marks int,@Dept varchar(30),@credit int) 
as
 insert into students values(@Name,@Marks,@Dept ,@credit)

 create procedure setInsert2(@SId int,@Name varchar(30),@Marks int,@Dept varchar(30),@credit int) 
as Begin
 insert into students values(@SId ,@Name,@Marks,@Dept ,@credit)
 end
 drop table students;
 use webapp;
 create table students(SId int identity,Name varchar(20),Marks int,Dept varchar(20),credit int,PRIMARY KEY(SId));
select * from students;
drop table students


 create procedure setInsert3(@Name varchar(30),@Marks int,@Dept varchar(30),@credit int) 
as Begin
 insert into students values(@Name,@Marks,@Dept ,@credit)
 end