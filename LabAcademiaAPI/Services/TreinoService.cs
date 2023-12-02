namespace LabAcademiaAPI.Services;

public class TreinoService : ITreinoService
{
    public LabAcademiaContext? C_Contexto { get; set; }

    public TreinoService(LabAcademiaContext? p_Contexto)
    {
        C_Contexto = p_Contexto;
    }

    public async Task CM_AtivarDesativarTreinoAsync(int p_Codigo)
    {
        var m_Treino = C_Contexto!.Treinos.Find(p_Codigo) ?? throw new KeyNotFoundException();
        m_Treino.Ativo = m_Treino.Ativo == false ? true : false;
        C_Contexto!.Treinos.Update(m_Treino);
        await C_Contexto!.SaveChangesAsync();
    }

    public async Task<int> CM_IniciarTreinoAsync(int p_Codigo)
    {
        var m_Treino = C_Contexto!.Treinos.Find(p_Codigo) ?? throw new KeyNotFoundException();
        m_Treino.Inicio = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        var m_TreinoJSON = JsonSerializer.Serialize(m_Treino);

        var m_Historico = new Historico
        {
            Treino = m_TreinoJSON
        };
        var m_Entidade = C_Contexto!.Historicos.Add(m_Historico);
        await C_Contexto!.SaveChangesAsync();

        return m_Entidade.Entity.Id;
    }

    public async Task CM_FinalizarTreinoAsync(int p_Codigo)
    {
        var m_Historico = C_Contexto!.Historicos.Find(p_Codigo) ?? throw new KeyNotFoundException();
        var m_Treino = JsonSerializer.Deserialize<Treino>(m_Historico.Treino!) ?? throw new KeyNotFoundException();
        m_Treino.Fim = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

        m_Historico.Treino = JsonSerializer.Serialize(m_Treino);
        C_Contexto!.Historicos.Update(m_Historico);
        await C_Contexto.SaveChangesAsync();
    }
}
