namespace LabAcademiaAPI.Repositories;

public class ExercicioRepository : EFRepositoryAbstract<Exercicio>
{
    public ExercicioRepository(LabAcademiaContext? p_Contexto) : base(p_Contexto) { }

    public override async Task<IEnumerable<Exercicio>> CM_LerAsync(int? p_Codigo)
    {
        var m_Retorno = await C_Contexto!.Exercicios.ToListAsync();

        if (p_Codigo == null)
            return m_Retorno;

        if (m_Retorno == null)
            return Enumerable.Empty<Exercicio>();

        if (p_Codigo == null && m_Retorno is IEnumerable<Exercicio>)
            return m_Retorno;
        else
        {
            return m_Retorno.Where(a => a.Id == p_Codigo);
        }
    }
}
