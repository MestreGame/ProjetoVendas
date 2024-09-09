CREATE TABLE fornecedor (
  codigo INTEGER  NOT NULL   IDENTITY ,
  nome VARCHAR(20)    ,
  telefone VARCHAR(14)      ,
PRIMARY KEY(codigo));





CREATE TABLE marca (
  codigo INTEGER  NOT NULL   IDENTITY ,
  nome VARCHAR(20)    ,
  descricao VARCHAR(30)      ,
PRIMARY KEY(codigo));





CREATE TABLE cliente (
  codigo INTEGER  NOT NULL   IDENTITY ,
  nome VARCHAR(30)    ,
  cpf VARCHAR(14)    ,
  rua VARCHAR(30)    ,
  numero INTEGER    ,
  cep VARCHAR(9)    ,
  telefone VARCHAR(15)    ,
  cidade VARCHAR(20)    ,
  uf VARCHAR(2)      ,
PRIMARY KEY(codigo));





CREATE TABLE fazerpedido (
  codigo INTEGER  NOT NULL   IDENTITY ,
  cliente_codigo INTEGER  NOT NULL  ,
  datapedido DATE    ,
  dataentrega DATE    ,
  valortotal DECIMAL(7,2)      ,
PRIMARY KEY(codigo)  ,
  FOREIGN KEY(cliente_codigo)
    REFERENCES cliente(codigo));



CREATE INDEX fazerpedido_FKIndex1 ON fazerpedido (cliente_codigo);



CREATE INDEX IFK_Rel_03 ON fazerpedido (cliente_codigo);



CREATE TABLE produto (
  codigo INTEGER  NOT NULL   IDENTITY ,
  fornecedor_codigo INTEGER  NOT NULL  ,
  marca_codigo INTEGER  NOT NULL  ,
  nome VARCHAR(20)    ,
  quantidade INTEGER    ,
  valorunitario DECIMAL(7,2)    ,
  descricao VARCHAR(30)      ,
PRIMARY KEY(codigo)    ,
  FOREIGN KEY(marca_codigo)
    REFERENCES marca(codigo),
  FOREIGN KEY(fornecedor_codigo)
    REFERENCES fornecedor(codigo));



CREATE INDEX produto_FKIndex1 ON produto (marca_codigo);

CREATE INDEX produto_FKIndex2 ON produto (fornecedor_codigo);



CREATE INDEX IFK_Rel_01 ON produto (marca_codigo);

CREATE INDEX IFK_Rel_02 ON produto (fornecedor_codigo);



CREATE TABLE itenspedido (
  codigo INTEGER  NOT NULL   IDENTITY ,
  fazerpedido_codigo INTEGER  NOT NULL  ,
  produto_codigo INTEGER  NOT NULL  ,
  valorunitario DECIMAL(7,0)    ,
  quantidade INTEGER      ,
PRIMARY KEY(codigo)    ,
  FOREIGN KEY(produto_codigo)
    REFERENCES produto(codigo),
  FOREIGN KEY(fazerpedido_codigo)
    REFERENCES fazerpedido(codigo));



CREATE INDEX itenspedido_FKIndex1 ON itenspedido (produto_codigo);

CREATE INDEX itenspedido_FKIndex2 ON itenspedido (fazerpedido_codigo);



CREATE INDEX IFK_Rel_04 ON itenspedido (produto_codigo);

CREATE INDEX IFK_Rel_05 ON itenspedido (fazerpedido_codigo);




