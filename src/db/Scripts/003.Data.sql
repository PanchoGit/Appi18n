USE Appi18n
GO

TRUNCATE TABLE dbo.Note;

SET IDENTITY_INSERT dbo.[Note] ON
INSERT INTO dbo.[Note] ( [Id], [Name], [Text], [Date]) VALUES (1, N'Les Jolies Filles', N'
J’AIME LES FILLES

J''aime les filles de chez Castel
J''aime les filles de chez Régine
J''aime les filles qu''on voit dans Elle
J''aime les filles des magazines
J''aime les filles de chez Renault
J''aime les filles de chez Citroën
J''aime les filles des hauts fourneaux
J''aime les filles qui travaillent à la chaîne

Si vous êtes comme ça, téléphonez-moi
Si vous êtes comme ci, téléphonez-mi

J''aime les filles à dot
J''aime les filles à papa
J''aime les filles de Loth


J''aime les filles sans papa
J''aime les filles de Megève
J''aime les filles de Saint-Tropez
J''aime les filles qui font la grève
J''aime les filles qui vont camper

J''aime les filles de la Rochelle
J''aime les filles de Camaret
J''aime les filles intellectuelles
J''aime les filles qui me font marrer
J''aime les filles qui font vieille France
J''aime les filles de cinéma
J''aime les filles de l''Assistance
J''aime les filles dans l''embarras

Si vous êtes comme ça, téléphonez-moi
Si vous êtes comme ci, téléphonez-mi...
', GETDATE()
)
SET IDENTITY_INSERT dbo.[Note] OFF
