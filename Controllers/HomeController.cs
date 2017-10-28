using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using mvc_template.models;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("get response");
        }

        [HttpPost]
        public IActionResult Index([FromBody]RequestModel value)
        {
            Console.WriteLine("deserialized input as");
            Console.WriteLine(value);

            ResponseModel response = new ResponseModel
            {
                speech = "I am annoying",
                displayText = "I am annoying"
            };

            return Ok(response);
        }
    }
}


