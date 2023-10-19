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

public class TipoMovimientoController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public TipoMovimientoController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoMovimientoDto>>> Get()
    {
        var datos = await unitOfWork.TipoMovimiento.GetAllAsync();
        return mapper.Map<List<TipoMovimientoDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoMovimientoDto>> Get(int id)
    {
        var data = await unitOfWork.TipoMovimiento.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TipoMovimientoDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoMovimientoDto>> Post(TipoMovimientoDto tipoMovimientoDto)
    {
        var data = this.mapper.Map<TipoMovimineto>(tipoMovimientoDto);
        this.unitOfWork.TipoMovimiento.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        tipoMovimientoDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoMovimientoDto.Id }, tipoMovimientoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TipoMovimientoDto>> Put(int id, [FromBody] TipoMovimientoDto tipoMovimientoDto)
    {
        if (tipoMovimientoDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<TipoMovimineto>(tipoMovimientoDto);
        unitOfWork.TipoMovimiento.Update(data);
        await unitOfWork.SaveAsync();
        return tipoMovimientoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.TipoMovimiento.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.TipoMovimiento.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}