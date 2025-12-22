using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Musicas.Core.Models;
using WebApiMusicas.DTOs;

namespace WebApiMusicas.Services
{
    public class MusicasServices
    {
        private readonly HttpClient _httpClient;
        private List<Musica>? _musicas;

        public MusicasServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Musica>> GetMusicasAsync()
        {
            if (_musicas == null)
            {
                var resposta = await _httpClient.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
                _musicas = JsonSerializer.Deserialize<List<Musica>>(resposta) ?? [];
            }
            return _musicas;
        }

        /// Mapeia Musica para MusicaDto
        private MusicaDto MapToDto(Musica musica)
        {
            return new MusicaDto
            {
                Nome = musica.Nome,
                Artista = musica.Artista,
                Duracao = musica.Duracao,
                Genero = musica.Genero,
                Tom = musica.Tom,
                Ano = musica.Ano,
                Popularidade = musica.Popularidade
            };
        }

        public async Task<List<MusicaDto>> GetMusicasDtoAsync()
        {
            var musicas = await GetMusicasAsync();
            return musicas.Select(MapToDto).ToList();
        }

        public async Task<List<string>> GetGenerosAsync()
        {
            var musicas = await GetMusicasAsync();
            return musicas
                .Select(m => m.Genero)
                .Distinct()
                .OrderBy(g => g)
                .ToList()!;
        }

        public async Task<List<string>> GetArtistasAsync()
        {
            var musicas = await GetMusicasAsync();
            return musicas
                .Select(m => m.Artista)
                .Distinct()
                .OrderBy(a => a)
                .ToList()!;
        }

        public async Task<List<string>> GetArtistasPorGeneroAsync(string genero)
        {
            var musicas = await GetMusicasAsync();
            return musicas
                .Where(m => m.Genero!.Equals(genero, StringComparison.OrdinalIgnoreCase))
                .Select(m => m.Artista)
                .Distinct()
                .OrderBy(a => a)
                .ToList()!;
        }

        public async Task<List<MusicaDto>> GetMusicasPorArtistaDtoAsync(string artista)
        {
            var musicas = await GetMusicasAsync();
            return musicas
                .Where(m => m.Artista!.Equals(artista, StringComparison.OrdinalIgnoreCase))
                .Select(MapToDto)
                .ToList();
        }

        public async Task<List<MusicaDto>> GetMusicasPorTomDtoAsync(string tom)
        {
            var musicas = await GetMusicasAsync();
            return musicas
                .Where(m => m.Tom!.Equals(tom, StringComparison.OrdinalIgnoreCase))
                .Select(MapToDto)
                .ToList();
        }
    }
}
