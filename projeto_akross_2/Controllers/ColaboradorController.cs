using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using projeto_akross_2.Data;
using projeto_akross_2.Data.Dtos;
using projeto_akross_2.Models;

namespace projeto_akross_2.Controllers;

[ApiController]
[Route("[controller]")]
public class ColaboradorController : ControllerBase
{
    private AplicacaoContext _context;
    private IMapper _mapper;

    public ColaboradorController(AplicacaoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaColaborador([FromBody]CreateColaboradorDto colaboradorDto)
    {
        Colaborador colaborador = _mapper.Map<Colaborador>(colaboradorDto);

        _context.Colaboradores.Add(colaborador);
        _context.SaveChanges();

        return CreatedAtAction(nameof(RecuperaColaboradorPorId), new {id = colaborador.Id}, colaborador);
    }

    [HttpGet]
    public IEnumerable<ReadColaboradorDto> RecuperaColaboradores([FromQuery] int skip=0, [FromQuery] int take=10) 
    {
        return _mapper.Map<List<ReadColaboradorDto>>(_context.Colaboradores.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaColaboradorPorId(int id)
    {
        var colaborador = _context.Colaboradores.FirstOrDefault(colaborador => colaborador.Id == id);

        if (colaborador == null) return NotFound();

        var colaboradorDto = _mapper.Map<ReadColaboradorDto>(colaborador);
        return Ok(colaboradorDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaColaborador(int id, [FromBody] UpdateColaboradorDto colaboradorDto)
    {
        var colaborador = _context.Colaboradores.FirstOrDefault(colaborador => colaborador.Id.Equals(id));

        if (colaborador == null) return NotFound();

        _mapper.Map(colaboradorDto, colaborador);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaColaboradorParcial(int id, JsonPatchDocument<UpdateColaboradorDto> patch)
    {
        var colaborador = _context.Colaboradores.FirstOrDefault(colaborador => colaborador.Id.Equals(id));

        if (colaborador == null) return NotFound();

        var colaboradorParaAtualizar = _mapper.Map<UpdateColaboradorDto>(colaborador);
        patch.ApplyTo(colaboradorParaAtualizar, ModelState);

        if (!TryValidateModel(colaboradorParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(colaboradorParaAtualizar, colaborador);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaColaborador(int id)
    {
        var colaborador = _context.Colaboradores.FirstOrDefault(colaborador => colaborador.Id.Equals(id));

        if (colaborador == null) return NotFound();

        _context.Remove(colaborador);
        _context.SaveChanges();

        return NoContent();
    }

}
