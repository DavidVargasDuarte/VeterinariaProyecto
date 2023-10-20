using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class PropietarioController : BaseApiController
{
   private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public PropietarioController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet("GoldenRetriever")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> GoldenRetriever()
    {
        var mascotas = await unitOfWork.Propietarios.GoldenRetriever();
        var golderRetriever = mapper.Map<IEnumerable<object>>(mascotas);
        return Ok(golderRetriever);
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PropietarioDto>>> Get()
    {
        var datos = await unitOfWork.Propietarios.GetAllAsync();
        return mapper.Map<List<PropietarioDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PropietarioDto>> Get(int id)
    {
        var data = await unitOfWork.Propietarios.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<PropietarioDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PropietarioDto>> Post(PropietarioDto propietarioDto)
    {
        var data = this.mapper.Map<Propietario>(propietarioDto);
        this.unitOfWork.Propietarios.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        propietarioDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = propietarioDto.Id }, propietarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PropietarioDto>> Put(int id, [FromBody] PropietarioDto propietarioDto)
    {
        if (propietarioDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Propietario>(propietarioDto);
        unitOfWork.Propietarios.Update(data);
        await unitOfWork.SaveAsync();
        return propietarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Propietarios.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Propietarios.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }     
}
