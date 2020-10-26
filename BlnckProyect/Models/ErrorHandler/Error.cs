using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlnckProyect.Models.ErrorHandler
{
    public class Error
    {
        public string ExceptionMessage { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ExceptionStackTrace { get; set; }
        public DateTime ExceptionLogTime { get; set; }
    }
}