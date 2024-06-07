USE Condo;

GO

INSERT INTO Condominiums(Name, Type, PropertyTax) VALUES('Residencial Bela Vista', 0, 350);
INSERT INTO Condominiums(Name, Type, PropertyTax) VALUES('Business One', 1, 2180);
GO

INSERT INTO Unities(Name, CondominiumId) VALUES('Ap 300', 1);
INSERT INTO Unities(Name, CondominiumId) VALUES('Ap 400', 1);
INSERT INTO Unities(Name, CondominiumId) VALUES('Ap 500', 1);
INSERT INTO Unities(Name, CondominiumId) VALUES('Ap 600', 1);
GO

INSERT INTO Unities(Name, CondominiumId) VALUES('Sala 15A', 2);
INSERT INTO Unities(Name, CondominiumId) VALUES('Sala 15B', 2);
INSERT INTO Unities(Name, CondominiumId) VALUES('Sala 15C', 2);
INSERT INTO Unities(Name, CondominiumId) VALUES('Sala 15D', 2);

GO


INSERT INTO Person(Name, Document) VALUES('Ana Maria Silva', '123456789');
INSERT INTO Person(Name, Document) VALUES('João Carlos Pereira', '987654321');
INSERT INTO Person(Name, Document) VALUES('Mariana Souza Lima', '234567890');
INSERT INTO Person(Name, Document) VALUES('Carlos Alberto Ferreira', '876543219');
INSERT INTO Person(Name, Document) VALUES('Fernanda Gomes Oliveira', '345678901');
INSERT INTO Person(Name, Document) VALUES('Lucas Henrique Santos', '765432198');
INSERT INTO Person(Name, Document) VALUES('Patrícia Almeida Rocha', '456789012');
INSERT INTO Person(Name, Document) VALUES('Rafael Augusto Costa', '654321987');
INSERT INTO Person(Name, Document) VALUES('Juliana Azevedo Silva', '567890123');
INSERT INTO Person(Name, Document) VALUES('Rodrigo de Souza Barbosa', '543219876');
INSERT INTO Person(Name, Document) VALUES('Marcelo Vieira Gomes', '678901234');
INSERT INTO Person(Name, Document) VALUES('Beatriz Martins Lima', '432198765');
INSERT INTO Person(Name, Document) VALUES('Gabriel Mendes Cunha', '789012345');
INSERT INTO Person(Name, Document) VALUES('Larissa Nogueira Dias', '321987654');
INSERT INTO Person(Name, Document) VALUES('Vinícius Ferreira Oliveira', '890123456');
INSERT INTO Person(Name, Document) VALUES('Renata de Oliveira Santos', '219876543');
INSERT INTO Person(Name, Document) VALUES('Felipe Barbosa Lima', '901234567');
INSERT INTO Person(Name, Document) VALUES('Carolina Moraes Silva', '198765432');
INSERT INTO Person(Name, Document) VALUES('Gustavo Ribeiro Souza', '012345678');
INSERT INTO Person(Name, Document) VALUES('Tatiana Costa Almeida', '876543210');
INSERT INTO Person(Name, Document) VALUES('Pedro Henrique Batista', '234567801');
INSERT INTO Person(Name, Document) VALUES('Adriana Machado Silva', '765432109');
INSERT INTO Person(Name, Document) VALUES('Thiago Lima Ferreira', '345678912');
INSERT INTO Person(Name, Document) VALUES('Amanda de Souza Rocha', '654321098');
INSERT INTO Person(Name, Document) VALUES('Ricardo Almeida Gomes', '456789023');
INSERT INTO Person(Name, Document) VALUES('Daniela Nogueira Azevedo', '543210987');
INSERT INTO Person(Name, Document) VALUES('Murilo Ferreira Lima', '678901245');
INSERT INTO Person(Name, Document) VALUES('Simone Ribeiro Costa', '432109876');
INSERT INTO Person(Name, Document) VALUES('Hugo de Oliveira Santos', '789012354');
INSERT INTO Person(Name, Document) VALUES('Natália Souza Lima', '321098765');
INSERT INTO Person(Name, Document) VALUES('Leandro Batista Ferreira', '890123465');
INSERT INTO Person(Name, Document) VALUES('Tatiane Moraes Silva', '210987654');
INSERT INTO Person(Name, Document) VALUES('Eduardo Mendes Cunha', '901234576');
INSERT INTO Person(Name, Document) VALUES('Aline Gomes Oliveira', '198765423');
INSERT INTO Person(Name, Document) VALUES('Bruno de Souza Barbosa', '012345687');
INSERT INTO Person(Name, Document) VALUES('Elaine Vieira Lima', '876543201');
INSERT INTO Person(Name, Document) VALUES('César Nogueira Dias', '234567812');
INSERT INTO Person(Name, Document) VALUES('Sabrina Azevedo Silva', '765432190');
INSERT INTO Person(Name, Document) VALUES('Victor Ribeiro Costa', '345678921');
INSERT INTO Person(Name, Document) VALUES('Marina de Oliveira Santos', '654321087');
INSERT INTO Person(Name, Document) VALUES('Danilo Silva', '487738596');
INSERT INTO Person(Name, Document) VALUES('Rafael Martins', '487738595');
GO

INSERT INTO Residents(UnityId, PersonId) VALUES(1, 1);
INSERT INTO Residents(UnityId, PersonId) VALUES(1, 2);
INSERT INTO Residents(UnityId, PersonId) VALUES(1, 3);
INSERT INTO Residents(UnityId, PersonId) VALUES(1, 4);
INSERT INTO Residents(UnityId, PersonId) VALUES(1, 5);

INSERT INTO Residents(UnityId, PersonId) VALUES(2, 6);
INSERT INTO Residents(UnityId, PersonId) VALUES(2, 7);
INSERT INTO Residents(UnityId, PersonId) VALUES(2, 8);
INSERT INTO Residents(UnityId, PersonId) VALUES(2, 9);
INSERT INTO Residents(UnityId, PersonId) VALUES(2, 10);

INSERT INTO Residents(UnityId, PersonId) VALUES(3, 11);
INSERT INTO Residents(UnityId, PersonId) VALUES(3, 12);
INSERT INTO Residents(UnityId, PersonId) VALUES(3, 13);
INSERT INTO Residents(UnityId, PersonId) VALUES(3, 14);
INSERT INTO Residents(UnityId, PersonId) VALUES(3, 15);

INSERT INTO Residents(UnityId, PersonId) VALUES(4, 16);
INSERT INTO Residents(UnityId, PersonId) VALUES(4, 17);
INSERT INTO Residents(UnityId, PersonId) VALUES(4, 18);
INSERT INTO Residents(UnityId, PersonId) VALUES(4, 19);
INSERT INTO Residents(UnityId, PersonId) VALUES(4, 20);

INSERT INTO Residents(UnityId, PersonId) VALUES(5, 21);
INSERT INTO Residents(UnityId, PersonId) VALUES(5, 22);
INSERT INTO Residents(UnityId, PersonId) VALUES(5, 23);
INSERT INTO Residents(UnityId, PersonId) VALUES(5, 24);
INSERT INTO Residents(UnityId, PersonId) VALUES(5, 25);

INSERT INTO Residents(UnityId, PersonId) VALUES(6, 26);
INSERT INTO Residents(UnityId, PersonId) VALUES(6, 27);
INSERT INTO Residents(UnityId, PersonId) VALUES(6, 28);
INSERT INTO Residents(UnityId, PersonId) VALUES(6, 29);
INSERT INTO Residents(UnityId, PersonId) VALUES(6, 30);

INSERT INTO Residents(UnityId, PersonId) VALUES(7, 31);
INSERT INTO Residents(UnityId, PersonId) VALUES(7, 32);
INSERT INTO Residents(UnityId, PersonId) VALUES(7, 33);
INSERT INTO Residents(UnityId, PersonId) VALUES(7, 34);
INSERT INTO Residents(UnityId, PersonId) VALUES(7, 35);

INSERT INTO Residents(UnityId, PersonId) VALUES(8, 36);
INSERT INTO Residents(UnityId, PersonId) VALUES(8, 37);
INSERT INTO Residents(UnityId, PersonId) VALUES(8, 38);
INSERT INTO Residents(UnityId, PersonId) VALUES(8, 39);
INSERT INTO Residents(UnityId, PersonId) VALUES(8, 40);

GO

INSERT INTO Users(Name, Email, Password, Type, PersonId, VerificationCode) VALUES('Danilo Silva', 'danilo@betrybe.com', '$2a$11$7QdLEGTOiOyfvxZ99qkQUe0..y6mgvgjrKJNpkKWYo0Dc8nYv.6Xi', '2', '41', 'abcde');
INSERT INTO Users(Name, Email, Password, Type, PersonId, VerificationCode) VALUES('Rafael Martins', 'rafael@betrybe.com', '$2a$11$7QdLEGTOiOyfvxZ99qkQUe0..y6mgvgjrKJNpkKWYo0Dc8nYv.6Xi', '1', '42', 'fghij');
INSERT INTO Users(Name, Email, Password, Type, PersonId, VerificationCode) VALUES('Marina Santos', 'marina@betrybe.com', '$2a$11$7QdLEGTOiOyfvxZ99qkQUe0..y6mgvgjrKJNpkKWYo0Dc8nYv.6Xi', '0', '40', 'klmno');

GO