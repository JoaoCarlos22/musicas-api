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

    private static bool InvalidPage(int page) => page < 0;
    private static bool InvalidPageSize(int pageSize) => pageSize <= 0;

    /// <summary>
    /// Retorna todas as músicas
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<MusicasResponseDto>> GetTodasMusicas([FromQuery] int page = 0, [FromQuery] int pageSize = 10)
    {
        if (InvalidPage(page) || InvalidPageSize(pageSize))
            return BadRequest("Parâmetros de paginação inválidos. 'page' deve ser >= 0 e 'pageSize' >= 1.");

        var (items, total) = await _musicasServices.GetMusicasDtoAsync(page, pageSize);
        return Ok(new MusicasResponseDto
        {
            Total = total,
            Items = items
        });
    }

    /// <summary>
    /// Retorna todos os gêneros musicais disponíveis
    /// </summary>
    [HttpGet("generos")]
    public async Task<ActionResult<StringResponseDto>> GetGeneros([FromQuery] int page = 0, [FromQuery] int pageSize = 10)
    {
        if (InvalidPage(page) || InvalidPageSize(pageSize))
            return BadRequest("Parâmetros de paginação inválidos. 'page' deve ser >= 0 e 'pageSize' >= 1.");

        var (items, total) = await _musicasServices.GetGenerosAsync(page, pageSize);
        return Ok(new StringResponseDto
        {
            Total = total,
            Items = items
        });
    }

    /// <summary>
    /// Retorna todos os artistas em ordem alfabética
    /// </summary>
    [HttpGet("artistas")]
    public async Task<ActionResult<StringResponseDto>> GetArtistas([FromQuery] int page = 0, [FromQuery] int pageSize = 10)
    {
        if (InvalidPage(page) || InvalidPageSize(pageSize))
            return BadRequest("Parâmetros de paginação inválidos. 'page' deve ser >= 0 e 'pageSize' >= 1.");

        var (items, total) = await _musicasServices.GetArtistasAsync(page, pageSize);
        return Ok(new StringResponseDto
        {
            Total = total,
            Items = items
        });
    }

    /// <summary>
    /// Retorna artistas filtrados por gênero
    /// </summary>
    /// <param name="genero">Nome do gênero (ex: rock)</param>
    [HttpGet("artistas/genero/{genero}")]
    public async Task<ActionResult<StringResponseDto>> GetArtistasPorGenero(string genero, [FromQuery] int page = 0, [FromQuery] int pageSize = 10)
    {
        if (string.IsNullOrWhiteSpace(genero))
            return BadRequest("Gênero não pode ser vazio");
        if (InvalidPage(page) || InvalidPageSize(pageSize))
            return BadRequest("Parâmetros de paginação inválidos. 'page' deve ser >= 0 e 'pageSize' >= 1.");

        var (items, total) = await _musicasServices.GetArtistasPorGeneroAsync(genero, page, pageSize);

        if (total == 0)
            return NotFound(new StringResponseDto { Total = 0, Items = [] });

        return Ok(new StringResponseDto
        {
            Total = total,
            Items = items
        });
    }

    /// <summary>
    /// Retorna músicas filtradas por artista
    /// </summary>
    /// <param name="artista">Nome do artista</param>
    [HttpGet("artista/{artista}")]
    public async Task<ActionResult<MusicasResponseDto>> GetMusicasPorArtista(string artista, [FromQuery] int page = 0, [FromQuery] int pageSize = 10)
    {
        if (string.IsNullOrWhiteSpace(artista))
            return BadRequest("Artista não pode ser vazio");
        if (InvalidPage(page) || InvalidPageSize(pageSize))
            return BadRequest("Parâmetros de paginação inválidos. 'page' deve ser >= 0 e 'pageSize' >= 1.");

        var (items, total) = await _musicasServices.GetMusicasPorArtistaDtoAsync(artista, page, pageSize);

        if (total == 0)
            return NotFound(new MusicasResponseDto { Total = 0, Items = [] });

        return Ok(new MusicasResponseDto
        {
            Total = total,
            Items = items
        });
    }

    /// <summary>
    /// Retorna músicas filtradas por tom
    /// </summary>
    /// <param name="tom">Tom musical (ex: C, D, E)</param>
    [HttpGet("tom/{tom}")]
    public async Task<ActionResult<MusicasResponseDto>> GetMusicasPorTom(string tom, [FromQuery] int page = 0, [FromQuery] int pageSize = 10)
    {
        if (string.IsNullOrWhiteSpace(tom))
            return BadRequest("Tom não pode ser vazio");
        if (InvalidPage(page) || InvalidPageSize(pageSize))
            return BadRequest("Parâmetros de paginação inválidos. 'page' deve ser >= 0 e 'pageSize' >= 1.");

        var (items, total) = await _musicasServices.GetMusicasPorTomDtoAsync(tom, page, pageSize);

        if (total == 0)
            return NotFound(new MusicasResponseDto { Total = 0, Items = [] });

        return Ok(new MusicasResponseDto
        {
            Total = total,
            Items = items
        });
    }
}
