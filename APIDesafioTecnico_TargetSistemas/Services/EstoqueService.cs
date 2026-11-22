using APIDesafioTecnico_TargetSistemas.DTOs;
using APIDesafioTecnico_TargetSistemas.Enums;
using APIDesafioTecnico_TargetSistemas.Interfaces;
using APIDesafioTecnico_TargetSistemas.Models;

namespace APIDesafioTecnico_TargetSistemas.Services
{
    public class EstoqueService : IEstoqueService
    {
        private static readonly List<Movimentacao> _movimentacoes = new();
        private static int _proximoId = 1;

        private static readonly List<Produto> _produtos = new()
        {
            new Produto
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            },
            new Produto
            {
                CodigoProduto = 102,
                DescricaoProduto = "Caderno Universitário",
                Estoque = 75
            },
            new Produto
            {
                CodigoProduto = 103,
                DescricaoProduto = "Borracha Branca",
                Estoque = 200
            },
            new Produto
            {
                CodigoProduto = 104,
                DescricaoProduto = "Lápis Preto HB",
                Estoque = 320
            },
            new Produto
            {
                CodigoProduto = 105,
                DescricaoProduto = "Marcador de Texto Amarelo",
                Estoque = 90
            }
        };

        public List<Produto> ObterTodosProdutos() => _produtos.ToList();

        public MovimentacaoResponseDTO MovimentacaoEstoque(MovimentacaoCreateDTO movimentacaoCreateDTO)
        {
            var response = new MovimentacaoResponseDTO();

            if (!Enum.IsDefined(movimentacaoCreateDTO.Tipo))
            {
                throw new ArgumentException("Tipo de movimentação inválido.");
            }

            var produtoExistente = _produtos.FirstOrDefault(p => p.CodigoProduto == movimentacaoCreateDTO.CodigoProduto);

            if (movimentacaoCreateDTO.Quantidade > 0)
            {
                if (produtoExistente != null)
                {
                    if (movimentacaoCreateDTO.Tipo == EnumTipoMovimentacao.Saida)
                    {
                        if (movimentacaoCreateDTO.Quantidade > produtoExistente.Estoque)
                            throw new ArgumentException($"Estoque insuficiente para o produto {produtoExistente.DescricaoProduto}. Estoque atual: {produtoExistente.Estoque}, Quantidade solicitada: {movimentacaoCreateDTO.Quantidade}.");

                        else
                            produtoExistente.Estoque -= movimentacaoCreateDTO.Quantidade;
                    }
                    else if (movimentacaoCreateDTO.Tipo == EnumTipoMovimentacao.Entrada)
                    {
                        produtoExistente.Estoque += movimentacaoCreateDTO.Quantidade;
                    }
                }
                else if (movimentacaoCreateDTO.Tipo == EnumTipoMovimentacao.Saida)
                    throw new ArgumentException($"O produto informado não existe no estoque para realizar uma saída de estoque");

                else if (movimentacaoCreateDTO.Tipo == EnumTipoMovimentacao.Entrada)
                {
                    new Produto()
                    {
                        CodigoProduto = movimentacaoCreateDTO.CodigoProduto,
                        DescricaoProduto = movimentacaoCreateDTO.Descricao,
                        Estoque = movimentacaoCreateDTO.Quantidade
                    };
                }

                response = new MovimentacaoResponseDTO
                {
                    Id = _proximoId++,
                    CodigoProduto = produtoExistente.CodigoProduto,
                    Descricao = produtoExistente.DescricaoProduto,
                    Tipo = movimentacaoCreateDTO.Tipo,
                    Quantidade = movimentacaoCreateDTO.Quantidade,
                    EstoqueFinal = produtoExistente.Estoque
                };

                _movimentacoes.Add(new Movimentacao
                {
                    Id = response.Id,
                    CodigoProduto = response.CodigoProduto,
                    Descricao = response.Descricao,
                    Tipo = response.Tipo,
                    Quantidade = response.Quantidade
                });
            }

            return response;
        }
    }
}
