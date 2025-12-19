using System.Text.Json.Serialization;

namespace Musicas.Core.Models;

public class Musica
{
    private readonly string[] tonalidades = ["C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G", "G#/Ab", "A", "A#/Bb", "B"];

    [JsonPropertyName("song")]
    public string? Nome { get; set; }

    [JsonPropertyName("artist")]
    public string? Artista { get; set; }

    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }

    [JsonPropertyName("genre")]
    public string? Genero { get; set; }

    [JsonPropertyName("key")]
    public int TomKey { get; set; }

    [JsonPropertyName("year")]
    public string? Ano { get; set; }

    [JsonPropertyName("popularity")]
    public string? PopularidadeString { get; set; }

    public string? Tom
    {
        get
        {
            return tonalidades[TomKey];
        }
    }

    public int Popularidade
    {
        get
        {
            if (int.TryParse(PopularidadeString, out int popularidade))
            {
                return popularidade;
            }
            return 0;
        }
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Duração: {Duracao / 1000}s");
        Console.WriteLine($"Gênero: {Genero}");
        Console.WriteLine($"Tom: {Tom}");
        Console.WriteLine();
    }
}