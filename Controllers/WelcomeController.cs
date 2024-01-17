using App_Bowling.Models;

using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using App_Bowling.Models;


namespace App_Bowling.Controllers
{



    public class WelcomeController : Controller
    {
        private readonly ILogger<WelcomeController> _logger;

        public WelcomeController(ILogger<WelcomeController> logger)
        {
            _logger = logger;
        }

        
        public ActionResult WelcomePage()
        {
            List<Joueur> joueurs = new List<Joueur>();
            //Console.WriteLine(joueurs.Count;
            return View("Welcome", joueurs);
        }

        [HttpPost]
        public IActionResult GetJoueurs()
        { 
            List<string> joueurs = new List<string>();
            string key;
            int nb_frames = 10;
            int nb_quilles = 10;
            for (int i = 1; i < HttpContext.Request.Form.Count-1 /* minus one for the nb_frames */ ;i++)

            {
                key = "joueur";
                key = key + i;
                Console.WriteLine(i);
                joueurs.Add(HttpContext.Request.Form[key]);
                Console.WriteLine(HttpContext.Request.Form[key]);
            }

            int.TryParse (HttpContext.Request.Form["nb_frames"], out nb_frames);
            int.TryParse(HttpContext.Request.Form["nb_quilles"], out nb_quilles);

            //return RedirectToAction("Index", "Instructions", new { p = partie });
            return RedirectToAction("Index","Instructions",new { temp_names = joueurs , nb_fr = nb_frames, nb_qu = nb_quilles});
        }
    }
}
