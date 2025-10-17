using ApiMusicas.Models;

namespace ApiMusicas.Filters;

internal class Filter
{
    public static void GenerosFiltro(List<Musica> musicas)
    {
        var generos = musicas.Select(m => m.Genero).Distinct();
        Console.WriteLine("=== Gêneros Musicais ===");
        foreach (var genero in generos)
        {
            Console.WriteLine($"Gênero: {genero}");
            var musicasDoGenero = musicas.Where(m => m.Genero == genero);
        }
    }
}
