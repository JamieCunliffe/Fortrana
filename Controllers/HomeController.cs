using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using mvc_template.models;
using Controllers;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
        private GameContext _context = new GameContext();

        public IActionResult Index()
        {
            return Ok("get response");
        }

        [HttpPost]
        public IActionResult Index([FromBody]RequestModel value)
        {
            Console.WriteLine("deserialized input as");
            Console.WriteLine(value);

            ResponseModel response;

            switch (value.result.action)
            {
                case "move-intent" :
                    response = HandleMoveIntent(value.result);
                break;
                case "pickup-intent" :
                    response = HandlePickupIntent(value.result);
                break;
                case "phonetic-nato-intent":
                    response = HandleNatoIntent(value.result);
                break;
                case "phonetic-rn-intent":
                    response = HandleRnIntent(value.result);
                break;
                case "debug-intent":
                    response = HandleDebugMode( value.result );
                    break;
                default:
                    response = new ResponseModel
                    {
                        speech = "I am annoying",
                        displayText = "I am annoying"
                    };
                break;
            }

            if( _debugMode)
            {
                var debugStr = _context.GetDebugString();

                response = new ResponseModel
                {
                    speech = response.speech,
                    displayText = debugStr
                };
            }


            return Ok(response);
        }

        #region intent-handlers

        private ResponseModel HandleDebugMode( ResultModel model )
        {
            _debugMode = !_debugMode;
                        return new ResponseModel
            {
                speech = @"Debug mode enabled",
                displayText = @"Debug mode enabled"
            };
        }

        private bool _debugMode;

        private ResponseModel HandleMoveIntent(ResultModel model)
        {
            var response = _context.Move( model );

            return new ResponseModel
            {
                speech = response,
                displayText = response
            };


            // return new ResponseModel
            // {
            //     speech = @"Can't handle this command yet",
            //     displayText = @"Can't handle this command yet"
            // };
        }

        private ResponseModel HandlePickupIntent(ResultModel model)
        {
            return new ResponseModel
            {
                speech = @"Can't handle this command yet",
                displayText = @"Can't handle this command yet"
            };
        }

        private ResponseModel HandleNatoIntent(ResultModel model)
        {
            return new ResponseModel {
                speech = @"Oh, I see you are using Nato phonetic alphabet, we currently don't support this type of input. 
                Please use the phonetic alphabet Royal Navy was using from 1914 to 1918",
                displayText = @"Oh, I see you are using Nato phonetic alphabet, we currently don't support this type of input. 
                Please use the phonetic alphabet Royal Navy was using from 1914 to 1918"
            };
        }

        private ResponseModel HandleRnIntent(ResultModel model)
        {
            if (model.parameters.phonetic_rn.ToString().Equals("charlie"))
            {
                return new ResponseModel
                {

                    speech = @"Although we currently don't support Nato phonetic alphabet Charlie matches phonetic alphabet Royal Navy was using from 1914 to 1918, please confirm that's what you meant",
                    displayText = @"Although we currently don't support Nato phonetic alphabet Charlie matches phonetic alphabet Royal Navy was using from 1914 to 1918, please confirm that's what you meant",
                };
            }

            return new ResponseModel
            {
                speech = @"Please confirm " + RnToNato(model.parameters.phonetic_rn.ToString()),
                displayText = @"Please confirm " + RnToNato(model.parameters.phonetic_rn.ToString())
            };
        }

        #endregion

        private string RnToNato (string letter)
        {
            switch (letter)
            {
                case "apples" :
                return "alpha";
                case "butter" :
                return "beta";
                case "charlie" :
                return "charlie";
                case "duff" :
                return "delta";
                case "edward" :
                return "echo";
                case "freddie" :
                return "foxtrot";
                case "george" :
                return "golf";
                case "harry" :
                return "hotel";
                case "ink" :
                return "india";
                case "johnny" :
                return "juliet";
                case "king" :
                return "kilo";
                case "london" :
                return "lima";
                case "monkey" :
                return "mike";
                case "nuts" :
                return "november";
                case "orange" :
                return "october";
                case "pudding" :
                return "papa";
                case "queen" :
                return "quebec";
                case "robert" :
                return "romeo";
                case "sugar" :
                return "sierra";
                case "tommy" :
                return "tango";
                case "uncle" :
                return "uniform";
                case "vinegar" :
                return "victor";
                case "willie" :
                return "whisky";
                case "xerxes" :
                return "x-ray";
                case "yellow" :
                return "yankee";
                case "zebra" :
                return "zulu";
                default:
                return "I don't know";
            }
        }
    }
}


