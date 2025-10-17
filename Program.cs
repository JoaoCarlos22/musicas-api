﻿using System.Text.Json;
using ApiMusicas.Filters;
using ApiMusicas.Models;

using HttpClient client = new();

try
{
    string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
    var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

    if (musicas == null || musicas.Count == 0)
    {
        Console.WriteLine("Nenhuma música carregada.");
        return;
    }

    while (true)
    {
        Console.Clear();
        Console.WriteLine("=== Menu de Filtros ===");
        Console.WriteLine("1 - Mostrar gêneros");
        Console.WriteLine("2 - Artistas em ordem");
        Console.WriteLine("3 - Artistas por gênero");
        Console.WriteLine("4 - Músicas por artista");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");

        var opc = Console.ReadLine()?.Trim();

        if (opc == "0")
            break;

        switch (opc)
        {
            case "1":
                Filter.GenerosFiltro(musicas);
                break;

            case "2":
                Order.ArtistasEmOrdem(musicas);
                break;

            case "3":
                Console.Write("Digite o gênero (ex: rock): ");
                var genero = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(genero))
                {
                    Console.WriteLine("Gênero inválido. Tente novamente");
                    break;
                }
                Filter.ArtistasPorGenero(musicas, genero.Trim());
                break;

            case "4":
                Console.Write("Digite o artista (ex: Red Hot Chili Peppers): ");
                var artista = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(artista))
                {
                    Console.WriteLine("Artista inválido. Tente novamente");
                    break;
                }
                Filter.MusicasPorArtista(musicas, artista.Trim());
                break;

            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }

        Console.WriteLine("\nPressione Enter para continuar...");
        Console.ReadLine();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
}