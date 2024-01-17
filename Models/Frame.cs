namespace App_Bowling.Models
{

    /*
     * t1 : points gagnes de la premiere lancee d'une frame 
     * t2 : points gagnes de la deuxieme lancee d'une frame
     
    Les conditions a verifier : 
        t1 et t2 >= 0 
     */
    public class Frame
    {
        private int t1, t2;
        public int T1
        {
            set { 
                if (t1 >= 0) { t1 = value; } 
                else { throw new Exception("Score cannot be negative"); } 
        }
            get { return t1; }
        }
        public int T2
        {
            set {
                if (t2 >= 0) { t2 = value; }
                else { throw new Exception("Score cannot be negative"); }
            }
    
            get { return t2; }
        }

        public Frame() { t1 = 0; t2 = 0; }
        public Frame(int t1, int t2) { T1 = t1; T2 = t2; }
    }

}
