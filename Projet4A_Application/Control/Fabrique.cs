using Modeles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Control
{
    public class Fabrique
    {
        /// <summary>
        /// On fabrique un ensemble de livre par rapport à des données
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Livre> CreateLivres(List<List<string>> input)
        {
            List<Livre> output = new List<Livre>();

            foreach (List<string> listBooks in input)
            {
                output.Add(new Livre(int.Parse(listBooks[0]), listBooks[1], listBooks[2], listBooks[3],listBooks[4], int.Parse(listBooks[5]), listBooks[6]));
            }
            return output;
        }

        /// <summary>
        /// On fabrique un ensemble de commentaires par rapport à des données 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Commentaire> CreateCommentaires(List<List<string>> input)
        {
            List<Commentaire> output = new List<Commentaire>();

            foreach (List<string> listComments in input)
            {
                output.Add(new Commentaire(int.Parse(listComments[0]), listComments[1], listComments[2], int.Parse(listComments[3]), int.Parse(listComments[4])));
            }
            return output;
        }


    }
}
