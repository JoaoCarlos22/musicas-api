namespace WebApiMusicas.DTOs;

/// <summary>
/// Resposta específica para músicas
/// </summary>
public class MusicasResponseDto
{
    public int Total { get; set; }
    public List<MusicaDto> Items { get; set; } = [];
}