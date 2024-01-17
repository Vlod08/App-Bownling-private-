namespace App_Bowling.Models
{

    public class Partie
    {
        public Partie(List<string> noms_joueurs, int nb_frames = 10, int nb_quilles = 10)
        {
            bool gameOver = false; ;
            joueurs = new List<Joueur>(noms_joueurs.Count);

            foreach (string nom in noms_joueurs)
            {
                joueurs.Add(new Joueur(nom));
            }
            this.nb_frames = nb_frames;
            this.nb_quilles=nb_quilles;
            gagnant = "The game isn't over yet!!!";
            
        }

        public Partie()
        {
            joueurs = new List<Joueur>();
            gagnant = "game is not over yet";
            gameOver = false;

        }

        public bool verify_unicity(List<String> names)
        {
            List<String> temp_names = new List<String>();
            foreach (string name in names)
            {
                if (temp_names.Contains(name))
                {
                    return false;
                }

                else
                {
                    temp_names.Add(name);
                }
            }
            return true;
        }


        /*public void update_score(string nom, int indice, int val1, int val2)
        {
            scores[nom].update(indice, val1, val2);
        }*/


        /*not implemented completely*/
        /*public void trouverGagnant() 
        {
            int max = 0;
            int total = 0;
            List<Joueur> joueursGagnants = new List<Joueur>();
            foreach (Joueur j in joueurs)
            {
                total = scores[j.Name].getTotal();
                if (total > max)
                {
                    joueursGagnants = new List<Joueur>();
                }
            }
        }*/

        /*public void GameOver()
        {
            gameOver = true;
            trouverGagnant();
        }*/

        public List<Joueur> Joueurs
        {
            set { joueurs = value; }
            get { return joueurs; }
        }

        private List<Joueur> joueurs;

        private string gagnant;
        int nb_frames, nb_quilles;
        bool gameOver;
        
        public int Nb_Frames
        {
            get { return nb_frames; }
        }

        public int Nb_Quilles
        {
            get { return nb_quilles; }
        }

    }

    
}
