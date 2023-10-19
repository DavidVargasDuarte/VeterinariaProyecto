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

public class MovimientoMedicController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public MovimientoMedicController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MovimientoMedicDto>>> Get()
    {
        var datos = await unitOfWork.MovimientoMedic.GetAllAsync();
        return mapper.Map<List<MovimientoMedicDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoMedicDto>> Get(int id)
    {
        var data = await unitOfWork.MovimientoMedic.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<MovimientoMedicDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MovimientoMedicDto>> Post(MovimientoMedicDto movimientoMedicDto)
    {
        var data = this.mapper.Map<MovimientoMedic>(movimientoMedicDto);
        this.unitOfWork.MovimientoMedic.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        movimientoMedicDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = movimientoMedicDto.Id }, movimientoMedicDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MovimientoMedicDto>> Put(int id, [FromBody] MovimientoMedicDto movimientoMedicDto)
    {
        if (movimientoMedicDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<MovimientoMedic>(movimientoMedicDto);
        unitOfWork.MovimientoMedic.Update(data);
        await unitOfWork.SaveAsync();
        return movimientoMedicDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.MovimientoMedic.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.MovimientoMedic.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }   
}
