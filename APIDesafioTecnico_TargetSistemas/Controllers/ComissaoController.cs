using APIDesafioTecnico_TargetSistemas.DTOs;
using APIDesafioTecnico_TargetSistemas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIDesafioTecnico_TargetSistemas.Controllers
{
    [ApiController]
    [Route("api/comissao")]
    public class ComissaoController : ControllerBase
    {
        private readonly IComissaoService _comissaoService;

        public ComissaoController(IComissaoService comissaoService)
        {
            _comissaoService = comissaoService;
        }

        [HttpPost]
        public IActionResult ObterComissaoPorVendedor([FromBody] List<VendaCreateDTO> vendas)
        {
            var comissoes = _comissaoService.ObterComissaoPorVendedor(vendas);
            return Ok(comissoes);
        }
    }
}
