namespace LabAcademiaAPI.Interfaces.Services;

public interface IUsuarioTreinoService
{
    Task<IEnumerable<IdentityUser>> CM_ObterUsuariosAsync();
    Task<IdentityUser> CM_ObterUsuarioPorIdAsync(string p_ID);
    Task<IdentityUser> CM_ObterUsuarioPorClaimAsync(string p_NomeClaim, string p_ValorClaim);
    Task<IEnumerable<ClaimDTO>> CM_ObterClaimsDoUsuarioAsync(string p_IdUsuario);
}
