namespace APIDesafioTecnico_TargetSistemas.DTOs
{
    public class ComissaoResponseDTO
    {
        public string Vendedor { get; set; } = string.Empty;
        public decimal TotalVendas { get; set; }
        public decimal TotalComissao { get; set; }
    }
}
