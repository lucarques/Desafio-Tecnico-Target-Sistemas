namespace APIDesafioTecnico_TargetSistemas.DTOs
{
    public class FinanceiroResponseDTO
    {
        public decimal Valor { get; set; }

        public string Resultado => $"O valor final calculado é: {Valor:C2}";
    }
}
