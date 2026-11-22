using APIDesafioTecnico_TargetSistemas.Enums;

namespace APIDesafioTecnico_TargetSistemas.DTOs
{
    public class MovimentacaoResponseDTO
    {
        public int Id { get; set; }
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public EnumTipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public int EstoqueFinal { get; set; }
    }
}
