using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using practice_falconsoft_B_2.Models;
using practice_falconsoft_B_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft_B_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallingAndDeserializationController : ControllerBase
    {
        private IDownloadService _downloadService;

        public CallingAndDeserializationController(IDownloadService downloadService)
        {
            _downloadService = downloadService;
        }

        [HttpGet]
        public ActionResult CallingAndDeserialization()
        {
            List<Sample> listaResultado =_downloadService.DownloadJson();
            _downloadService.SaveJsonToFile(listaResultado);
            return Ok(listaResultado);
        }
    }
}
