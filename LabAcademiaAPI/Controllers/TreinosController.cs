namespace LabAcademiaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TreinosController : Controller
{
    public EFRepositoryAbstract<Treino>? C_TreinosRepositorio { get; set; }
    public ITreinoService C_TreinosService { get; set; }

    public TreinosController(EFRepositoryAbstract<Treino> p_TreinosRepositorio, ITreinoService p_TreinosService)
    {
        C_TreinosRepositorio = p_TreinosRepositorio;
        C_TreinosService = p_TreinosService;
    }

    [HttpGet]
    public async Task<IEnumerable<Treino>> CM_ObterTreinosAsync(int? p_Codigo) => await C_TreinosRepositorio!.CM_LerAsync(p_Codigo);

    [HttpPut]
    [Authorize(Policy = "Administrador")]
    public async Task CM_AtivarDesativarTreinoAsync(int p_Codigo) => await C_TreinosService!.CM_AtivarDesativarTreinoAsync(p_Codigo);

    [HttpPost]
    [Authorize(Policy = "Administrador")]
    public async Task CM_CriarTreinoAsync(char p_Codigo, string p_Nome)
    {
        var m_Treino = new Treino
        {
            Codigo = p_Codigo,
            Nome = p_Nome
        };
        await C_TreinosRepositorio!.CM_AdicionarAsync(m_Treino);
    }

    [HttpDelete]
    [Authorize(Policy = "Administrador")]
    public async Task CM_RemoverTreinoAsync(int p_Codigo) => await C_TreinosRepositorio!.CM_RemoverAsync(p_Codigo);

    [HttpPut("editar")]
    [Authorize(Policy = "Administrador")]
    public async Task CM_EditarTreinoAsync(Treino p_Treino) => await C_TreinosRepositorio!.CM_AtualizarAsync(p_Treino);

    [HttpPost("iniciar")]
    public async Task<int> CM_IniciarTreinoAsync(int p_Codigo) => await C_TreinosService.CM_IniciarTreinoAsync(p_Codigo);

    [HttpPost("finalizar")]
    public async Task CM_FinalizarTreinoAsync(int p_Codigo) => await C_TreinosService.CM_FinalizarTreinoAsync(p_Codigo);
}
