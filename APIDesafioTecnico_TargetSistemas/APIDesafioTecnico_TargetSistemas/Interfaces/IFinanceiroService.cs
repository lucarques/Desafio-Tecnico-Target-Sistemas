using APIDesafioTecnico_TargetSistemas.DTOs;

namespace APIDesafioTecnico_TargetSistemas.Interfaces
{
    public interface IFinanceiroService
    {
        string CalcularJuros(decimal valor, DateTime dataVencimento);
    }
}
