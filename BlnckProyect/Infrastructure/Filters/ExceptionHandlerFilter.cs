using BlnckProyect.Models.ErrorHandler;
using BlnckProyect.Services.Utility;
using System;
using System.Web.Mvc;

namespace BlnckProyect.Infrastructure.Filters
{
    public class ExceptionHandlerFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Error error = new Error()
            {
                ExceptionMessage = filterContext.Exception.Message,
                ExceptionStackTrace = filterContext.Exception.StackTrace,
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ExceptionLogTime = DateTime.Now
            };

            MyLogger.GetInstance()
                .Error($"Exception.Message: {error.ExceptionMessage}|Exception.StackTrace: {error.ExceptionStackTrace} \n ControllerName: {error.ControllerName} \n ActionName: {error.ActionName}");

            /*
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            }; */

            filterContext.ExceptionHandled = true;
            filterContext.Controller.ViewData.Model = error;
            filterContext.Result = new ViewResult { ViewName = "Error", ViewData = new ViewDataDictionary(error) };
        }
    }
}