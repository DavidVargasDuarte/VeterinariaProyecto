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

public class DetalleMovimientoController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public DetalleMovimientoController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetallemovimientoDto>>> Get()
    {
        var datos = await unitOfWork.DetalleMovimientos.GetAllAsync();
        return mapper.Map<List<DetallemovimientoDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetallemovimientoDto>> Get(int id)
    {
        var data = await unitOfWork.DetalleMovimientos.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<DetallemovimientoDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DetallemovimientoDto>> Post(DetallemovimientoDto detallemovimientoDto)
    {
        var data = this.mapper.Map<DetalleMovimiento>(detallemovimientoDto);
        this.unitOfWork.DetalleMovimientos.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        detallemovimientoDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = detallemovimientoDto.Id }, detallemovimientoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DetallemovimientoDto>> Put(int id, [FromBody] DetallemovimientoDto detallemovimientoDto)
    {
        if (detallemovimientoDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<DetalleMovimiento>(detallemovimientoDto);
        unitOfWork.DetalleMovimientos.Update(data);
        await unitOfWork.SaveAsync();
        return detallemovimientoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.DetalleMovimientos.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.DetalleMovimientos.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}
