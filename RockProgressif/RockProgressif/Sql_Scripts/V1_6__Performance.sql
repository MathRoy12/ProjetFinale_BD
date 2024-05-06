USE ProgRockBD
GO

CREATE NONCLUSTERED INDEX IX_Role_IDs ON Groupes.Role (ArtisteID,GroupeID)
CREATE NONCLUSTERED INDEX IX_Artiste_ArtisteId ON Groupes.Artiste (ArtisteID)
CREATE NONCLUSTERED INDEX IX_Groupe_GroupeID ON Groupes.Groupe (GroupeID)
CREATE NONCLUSTERED INDEX IX_ChansonAlbum_IDs ON Albums.ChansonAlbum (ChansonID, AlbumID)
CREATE NONCLUSTERED INDEX IX_Chanson_ChansonID ON Albums.Chanson (ChansonID)
CREATE NONCLUSTERED INDEX IX_Album_AlbumID ON Albums.Album (AlbumID)
