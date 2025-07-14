using ContainRs.WebApp.Data;
using ContainRs.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContainRs.WebApp.Controllers
{
    [ApiController]
    [Route("api/registros")]
    public class ApiRegistroController(AppDbContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RegistroViewModel request)
        {         
            var cliente = new Cliente(request.Nome, new Email(request.Email), request.CPF)
            {
                Celular = request.Celular,
                CEP = request.CEP,
                Rua = request.Rua,
                Numero = request.Numero,
                Complemento = request.Complemento,
                Bairro = request.Bairro,
                Municipio = request.Municipio,
                Estado = request.Estado
            };

            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
