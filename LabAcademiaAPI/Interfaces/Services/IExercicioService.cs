namespace LabAcademiaAPI.Interfaces.Services;

public interface IExercicioService
{
    void CM_AlterarCarga(int p_CodigoExercicio, double? p_Carga);
    void CM_AlterarTempo(int p_CodigoExercicio, double? p_Tempo);
    void CM_AlterarSerie(int p_CodigoExercicio, int? p_Serie);
    void CM_AlterarRepeticao(int p_CodigoExercicio, int? p_Repeticao);
}
