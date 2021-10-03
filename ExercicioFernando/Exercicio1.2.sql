CREATE TABLE produto (
  id INT NOT NULL,
  nome VARCHAR(45) NOT NULL,
  valor DECIMAL NOT NULL,
  CONSTRAINT PK_ID_PRODUTO PRIMARY KEY (id));

CREATE TABLE estoque (
  quantidade INT NULL,
  id_produto INT NOT NULL,
	CONSTRAINT FK_ID_PRODUTO FOREIGN KEY (id_produto) REFERENCES produto (id));
    
CREATE TABLE nota_fiscal (
  id INT NOT NULL,
  valor_total DECIMAL NULL,
  CONSTRAINT PK_ID_NOTA PRIMARY KEY (id));

CREATE TABLE venda (
  produto_id INT NOT NULL,
  id_nota INT NOT NULL,
  quantidade_produtos INT NULL,
  
  CONSTRAINT FK_VENDA_PRODUTO FOREIGN KEY (produto_id) REFERENCES produto (id), 
  CONSTRAINT FK_NOTA_FISCAL FOREIGN KEY (id_nota) REFERENCES nota_fiscal (id));
