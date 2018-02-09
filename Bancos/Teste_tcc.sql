drop user tcc cascade;

CREATE USER tcc IDENTIFIED BY A12345;
ALTER USER tcc ACCOUNT UNLOCK;
GRANT ALL PRIVILEGES TO tcc;
 
 create table tcc.tbCurso(
 IDCurso integer not null,
 NomeCurso varchar(3) not null,
 constraint pk_IDCurso primary key (IDCurso));
 
 insert into tcc.tbCurso values (1,'INF');
 insert into tcc.tbCurso values (2,'EDF');
 insert into tcc.tbCurso values (3,'TEL');
 insert into tcc.tbCurso values (4,'EEL');
 
 
 create table tcc.tbMateria(
 IDMateria integer not null, 
 NomeMateria varchar2(20) not null,
 QtdAula NUMBER not null,
 constraint pk_IDMateria primary key (IDMateria));
 
 insert into tcc.tbMateria values (1,'INGLES',2);
 insert into tcc.tbMateria values (2,'SOCIOLOGIA',3);
 insert into tcc.tbMateria values (3,'PORTUGUES',3);
 insert into tcc.tbMateria values (4,'FISICA',2);
 insert into tcc.tbMateria values (5,'QUIMICA',2);
 insert into tcc.tbMateria values (6,'BIOLOGIA',2);
 insert into tcc.tbMateria values (7,'GEOGRAFIA',2);
 insert into tcc.tbMateria values (8,'HISTORIA',2);
 insert into tcc.tbMateria values (10,'ESTATISTICA',1);
 insert into tcc.tbMateria values (9,'MATEMATICA',3);
 insert into tcc.tbMateria values (11,'FILOSOFIA',1);
 insert into tcc.tbMateria values (12,'Educaçao fisica',1);
 
 create or replace view tcc.vw_materia as
 select IDMATERIA as codigo,NOMEMATERIA as materia, QTDAULA as quantidade_aulas from tcc.tbmateria ;
 
 create table tcc.tbNivelHierarquico(
 CodigoNH integer not null,
 NomeNH varchar2(20),
 constraint pk_CodigoNH primary key (CodigoNH));
 
 insert into tcc.tbNivelHierarquico values (1,'ESTRATEGICO');
 insert into tcc.tbNivelHierarquico values (2,'LOGICO');
 insert into tcc.tbNivelHierarquico values (3,'OPERACIONAL');
 
 
 create sequence tcc.SEQIDCARGO
 INCREMENT BY 1
 START WITH 1
 NOMAXVALUE
 NOMINVALUE 
 NOCACHE
 NOCYCLE; 
 create table tcc.tbCargo(
 IDCargo integer not null,
 NomeCargo varchar2(30) not null,
 SalCargo decimal not null,
 constraint pk_IDCargo primary key (IDCargo));
 insert into tcc.tbCargo values (tcc.SEQIDCARGO.NEXTVAL,'DIRETOR','3000');
 insert into tcc.tbCargo values (tcc.SEQIDCARGO.NEXTVAL,'VICE-DIRETOR','2500');
 insert into tcc.tbCargo values (tcc.SEQIDCARGO.NEXTVAL,'COORDENADOR','2400');
 insert into tcc.tbCargo values (tcc.SEQIDCARGO.NEXTVAL,'PROFESSOR','2300');
 insert into tcc.tbCargo values (tcc.SEQIDCARGO.NEXTVAL,'INSPETOR','2000');
 insert into tcc.tbCargo values (tcc.SEQIDCARGO.NEXTVAL,'FAXINEIRO','1700');
 
 create or replace view tcc.vw_cargo as 
 select idcargo as codigo, nomecargo as cargo, CONCAT('R$',salcargo) as salario from tcc.tbcargo;
 
 create sequence tcc.SEQIDFUNC
 INCREMENT BY 1
 START WITH 1
 NOMAXVALUE
 NOMINVALUE 
 NOCACHE
 NOCYCLE;
 create table tcc.tbFunc(
 IDFunc integer not null,
 FKIDCargo integer not null,
 NomeFunc varchar2(100) not null,
 CPFFunc varchar(11) not null,
 AIFUNC varchar2(8) NOT NULL,
  constraint pk_IDFunc primary key (IDFunc),
 constraint fk_IDCargoFunc foreign key (FKIDCargo)
 references tcc.tbCargo);
 
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,1,'Leonardo Sobral de Menezes','11111111111','A');
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,4,'Bruna Magrini','22222222222','A');
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,4,'Felipe Augusto Vasconcelos','33333383333','A');
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,4,'Emily Aparecida Silva dos Santos','42333333333','A');
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,4,'Ellen Christina Alcantra','33353633333','I');
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,4,'Karla Sobral de Menezes','12345678901','A');
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,4,'Dayana Sobral de Menezes','99964661333','I');
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,4,'Magali Sobral de Menezes','99926678653','A');
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,4,'Lucas Andrade de Avila','10293847561','A');
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,4,'Mariana Andrade de Avila','34593847561','A');
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,4,'Julia Gonçalves Silva','76538247561','A');
 insert into tcc.tbFunc values (tcc.SEQIDFUNC.NEXTVAL,2,'Pedro Gonçalves Silva','76548247561','A');
 
create or replace view tcc.vw_Funcionarios as
select f.idfunc as codigo ,f.NomeFunc as Nome, CPFFunc as CPF,cu.CARGO,cu.SALARIO , f.aifunc as situacao  
FROM TCC.TBFUNC f
inner join TCC.VW_CARGO cu on cu.CODIGO=f.FKIDCARGO ORDER BY 4;


create sequence tcc.seqProfMate
increment by 1
start with 1
nomaxvalue
nominvalue
nocache
nocycle;
create table tcc.tbProfMate(
IDProfMate integer not null,
FKIDMateria integer,
FKIDFunc integer not null,
constraint PK_IDProfMate primary key (IDProfMate),
constraint FK_IDMateria_ProfMate foreign key (FKIDMateria)
references tcc.tbMateria(IDMateria),
constraint FK_FKIDFunc_ProfMate foreign key (FKIDFunc)
references tcc.tbFunc (IDFunc));

insert into TCC.TBPROFMATE (IDPROFMATE,FKIDFUNC) values(tcc.seqprofmate.nextval,1);
insert into TCC.TBPROFMATE (IDPROFMATE,FKIDFUNC) values(tcc.seqprofmate.nextval,12);
insert into TCC.TBPROFMATE values(tcc.seqprofmate.nextval,2,6);
insert into TCC.TBPROFMATE values(tcc.seqprofmate.nextval,3,4);
insert into TCC.TBPROFMATE values(tcc.seqprofmate.nextval,4,1);
insert into TCC.TBPROFMATE values(tcc.seqprofmate.nextval,5,7);
insert into TCC.TBPROFMATE values(tcc.seqprofmate.nextval,6,2);
insert into TCC.TBPROFMATE values(tcc.seqprofmate.nextval,7,3);
insert into TCC.TBPROFMATE values(tcc.seqprofmate.nextval,8,2);
insert into TCC.TBPROFMATE values(tcc.seqprofmate.nextval,9,11);
insert into TCC.TBPROFMATE values(tcc.seqprofmate.nextval,10,10);
insert into TCC.TBPROFMATE values(tcc.seqprofmate.nextval,11,9);
insert into TCC.TBPROFMATE values(tcc.seqprofmate.nextval,12,5);
--Mostrar informaçoes importantes do funcionario
create or replace view tcc.vw_professormateria as
select f.IDFunc as codigo, f.NOMEFUNC as nome, f.CPFFUNC as CPF, cargo.NomeCargo as funcao, m.NOMEMATERIA as materia  from TCC.tbfunc f
INNER join TCC.tbcargo cargo on cargo.IDCARGO= f.FKIDCARGO
INNER join TCC.TBprofmate pm on f.IDFUNC=pm.FKIDFUNC
INNER join tcc.tbmateria m on m.IDMateria=pm.FKIDMateria;

select * from tcc.vw_professormateria order by 1;
 

 create sequence tcc.SEQIDTURMA
 INCREMENT BY 1
 START WITH 1
 NOMAXVALUE
 NOMINVALUE 
 NOCACHE
 NOCYCLE;
 create table tcc.tbTurma(
 IDTurma integer not null,
 NomeTurma varchar(1) not null,
 AnoTurma varchar(1) not null,
 PeriodoTurma varchar(1) not null,
 FKCursoTurma integer not null,
 constraint pk_IDTurma primary key (IDTurma),
 constraint fk_FKCursoTurma foreign key (FKCursoTurma)
 references tcc.tbCurso (IDCurso));
 
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','1','T',1);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','2','M',1);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','3','M',1);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','1','T',1);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','2','M',1);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','3','M',1);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','1','T',2);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','2','M',2);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','3','M',2);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','1','T',2);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','2','M',2);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','3','M',2);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','1','T',3);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','2','T',3);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','3','M',3);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','1','T',3);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','2','T',3);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','3','M',3);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','1','T',4);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','2','T',4);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'A','3','M',4);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','1','T',4);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','2','T',4);
insert into tcc.tbTurma values (TCC.SEQIDTURMA.NEXTVAL,'B','3','M',4);

create or replace view tcc.vw_sala as
select concat(curso.NOMECURSO, concat(t.ANOTURMA,concat(t.nometurma, t.PERIODOTURMA))) as sala from tcc.tbTurma t
inner join tcc.tbCurso curso on t.FKCursoTurma=curso.IDCurso with read only; 

select * from tcc.vw_sala;


 create sequence tcc.seqrmaluno
 increment by 15
 start with 25000
 nominvalue
 nomaxvalue
 nocache
 nocycle;
create table tcc.tbAluno(
RMAluno integer not null,
NomeAluno varchar2(75) not null,
CPFAluno varchar(11) not null unique,
EmailAluno varchar2(50) not null unique,
AIAluno VARCHAR(8) not null,
DTAluno VARCHAR2(20) not null,
FKTurmaAluno integer not null,
constraint pk_RMAluno primary key (RMAluno),
constraint fk_FKTurmaAluno foreign key (FKTurmaAluno)
references tcc.tbTurma (IDTurma));

select * from tcc.tbaluno;
select * from tcc.tbAlunoFoto;

create table tcc.tbAlunoFoto(
Foto blob not null, 
FKRMAluno integer not null,
constraint fkfoto_FKRMAluno foreign key (FKRMAluno)
references tcc.tbAluno(RMAluno)
);



SELECT * FROM TCC.TBALUNO;

 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Osvaldo Pereira dos Santos', '90080711125', 'osvaldo@teste.com','A','07-10-2002',1);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Fulano da Silva Cruz', '12358711125', 'fulano@teste.com','A','07-05-2002',1);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Cicrano da Silva Sauro', '67489209155', 'cicrano@teste.com','A','30-12-2002',1);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Giovana Marinai', '84756382923', 'giovana@teste.com','A','13-07-2001',2);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Christian Santos Viana', '67480947813', 'christian@teste.com','A','21-03-2001',2);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Jhonathan Santos', '69078563813', 'jhow@teste.com','A','17-05-2001',2);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Camille Viana', '34568923102', 'Camille@teste.com','A','20-11-2000',3);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Leticia Correa Aguiar','67457819813', 'leh@teste.com','A','04-09-2000',3);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Adam Riquelmi Aliança', '56473829104', 'ada1@teste.com','A','04-01-2000',3);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Jorge Grão Gerbasi Caldeira Pedrosa', '08000770800', 'nome.estranho@teste.com','I','16-08-2002',4);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Paolo Oliveira Teixeira', '47568390856', 'paloco@teste.com','A','07-04-2002',4);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Pietro Pereira Paxeco', '90234658196', 'jusalves@teste.com','A','07-01-2002',4); 
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Jade Gonsalves Sobral',   '12345632456', 'jade0102@teste.com','A','21-12-2001',5);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Louis Gonçalves Menezes', '84759323457', 'l01S@teste.com','A','21-12-2001',5);
 insert into tcc.tbAluno values (tcc.seqrmaluno.nextval, 'Bianca Gonçalves Aparecida dos Santos', '48576098704', 'bihh@teste.com','A','30-08-2001',5);
 
 create or replace view tcc.vw_Aluno as
 select alu.RMAluno as RM,alu.NomeAluno as Nome,alu.CPFALUNO as cpf,concat(curso.NOMECURSO, concat(t.ANOTURMA,concat(t.nometurma, t.PERIODOTURMA))) as sala,alu.AIALUNO AS SITUACAO  
 from tcc.tbAluno alu
 inner join tcc.tbTurma t on t.IDTurma=alu.FKTurmaAluno
 inner join tcc.tbCurso curso on curso.IDCurso=t.FKCursoTurma;
 
 select * from tcc.vw_aluno;
 -- curso, profMate, func, cargo, nh, materia, turma, aluno, noita
 
 
 create table tcc.tbNota(
 IDNota integer not null,
 PATNota number(3,1) not null,
 PEMNota number(3,1) not null,
 TrabalhoNota number(3,1) not null,
 TrimestreNota varchar(1) not null,
 FKRMAluno integer not null,
 FKIDPMNota integer not null,
 constraint pk_IDNota primary key (IDNota),
 constraint fk_FKRMAluno foreign key (FKRMAluno)
 references tcc.tbAluno (RMAluno),
 constraint fk_FKIDFuncMateNota foreign key (FKIDPMNota)
 references tcc.tbProfMate (IDProfMate)); 
 
 insert into tcc.tbNota values(1,09.5,8,9,'2',25015,1);

create or replace view tcc.vw_media as
select concat(cs.NOMECURSO ,concat( t.NOMETURMA ,concat( t.ANOTURMA , t.PERIODOTURMA))) as sala,alu.RMALUNO as RM, 
alu.NOMEALUNO as nome_do_aluno, m.NOMEMATERIA as materia, f.NOMEFUNC as professor, n.TRIMESTRENOTA as Trimestre, n.PATNOTA as PAT,
n.PEMNOTA as PEM, n.TRABALHONOTA as Trabalho
from tcc.tbNota n
inner join tcc.tbAluno alu on alu.RMAluno=n.FKRMAluno
inner join tcc.tbProfMate pm on n.FKIDPMNota=pm.IDProfMate
inner join tcc.tbFunc f on pm.FKIDFunc=f.IDFunc
inner join tcc.tbMateria m on pm.FKIDMateria=m.IDMateria
inner join TCC.TBTURMA t on alu.FKTURMAALUNO=t.IDTURMA
inner join tcc.tbCurso cs on cs.IDCURSO=t.FKCURSOTURMA;

Select * from TCC.VW_MEDIA;

 create table tcc.tbLogin(
 CodigoLogin integer not null,
 UsuarioLogin varchar2(20) not null unique,
 SenhaLogin varchar2(20) not null,
 FKNHLogin integer not null,
 constraint pk_CodigoLogin primary key (CodigoLogin),
 constraint fk_FKNHLogin foreign key (FKNHLogin)
 references tcc.tbNIVELHIERARQUICO (CODIGONH));
 insert into tcc.tbLogin values(1,'Dinossauro','void7',1);
 insert into tcc.tblogin values (2, 'Everton', 'senha123', 2);


 --TABELAS/VIEWS PRONTAS
 SELECT *FROM TCC.TBCUSO;
 SELECT *FROM TCC.TBMATERIA;
 SELECT *FROM TCC.TBNIVELHIERARQUICO;
 SELECT *FROM TCC.TBCARGO;
 SELECT *FROM TCC.TBFUNC;
 SELECT *FROM TCC.TBPROFMATE;
 SELECT *FROM TCC.TBTURMA;
 SELECT *FROM TCC.TBALUNO; 
 SELECT *FROM TCC.VW_MATERIA;
 SELECT *FROM TCC.VW_CARGO;
 SELECT *FROM TCC.VW_FUNCIONARIOS;
 SELECT *FROM TCC.VW_PROFESSORMATERIA;
 SELECT *FROM TCC.VW_SALA;
 SELECT *FROM TCC.vw_MATERIA;
 SELECT *FROM TCC.VW_ALUNO;