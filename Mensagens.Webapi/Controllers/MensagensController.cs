using System.Collections.Generic;
using Mensagens.Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Mensagens.Webapi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class MensagensController : ControllerBase
    {

        private static IList<Mensagem> _mensagens;

        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mensagens);
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post(Mensagem mensagem)
        {
            mensagem.Id = _mensagens.Count + 1;
            _mensagens.Add(mensagem);
            return Ok(mensagem);
        }
        
    }
}