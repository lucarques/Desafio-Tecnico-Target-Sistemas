using APIDesafioTecnico_TargetSistemas.DTOs;
using APIDesafioTecnico_TargetSistemas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioTecnico_TargetSistemas.Controllers
{
    [ApiController]
    [Route("api/financeiro")]
    public class FinanceiroController : ControllerBase
    {
        private readonly IFinanceiroService _financeiroService;

        public FinanceiroController(IFinanceiroService financeiroService)
        {
            _financeiroService = financeiroService;
        }

        [HttpPost("calcular-juros")]
        public IActionResult CalcularJuros([FromBody] FinanceiroCreateDTO financeiroCreateDTO)
        {
            var response = _financeiroService.CalcularJuros(financeiroCreateDTO.Valor, financeiroCreateDTO.DataVencimento);
            return Ok(response);
        }
    }
}
