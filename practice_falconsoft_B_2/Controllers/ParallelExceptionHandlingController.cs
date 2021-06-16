using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practice_falconsoft_B_2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace practice_falconsoft_B_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParallelExceptionHandlingController : ControllerBase
    {
        private IDownloadService _downloadService;
        private CancellationTokenSource _cancellationTokenSource;

        public ParallelExceptionHandlingController(IDownloadService downloadService)
        {
            _downloadService = downloadService;
            _cancellationTokenSource = new CancellationTokenSource();
        }
        [HttpGet]
        public async Task<ActionResult> ObtenerSumaQty(CancellationToken cancellationToken)
        {
            int total = 0;
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        throw new TaskCanceledException();
                    }
                    //cancellationToken.ThrowIfCancellationRequested();
                    total += await _downloadService.GetTotalQty();
                }

                return Ok(total);
            }            
            catch (TaskCanceledException ex)
            {
                //throw;
                return Ok(total);
            }
            catch (WebException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> CancelarObtenerSumaQty()
        {
            _cancellationTokenSource?.Cancel();
            return Ok();
        }
    }
}
