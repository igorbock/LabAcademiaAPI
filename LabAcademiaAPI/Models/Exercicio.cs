namespace LabAcademiaAPI.Models;

[Table("Exercicios", Schema = "academia")]
public class Exercicio
{
    [Key]
    public int Id { get; set; }
    public string? Descricao { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Series { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Repeticao { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Tempo { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Carga { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Concluido { get; set; }

    [ForeignKey("Treinos")]
    public int CodigoTreino { get; set; }

    [NotMapped]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual Treino? Treinos { get; set; }
}
