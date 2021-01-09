using System.Threading.Tasks;
using Mensagens.Dominio.Modelos;
using Mensagens.Infra.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Webapi.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class MensagensController : ControllerBase
    {

        private readonly MyContext _context;

        public MensagensController(MyContext context)
        {
            _context = context;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var mensagens = await _context.Mensagens.ToListAsync();
            return Ok(mensagens);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Post(Mensagem mensagem)
        {
            await _context.AddAsync(mensagem);
            await _context.SaveChangesAsync();
            return Ok(mensagem);
        }
        
    }
}