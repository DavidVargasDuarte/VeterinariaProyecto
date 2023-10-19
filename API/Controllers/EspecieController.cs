using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Dominio;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class EspecieController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public EspecieController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EspecieDto>>> Get()
    {
        var datos = await unitOfWork.Especie.GetAllAsync();
        return mapper.Map<List<EspecieDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EspecieDto>> Get(int id)
    {
        var data = await unitOfWork.Especie.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<EspecieDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<EspecieDto>> Post(EspecieDto especieDto)
    {
        var data = this.mapper.Map<Especies>(especieDto);
        this.unitOfWork.Especie.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        especieDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = especieDto.Id }, especieDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EspecieDto>> Put(int id, [FromBody] EspecieDto especieDto)
    {
        if (especieDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Especies>(especieDto);
        unitOfWork.Especie.Update(data);
        await unitOfWork.SaveAsync();
        return especieDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Especie.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Especie.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }    
}
