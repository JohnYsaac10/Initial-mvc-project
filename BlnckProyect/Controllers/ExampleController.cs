using AutoMapper;
using BlnckProyect.Infrastructure.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlnckProyect.Controllers
{
    [Authentication]
    public class ExampleController : Controller
    {

        private readonly IMapper _mapper;
        public ExampleController(IMapper mapper)
        {
            _mapper = mapper;
        }
        // GET: Example
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[AllowedRoles("Admin", "SuperAdmin")]
        //[ProtectPost]
        public ActionResult Usuarios()
        {
            //ModelState.IsValid
            return null;
        }
    }
}