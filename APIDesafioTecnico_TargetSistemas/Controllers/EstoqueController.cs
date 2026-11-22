using Microsoft.AspNetCore.Mvc;
using APIDesafioTecnico_TargetSistemas.Interfaces;
using APIDesafioTecnico_TargetSistemas.DTOs;
namespace APIDesafioTecnico_TargetSistemas.Controllers
{
    [ApiController]
    [Route("api/estoque")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        public ActionResult ObterProdutos()
        {
            var response = _estoqueService.ObterTodosProdutos();
            return Ok(response);
        }

        [HttpPost]
        public ActionResult MovimentacaoEstoque([FromBody] MovimentacaoCreateDTO movimentacaoCreateDTO)
        {
            var response = _estoqueService.MovimentacaoEstoque(movimentacaoCreateDTO);
            return Ok(response);
        }

    }
}
