namespace LabAcademiaAPI.Interfaces.Services;

public interface IHistoricoService
{
    IEnumerable<Treino> CM_VerHistoricos(DateTime? p_Inicio, DateTime? p_Fim);
}
