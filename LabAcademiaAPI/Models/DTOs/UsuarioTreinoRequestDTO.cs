namespace LabAcademiaAPI.Models.DTOs;

public record UsuarioTreinoRequestDTO
{
    [JsonPropertyName("CodigoUsuario")]
    public string? C_IdUsuario { get; set; }

    [JsonPropertyName("CodigoTreino")]
    public int C_IdTreino { get; set; }
}
