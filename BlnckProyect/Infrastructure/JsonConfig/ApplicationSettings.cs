using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlnckProyect.Infrastructure.JsonConfig
{
    public class ApplicationSettings
    {
        public List<ErrorMessage> ErrorMessages { get; set; }
    }




    //clases
    public class ErrorMessage
    {
        public int code { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string redirectTo { get; set; }
    }
}