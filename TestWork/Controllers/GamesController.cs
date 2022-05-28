using Microsoft.AspNetCore.Mvc;
using TestWork.Data;
using TestWork.Model;
using TestWork.Model.Repository;

namespace TestWork.Controllers;

[ApiController]
[Route("[controller]")]

public class GamesController : Controller
{
    private readonly GameManager _gameManager;
    private readonly GenreManager _genreManager;

    public GamesController(GameManager gameManager, GenreManager genreManager)
    {
        _gameManager = gameManager;
        _genreManager = genreManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Game game)
    {
        
        var result = await _gameManager.AddAsync(game);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> ReadAsync([FromQuery] int idGame)
    {
        var result = await _gameManager.ReadAsync(idGame);
        return Ok(result);
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> ReadAllAsync()
    {
        var result = await _gameManager.ReadAllAsync();
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] Game game)
    {
        var result = await _gameManager.UpdateAsync(game);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery] int idGame)
    {
        var result = await _gameManager.DeleteAsync(idGame);
        return Ok(result);
    }
    
    [HttpGet("genre")]
    public async Task<IActionResult> GetGamesByGenreAsync([FromQuery] int genreId)
    {
        var result = await _genreManager.GetGameByGenreAsync(genreId);
        return Ok(result);
    }
}