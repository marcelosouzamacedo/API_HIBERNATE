CREATE TABLE CLIENTE (
    Id int NOT NULL IDENTITY PRIMARY KEY,
    CodIdentificadorTotvs nvarchar(4),
	Cpf nvarchar(14),
	Nome nvarchar(30),
	DataInclusao datetime,
    PROGRAMA_DESCONTO_ID int FOREIGN KEY REFERENCES PROGRAMA_DESCONTO(ID)
);