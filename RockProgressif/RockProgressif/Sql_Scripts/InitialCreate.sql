﻿USE
    master
GO

-- CREATION ou RECREATION de la BD R22_Billeterie
-- le petit de création ou de recréation de la BD
IF EXISTS(SELECT *
          FROM sys.databases
          WHERE name = 'ProgRockBD')
    BEGIN
        DROP
            DATABASE ProgRockBD
    END
CREATE
    DATABASE ProgRockBD
GO

USE
    ProgRockBD
GO
-- Configuration de FILESTREAM
-- nous avons vu ça lors de la rencontre 19
EXEC sp_configure filestream_access_level, 2 RECONFIGURE

ALTER
    DATABASE ProgRockBD
    ADD FILEGROUP FG_Images CONTAINS FILESTREAM;
GO

ALTER
    DATABASE ProgRockBD
    ADD FILE (
        NAME = FG_Images,
        FILENAME = 'C:\EspaceLabo\FG_Images'
        )
        TO FILEGROUP FG_Images
GO
-- Configuration des clés symétriques
-- il s'agit de créer la clé master, le certificat et enfin la clé symmétrique
CREATE
    MASTER KEY ENCRYPTION BY PASSWORD = 'MonMotDePasseSuperL0ng!'
GO

CREATE
    CERTIFICATE MonCertificat WITH SUBJECT = 'ChiffrementJeSaisPasEncore'
GO

CREATE
    SYMMETRIC KEY MaSuperCle WITH ALGORITHM = AES_256 ENCRYPTION BY CERTIFICATE MonCertificat;