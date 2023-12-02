namespace LabAcademiaAPI.Interfaces;

public abstract class EFRepositoryAbstract<TipoT> : IGenericRepository<TipoT> where TipoT : class
{
    public LabAcademiaContext? C_Contexto { get; set; }

    public EFRepositoryAbstract(LabAcademiaContext? p_Contexto)
    {
        C_Contexto = p_Contexto;
    }

    public virtual async Task CM_AdicionarAsync(TipoT p_Entidade)
    {
        if(p_Entidade == null)
            throw new ArgumentNullException(nameof(p_Entidade));

        C_Contexto!.Add(p_Entidade);
        await C_Contexto.SaveChangesAsync();
    }
    public virtual async Task CM_AtualizarAsync(TipoT p_Entidade)
    {
        if (p_Entidade == null)
            throw new ArgumentNullException(nameof(p_Entidade));

        C_Contexto!.Update(p_Entidade);
        await C_Contexto.SaveChangesAsync();
    }
    public abstract Task<IEnumerable<TipoT>> CM_LerAsync(int? p_Codigo);
    public virtual async Task CM_RemoverAsync(int p_Codigo)
    {
        var m_Entidade = await C_Contexto!.FindAsync<TipoT>(p_Codigo) ?? throw new KeyNotFoundException();
        C_Contexto!.Remove(m_Entidade);
        await C_Contexto!.SaveChangesAsync();
    }
}
