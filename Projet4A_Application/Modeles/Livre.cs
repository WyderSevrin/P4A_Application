using System;
using System.Collections.Generic;
using System.Text;

namespace Modeles
{
    public class Livre
    {
        private int _id;
        private string _titre;
        private string _genre;
        private string _text;
        private string _resumer;
        private int _nb_Pages;
        private string _mouvement;

        //Auteur du livre

        public int id { get => _id; set => _id = value; }
        public string titre { get => _titre; set => _titre = value; }
        public string genre { get => _genre; set => _genre = value; }
        public string text { get => _text; set => _text = value; }
        public string resumer { get => _resumer; set => _resumer = value; }
        public int nb_Pages { get => _nb_Pages; set => _nb_Pages = value; }
        public string mouvement { get => _mouvement; set => _mouvement = value; }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titre"></param>
        /// <param name="genre"></param>
        /// <param name="text"></param>
        /// <param name="resumer"></param>
        /// <param name="nb_Pages"></param>
        /// <param name="mouvement"></param>
        public Livre(int id, string titre, string genre, string text, string resumer, int nb_Pages, string mouvement)
        {
            this._id = id;
            this._genre = genre;
            this._text = text;
            this._resumer = resumer;
            this._nb_Pages = nb_Pages;
            this._mouvement = mouvement;
        }

        public Livre()
        {
        }
    }
}
