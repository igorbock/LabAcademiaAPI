namespace LabAcademiaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ExerciciosController : Controller
{
    public EFRepositoryAbstract<Exercicio>? C_ExerciciosRepository { get; set; }
    public IExercicioService? C_Service { get; set; }

    public ExerciciosController(EFRepositoryAbstract<Exercicio> p_ExerciciosRepository, IExercicioService? p_Service)
    {
        C_ExerciciosRepository = p_ExerciciosRepository;
        C_Service = p_Service;
    }

    [HttpPost]
    [Authorize(Policy = "Administrador")]
    public async Task CM_CriarExercicioAsync(string p_Descricao, int? p_Series, int? p_Repeticao, double? p_Tempo, double? p_Carga, int p_CodigoTreino)
    {
        var m_Exercicio = new Exercicio
        {
            Descricao = p_Descricao,
            Series = p_Series,
            Repeticao = p_Repeticao,
            Tempo = p_Tempo,
            Carga = p_Carga,
            CodigoTreino = p_CodigoTreino
        };

        await C_ExerciciosRepository!.CM_AdicionarAsync(m_Exercicio);
    }

    [HttpPut]
    [Authorize(Policy = "Administrador")]
    public async Task CM_EditarExercicioAsync(Exercicio p_Exercicio) => await C_ExerciciosRepository!.CM_AtualizarAsync(p_Exercicio);

    [HttpGet]
    public async Task<IEnumerable<Exercicio>> CM_ObterExerciciosAsync(int? p_Codigo) => await C_ExerciciosRepository!.CM_LerAsync(p_Codigo);

    [HttpDelete]
    [Authorize(Policy = "Administrador")]
    public async Task CM_RemoverExercicioAsync(int p_Codigo) => await C_ExerciciosRepository!.CM_RemoverAsync(p_Codigo);

    [HttpPut("carga")]
    public void CM_AlterarCarga(int p_CodigoExercicio, double? p_Carga) => C_Service!.CM_AlterarCarga(p_CodigoExercicio, p_Carga);

    [HttpPut("tempo")]
    public void CM_AlterarTempo(int p_CodigoExercicio, double? p_Tempo) => C_Service!.CM_AlterarTempo(p_CodigoExercicio, p_Tempo);

    [HttpPut("series")]
    public void CM_AlterarSerie(int p_CodigoExercicio, int? p_Serie) => C_Service!.CM_AlterarSerie(p_CodigoExercicio, p_Serie);

    [HttpPut("repeticao")]
    public void CM_AlterarRepeticao(int p_CodigoExercicio, int? p_Repeticao) => C_Service!.CM_AlterarRepeticao(p_CodigoExercicio, p_Repeticao);
}
