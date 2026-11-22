using APIDesafioTecnico_TargetSistemas.DTOs;
using APIDesafioTecnico_TargetSistemas.Interfaces;

namespace APIDesafioTecnico_TargetSistemas.Services
{
    public class FinanceiroService : IFinanceiroService
    {
        public string CalcularJuros(decimal valor, DateTime dataVencimento)
        {
            var response = new FinanceiroResponseDTO();

            if (valor <= 0)
                throw new ArgumentException("O valor deve ser maior que zero.");
            
            var diasAtraso = (DateTime.Today - dataVencimento.Date).Days;

            if (diasAtraso <= 0)
                throw new ArgumentException("Não existe juros a ser aplicado, pois não há dias de atraso.");

            decimal juros = valor * 0.025m * diasAtraso;

            response.Valor = Math.Round(juros, 2, MidpointRounding.AwayFromZero);
            return response.Resultado;
        }
    }
}
