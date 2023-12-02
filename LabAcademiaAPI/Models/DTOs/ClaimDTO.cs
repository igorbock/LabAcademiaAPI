namespace LabAcademiaAPI.Models.DTOs;

public record ClaimDTO
{
    public string? Type { get; set; }
    public string? Value { get; set; }
    public string? ValueType { get; set; }
}
