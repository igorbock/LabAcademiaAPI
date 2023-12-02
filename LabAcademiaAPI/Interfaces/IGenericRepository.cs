namespace LabAcademiaAPI.Interfaces;

public interface IGenericRepository<TipoT>
{
    Task CM_AdicionarAsync(TipoT p_Entidade);
    Task<IEnumerable<TipoT>> CM_LerAsync(int? p_Codigo);
    Task CM_AtualizarAsync(TipoT p_Entidade);
    Task CM_RemoverAsync(int p_Codigo);
}
