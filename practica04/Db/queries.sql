-- describe users; (mysql)
PRAGMA table_info('users');

select * from users;

insert into users (name,password,first_name,last_name,email,status)
values ('alfredo','123','Alfredo','Gomez','alfredo@gomez',1);

-- no funciona
select last_insert_rowid();

select id from users where name = 'alfredo';