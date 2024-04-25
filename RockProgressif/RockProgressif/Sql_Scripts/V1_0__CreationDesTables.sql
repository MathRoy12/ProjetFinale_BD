USE ProgRockBD
GO
CREATE TABLE Albums.Album
(
    AlbumID         int IDENTITY (1,1) NOT NULL,
    Nom             nvarchar(865)      NOT NULL,
    DatePublication date               NOT NULL,
    NombreVentes    int                NOT NULL,
    NoteCritiques   int                NOT NULL,
    GroupeID        int                NOT NULL
        CONSTRAINT PK_Album_AlbumID PRIMARY KEY (AlbumID)
);

CREATE TABLE Albums.ChansonAlbum
(
    ChansonAlbumID int IDENTITY (1,1) NOT NULL,
    ChansonID      int                NOT NULL,
    AlbumID        int                NOT NULL
        CONSTRAINT PK_ChansonAlbum_ChansonAlbumID PRIMARY KEY (ChansonAlbumID)
);

CREATE TABLE Albums.Chanson
(
    ChansonID    int IDENTITY (1,1) NOT NULL,
    Titre        nvarchar(210)      NOT NULL,
    DureeSeconde int                NOT NULL
        CONSTRAINT PK_Chanson_ChansonID PRIMARY KEY (ChansonID)
);

CREATE TABLE Groupes.Groupe
(
    GroupeID          int IDENTITY (1,1) NOT NULL,
    Nom               nvarchar(100)      NOT NULL,
    DateFormation     date               NOT NULL,
    TotaleAlbumVendue int                NOT NULL
        CONSTRAINT PK_Groupe_GroupeID PRIMARY KEY (GroupeID)
);

CREATE TABLE Groupes.Role
(
    RoleID            int IDENTITY (1,1) NOT NULL,
    Instrument        nvarchar(50)       NOT NULL,
    DateDebut         date               NOT NULL,
    DateFin           date               NULL,
    EstMembreOfficiel bit                NOT NULL,
    GroupeID          int                NOT NULL,
    ArtisteID         int                NOT NULL
        CONSTRAINT PK_Role_RoleID PRIMARY KEY (RoleID)
);

CREATE TABLE Groupes.Artiste
(
    ArtisteID     int IDENTITY (1,1) NOT NULL,
    NomScene      nvarchar(50)       NULL,
    NomComplet    nvarchar(100)      NOT NULL,
    DateNaissance date               NOT NULL
        CONSTRAINT PK_Artiste_ArtisteID PRIMARY KEY (ArtisteID)
);
GO

-- Création des clés étrangères
ALTER TABLE Albums.ChansonAlbum
    ADD CONSTRAINT FK_ChansonAlbum_ChansonID
        FOREIGN KEY (ChansonID)
            REFERENCES Albums.Chanson (ChansonID)

ALTER TABLE Albums.ChansonAlbum
    ADD CONSTRAINT FK_ChansonAlbum_AlbumID
        FOREIGN KEY (AlbumID)
            REFERENCES Albums.Album (AlbumID)

ALTER TABLE Albums.Album
    ADD CONSTRAINT FK_Album_GroupeID
        FOREIGN KEY (GroupeID)
            REFERENCES Groupes.Groupe (GroupeID)
            ON DELETE CASCADE

ALTER TABLE Groupes.Role
    ADD CONSTRAINT FK_Role_GroupeID
        FOREIGN KEY (GroupeID)
            REFERENCES Groupes.Groupe (GroupeID)

ALTER TABLE Groupes.Role
    ADD CONSTRAINT FK_Role_ArtisteID
        FOREIGN KEY (ArtisteID)
            REFERENCES Groupes.Artiste (ArtisteID)
Go

-- Création des contraintes restantes
ALTER TABLE Albums.Album
    ADD CONSTRAINT CK_Album_NoteCritiques CHECK (NoteCritiques <= 100)
Go

CREATE TRIGGER Groupes.trg_dGroupe
    ON Groupes.Groupe
    INSTEAD OF DELETE
    AS
BEGIN
    DECLARE @GroupeId int;
    SELECT @GroupeId = GroupeID FROM deleted;

    UPDATE Groupes.Role
    SET DateFin = GETDATE()
    WHERE GroupeID = @GroupeId
      AND DateFin IS NULL
END
GO