USE ProgRockBD
GO
CREATE VIEW Groupes.vw_LiensArtisteGroupe
AS
SELECT DISTINCT A.ArtisteID, A.NomScene, A.NomComplet AS [NomArtiste], G.GroupeID, G.Nom AS [NomGroupe], R.Instrument
FROM Groupes.Artiste AS [A]
         INNER JOIN Groupes.Role AS [R] ON A.ArtisteID = R.ArtisteID
         INNER JOIN Groupes.Groupe AS [G] ON G.GroupeID = R.GroupeID