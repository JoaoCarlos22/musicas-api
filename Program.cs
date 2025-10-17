using System.Text.Json;
using ApiMusicas.Filters;
using ApiMusicas.Models;

using HttpClient client = new();

try
{
    string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
    var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
    Filter.GenerosFiltro(musicas);
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
}