CREATE TABLE balance_report (
    Id int not null,
    licence_plate nvarchar(30),
    mobileNo nvarchar(30),
    entranceDate DATE,
	onthewaydate DATE,
	paidbalance int,
	primary key(Id)
);

ALTER TABLE login_crd ALTER COLUMN userName nvarchar(30)


insert into balance_report (licence_plate,mobileNo,entranceDate,onthewaydate,paidbalance) values ('YCAVUSOGLU','YCAVUSOGLU',GETDATE(),'7.04.2021',50)
truncate table reg_detail
select * from reg_detail

select (SELECT DATEDIFF(minute, entranceDate, )) AS DateDiff,* from reg_detail

alter table reg_detail add location nvarchar(30)

SELECT DATEDIFF(minute, '2017/08/25 07:00', '2017/08/25 12:45') AS DateDiff;

update balance_report set onthewaydate='7.04.2021'
select SUM(paidbalance) from balance_report where onthewaydate='7.04.2021'
