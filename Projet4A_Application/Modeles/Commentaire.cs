using System;
using System.Collections.Generic;
using System.Text;

namespace Modeles
{
    public class Commentaire
    {
        private int _nbSignalement;
        private int _notation;
        private string _contenu;
        private string _titre;
        private int _idLivre; // PAS GERER ENCORE !!!
        private int _id;

        public int id { get => _id; set => _id = value; }
        public int idLivre { get => _idLivre; set => _idLivre = value; } //PAS GERER ENCORE !!!
        public string titre { get => _titre; set => _titre = value; }
        public string contenu { get => _contenu; set => _contenu = value; }
        public int notation { get => _notation; set => _notation = value; }
        public int nbSignalement { get => _nbSignalement; set => _nbSignalement = value; }

        /// <summary>
        /// A RETRAVAILLER POUR IMPLEMENTER L'ID DU LIVRE, JE NE SAIS PAS OU ON L'OBTIENT DANS LA REQUETE   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titre"></param>
        /// <param name="contenu"></param>
        /// <param name="notation"></param>
        /// <param name="nbSignalement"></param>
        public Commentaire(int id, string titre, string contenu, int notation, int nbSignalement)
        {
            this._id = id;
            this._titre = titre;
            this._contenu = contenu;
            this._notation = notation;
            this._nbSignalement = nbSignalement;
        }
    }
}
