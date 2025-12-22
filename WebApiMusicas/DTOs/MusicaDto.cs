namespace WebApiMusicas.DTOs;

public class MusicaDto
{
    public string? Nome { get; set; }
    public string? Artista { get; set; }
    public int Duracao { get; set; }
    public string? Genero { get; set; }
    public string? Tom { get; set; }
    public string? Ano { get; set; }
    public int Popularidade { get; set; }
}