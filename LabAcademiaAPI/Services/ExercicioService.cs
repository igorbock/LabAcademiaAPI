namespace LabAcademiaAPI.Services;

public class ExercicioService : IExercicioService
{
    public LabAcademiaContext? C_Contexto { get; set; }

    public ExercicioService(LabAcademiaContext? p_Contexto)
    {
        C_Contexto = p_Contexto;
    }

    public void CM_AlterarCarga(int p_CodigoExercicio, double? p_Carga)
    {
        if (p_Carga == null)
            return;

        var m_Exercicio = C_Contexto!.Exercicios.Find(p_CodigoExercicio) ?? throw new KeyNotFoundException();
        m_Exercicio.Carga = p_Carga;
        C_Contexto!.Update(m_Exercicio);
        C_Contexto.SaveChanges();
    }

    public void CM_AlterarRepeticao(int p_CodigoExercicio, int? p_Repeticao)
    {
        if (p_Repeticao == null)
            return;

        var m_Exercicio = C_Contexto!.Exercicios.Find(p_CodigoExercicio) ?? throw new KeyNotFoundException();
        m_Exercicio.Repeticao = p_Repeticao;
        C_Contexto!.Update(m_Exercicio);
        C_Contexto.SaveChanges();
    }

    public void CM_AlterarSerie(int p_CodigoExercicio, int? p_Serie)
    {
        if (p_Serie == null)
            return;

        var m_Exercicio = C_Contexto!.Exercicios.Find(p_CodigoExercicio) ?? throw new KeyNotFoundException();
        m_Exercicio.Series = p_Serie;
        C_Contexto!.Update(m_Exercicio);
        C_Contexto.SaveChanges();
    }

    public void CM_AlterarTempo(int p_CodigoExercicio, double? p_Tempo)
    {
        if (p_Tempo == null)
            return;

        var m_Exercicio = C_Contexto!.Exercicios.Find(p_CodigoExercicio) ?? throw new KeyNotFoundException();
        m_Exercicio.Tempo = p_Tempo;
        C_Contexto!.Update(m_Exercicio);
        C_Contexto.SaveChanges();
    }
}
