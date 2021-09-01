using AutoMapper;
using CadastroClienteWebService.Api.Models;
using CadastroClienteWebService.Domain.Entidades;
using CadastroClienteWebService.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroClienteWebService.Api.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICadastroClienteUseCase _cadastroClienteUseCase;

        public ClienteController(IMapper mapper, ICadastroClienteUseCase cadastroClienteUseCase)
        {
            _mapper = mapper;
            _cadastroClienteUseCase = cadastroClienteUseCase;
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] ClienteRequest request)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(request);

                var clienteResponse = _mapper.Map<ClienteResponse>(_cadastroClienteUseCase.Inserir(cliente));

                return Ok(clienteResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Atualizar([FromBody] ClienteRequest request)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(request);

                var clienteResponse = _mapper.Map<ClienteResponse>(_cadastroClienteUseCase.Atualizar(cliente));

                return Ok(clienteResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Deletar([FromBody] ClienteRequest request)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(request);

                _cadastroClienteUseCase.Deletar(cliente);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObterPorId/{id:int}")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var clienteResponse = _mapper.Map<ClienteResponse>(_cadastroClienteUseCase.ObterPorId(id));

                return Ok(clienteResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                var clientesResponse = _mapper.Map<IEnumerable<ClienteResponse>>(_cadastroClienteUseCase.ObterTodos());

                return Ok(clientesResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
