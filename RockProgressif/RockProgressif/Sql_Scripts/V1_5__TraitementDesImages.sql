USE ProgRockBD
GO

ALTER TABLE Albums.Album
    ADD IdentifiantCover uniqueidentifier
GO

UPDATE Albums.Album
SET IdentifiantCover = newid()
GO

ALTER TABLE Albums.Album
    ALTER COLUMN IdentifiantCover uniqueidentifier NOT NULL;
GO
ALTER TABLE Albums.Album
    ALTER COLUMN IdentifiantCover ADD ROWGUIDCOL;
GO

ALTER TABLE Albums.Album
    ADD CONSTRAINT UC_Album_IdentifiantCover UNIQUE (IdentifiantCover)
GO

ALTER TABLE Albums.Album ADD CONSTRAINT DF_Album_IdentifiantCover DEFAULT newid() FOR IdentifiantCover
GO

ALTER TABLE Albums.Album ADD CoverContent varbinary(max) FILESTREAM NULL
GO

UPDATE Albums.Album
SET CoverContent = BulkColumn FROM OPENROWSET(
                                           BULK 'C:\EspaceLabo\ProjetFinale_BD\RockProgressif\RockProgressif\img\SellingEnglandByThePound.png', SINGLE_BLOB) AS myfile
WHERE AlbumID = 1
GO
UPDATE Albums.Album
SET CoverContent = BulkColumn FROM OPENROWSET(
                                           BULK 'C:\EspaceLabo\ProjetFinale_BD\RockProgressif\RockProgressif\img\Duke.png', SINGLE_BLOB) AS myfile
WHERE AlbumID = 2
GO
UPDATE Albums.Album
SET CoverContent = BulkColumn FROM OPENROWSET(
                                           BULK 'C:\EspaceLabo\ProjetFinale_BD\RockProgressif\RockProgressif\img\InvisibleTouch.png', SINGLE_BLOB) AS myfile
WHERE AlbumID = 3
GO
UPDATE Albums.Album
SET CoverContent = BulkColumn FROM OPENROWSET(
                                           BULK 'C:\EspaceLabo\ProjetFinale_BD\RockProgressif\RockProgressif\img\TurnItOnAgain.png', SINGLE_BLOB) AS myfile
WHERE AlbumID = 4
GO
UPDATE Albums.Album
SET CoverContent = BulkColumn FROM OPENROWSET(
                                           BULK 'C:\EspaceLabo\ProjetFinale_BD\RockProgressif\RockProgressif\img\FlyByNight.png', SINGLE_BLOB) AS myfile
WHERE AlbumID = 5
GO
UPDATE Albums.Album
SET CoverContent = BulkColumn FROM OPENROWSET(
                                           BULK 'C:\EspaceLabo\ProjetFinale_BD\RockProgressif\RockProgressif\img\Hemispheres.png', SINGLE_BLOB) AS myfile
WHERE AlbumID = 6
GO
UPDATE Albums.Album
SET CoverContent = BulkColumn FROM OPENROWSET(
                                           BULK 'C:\EspaceLabo\ProjetFinale_BD\RockProgressif\RockProgressif\img\MovingPictures.png', SINGLE_BLOB) AS myfile
WHERE AlbumID = 7
GO
UPDATE Albums.Album
SET CoverContent = BulkColumn FROM OPENROWSET(
                                           BULK 'C:\EspaceLabo\ProjetFinale_BD\RockProgressif\RockProgressif\img\ImagesAndWords.png', SINGLE_BLOB) AS myfile
WHERE AlbumID = 8
GO
UPDATE Albums.Album
SET CoverContent = BulkColumn FROM OPENROWSET(
                                           BULK 'C:\EspaceLabo\ProjetFinale_BD\RockProgressif\RockProgressif\img\MetropolisPart2.png', SINGLE_BLOB) AS myfile
WHERE AlbumID = 9
GO
UPDATE Albums.Album
SET CoverContent = BulkColumn FROM OPENROWSET(
                                           BULK 'C:\EspaceLabo\ProjetFinale_BD\RockProgressif\RockProgressif\img\Octovarium.png', SINGLE_BLOB) AS myfile
WHERE AlbumID = 10
GO
UPDATE Albums.Album
SET CoverContent = BulkColumn FROM OPENROWSET(
                                           BULK 'C:\EspaceLabo\ProjetFinale_BD\RockProgressif\RockProgressif\img\GreatestHit.png', SINGLE_BLOB) AS myfile
WHERE AlbumID = 11
GO