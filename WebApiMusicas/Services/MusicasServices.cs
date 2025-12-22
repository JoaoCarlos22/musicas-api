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
                _musicas = JsonSerializer.Deserialize<List<Musica>>(resposta) ?? new List<Musica>();
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

        // Helper de paginação
        private static List<T> Paginar<T>(IEnumerable<T> source, int page, int pageSize)
        {
            return source
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public async Task<(List<MusicaDto> items, int total)> GetMusicasDtoAsync(int page = 0, int pageSize = 10)
        {
            var musicas = await GetMusicasAsync();
            var musicasDto = musicas.Select(MapToDto).ToList();
            var paginados = Paginar(musicasDto, page, pageSize);
            return (paginados, musicasDto.Count);
        }

        public async Task<(List<string> items, int total)> GetGenerosAsync(int page = 0, int pageSize = 10)
        {
            var musicas = await GetMusicasAsync();
            var generos = musicas
                .Select(m => m.Genero)
                .Distinct()
                .OrderBy(g => g)
                .ToList()!;
            var paginados = Paginar(generos, page, pageSize);
            return (paginados, generos.Count);
        }

        public async Task<(List<string> items, int total)> GetArtistasAsync(int page = 0, int pageSize = 10)
        {
            var musicas = await GetMusicasAsync();
            var artistas = musicas
                .Select(m => m.Artista)
                .Distinct()
                .OrderBy(a => a)
                .ToList()!;
            var paginados = Paginar(artistas, page, pageSize);
            return (paginados, artistas.Count);
        }

        public async Task<(List<string> items, int total)> GetArtistasPorGeneroAsync(string genero, int page = 0, int pageSize = 10)
        {
            var musicas = await GetMusicasAsync();
            var artistas = musicas
                .Where(m => m.Genero!.Equals(genero, StringComparison.OrdinalIgnoreCase))
                .Select(m => m.Artista)
                .Distinct()
                .OrderBy(a => a)
                .ToList()!;
            var paginados = Paginar(artistas, page, pageSize);
            return (paginados, artistas.Count);
        }

        public async Task<(List<MusicaDto> items, int total)> GetMusicasPorArtistaDtoAsync(string artista, int page = 0, int pageSize = 10)
        {
            var musicas = await GetMusicasAsync();
            var filtradas = musicas
                .Where(m => m.Artista!.Equals(artista, StringComparison.OrdinalIgnoreCase))
                .Select(MapToDto)
                .ToList();
            var paginados = Paginar(filtradas, page, pageSize);
            return (paginados, filtradas.Count);
        }

        public async Task<(List<MusicaDto> items, int total)> GetMusicasPorTomDtoAsync(string tom, int page = 0, int pageSize = 10)
        {
            var musicas = await GetMusicasAsync();
            var filtradas = musicas
                .Where(m => m.Tom!.Equals(tom, StringComparison.OrdinalIgnoreCase))
                .Select(MapToDto)
                .ToList();
            var paginados = Paginar(filtradas, page, pageSize);
            return (paginados, filtradas.Count);
        }
    }
}
