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
  
public class LaboratorioController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public LaboratorioController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<LaboratorioDto>>> Get()
    {
        var datos = await unitOfWork.Laboratorios.GetAllAsync();
        return mapper.Map<List<LaboratorioDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LaboratorioDto>> Get(int id)
    {
        var data = await unitOfWork.Laboratorios.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<LaboratorioDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<LaboratorioDto>> Post(LaboratorioDto laboratorioDto)
    {
        var data = this.mapper.Map<Laboratorios>(laboratorioDto);
        this.unitOfWork.Laboratorios.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        laboratorioDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = laboratorioDto.Id }, laboratorioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<LaboratorioDto>> Put(int id, [FromBody] LaboratorioDto laboratorioDto)
    {
        if (laboratorioDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Laboratorios>(laboratorioDto);
        unitOfWork.Laboratorios.Update(data);
        await unitOfWork.SaveAsync();
        return laboratorioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Laboratorios.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Laboratorios.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }     
}
