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

public class RolController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public RolController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RolesDto>>> Get()
    {
        var datos = await unitOfWork.Roles.GetAllAsync();
        return mapper.Map<List<RolesDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RolesDto>> Get(int id)
    {
        var data = await unitOfWork.Roles.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<RolesDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<RolesDto>> Post(RolesDto rolesDto)
    {
        var data = this.mapper.Map<Roles>(rolesDto);
        this.unitOfWork.Roles.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        rolesDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = rolesDto.Id }, rolesDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<RolesDto>> Put(int id, [FromBody] RolesDto rolesDto)
    {
        if (rolesDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Roles>(rolesDto);
        unitOfWork.Roles.Update(data);
        await unitOfWork.SaveAsync();
        return rolesDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Roles.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Roles.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }   
}
