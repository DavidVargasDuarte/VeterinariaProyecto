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

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class UsuarioController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public UsuarioController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
    {
        var datos = await unitOfWork.Usuarios.GetAllAsync();
        return mapper.Map<List<UsuarioDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UsuarioDto>> Get(int id)
    {
        var data = await unitOfWork.Usuarios.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return mapper.Map<UsuarioDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<UsuarioDto>> Post(UsuarioDto usuarioDto)
    {
        var data = mapper.Map<Usuarios>(usuarioDto);
        unitOfWork.Usuarios.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        usuarioDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = usuarioDto.Id }, usuarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<UsuarioDto>> Put(int id, [FromBody] UsuarioDto usuarioDto)
    {
        if (usuarioDto == null)
        {
            return NotFound();
        }
        var data = mapper.Map<Usuarios>(usuarioDto);
        unitOfWork.Usuarios.Update(data);
        await unitOfWork.SaveAsync();
        return usuarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Usuarios.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Usuarios.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}