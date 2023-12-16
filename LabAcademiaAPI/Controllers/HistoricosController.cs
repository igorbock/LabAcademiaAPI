namespace LabAcademiaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "Professor")]
public class HistoricosController : Controller
{
    public LabAcademiaContext? C_Contexto { get; set; }
    public IHistoricoService? C_Service { get; set; }

    public HistoricosController(LabAcademiaContext? p_Contexto, IHistoricoService p_Service)
    {
        C_Contexto = p_Contexto;
        C_Service = p_Service;
    }

    [HttpPost]
    public IEnumerable<Treino> CM_VerHistoricos(DateTime? p_Inicio, DateTime? p_Fim) => C_Service!.CM_VerHistoricos(p_Inicio, p_Fim);
}
