using System.Text.Json.Serialization;

namespace ApiMusicas.Models;

internal class Musica
{
    [JsonPropertyName("song")]
    public string? Nome { get; set; }

    [JsonPropertyName("artist")]
    public string? Artista { get; set; }

    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }

    [JsonPropertyName("genre")]
    public string? Genero { get; set; }

    [JsonPropertyName("key")]
    private int TomKey { get; }

    public string? Tom { 
        get
        {
            return TomKey switch
            {
                0 => "C",
                1 => "C#/Db",
                2 => "D",
                3 => "D#/Eb",
                4 => "E",
                5 => "F",
                6 => "F#/Gb",
                7 => "G",
                8 => "G#/Ab",
                9 => "A",
                10 => "A#/Bb",
                11 => "B",
                _ => null,
            };
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
