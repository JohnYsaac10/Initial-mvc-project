using AutoMapper;
using BlnckProyect.Infrastructure.Filters;
using BlnckProyect.Infrastructure.JsonConfig;
using System.Web.Mvc;

namespace BlnckProyect.Controllers
{
    [ExceptionHandlerFilter]
    //[Authentication]
    public class ExampleController : Controller
    {
        private readonly ApplicationSettings _settings;
        private readonly IMapper _mapper;
        public ExampleController(IMapper mapper, EnvModeSettingsManager settings)
        {
            _mapper = mapper;
            _settings = settings.Config;
        }
        // GET: Example
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[AllowedRoles("Admin", "SuperAdmin")]
        //[ProtectPost]
        public ActionResult Usuarios()
        {
            //ModelState.IsValid
            return View("Example");
        }

        [AllowedRoles("Admin", "SuperAdmin")]
        public ActionResult Hola(string data)
        {
            return Json(new { Data = "it's ok" });
        }
    }
}