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

public class MascotaController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public MascotaController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet("EspecieFelina")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Mascotas>>> EspecieFelina()
    {
        var felinos = await unitOfWork.Mascotas.EspecieFelina();
        return Ok(felinos);
    }

    [HttpGet("MascotasVacunadas2023")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> MascotasVacunadas2023()
    {
        var mascotasVacunadas = await unitOfWork.Mascotas.MascotasVacunadas2023();
        return mapper.Map<List<MascotaDto>>(mascotasVacunadas);
    }

    [HttpGet("MascotaEspecie")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> MascotaEspecie()
    {
        var mascota = await unitOfWork.Mascotas.MascotaEspecie();
        var especie = mapper.Map<IEnumerable<object>>(mascota);
        return Ok(especie);
    }

    [HttpGet("MascotaXVeterinario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> MascotaXVeterinario()
    {
        var mascotas = await unitOfWork.Mascotas.MascotaXVeterinario();
        var vacunadas = mapper.Map<IEnumerable<object>>(mascotas);
        return Ok(vacunadas);
    }

    [HttpGet("RazasCantidadMascotas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> RazasCantidadMascotas()
    {
        var mascotasRazas = await unitOfWork.Mascotas.RazasCantidadMascotas();
        var cantidad = mapper.Map<IEnumerable<object>>(mascotasRazas);
        return Ok(cantidad);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> Get()
    {
        var datos = await unitOfWork.Mascotas.GetAllAsync();
        return mapper.Map<List<MascotaDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MascotaDto>> Get(int id)
    {
        var data = await unitOfWork.Mascotas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<MascotaDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MascotaDto>> Post(MascotaDto mascotaDto)
    {
        var data = this.mapper.Map<Mascotas>(mascotaDto);
        this.unitOfWork.Mascotas.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        mascotaDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = mascotaDto.Id }, mascotaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MascotaDto>> Put(int id, [FromBody] MascotaDto mascotaDto)
    {
        if (mascotaDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Mascotas>(mascotaDto);
        unitOfWork.Mascotas.Update(data);
        await unitOfWork.SaveAsync();
        return mascotaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Mascotas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Mascotas.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}