using APIDesafioTecnico_TargetSistemas.DTOs;
using APIDesafioTecnico_TargetSistemas.Models;

namespace APIDesafioTecnico_TargetSistemas.Interfaces
{
    public interface IEstoqueService
    {
        MovimentacaoResponseDTO MovimentacaoEstoque (MovimentacaoCreateDTO movimentacaoCreateDTO);
        List<Produto> ObterTodosProdutos();
    }
}
