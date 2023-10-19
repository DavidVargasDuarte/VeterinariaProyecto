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

public class TratamientosMedicController : BaseApiController
{
    private readonly IUnitOfwork unitOfWork;
    private readonly IMapper mapper;

    public TratamientosMedicController(IUnitOfwork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TratamientoMedicoDto>>> Get()
    {
        var datos = await unitOfWork.TratamientoMedic.GetAllAsync();
        return mapper.Map<List<TratamientoMedicoDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TratamientoMedicoDto>> Get(int id)
    {
        var data = await unitOfWork.TratamientoMedic.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TratamientoMedicoDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TratamientoMedicoDto>> Post(TratamientoMedicoDto tratamientoMedicoDto)
    {
        var data= this.mapper.Map<TratamientosMedicos>(tratamientoMedicoDto);
        this.unitOfWork.TratamientoMedic.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        tratamientoMedicoDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = tratamientoMedicoDto.Id }, tratamientoMedicoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TratamientoMedicoDto>> Put(int id, [FromBody] TratamientoMedicoDto tratamientoMedicoDto)
    {
        if (tratamientoMedicoDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<TratamientosMedicos>(tratamientoMedicoDto);
        unitOfWork.TratamientoMedic.Update(data);
        await unitOfWork.SaveAsync();
        return tratamientoMedicoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
       var data = await unitOfWork.TratamientoMedic.GetByIdAsync(id);
       if(data == null)
       {
          return NotFound();
       }
       unitOfWork.TratamientoMedic.Remove(data);
       await unitOfWork.SaveAsync();
       return NoContent();
    }
}