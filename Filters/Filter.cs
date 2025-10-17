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

    public static void ArtistasPorGenero(List<Musica> musicas, string genero)
    {
        var artistas = musicas
            .Where(m => m.Genero!.Equals(genero))
            .Select(m => m.Artista)
            .Distinct()
            .ToList();

        Console.WriteLine($"Artistas no gênero '{genero}':");
        if (artistas.Count == 0)
        {
            Console.WriteLine("Nenhum artista encontrado para este gênero.");
            return;
        }
        foreach (var artista in artistas)
        {
            Console.WriteLine(artista);
        }
    }
}
