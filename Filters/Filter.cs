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

    public static void MusicasPorArtista(List<Musica> musicas, string artista)
    {
        var musicasDoArtista = musicas
            .Where(m => m.Artista!.Equals(artista))
            .ToList();

        if (musicasDoArtista.Count == 0)
        {
            Console.WriteLine("Nenhuma música encontrada para este artista.");
            return;
        }
        Console.WriteLine($"Músicas do artista '{artista}':");
        foreach (var musica in musicasDoArtista)
        {
            Console.WriteLine($"- {musica.Nome} ({musica.Genero})");
        }
    }

    public static void MusicasPorTom(List<Musica> musicas, string tom)
    {
        var musicasDoTom = musicas
            .Where(m => m.Tom!.Equals(tom))
            .ToList();

        if (musicasDoTom.Count == 0)
        {
            Console.WriteLine("Nenhuma música encontrada para este tom.");
        }
        Console.WriteLine($"Músicas no tom '{tom}':");
        foreach (var musica in musicasDoTom)
        {
            Console.WriteLine($"- {musica.Nome} ({musica.Genero})");
        }
    }
}
