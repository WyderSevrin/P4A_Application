using Communication;
using Modeles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Control
{
    public class Controleur
    {
        private SQL sqlManager;
        private FTP ftpManager;
        private Fabrique fabrique;
        //private SQL_constante;
        public List<Livre> Bibliotheque { get; set; }
        public List<Commentaire> Commentaires { get; set; }
        private Utilisateur utilisateur { get; set; }

        public Controleur()
        {
            updateListLivre();
        }

        /// <summary>
        /// Permet d'obtenir tout les livres de la librairie
        /// </summary>
        public void updateListLivre()
        {
            List<List<string>> liste = sqlManager.SqlRequest(SQL_constants.selectAllBooks);
            Bibliotheque = fabrique.CreateLivres(liste);
        }

        /// <summary>
        /// Permet d'obtenir tout les commentaires
        /// </summary>
        public void updateListCommentaire()
        {
            List<List<string>> liste = sqlManager.SqlRequest(SQL_constants.selectAllComments);
            Commentaires = fabrique.CreateCommentaires(liste);
        }

        /// <summary>
        /// on obtient tous les commentaires d'un livre
        /// </summary>
        /// <param name="idBook"></param>
        /// <returns></returns>
        public List<Commentaire> getCommentaireOfBook(int idBook)
        {
            List<Commentaire> output = new List<Commentaire>();
            foreach (Commentaire c in this.Commentaires)
            {
                if (c.idLivre== idBook)
                {
                    output.Add(c);
                }
            }
            return output;
        }

        /// <summary>
        /// IMPLEMENTER 4AUTERU DANS LIVRE
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public List<Livre> searchLivreByNom(string nom)
        {
            List<Livre> result = new List<Livre>();
            foreach (Livre l in this.Bibliotheque)
            {
                if (l.titre == nom)
                {
                    result.Add(l);
                }

            }
            
            return result;
        }

        public List<Livre> searchLivreByGenre(string genre)
        {
            List<Livre> result = new List<Livre>();
            foreach (Livre l in this.Bibliotheque)
            {
                if (l.genre == genre)
                {
                    result.Add(l);
                }

            }

            return result;
        }

        public List<Livre> searchLivreByMouvement(string mouv)
        {
            List<Livre> result = new List<Livre>();
            foreach (Livre l in this.Bibliotheque)
            {
                if (l.mouvement == mouv)
                {
                    result.Add(l);
                }

            }

            return result;
        }

        //Par ordre

        //Par favoris



        /// <summary>
        /// on télécharge un livre par rapport à son id
        /// </summary>
        /// <param name="nom"></param>
        public async void downLoadLivre(int idLivre)
        {
            string nom = "";
            foreach (Livre l in this.Bibliotheque)
            {
                if (l.id == idLivre)
                {
                    nom = l.titre;
                    break;
                }
            }
            await ftpManager.download_Async(nom);
        }
    }
}
