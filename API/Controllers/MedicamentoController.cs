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

public class MedicamentoController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public MedicamentoController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet("MedicamentosGenfar")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> MedicamentosGenfar()
    {
        var medicamentosGenfar = await unitOfWork.Medicamentos.MedicamentosGenfar();
        return mapper.Map<List<MedicamentoDto>>(medicamentosGenfar);
    }

    [HttpGet("PrecioMayorA50000")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> PrecioMayorA50000()
    {
        var precioMayorA50 = await unitOfWork.Medicamentos.PrecioMayorA50000();
        return mapper.Map<List<MedicamentoDto>>(precioMayorA50);
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoDto>>> Get()
    {
        var datos = await unitOfWork.Medicamentos.GetAllAsync();
        return mapper.Map<List<MedicamentoDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicamentoDto>> Get(int id)
    {
        var data = await unitOfWork.Medicamentos.GetByIdAsync(id);
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
        this.unitOfWork.Medicamentos.Add(data);
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
        unitOfWork.Medicamentos.Update(data);
        await unitOfWork.SaveAsync();
        return medicamentoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Medicamentos.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Medicamentos.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}

