USE ProgRockBD
GO

BEGIN TRANSACTION T1

GO
ALTER TABLE Groupes.Groupe
    ALTER COLUMN TotaleAlbumVendue varbinary(max)

GO
CREATE TABLE Groupes.GroupeEnClair
(
    GroupeId          int           NOT NULL,
    Nom               nvarchar(100) NOT NULL,
    DateFormation     date          NOT NULL,
    TotaleAlbumVendue int           NOT NULL
);
GO

CREATE PROCEDURE Groupes.USP_CreerGroupe @Nom nvarchar(100),
                                         @DateFormation date,
                                         @TotaleAlbumVendue int
AS
BEGIN
    OPEN SYMMETRIC KEY MaSuperCle DECRYPTION BY CERTIFICATE MonCertificat;

    DECLARE @VenteChiffre varbinary(max) = ENCRYPTBYKEY(KEY_GUID('MaSuperCle'), CONVERT(varbinary, @TotaleAlbumVendue))

    CLOSE SYMMETRIC KEY MaSuperCle

    INSERT INTO Groupes.Groupe (Nom, DateFormation, TotaleAlbumVendue)
    VALUES (@Nom, @DateFormation, @VenteChiffre);
END
GO

OPEN SYMMETRIC KEY MaSuperCle DECRYPTION BY CERTIFICATE MonCertificat;

UPDATE Groupes.Groupe
SET TotaleAlbumVendue = ENCRYPTBYKEY(KEY_GUID('MaSuperCle'), CONVERT(varbinary, TotaleAlbumVendue))

CLOSE SYMMETRIC KEY MaSuperCle
GO

CREATE PROCEDURE Groupes.USP_ObtenirGroupeEnClair @Id int
AS
BEGIN
    OPEN SYMMETRIC KEY MaSuperCle DECRYPTION BY CERTIFICATE MonCertificat;

    SELECT  GroupeID ,Nom, DateFormation, CONVERT(int, DecryptByKEY(TotaleAlbumVendue)) AS TotaleAlbumVendue
    FROM Groupes.Groupe
    WHERE GroupeID = @Id

    CLOSE SYMMETRIC KEY MaSuperCle
END
GO

COMMIT TRANSACTION T1