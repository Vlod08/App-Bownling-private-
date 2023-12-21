using System.Security.Cryptography.X509Certificates;


namespace App_Bowling.Models
{
    public class Frame
    {
        private int t1, t2;
        public int T1
        {
            set { t1 = value; }
            get { return t1; }
        }
        public int T2
        {
            set { t2 = value; }
            get { return t2; }
        }


    }


    public class Score
    {

        public Score(int nb_frames)
        {
            frames = new List<Frame>(nb_frames);
            foreach (Frame f in frames) { f.T1 = 0; f.T2 = 0; }
            total = new List<int>(10) { 0 };
            spareStreak = 0;
            strikeStreak = 0;
        }


        public void update(int indice, int val1, int val2)
        {
            frames[indice].T1 = val1;
            frames[indice].T2 = val2;
        }

        public int getTotal(int ind) /* To be verified !!! */
        {


            if (ind == 0)
            {
                return frames[0].T1 + frames[0].T2;
            }


            else if (frames[ind].T1 == 10)                  /* strike current frame */
            {
                strikeStreak++;
                return total[ind] = STRIKE;
            }
            else if (frames[ind].T1 + frames[ind].T2 == 10)  /* spare current frame */
            {
                spareStreak++;
                return total[ind] = SPARE;
            }
            else if (spareStreak == 0 && strikeStreak == 0)    /* base condition and no streaks */
            {
                total[ind] = frames[ind].T1 + frames[ind].T2;
                return total[ind];
            }
            else if (spareStreak > 0)
            {
                //

                spareResolver(ind);
                return total[ind] = frames[ind].T1 + frames[ind].T2;

            }
            else
            {
                //
                strikeResolver(ind);

                return total[ind] = frames[ind].T1 + frames[ind].T2;
            }





        }

        const int SPARE = -2;
        const int STRIKE = -1;
        private List<Frame> frames;
        int spareStreak;
        int strikeStreak;
        List<int> total;
        void strikeResolver(int ind)
        {
            strikeStreak = 0;
        }
        void spareResolver(int ind)
        {
            total[ind - 1] = frames[ind].T1 + 10;
            spareStreak = 0;
        }

        public List<Frame> Frames {
            set { frames = value; }
            get {  return frames; }
        }

    }

    public class Joueur
    {
        public Joueur(string nom) { name = nom; }

        private string name;
        private Score scores;

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

    public class Partie
    {
        public Partie(List<string> noms_joueurs, int nb_frames)
        {
            bool gameOver = false; ;
            joueurs = new List<Joueur>(noms_joueurs.Count);


            foreach (string nom in noms_joueurs)
            {
                joueurs.Add(new Joueur(nom));
            }

            gagnant = "The game isn't over yet!!!";
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

        public List<Joueur> Joueurs {
            set { joueurs = value; }
            get { return joueurs;  }
        } 

        private List<Joueur> joueurs;

        private string gagnant;

        bool gameOver;


    }
    public class MVCModel
    {
        public MVCModel(List<string> noms_jouers, int nb_frames)
        {
            p = new Partie(noms_jouers, nb_frames);
        }

        private Partie p;
    }
}