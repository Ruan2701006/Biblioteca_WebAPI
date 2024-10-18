using Biblioteca_WebApi_ruan.Model;
using Biblioteca_WebApi_ruan.ORM;
using Biblioteca_WebApi_ruan.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_WebApi_ruan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioR _funcionarioRepo;
        
        public FuncionarioController(FuncionarioR funcionarioRepo)
        {
            _funcionarioRepo = funcionarioRepo;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public ActionResult<List<Funcionario>> GetAll()
        {

            {
                var funcionarios = _funcionarioRepo.GetAll();

                if (funcionarios == null || !funcionarios.Any())
                {
                    return NotFound(new { Mensagem = "Nenhum categoria encontrado." });
                }

                var listaCat = funcionarios.Select(funcionario => new Funcionario
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    Telefone = funcionario.Telefone,
                    Email = funcionario.Email,
                    Cargo = funcionario.Cargo

                }).ToList();

                return Ok(listaCat);
            }

        }

        // GET: api/Categoria/{id}
        [HttpGet("{id}")]
        public ActionResult<Funcionario> GetById(int id)
        {

            {
                var funcionario = _funcionarioRepo.GetById(id);

                if (funcionario == null)
                {
                    return NotFound(new { Mensagem = "Funcionario não encontrado." });
                }

                var funcionarioId = new Funcionario
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    Telefone = funcionario.Telefone,
                    Email = funcionario.Email,
                    Cargo = funcionario.Cargo
                };

                return Ok(funcionarioId);
            }

        }

        // POST api/<CategoriaController>
        [HttpPost]
        public ActionResult<object> Post([FromForm] FuncionarioDto novoFuncionario)
        {

            {
                var funcionario = new Funcionario
                {
                    Nome = novoFuncionario.Nome,
                    Telefone = novoFuncionario.Telefone,
                    Email = novoFuncionario.Email,
                    Cargo = novoFuncionario.Cargo
                };

                _funcionarioRepo.Add(funcionario);

                var resultado = new
                {
                    Mensagem = "Funcionario cadastrado com sucesso!",

                    Nome = funcionario.Nome,
                    Telefone = funcionario.Telefone,
                    Email = funcionario.Email,
                    Cargo = funcionario.Cargo
                };

                return Ok(resultado);
            }

        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public ActionResult<object> Put(int id, [FromForm] FuncionarioDto funcionarioAtualizado)
        {

            {
                var funcionarioExistente = _funcionarioRepo.GetById(id);

                if (funcionarioExistente == null)
                {
                    return NotFound(new { Mensagem = "Funcionario não encontrado." });
                }


                funcionarioExistente.Nome = funcionarioAtualizado.Nome;
                funcionarioExistente.Telefone = funcionarioAtualizado.Telefone;
                funcionarioExistente.Email = funcionarioAtualizado.Email;
                funcionarioExistente.Cargo = funcionarioAtualizado.Cargo;

                _funcionarioRepo.Update(funcionarioExistente);

                var resultado = new
                {
                    Mensagem = "Funcionario atualizado com sucesso!",

                    Nome = funcionarioExistente.Nome,
                    Telefone = funcionarioExistente.Telefone,
                    Email = funcionarioExistente.Email,
                    Cargo = funcionarioExistente.Cargo
                };

                return Ok(resultado);
            }

        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            {
                var funcionarioExistente = _funcionarioRepo.GetById(id);

                if (funcionarioExistente == null)
                {
                    return NotFound(new { Mensagem = "Funcionario não encontrado." });
                }

                _funcionarioRepo.Delete(id);

                var resultado = new
                {
                    Mensagem = "Funcionario excluído com sucesso!",


                    Nome = funcionarioExistente.Nome,
                    Telefone = funcionarioExistente.Telefone,
                    Email = funcionarioExistente.Email,
                    Cargo = funcionarioExistente.Cargo
                };

                return Ok(resultado);
            }

        }
    }
}
    
    