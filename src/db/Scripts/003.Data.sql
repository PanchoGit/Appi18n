USE Appi18n
GO

TRUNCATE TABLE dbo.Note;

SET IDENTITY_INSERT dbo.[Note] ON
INSERT INTO dbo.[Note] ( [Id], [Name], [Text], [Date]) VALUES (1, N'Les Jolies Filles', N'J’AIME LES FILLES

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

INSERT INTO dbo.[Note] ( [Id], [Name], [Text], [Date]) VALUES (2, N'Nur eine Frage der Zeit, bis uns ein Asteroid trifft', N'Seit 2015 findet deshalb am 30. Juni der Asteroid Day statt (siehe Box). Ziel der Bewegung ist es, die weltweite Öffentlichkeit über die Gefahr von Asteroideneinschlägen aufzuklären. 20 Minuten hat sich mit dem ehemaligen Astronauten Ed Lu über Möglichkeiten unterhalten, die Welt vor einer Katastrophe zu schützen.', GETDATE())
INSERT INTO dbo.[Note] ( [Id], [Name], [Text], [Date]) VALUES (3, N'読売新聞 ニュース一覧', N'がんを発症する危険性は居住する都道府県により差があることが２９日、国立がん研究センターが発表した２０１２年のがん患者の推計値でわかった。

　乳がんの発症は東京で突出して高く、肝臓がんは西日本に偏っていた。全都道府県でがん登録のデータがそろい、地域ごとの全容が明らかになったのは初めて。

　推計値によると、１２年に新たにがんと診断されたのは約８６万５０００人。集計結果から年齢などを調整し、発症の危険性を全国平均を１００として都道府県ごとに算出した。

　がん全体では、男性は北海道、東北、山陰、九州北部で発症が多く、女性は東京、大阪、福岡など都市圏で目立った。', GETDATE())
INSERT INTO dbo.[Note] ( [Id], [Name], [Text], [Date]) VALUES (4, N'Amerikaner tog sig till Sverige för släktträff', N'Under några dagar i slutet av maj 24-28, besökte tolv amerikanare Sverige för att se sina förfäders födelseplatser.
Per Persson i Storbo och två av hans bröder, Gustav och Jonas emigrerade till Minnesota 1903. Per Persson kom hem till Sverige igen medan de två andra bröderna skaffade sig mark där i USA och kom aldrig tillbaka. Barnbarn med familjer till den ene av bröderna, Gustav, har nu för första gången besökt Sverige och det blev en trevlig släktträff i Storbo.', GETDATE())


SET IDENTITY_INSERT dbo.[Note] OFF
