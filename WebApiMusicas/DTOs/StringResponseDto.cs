namespace WebApiMusicas.DTOs;

/// <summary>
/// Resposta específica para strings (gêneros, artistas)
/// </summary>
public class StringResponseDto
{
    public int Total { get; set; }
    public List<string> Items { get; set; } = [];
}