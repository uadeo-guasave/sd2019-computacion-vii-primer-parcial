-- describe users; (mysql)
PRAGMA table_info('users');
PRAGMA foreign_keys = 1;
PRAGMA foreign_keys;

select * from users;

insert into users (name,password,first_name,last_name,email,status,role_id)
values ('alfredo','123','Alfredo','Gomez','alfredo@gomez',1,1);

-- no funciona
select last_insert_rowid();

select id from users where name = 'alfredo';

delete from users;

insert into roles (name)
values ('Administrador'),
       ('Usuario'),
       ('Invitado');
select * from roles;

explain
select id,
       name,
       password,
       first_name,
       last_name,
       email,
       status,
       (select name from roles where id = u.role_id) 'role'
  from users u;

EXPLAIN
select u.id,
       u.name,
       u.password,
       u.first_name,
       u.last_name,
       u.email,
       u.status,
       r.name 'role'
  from users u
  join roles r
    on u.role_id = r.id;


select * from users;
select * from roles;
select * from permissions;
select * from roles_permissions;

-- ImprimirUsuariosConPermisos
select u.id user_id,
       u.name user_name,
       u.first_name || ' ' || u.last_name user_fullname,
       r.name role_name,
       group_concat(p.description, ', ') perm_description
  from users u
  join roles r
    on u.role_id = r.id
    join roles_permissions rp
        on r.id = rp.role_id
        join permissions p
            on rp.permission_id = p.id
 group by u.id;
 