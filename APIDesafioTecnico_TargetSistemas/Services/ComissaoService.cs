using APIDesafioTecnico_TargetSistemas.DTOs;
using APIDesafioTecnico_TargetSistemas.Interfaces;

namespace APIDesafioTecnico_TargetSistemas.Services
{
    public class ComissaoService : IComissaoService
    {
        public List<ComissaoResponseDTO> ObterComissaoPorVendedor(List<VendaCreateDTO> vendas)
        {
            var comissoes = new List<ComissaoResponseDTO>();

            foreach (var venda in vendas)
            {
                if (venda.Valor >= 100 && venda.Valor < 500)
                {
                    var comissao = new ComissaoResponseDTO
                    {
                        Vendedor = venda.Vendedor,
                        TotalVendas = venda.Valor,
                        TotalComissao = Math.Round(venda.Valor * 0.1m, 2)
                    };
                    comissoes.Add(comissao);

                }
                else if (venda.Valor >= 500)
                {
                    var comissao = new ComissaoResponseDTO
                    {
                        Vendedor = venda.Vendedor,
                        TotalVendas = venda.Valor,
                        TotalComissao = Math.Round(venda.Valor * 0.5m, 2)
                    };
                    comissoes.Add(comissao);
                }
                else
                {
                    var comissao = new ComissaoResponseDTO
                    {
                        Vendedor = venda.Vendedor,
                        TotalVendas = venda.Valor,
                        TotalComissao = 0
                    };
                    comissoes.Add(comissao);
                }
            }

            return comissoes.GroupBy(x => x.Vendedor).Select(g => new ComissaoResponseDTO
            {
                Vendedor = g.Key,
                TotalVendas = g.Sum(v => v.TotalVendas),
                TotalComissao = g.Sum(v => v.TotalComissao)
            }).ToList();
        }
    }
}