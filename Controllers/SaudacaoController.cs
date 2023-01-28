using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API_Teste.Controllers
{
    [ApiController]
    [Route("controller")]
    public class SaudacaoController : ControllerBase
    {
        [HttpGet("ObterDataHora")]
        public IActionResult DataHora()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString()
            };

            return Ok(obj);
        }
    }
}