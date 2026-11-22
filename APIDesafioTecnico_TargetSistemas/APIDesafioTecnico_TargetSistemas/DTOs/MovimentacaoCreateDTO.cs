using APIDesafioTecnico_TargetSistemas.Enums;

namespace APIDesafioTecnico_TargetSistemas.DTOs
{
    public class MovimentacaoCreateDTO
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public EnumTipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
    }
}
