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

public class MedicamentoController : BaseApiController
{
   private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public MedicamentoController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> Get()
    {
        var datos = await unitOfWork.Medicamento.GetAllAsync();
        return mapper.Map<List<MedicamentoDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicamentoDto>> Get(int id)
    {
        var data = await unitOfWork.Medicamento.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<MedicamentoDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MedicamentoDto>> Post(MedicamentoDto medicamentoDto)
    {
        var data = this.mapper.Map<Medicamento>(medicamentoDto);
        this.unitOfWork.Medicamento.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        medicamentoDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = medicamentoDto.Id }, medicamentoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MedicamentoDto>> Put(int id, [FromBody] MedicamentoDto medicamentoDto)
    {
        if (medicamentoDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Medicamento>(medicamentoDto);
        unitOfWork.Medicamento.Update(data);
        await unitOfWork.SaveAsync();
        return medicamentoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Medicamento.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Medicamento.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }    
}

