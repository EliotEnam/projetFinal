

INSERT INTO Administrateur (motDePasse) VALUES
('password123');

INSERT INTO Adherent (idAdherent, nom, prenom, adresse, dateNaiss) VALUES
('JD-1985-', 'Doe', 'John', '123 Rue Principale', '1985-05-15'),
('JA-1990-', 'Appleseed', 'Johnny', '456 Avenue des Pommiers', '1990-08-01'),
('BS-1995-', 'Smith', 'Bob', '789 Boulevard de l’Étang', '1995-12-22'),
('MJ-1980-', 'Jackson', 'Mary', '321 Chemin des Fleurs', '1980-03-14'),
('LT-1992-', 'Thompson', 'Linda', '567 Rue de la Paix', '1992-07-30'),
('DF-1988-', 'Fisher', 'Daniel', '678 Avenue du Lac', '1988-11-11'),
('AN-1991-', 'Nguyen', 'Anna', '890 Route de la Forêt', '1991-04-02'),
('PW-1990-', 'White', 'Paul', '234 Rue des Champs', '1990-09-19'),
('RR-1987-', 'Robinson', 'Rachel', '345 Avenue du Soleil', '1987-01-07'),
('KH-1993-', 'Harris', 'Kevin', '456 Chemin des Étoiles', '1993-05-23');

ALTER table adherent
modify idAdherent VARCHAR(50);

INSERT INTO Categorie (nomCategorie) VALUES
('Yoga'), ('Pilates'), ('CrossFit'), ('Zumba'), ('Cardio'), ('Musculation'),
('Natation'), ('Running'), ('Cycling'), ('Boxe');

INSERT INTO Activite (nom, coutOrgCli, coutVentCli, idCategorie) VALUES
('Cours de Yoga', 10.00, 15.00, 1),
('Séance de Pilates', 12.00, 18.00, 2),
('Entraînement CrossFit', 15.00, 25.00, 3),
('Cours de Zumba', 8.00, 12.00, 4),
('Session de Cardio', 9.00, 14.00, 5),
('Cours de Musculation', 13.00, 20.00, 6),
('Séance de Natation', 11.00, 17.00, 7),
('Session de Running', 7.00, 10.00, 8),
('Cours de Cycling', 10.00, 15.00, 9),
('Séance de Boxe', 14.00, 22.00, 10);


INSERT INTO Sceance (date, heure, nbPlaceDispo, note, idActivite) VALUES
('2024-12-01', '08:00:00', 10, 4.5, 1),
('2024-12-02', '10:00:00', 8, 4.7, 2),
('2024-12-03', '18:00:00', 5, 4.8, 3),
('2024-12-04', '09:00:00', 12, 4.3, 4),
('2024-12-05', '11:00:00', 7, 4.6, 5),
('2024-12-06', '15:00:00', 9, 4.4, 6),
('2024-12-07', '07:00:00', 11, 4.9, 7),
('2024-12-08', '13:00:00', 6, 4.5, 8),
('2024-12-09', '17:00:00', 8, 4.7, 9),
('2024-12-10', '19:00:00', 10, 4.8, 10);


INSERT INTO ParticipationSceance (idSceance, idAdherent, noteAppreciation) VALUES
(1, 'JD-1985-', 4.5),
(2, 'JA-1990-', 4.7),
(3, 'BS-1995-', 4.8),
(4, 'MJ-1980-', 4.3),
(5, 'LT-1992-', 4.6),
(6, 'DF-1988-', 4.4),
(7, 'AN-1991-', 4.9),
(8, 'PW-1990-', 4.5),
(9, 'RR-1987-', 4.7),
(10, 'KH-1993_', 4.8);

UPDATE sceance
SET idActivite = 3
WHERE idActivite IS NULL;

CALL ajout_adherent();


    DELIMITER //
CREATE PROCEDURE ajout_adherent ( IN lnom VARCHAR(30),IN lprenom VARCHAR(30) ,IN laddresse VARCHAR(100), IN ldatenaiss DATE)
BEGIN
    INSERT INTO adherent ( nom, prenom, adresse, dateNaiss) VALUES (lnom,lprenom,laddresse,ldatenaiss);
end //
DELIMITER ;
DROP PROCEDURE ajout_adherent;

CALL ajout_adherent('nom','prenom','adresse','2010-10-10');


DELIMITER //
CREATE FUNCTION f_idCat(lnomCategorie VARCHAR(30)) RETURNS INT
BEGIN
    DECLARE nb INT;
    SELECT idCategorie INTO nb FROM categorie WHERE nomCategorie = lnomCategorie;
    RETURN nb;
end //
DELIMITER ;

SELECT f_idCat('Natation');



INSERT INTO Categorie (nomCategorie) VALUES
('Yoga'), ('Pilates'), ('CrossFit'), ('Zumba'), ('Cardio'), ('Musculation'),
('Natation'), ('Running'), ('Cycling'), ('Boxe');
INSERT INTO Activite (nom, coutOrgCli, coutVentCli, idCategorie) VALUES
('Cours de Yoga', 10.00, 15.00, 1),
('Séance de Pilates', 12.00, 18.00, 2),
('Entraînement CrossFit', 15.00, 25.00, 3),
('Cours de Zumba', 8.00, 12.00, 4),
('Session de Cardio', 9.00, 14.00, 5),
('Cours de Musculation', 13.00, 20.00, 6),
('Séance de Natation', 11.00, 17.00, 7),
('Session de Running', 7.00, 10.00, 8),
('Cours de Cycling', 10.00, 15.00, 9),
('Séance de Boxe', 14.00, 22.00, 10);


DELIMiTER //
CREATE PROCEDURE supprimer(In ltable VARCHAR(30), IN id VARCHAR(5), IN lidName VARCHAR(30))
BEGIN
    DELETE FROM ltable
    WHERE lidName = id;
end //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE ajout_adherent ( IN lnom VARCHAR(30),IN lprenom VARCHAR(30) ,IN laddresse VARCHAR(100), IN ldatenaiss DATE)
BEGIN
    INSERT INTO adherent ( nom, prenom, adresse, dateNaiss) VALUES (lnom,lprenom,laddresse,ldatenaiss);
end //
DELIMITER ;
DROP PROCEDURE ajout_adherent;
DROP TRIGGER num_identification;
DELIMITER //
CREATE TRIGGER num_identification
BEFORE INSERT ON Adherent
FOR EACH ROW
BEGIN
    SET new.idAdherent = CONCAT(LEFT(new.prenom,1),LEFT(new.nom,1),'-',YEAR(new.dateNaiss),'-',
        ROUND( RAND() * 9 ) + 1,ROUND( RAND() * 9 ) + 1,ROUND( RAND() * 9 ) + 1);
end //
DELIMITER ;

CALL ajout_adherent('nom','prenom','daresse','2004-10-10');
CALL ajout_activite()
