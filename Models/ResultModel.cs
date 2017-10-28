namespace mvc_template.models
{
    public class ResultModel
    {
        public string resolvedQuery {get;set;}
        public string action {get;set;}
        public bool actionIncomplete {get;set;}
        public dynamic parameters {get;set;}
    }
}
