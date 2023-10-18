using ApiIBGE.Data;
using ApiIBGE.Models;
using ApiIBGE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiIBGE.Controllers;
[ApiController]
[Route(template: "v1")]
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
    public async Task<IActionResult> GetByIdAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {
        var ibge = await context.ibge.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        return ibge == null ? NotFound() : Ok(ibge);
    }

    [HttpPost]
    [Route(template: "ibge")]
    public async Task<IActionResult> PostAsync([FromServices] AppDbContext context, [FromBody] CreateIbgeViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var ibge = new Ibge
        {
            State = model.State
        };

        try
        {
            await context.ibge.AddAsync(ibge);
            await context.SaveChangesAsync();
            return Created(uri: $"v1/ibge/{ibge.Id}", ibge);
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }

    [HttpPut]
    [Route(template: "ibge/{id}")]

    public async Task<IActionResult> PutAsync([FromServices] AppDbContext context, [FromBody] CreateIbgeViewModel model, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var ibge = await context.ibge.FirstOrDefaultAsync(x => x.Id == id);

        if (ibge == null)
            return NotFound();

        try
        {
            ibge.State = model.State;

            context.ibge.Update(ibge);
            await context.SaveChangesAsync();

            return Ok(ibge);
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }

    [HttpDelete]
    [Route(template: "ibge/{id}")]
    public async Task<IActionResult> DeleteAsync([FromServices] AppDbContext context, [FromRoute] int id)
    {
        var ibge = await context.ibge.FirstOrDefaultAsync(x => x.Id == id);

        try
        {
            context.ibge.Remove(ibge);
            await context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }
}