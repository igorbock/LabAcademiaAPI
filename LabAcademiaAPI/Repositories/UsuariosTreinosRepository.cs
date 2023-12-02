namespace LabAcademiaAPI.Repositories;

public class UsuariosTreinosRepository : EFRepositoryAbstract<UsuariosTreinos>
{
    public UsuariosTreinosRepository(LabAcademiaContext? p_Contexto) : base(p_Contexto) { }

    public override async Task<IEnumerable<UsuariosTreinos>> CM_LerAsync(int? p_Codigo)
        => await C_Contexto!.UsuariosTreinos.ToListAsync();

    public override async Task CM_RemoverAsync(int p_Codigo)
    {
        var m_Entidade = C_Contexto!.UsuariosTreinos.Where(a => a.CodigoTreino == p_Codigo);
        C_Contexto.UsuariosTreinos.RemoveRange(m_Entidade);
        await C_Contexto.SaveChangesAsync();
    }
}
