using ExercicioApiEcommerce.DTOs;
using ExercicioApiEcommerce.Entidades;
using ExercicioApiEcommerce.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ExercicioApiEcommerce.Controllers
{
    [ApiController, Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteDTO clienteDTO)
        {
            clienteDTO.Validar();

            if (!clienteDTO.Valido)
                return BadRequest("Cliente informado inválido!");

            var gui = Guid.NewGuid();
            var cli = new Cliente(nome: clienteDTO.Nome, sobrenome: clienteDTO.Sobrenome, documento: clienteDTO.Documento, idade: clienteDTO.Idade, tipoPessoa: clienteDTO.TipoPessoa);

            return Created("", _clienteService.Cadastrar(cli));
        }


        [HttpGet, Route("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_clienteService.Get(id));

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_clienteService.Get());

        }

        [HttpPut, Route("{id}")]
        public IActionResult Atualizar(Guid id, ClienteDTO clienteDTO)
        {
            clienteDTO.Validar();

            if (!clienteDTO.Valido)
                return BadRequest("Cliente informado inválido!");

            var prod = new Cliente(nome: clienteDTO.Nome, sobrenome: clienteDTO.Sobrenome, documento: clienteDTO.Documento, idade: clienteDTO.Idade, tipoPessoa: clienteDTO.TipoPessoa);

            return Created("Cliente alterado com sucesso!", _clienteService.Atualizar(id, prod));

        }

        [HttpDelete, Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            if(!_clienteService.Delete(id))
                return BadRequest("Não foi possível deletar o usuário!");

            return Ok("Cliente deletado com sucesso.");

        }


    }
}
