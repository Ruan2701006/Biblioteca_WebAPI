using Biblioteca_WebApi_ruan.Model;
using Biblioteca_WebApi_ruan.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca_WebApi_ruan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmprestimoController : ControllerBase
    {
        private readonly EmprestimoR _emprestimoRepo;
        

        public EmprestimoController(EmprestimoR emprestimoRepo)
        {
            _emprestimoRepo = emprestimoRepo;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public ActionResult<List<Emprestimo>> GetAll()
        {

            {
                var emprestimos = _emprestimoRepo.GetAll();

                if (emprestimos == null || !emprestimos.Any())
                {
                    return NotFound(new { Mensagem = "Nenhum categoria encontrado." });
                }

                var listaCat = emprestimos.Select(emprestimo => new Emprestimo
                {
                    Id = emprestimo.Id,
                    FkLivros = emprestimo.FkLivros,
                    FkMenbros = emprestimo.FkMenbros,
                    DataEmprestimo = emprestimo.DataEmprestimo,
                    DataDevolucao = emprestimo.DataDevolucao

                }).ToList();

                return Ok(listaCat);
            }

        }

        // GET: api/Categoria/{id}
        [HttpGet("{id}")]
        public ActionResult<Emprestimo> GetById(int id)
        {

            {
                var emprestimo = _emprestimoRepo.GetById(id);

                if (emprestimo == null)
                {
                    return NotFound(new { Mensagem = "Emprestimo não encontrado." });
                }

                var emprestimoId = new Emprestimo
                {
                    Id = emprestimo.Id,
                    FkLivros = emprestimo.FkLivros,
                    FkMenbros = emprestimo.FkMenbros,
                    DataEmprestimo = emprestimo.DataEmprestimo,
                    DataDevolucao = emprestimo.DataDevolucao
                };

                return Ok(emprestimoId);
            }

        }

        // POST api/<CategoriaController>
        [HttpPost]
        public ActionResult<object> Post([FromForm] EmprestimoDto novoEmprestimo)
        {

            {
                var emprestimo = new Emprestimo
                {
                    FkLivros = novoEmprestimo.FkLivros,
                    FkMenbros = novoEmprestimo.FkMenbros,
                    DataEmprestimo = novoEmprestimo.DataEmprestimo,
                    DataDevolucao = novoEmprestimo.DataDevolucao
                };

                _emprestimoRepo.Add(emprestimo);

                var resultado = new
                {
                    Mensagem = "Categoria cadastrado com sucesso!",
                    Id = emprestimo.Id,
                    FkLivros = emprestimo.FkLivros,
                    FkMenbros = emprestimo.FkMenbros,
                    DataEmprestimo = emprestimo.DataEmprestimo,
                    DataDevolucao = emprestimo.DataDevolucao
                };

                return Ok(resultado);
            }

        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, [FromForm] EmprestimoDto emprestimoAtualizado)
        {

            {
                var emprestimoExistente = _emprestimoRepo.GetById(id);

                if (emprestimoExistente == null)
                {
                    return NotFound(new { Mensagem = "Categoria não encontrado." });
                }

                
                emprestimoExistente.FkLivros = emprestimoAtualizado.FkLivros;
                emprestimoExistente.FkMenbros = emprestimoAtualizado.FkMenbros;
                emprestimoExistente.DataEmprestimo = emprestimoAtualizado.DataEmprestimo;
                emprestimoExistente.DataDevolucao = emprestimoAtualizado.DataDevolucao;

                _emprestimoRepo.Update(emprestimoExistente);

                var resultado = new
                {
                    Mensagem = "Emprestimo atualizado com sucesso!",
                    Id = emprestimoExistente.Id,
                    FkLivros = emprestimoExistente.FkLivros,
                    FkMenbros = emprestimoExistente.FkMenbros,
                    DataEmprestimo = emprestimoExistente.DataEmprestimo,
                    DataDevolucao = emprestimoExistente.DataDevolucao,
                };

                return Ok(resultado);
            }

        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            {
                var emprestimoExistente = _emprestimoRepo.GetById(id);

                if (emprestimoExistente == null)
                {
                    return NotFound(new { Mensagem = "Emprestimo não encontrado." });
                }

                _emprestimoRepo.Delete(id);

                var resultado = new
                {
                    Mensagem = "Emprestimo excluído com sucesso!",
                    Id = emprestimoExistente.Id,
                    FkLivros = emprestimoExistente.FkLivros,
                    FkMenbros = emprestimoExistente.FkMenbros,
                    DataEmprestimo = emprestimoExistente.DataEmprestimo,
                    DataDevolucao = emprestimoExistente.DataDevolucao,
                };

                return Ok(resultado);
            }

        }
    }
}
    
