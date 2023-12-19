namespace WebApplication2.Models
{
    public class model1
    {
    }

    public class frame{
        int t1, t2;
    }
    public class joueur
    {
        string name;
        frame[] score = new frame[10];
    }

    public class partie
    {
        List<joueur> joeurs;

        string gagnant;
    }

}
