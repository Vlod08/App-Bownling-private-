namespace App_Bowling.Models
{
    /*
     * Score contient une liste des frames et les methodes de calculs de points
     * 
     * Conditions a verifier:
     * verifier le score est initialise a zero
     * nb_frames = taille du frames
     * verfier que total >= 0 
     * verificatons de methodes de calculs des points !!! 
     * 
     */
    public class Score
    {

        public Score(int nb_frames = 10)
        {
            frames = new List<Frame>(nb_frames);
            foreach (Frame f in frames) { f.T1 = 0; f.T2 = 0; } // extra couche de verification pas necessaire
            total = new List<int>(10) { 0 };
            spareStreak = 0;
            strikeStreak = 0;
            this.nb_frames = nb_frames;
            Console.WriteLine("This constructor is being called");
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
                spareResolver(ind);
                return total[ind] = frames[ind].T1 + frames[ind].T2;
            }
            else
            {
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
        int nb_frames;
        void strikeResolver(int ind)
        {
            strikeStreak = 0;
        }
        void spareResolver(int ind)
        {
            total[ind - 1] = frames[ind].T1 + 10;
            spareStreak = 0;
        }

        public List<Frame> Frames
        {
            set { frames = value; }
            get { return frames; }
        }

        public int Nb_Frames
        {
            get { return nb_frames; }
        }

    }
}
