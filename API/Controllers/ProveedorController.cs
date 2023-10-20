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

public class ProveedorController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public ProveedorController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet("ProveedorMedicamentos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> ProveedorMedicamentos()
    {
        var medicamento = await unitOfWork.Proveedors.ProveedorMedicamentos();
        var proveedor = mapper.Map<IEnumerable<object>>(medicamento);
        return Ok(proveedor);
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get()
    {
        var datos = await unitOfWork.Proveedors.GetAllAsync();
        return mapper.Map<List<ProveedorDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProveedorDto>> Get(int id)
    {
        var data = await unitOfWork.Proveedors.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<ProveedorDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ProveedorDto>> Post(ProveedorDto proveedorDto)
    {
        var data = this.mapper.Map<Proveedores>(proveedorDto);
        this.unitOfWork.Proveedors.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        proveedorDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = proveedorDto.Id }, proveedorDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProveedorDto>> Put(int id, [FromBody] ProveedorDto proveedorDto)
    {
        if (proveedorDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Proveedores>(proveedorDto);
        unitOfWork.Proveedors.Update(data);
        await unitOfWork.SaveAsync();
        return proveedorDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Proveedors.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Proveedors.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}
