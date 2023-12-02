namespace LabAcademiaAPI.Models;

[Table("UsuariosTreinos", Schema = "academia")]
public class UsuariosTreinos
{
    public int CodigoUsuario { get; set; }

    [ForeignKey("Treinos")]
    public int CodigoTreino { get; set; }

    [NotMapped]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual Treino? Treinos { get; set; }
}
