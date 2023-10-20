using ApiIBGE.Data;
using ApiIBGE.Models;
using ApiIBGE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiIBGE.Controllers;

/// <summary>
/// Controlador IBGE para os métodos POST, GET, PUT e DELETE da classe IBGE
/// </summary>
[ApiController]
[Route(template: "v1/ibge/")]
[Authorize]
public class IBGEController : ControllerBase
{

    private AppDbContext _context;
    /// <summary>
    /// Controlador IBGE com o contexto de banco de dados
    /// </summary>
    /// <param name="context"></param>
    public IBGEController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GET para buscar uma localidade através do ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(template: "{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var ibge = await _context.ibge.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return ibge == null ? NotFound() : Ok(ibge);
    }

    /// <summary>
    /// GET para buscar uma localidade através do nome exato da cidade, considerando espaços e acentuações.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(template: "city")]
    public async Task<IActionResult> GetByCityAsync([FromBody] CityViewModel model)
    {
        var ibge = await _context.ibge.AsNoTracking().FirstOrDefaultAsync(x => x.City == model.City);
        return ibge == null ? NotFound() : Ok(ibge);
    }

    /// <summary>
    /// GET para buscar uma localidade através do UF diretamente pelo link do navegador.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpGet]
    [Route(template: "state")]
    public async Task<IActionResult> GetByStateAsync([FromBody] StateViewModel model)
    {
        var ibge = await _context.ibge.Where(x => x.State == model.State).ToListAsync<Ibge>();
        return ibge == null ? NotFound() : Ok(ibge);
    }

    /// <summary>
    /// POST para inserir uma nova localidade com os dados do IBGE.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> PostAsync( [FromBody] CreateIbgeViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        Ibge ibge = new Ibge
        {
            State = model.State,
            City= model.city,
            Id= model.id
        };

        try
        {
            await _context.ibge.AddAsync(ibge);
            await _context.SaveChangesAsync();
            return Created(uri: $"v1/ibge/{ibge.Id}", ibge);
        }
        catch (Exception)
        {
            return UnprocessableEntity();
        }

    }

    /// <summary>
    /// PUT para atualizar uma localidade existente com os dados do IBGE.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut]
    [Route(template: "{id}")]
    public async Task<IActionResult> PutAsync([FromBody] CreateIbgeViewModel model, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var ibge = await _context.ibge.FirstOrDefaultAsync(x => x.Id == id);

        if (ibge == null)
            return NotFound();

        try
        {
            ibge.State = model.State;
            ibge.City = model.city;

            _context.ibge.Update(ibge);
            await _context.SaveChangesAsync();

            return Ok(ibge);
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }

    /// <summary>
    /// DELETE para deletar uma localidade existente com os dados do IBGE.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route(template: "{id}")]
    public async Task<IActionResult> DeleteAsync( [FromRoute] int id)
    {
        var ibge = await _context.ibge.FirstOrDefaultAsync(x => x.Id == id);

        try
        {
            _context.ibge.Remove(ibge!);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }
}