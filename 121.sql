CREATE DATABASE Midtree;
USE Midtree;


 select * from tblEmployee
 select * from tblBonus
 select * from tblTitle

1. select FIRST_NAME+' '+LAST_NAME AS EmployeesNames , SALARY from tblEmployee where SALARY  BETWEEN 5000 AND 10000

2.
 SELECT COUNT(EMPLOYEE_ID) AS NO_OF_EMPLOYEES ,DEPARTMENT FROM tblEmployee group by DEPARTMENT ORDER BY DEPARTMENT DESC
 SELECT FIRST_NAME+' '+LAST_NAME as Employees_names,EMPLOYEE_ID,SALARY,JOINING_DATE,DEPARTMENT,EMPLOYEE_TITLE FROM tblEmployee e inner join tblTitle t on e.EMPLOYEE_ID=t.EMPLOYEE_REF_ID where EMPLOYEE_TITLE='Manager';
 
 SELECT EMPLOYEE_TITLE,AFFECTED_FROM FROM tblTitle group by EMPLOYEE_TITLE,AFFECTED_FROM having count(*)>1
 select * from tblEmployee where (EMPLOYEE_ID%2=1)
 select max(SALARY) as second_highest_salary  FROM tblEmployee where SALARY not in (select Max(SALARY) from tblEmployee)
 select FIRST_NAME+' '+LAST_NAME As Employees_names ,SALARY ,DEPARTMENT from tblEmployee where SALARY in(select Max(SALARY) from tblEmployee group by DEPARTMENT)