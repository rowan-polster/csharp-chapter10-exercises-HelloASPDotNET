using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloASPDotNET.Controllers
{

    [Route("/helloworld")]
    public class HelloController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            //change value to "greeting" so helloworld executes the right code
            string html = "<form method='post' action='/helloworld/greeting'>" +
               "<input type='text' name='name' />" +

               "<select name = 'language'> " +
                    "<option value = 'English'> English </option>" +
                    "<option value = 'Spanish'> Spanish </option>" +
                    "<option value = 'French'> French </option>" +
                    "<option value = 'Mandarin'> Mandarin </option>" +
                    "<option value = 'Irish Gaelic'> Irish Gaelic </option>" +
                "</select>" +

                "<input type='submit' value='Greet Me!' />" +
                "</form>";

            return Content(html, "text/html");
        }


        [HttpGet("welcome/{name?}")]
        [HttpPost("welcome")]
        public IActionResult Welcome(string name = "World")
        {
            return Content("<h1>Welcome to my app, " + name + "!</h1>", "text/html");
        }

        //Greeting
        [HttpGet("greeting/{language?}/{name?}")]
        [HttpPost("greeting")]
        public IActionResult Greeting(string name = "World", string language = "English")
        {
            return Content(CreateMessage(name, language), "text/html");
        }


        //Changing the language of the greeting
        public static string CreateMessage(string name, string language)
        {
            string greeting = "";

            if (language == "English")
            {
                greeting = "Hello";
            }
            else if (language == "Spanish")
            {
                greeting = "Hola";
            }
            else if (language == "French")
            {
                greeting = "Bonjour";
            }
            else if (language == "Mandarin")
            {
                greeting = "Nihao";
            }
            else if (language == "Irish Gaelic")
            {
                greeting = "Dia dhuit";
            }

            return ($"<h1 style='font-family: Garamond, Baskerville, Baskerville Old Face, Hoefler Text, Times New Roman, serif; font-size: 45px; font-style: normal; color:slategray'> {greeting}, {name}!");

        }
    }
}
