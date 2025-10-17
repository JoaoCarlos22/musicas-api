using ApiMusicas.Models;

namespace ApiMusicas.Filters;

internal class Order
{
    public static void ArtistasEmOrdem(List<Musica> musicas)
    {
        var artistasOrdenados = musicas
            .Select(m => m.Artista)
            .Distinct()
            .OrderBy(artista => artista)
            .ToList();
        Console.WriteLine("Artistas em ordem alfabética:");
        foreach (var artista in artistasOrdenados)
        {
            Console.WriteLine(artista);
        }
    }
}
