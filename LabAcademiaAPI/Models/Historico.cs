namespace LabAcademiaAPI.Models;

[Table("Historicos", Schema = "academia")]
public class Historico
{
    [Key]
    public int Id { get; set; }
    
    [Column(TypeName = "jsonb")]
    public string? Treino { get; set; }
}
