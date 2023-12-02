namespace LabAcademiaAPI.Interfaces.Services;

public interface ITreinoService
{
    Task CM_AtivarDesativarTreinoAsync(int p_Codigo);
    Task<int> CM_IniciarTreinoAsync(int p_Codigo);
    Task CM_FinalizarTreinoAsync(int p_Codigo);
}
