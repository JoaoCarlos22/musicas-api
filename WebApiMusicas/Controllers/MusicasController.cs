using Microsoft.AspNetCore.Mvc;
using Musicas.Core.Models;
using WebApiMusicas.Services;
using WebApiMusicas.DTOs;

namespace WebApiMusicas.Controllers;

[ApiController]
[Route("api/musicas/")]
public class MusicasController : ControllerBase
{
    private readonly MusicasServices _musicasServices;

    public MusicasController(MusicasServices musicasServices)
    {
        _musicasServices = musicasServices;
    }

    /// Retorna todas as músicas
    [HttpGet]
    public async Task<ActionResult<List<MusicaDto>>> GetTodasMusicas()
    {
        var musicas = await _musicasServices.GetMusicasDtoAsync();
        return Ok(musicas);
    }

    /// Retorna todos os gêneros musicais disponíveis
    [HttpGet("generos")]
    public async Task<ActionResult<List<string>>> GetGeneros()
    {
        var generos = await _musicasServices.GetGenerosAsync();
        return Ok(generos);
    }

    /// Retorna todos os artistas em ordem alfabética
    [HttpGet("artistas")]
    public async Task<ActionResult<List<string>>> GetArtistas()
    {
        var artistas = await _musicasServices.GetArtistasAsync();
        return Ok(artistas);
    }

    /// Retorna artistas filtrados por gênero
    /// <param name="genero">Nome do gênero (ex: rock)</param>
    [HttpGet("artistas/genero/{genero}")]
    public async Task<ActionResult<List<string>>> GetArtistasPorGenero(string genero)
    {
        if (string.IsNullOrWhiteSpace(genero))
            return BadRequest("Gênero não pode ser vazio");

        var artistas = await _musicasServices.GetArtistasPorGeneroAsync(genero);
        
        if (artistas.Count == 0)
            return NotFound($"Nenhum artista encontrado para o gênero '{genero}'");

        return Ok(artistas);
    }

    /// Retorna músicas filtradas por artista
    /// <param name="artista">Nome do artista</param>
    [HttpGet("artista/{artista}")]
    public async Task<ActionResult<List<MusicaDto>>> GetMusicasPorArtista(string artista)
    {
        if (string.IsNullOrWhiteSpace(artista))
            return BadRequest("Artista não pode ser vazio");

        var musicas = await _musicasServices.GetMusicasPorArtistaDtoAsync(artista);
        
        if (musicas.Count == 0)
            return NotFound($"Nenhuma música encontrada para o artista '{artista}'");

        return Ok(musicas);
    }

    /// Retorna músicas filtradas por tom
    /// <param name="tom">Tom musical (ex: C, D, E)</param>
    [HttpGet("tom/{tom}")]
    public async Task<ActionResult<List<MusicaDto>>> GetMusicasPorTom(string tom)
    {
        if (string.IsNullOrWhiteSpace(tom))
            return BadRequest("Tom não pode ser vazio");

        var musicas = await _musicasServices.GetMusicasPorTomDtoAsync(tom);
        
        if (musicas.Count == 0)
            return NotFound($"Nenhuma música encontrada para o tom '{tom}'");

        return Ok(musicas);
    }
}
