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

    /// <summary>
    /// Retorna todas as músicas
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<MusicasResponseDto>> GetTodasMusicas()
    {
        var musicas = await _musicasServices.GetMusicasDtoAsync();
        return Ok(new MusicasResponseDto
        {
            Total = musicas.Count,
            Items = musicas
        });
    }

    /// <summary>
    /// Retorna todos os gêneros musicais disponíveis
    /// </summary>
    [HttpGet("generos")]
    public async Task<ActionResult<StringResponseDto>> GetGeneros()
    {
        var generos = await _musicasServices.GetGenerosAsync();
        return Ok(new StringResponseDto
        {
            Total = generos.Count,
            Items = generos
        });
    }

    /// <summary>
    /// Retorna todos os artistas em ordem alfabética
    /// </summary>
    [HttpGet("artistas")]
    public async Task<ActionResult<StringResponseDto>> GetArtistas()
    {
        var artistas = await _musicasServices.GetArtistasAsync();
        return Ok(new StringResponseDto
        {
            Total = artistas.Count,
            Items = artistas
        });
    }

    /// <summary>
    /// Retorna artistas filtrados por gênero
    /// </summary>
    /// <param name="genero">Nome do gênero (ex: rock)</param>
    [HttpGet("artistas/genero/{genero}")]
    public async Task<ActionResult<StringResponseDto>> GetArtistasPorGenero(string genero)
    {
        if (string.IsNullOrWhiteSpace(genero))
            return BadRequest("Gênero não pode ser vazio");

        var artistas = await _musicasServices.GetArtistasPorGeneroAsync(genero);
        
        if (artistas.Count == 0)
            return NotFound(new StringResponseDto
            {
                Total = 0,
                Items = new List<string>()
            });

        return Ok(new StringResponseDto
        {
            Total = artistas.Count,
            Items = artistas
        });
    }

    /// <summary>
    /// Retorna músicas filtradas por artista
    /// </summary>
    /// <param name="artista">Nome do artista</param>
    [HttpGet("artista/{artista}")]
    public async Task<ActionResult<MusicasResponseDto>> GetMusicasPorArtista(string artista)
    {
        if (string.IsNullOrWhiteSpace(artista))
            return BadRequest("Artista não pode ser vazio");

        var musicas = await _musicasServices.GetMusicasPorArtistaDtoAsync(artista);
        
        if (musicas.Count == 0)
            return NotFound(new MusicasResponseDto
            {
                Total = 0,
                Items = new List<MusicaDto>()
            });

        return Ok(new MusicasResponseDto
        {
            Total = musicas.Count,
            Items = musicas
        });
    }

    /// <summary>
    /// Retorna músicas filtradas por tom
    /// </summary>
    /// <param name="tom">Tom musical (ex: C, D, E)</param>
    [HttpGet("tom/{tom}")]
    public async Task<ActionResult<MusicasResponseDto>> GetMusicasPorTom(string tom)
    {
        if (string.IsNullOrWhiteSpace(tom))
            return BadRequest("Tom não pode ser vazio");

        var musicas = await _musicasServices.GetMusicasPorTomDtoAsync(tom);
        
        if (musicas.Count == 0)
            return NotFound(new MusicasResponseDto
            {
                Total = 0,
                Items = new List<MusicaDto>()
            });

        return Ok(new MusicasResponseDto
        {
            Total = musicas.Count,
            Items = musicas
        });
    }
}
