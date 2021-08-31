using AutoMapper;
using CadastroClienteWebService.Api.Models;
using CadastroClienteWebService.Domain.Entidades;
using CadastroClienteWebService.UseCase.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

                _cadastroClienteUseCase.Inserir(cliente);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
