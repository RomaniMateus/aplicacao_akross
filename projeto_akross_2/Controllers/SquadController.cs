using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_akross_2.Data;
using projeto_akross_2.Data.Dtos;
using projeto_akross_2.Models;

namespace projeto_akross_2.Controllers;

[ApiController]
[Route("[controller]")]
public class SquadController : ControllerBase
{
    private AplicacaoContext _context;
    private IMapper _mapper;

    public SquadController(AplicacaoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaSquad([FromBody] CreateSquadDto squadDto)
    {
        Squad squad = _mapper.Map<Squad>(squadDto);

        _context.Squads.Add(squad);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaSquadPorId), new { id = squad.Id }, squad);
    }

    [HttpGet]
    public IEnumerable<ReadSquadDto> RecuperaSquads([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadSquadDto>>(_context.Squads.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaSquadPorId(int id)
    {
        var squad = _context.Squads.FirstOrDefault(squad => squad.Id == id);

        if (squad == null) return NotFound();

        var squadDto = _mapper.Map<ReadSquadDto>(squad);
        return Ok(squadDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaSquad(int id, [FromBody] UpdateSquadDto squadDto)
    {
        var squad = _context.Squads.FirstOrDefault(squad => squad.Id.Equals(id));

        if (squad == null) return NotFound();

        _mapper.Map(squadDto, squad);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaSquadParcial(int id, JsonPatchDocument<UpdateSquadDto> patch)
    {
        var squad = _context.Squads.FirstOrDefault(squad => squad.Id.Equals(id));

        if (squad == null) return NotFound();

        var squadParaAtualizar = _mapper.Map<UpdateSquadDto>(squad);
        patch.ApplyTo(squadParaAtualizar, ModelState);

        if (!TryValidateModel(squadParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(squadParaAtualizar, squad);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaSquad(int id)
    {
        var squad = _context.Squads.FirstOrDefault(squad => squad.Id.Equals(id));

        if (squad == null) return NotFound();

        _context.Remove(squad);
        _context.SaveChanges();

        return NoContent();
    }
}
