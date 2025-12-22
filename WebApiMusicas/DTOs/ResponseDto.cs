namespace WebApiMusicas.DTOs;

/// <summary>
/// Resposta genérica com lista de itens e total
/// </summary>
public class ResponseDto<T>
{
    public int Total { get; set; }
    public List<T> Items { get; set; } = [];
}