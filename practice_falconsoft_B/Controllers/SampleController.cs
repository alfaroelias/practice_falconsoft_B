using Microsoft.AspNetCore.Mvc;
using practice_falconsoft_B.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : Controller
    {
        private ISampleService _sampleService;
        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet]
        public ActionResult GetLista()
        {
            var lista = _sampleService.ObtenerListaAmbasListas();

            return Ok(lista);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
