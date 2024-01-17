using Microsoft.AspNetCore.Mvc;
using App_Bowling.Models;

namespace App_Bowling.Controllers
{
    public class TestController : Controller //gamecontrolle
    {
        public IActionResult Index(List<String> j , int nb_fr, int nb_qu)
        {
            Partie partie = new Partie(j, nb_fr, nb_qu);

            //Console.WriteLine(partie.Joueurs[0].Scores.Frames.Count);
            return View("Index",partie);
        }


    }




}
