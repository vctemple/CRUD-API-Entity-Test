using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Teste.Context;
using API_Teste.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Teste.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext Context)
        {
            _context = Context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }

        [HttpGet("{id}")]
        public IActionResult VisualizarContatoPorId(int id)
        {
            var contato = _context.Contatos.Find(id);
            if(contato == null)
                return NotFound();
            
            return Ok(contato);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarContatoPorId(int id, Contato contatoAtualizado)
        {
            var contatoBanco = _context.Contatos.Find(id);
            if(contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contatoAtualizado.Nome;
            contatoBanco.Telefone = contatoAtualizado.Telefone;
            contatoBanco.Email = contatoAtualizado.Email;
            contatoBanco.Ativo = contatoAtualizado.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarContatoPorId(int id)
        {
            var contatoBanco = _context.Contatos.Find(id);
            if(contatoBanco == null)
                return NotFound();

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}