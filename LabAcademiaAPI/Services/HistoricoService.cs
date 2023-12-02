namespace LabAcademiaAPI.Services;

public class HistoricoService : IHistoricoService
{
    public LabAcademiaContext? C_Contexto { get; set; }

    public HistoricoService(LabAcademiaContext? p_Contexto)
    {
        C_Contexto = p_Contexto;
    }

    public IEnumerable<Treino> CM_VerHistoricos(DateTime? p_Inicio, DateTime? p_Fim)
    {
        List<Treino> m_Treinos = new();
        foreach (var item in C_Contexto!.Historicos)
            m_Treinos.Add(JsonSerializer.Deserialize<Treino>(item.Treino!)!);

        if (p_Inicio == null)
            return m_Treinos;

        if (p_Fim == null)
            return m_Treinos.Where(a => a.Inicio >= p_Inicio.Value);

        return m_Treinos.Where(a => a.Inicio >= p_Inicio && a.Fim <= p_Fim);
    }
}
