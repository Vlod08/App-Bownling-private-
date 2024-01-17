using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;


namespace App_Bowling.Models
{
  
    public class MVCModel
    {
        public MVCModel(List<string> noms_jouers, int nb_frames)
        {
            p = new Partie(noms_jouers, nb_frames);
        }

        private Partie p;
    }
}