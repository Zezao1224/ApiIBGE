using ApiIBGE.Data;
using ApiIBGE.Models;
using ApiIBGE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiIBGE.Controllers;
[ApiController]
[Route(template: "v1")]
[Authorize]
public class IBGEController : ControllerBase
{

    private AppDbContext _context;

    public IBGEController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route(template: "ibge")]
    public async Task<IActionResult> GetAsync()
    {
        var ibge = await _context.ibge.AsNoTracking().ToListAsync();
        return Ok(ibge);
    }

    [HttpGet]
    [Route(template: "ibge/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var ibge = await _context.ibge.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return ibge == null ? NotFound() : Ok(ibge);
    }

    [HttpPost]
    [Route(template: "ibge")]
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

    [HttpPut]
    [Route(template: "ibge/{id}")]
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

    [HttpDelete]
    [Route(template: "ibge/{id}")]
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