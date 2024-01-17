namespace App_Bowling.Models
{
    /*
     * Joueur contient un nom et un score 
     * on verifie que le nom est pas null 
     * 
     */
    public class Joueur
    {

        private string name;
        private Score scores;

        public Joueur(string nom) { 
            name = nom;
            scores = new Score();
        }

        public Joueur()
        {
            name = "Unknown Player";
            scores = new Score();
        }

       

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public Score Scores
        {
            get { return scores; }
            set { scores = value; }
        }
    }
}
