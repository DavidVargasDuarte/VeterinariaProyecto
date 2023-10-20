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

public class RazaController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public RazaController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RazaDto>>> Get()
    {
        var datos = await unitOfWork.Razas.GetAllAsync();
        return mapper.Map<List<RazaDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RazaDto>> Get(int id)
    {
        var data = await unitOfWork.Razas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<RazaDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<RazaDto>> Post(RazaDto razaDto)
    {
        var data = this.mapper.Map<Razas>(razaDto);
        this.unitOfWork.Razas.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        razaDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = razaDto.Id }, razaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<RazaDto>> Put(int id, [FromBody] RazaDto razaDto)
    {
        if (razaDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Razas>(razaDto);
        unitOfWork.Razas.Update(data);
        await unitOfWork.SaveAsync();
        return razaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Razas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Razas.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }    
}
