use mydb;

/*===== INSERTS =====*/ 

/* Utilisateur */
INSERT INTO Utilisateur(Nom,Nb_Signalement) VALUES ('Admin 1',0),
('Admin 2 ',0);
/* Livre*/
INSERT INTO Livre(Nom,Genre,Text,Resumer,Nb_Pages,Mouvement,Auteur) 
VALUES ('Au_Soleil_Maupassant','Roman','Au_Soleil_Maupassant','Les contenus accessibles sur le site Gallica sont pour la plupart des reproductions numériques d\'oeuvres tombées dans le domaine public provenant des collections de la BnF.',321,'Rennaissance','Maupassant'),
('Lettres_Persanes_Montesquieu','Roman','Lettres persanes.','La réutilisation non commerciale de ces contenus ou dans le cadre d’une publication académique ou scientifique est libre et gratuite dans le respect de la législation en vigueur et notamment du maintien de la mention de source des contenus telle que précisée ci-après : « Source gallica.bnf.fr / Bibliothèque nationale de France » ou « Source gallica.bnf.fr / BnF ».',359,'Rennaissance','Montesquieu');

/* Recommandation*/
INSERT INTO Recommandation(Titre,Message,Utilisateur_idUtilisateur) VALUES ('Test_Recommandation','Test Je recommande ce livre là',1);
/* Commentaires*/
INSERT INTO Commentaire(Titre,Contenu,Notation,Nb_Signalement,Utilisateur_idUtilisateur,Livre_idLivre) 
VALUES 	('Test Commentaire 1','J\'aime beaucoup ce livre, bonne qualité ',5,0,1,1),
		('Test Commentaire 2','Merci pour le livre ',5,0,1,1);
/* Favoris*/
INSERT INTO Favoris(Utilisateur_idUtilisateur,Livre_idLivre) VALUES (1,1),(1,2),(2,1);
/* Lire*/
INSERT INTO Lire(Utilisateur_idUtilisateur,Livre_idLivre) VALUES (1,1),(1,2);


/*===== REQUETES =====*/ 

/*== Favoris*/
/*favories d'une personne*/
SELECT Nom FROM livre NATURAL JOIN favoris WHERE  favoris.Utilisateur_idUtilisateur = (SELECT idUtilisateur FROM utilisateur WHERE Nom ="ADMIN");
SELECT distinct * FROM livre;
SELECT * FROM Commentaire Where Commentaire.Livre_idLivre = 1;

SELECT Nom FROM utilisateur Where utilisateur.idUtilisateur = 1;
SELECT Nom FROM utilisateur Where idUtilisateur = 1;