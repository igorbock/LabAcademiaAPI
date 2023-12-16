namespace LabAcademiaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "Professor")]
public class UsuariosTreinosController : Controller
{
    public EFRepositoryAbstract<UsuariosTreinos>? C_Repository { get; set; }
    public IUsuarioTreinoService? C_Service { get; set; }

    public UsuariosTreinosController(EFRepositoryAbstract<UsuariosTreinos> p_Repository, IUsuarioTreinoService p_Service)
    {
        C_Repository = p_Repository;
        C_Service = p_Service;
    }

    [HttpGet]
    public async Task<IEnumerable<UsuariosTreinos>> CM_ObterRelacoesAsync() => await C_Repository!.CM_LerAsync(null);

    [HttpGet("dto")]
    public async Task<IEnumerable<UsuarioTreinoResponseDTO>> CM_VerRelacoesAsync()
    {
        var m_Retorno = new List<UsuarioTreinoResponseDTO>();

        var m_Relacoes = await C_Repository!.CM_LerAsync(null);
        foreach (var item in m_Relacoes)
        {
            var m_Usuario = await C_Service!.CM_ObterUsuarioPorClaimAsync("matricula", item.CodigoUsuario.ToString().PadLeft(6, '0'));
            var m_Treino = C_Repository.C_Contexto!.Treinos.FirstOrDefault(a => a.Id == item.CodigoTreino);

            m_Retorno.Add(new UsuarioTreinoResponseDTO
            {
                C_IdUsuario = m_Usuario.Id,
                C_Usuario = m_Usuario.UserName,
                C_Treino = m_Treino!.Nome
            });
        }

        return m_Retorno;
    }

    [HttpPost]
    public async Task CM_RelacionarUsuarioTreino(UsuarioTreinoRequestDTO p_Request)
    { 
        //var m_Usuario = await C_Service!.CM_ObterUsuarioPorIdAsync(p_Request.C_IdUsuario!, Request.Headers.Authorization.SingleOrDefault()!);
        //if (m_Usuario == null) throw new KeyNotFoundException(nameof(m_Usuario));

        //var m_Treino = C_Repository!.C_Contexto!.Treinos.Find(p_Request.C_IdTreino);
        //if (m_Treino == null) throw new KeyNotFoundException(nameof(m_Treino));

        //var m_Claims = await C_Service!.CM_ObterClaimsDoUsuarioAsync(p_Request.C_IdUsuario!);
        //var m_Matricula = m_Claims.First(a => a.Type!.Equals("matricula")).Value;

        await C_Repository!.CM_AdicionarAsync(new UsuariosTreinos
        {
            CodigoTreino = p_Request.C_IdTreino,
            CodigoUsuario = int.Parse(p_Request.C_IdUsuario!),
        });
    }

    [HttpDelete]
    public async Task CM_RemoverUsuarioTreino(int p_CodigoTreino)
        => await C_Repository!.CM_RemoverAsync(p_CodigoTreino);
}
