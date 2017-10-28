using System.Collections.Generic;

namespace mvc_template.models
{
    public class ResponseModel
    {
        public string speech {get;set;}
        public string displayText {get;set;}
        public dynamic data {get;set;}
        public List<dynamic> contextOut {get;set;}
        public string source {get;set;}
    }
}
