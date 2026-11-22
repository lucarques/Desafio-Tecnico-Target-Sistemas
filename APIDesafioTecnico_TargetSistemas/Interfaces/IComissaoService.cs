using APIDesafioTecnico_TargetSistemas.DTOs;

namespace APIDesafioTecnico_TargetSistemas.Interfaces
{
    public interface IComissaoService
    {
        List<ComissaoResponseDTO> ObterComissaoPorVendedor(List<VendaCreateDTO> vendas);
    }
}
