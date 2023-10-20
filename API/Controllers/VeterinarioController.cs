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


public class VeterinarioController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public VeterinarioController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet("CirujanoVascular")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> CirujanoVascular()
    {
        var cirujanoVascular = await unitOfWork.Veterinarios.CirujanoVascular();
        return mapper.Map<List<VeterinarioDto>>(cirujanoVascular);
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VeterinarioDto>>> Get()
    {
        var datos = await unitOfWork.Veterinarios.GetAllAsync();
        return mapper.Map<List<VeterinarioDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VeterinarioDto>> Get(int id)
    {
        var data = await unitOfWork.Veterinarios.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<VeterinarioDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<VeterinarioDto>> Post(VeterinarioDto veterinarioDto)
    {
        var data = this.mapper.Map<Veterinario>(veterinarioDto);
        this.unitOfWork.Veterinarios.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        veterinarioDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = veterinarioDto.Id }, veterinarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<VeterinarioDto>> Put(int id, [FromBody] VeterinarioDto veterinarioDto)
    {
        if (veterinarioDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Veterinario>(veterinarioDto);
        unitOfWork.Veterinarios.Update(data);
        await unitOfWork.SaveAsync();
        return veterinarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Veterinarios.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Veterinarios.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}
