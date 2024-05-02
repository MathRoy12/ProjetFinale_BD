USE ProgRockBD
GO

CREATE PROCEDURE Albums.USP_GetChansonsAlbum(@AlbumId int)
AS
BEGIN
    SELECT C.ChansonID, C.Titre, C.DureeSeconde
    FROM Albums.Chanson AS [C]
             INNER JOIN Albums.ChansonAlbum [CA] ON C.ChansonID = CA.ChansonID
             INNER JOIN Albums.Album [A] ON A.AlbumID = CA.AlbumID
    WHERE A.AlbumID = @AlbumId;
END
GO