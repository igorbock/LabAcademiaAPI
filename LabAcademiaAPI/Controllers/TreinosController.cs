namespace LabAcademiaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "Professor")]
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
    public async Task CM_AtivarDesativarTreinoAsync(int p_Codigo) => await C_TreinosService!.CM_AtivarDesativarTreinoAsync(p_Codigo);

    [HttpPost]
    public async Task CM_CriarTreinoAsync(Treino p_Treino)
    {
        //var m_Treino = new Treino
        //{
        //    Codigo = p_Codigo,
        //    Nome = p_Nome
        //};
        await C_TreinosRepositorio!.CM_AdicionarAsync(p_Treino);
    }

    [HttpDelete]
    public async Task CM_RemoverTreinoAsync(int p_Codigo) => await C_TreinosRepositorio!.CM_RemoverAsync(p_Codigo);

    [HttpPut("editar")]
    public async Task CM_EditarTreinoAsync(Treino p_Treino) => await C_TreinosRepositorio!.CM_AtualizarAsync(p_Treino);

    [HttpPost("iniciar")]
    public async Task<int> CM_IniciarTreinoAsync(int p_Codigo) => await C_TreinosService.CM_IniciarTreinoAsync(p_Codigo);

    [HttpPost("finalizar")]
    public async Task CM_FinalizarTreinoAsync(int p_Codigo) => await C_TreinosService.CM_FinalizarTreinoAsync(p_Codigo);
}
