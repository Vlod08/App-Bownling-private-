using Microsoft.AspNetCore.Mvc;
using App_Bowling.Models;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Http;
using System.Diagnostics.Eventing.Reader;

namespace App_Bowling.Controllers
{
    public class InstructionsController : Controller
    {

        private List<string> temp_names;
        public IActionResult Index(List<string> temp_names, int nb_fr, int nb_qu )
        {
           //this.names = args;

            Console.WriteLine("Printing from the Index method");
            byte[] tempNamesBytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(temp_names);
            byte[] FramesBytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(nb_fr);
            byte[] QuillesBytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(nb_qu);

            HttpContext.Session.Set("TempNames", tempNamesBytes);
            HttpContext.Session.Set("TempFrames",FramesBytes);
            HttpContext.Session.Set("TempQuilles",QuillesBytes);

            foreach (string n in temp_names)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("frame : " + nb_fr);
            return View();
        }

        /***************************************************************************************/

        /*public IActionResult Index(Partie p)
        {
            //this.names = args;

            Console.WriteLine("Printing from the Index method partie" + p.Joueurs.Count);
            byte[] tempNamesBytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(p);
            HttpContext.Session.Set("TempNames", tempNamesBytes);
            foreach (Joueur j in p.Joueurs)
            {
                Console.WriteLine(j.Name);
            }
            return View();
        }*/

        /***************************************************************************************/

        public IActionResult ProceedToGame() {
            Console.WriteLine("Printing from the ProceedToGame method");

            if(HttpContext.Session.TryGetValue("TempNames", out byte[] tempNamesBytes) 
                && HttpContext.Session.TryGetValue("TempFrames", out byte[] tempFramesBytes)
                && HttpContext.Session.TryGetValue("TempQuilles", out byte[] tempQuillesBytes))
            {
                var tempNames = System.Text.Json.JsonSerializer.Deserialize<List<String>>(tempNamesBytes);
                var tempFrames = System.Text.Json.JsonSerializer.Deserialize<int>(tempFramesBytes);
                var tempQuilles = System.Text.Json.JsonSerializer.Deserialize<int>(tempQuillesBytes);



                foreach (String j in tempNames)
                {
                    Console.WriteLine(j);
                }

                Console.WriteLine("Nb frames : " + tempFrames);

                // Use tempNames or pass it to another method as needed

                return RedirectToAction("Index", "Test", new { j = tempNames, nb_fr = tempFrames, nb_qu = tempQuilles });
            
                //return RedirectToAction("WelcomePage", "Welcome", new { j = tempNames , nb = tempFrames});
            }

            else{
                return View("Error");
            }
        }
    }
}
