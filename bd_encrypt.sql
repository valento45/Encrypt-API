
CREATE DATABASE  bd_encrypt
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;
	
	
	CREATE SCHEMA IF NOT EXISTS sys
    AUTHORIZATION postgres;


	create table if not exists sys.chave_criptografia_tb(
		id_chave serial not null primary key,
		chave varchar not null,
		sistema integer not null	
	);
		
	create table if not exists sys.login_tb(
		id_login serial not null primary key,
		dh_login timestamp not null,
		licensa varchar,
		ip varchar,
		ip_rede varchar,
		name_machine varchar,
		id_usuario varchar
	);
	
	drop table sys.historico_requisicao_tb
	create table if not exists sys.historico_requisicao_tb(
			id_requisicao serial not null primary key,
			dh_requisicao timestamp not null,
		id_login integer not null,
		constraint id_login_fk foreign key(id_login)
		references sys.login_tb(id_login)
	);
	
	
	
	
	CREATE TABLE IF NOT EXISTS sys.tb_licensa(
	
	id_licensa serial not null primary key,
	codigo_licensa varchar not null,
	data_expiracao timestamp not null,
	tipo_licensa integer not null,
	qtd_acessos integer not null,
	qtd_ativos integer,
	bloqueada BOOLEAN
);

CREATE TABLE IF NOT EXISTS sys.tb_licensa_ativa(
	id_licensa_ativa serial not null primary key,
	id_disco varchar not null unique,
	codigo_licensa varchar not null
);
	
