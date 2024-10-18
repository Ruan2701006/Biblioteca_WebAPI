using Biblioteca_WebApi_ruan.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Biblioteca_WebApi_ruan.Repositorio.MembroR;

namespace Biblioteca_WebApi_ruan.Controllers
{
    public class MembrosController
    {
        [Route("api/[controller]")]
        [ApiController]
       
        public class MembroController : ControllerBase
        {
            private readonly MembroRepositorio _membroRepo;

            public MembroController(MembroRepositorio membroRepo)
            {
                _membroRepo = membroRepo;
            }

            // GET: api/<MembroController>
            [HttpGet]
            public ActionResult<List<Membro>> GetAll()
            {
               
                {
                    var membros = _membroRepo.GetAll();

                    if (membros == null || !membros.Any())
                    {
                        return NotFound(new { Mensagem = "Nenhum membro encontrado." });
                    }

                    var listaMem = membros.Select(membro => new Membro
                    {
                        Id = membro.Id,
                        Nome = membro.Nome,
                        Telefone = membro.Telefone,
                        Email = membro.Email,
                        TipoMembro = membro.TipoMembro,
                        DataCadastro = membro.DataCadastro
                    }).ToList();

                    return Ok(listaMem);
                }
                
            }

            // GET: api/Membro/{id}
            [HttpGet("{id}")]
            public ActionResult<Membro> GetById(int id)
            {
                
                {
                    var membro = _membroRepo.GetById(id);

                    if (membro == null)
                    {
                        return NotFound(new { Mensagem = "Membro não encontrado." });
                    }

                    var membroId = new Membro
                    {
                        Id = membro.Id,
                        Nome = membro.Nome,
                        Telefone = membro.Telefone,
                        Email = membro.Email,
                        TipoMembro = membro.TipoMembro,
                        DataCadastro = membro.DataCadastro
                    };

                    return Ok(membroId);
                }
               
            }

            // POST api/<MembroController>
            [HttpPost]
            public ActionResult<object> Post([FromForm] MembroDto novoMembro)
            {
                
                {
                    var membro = new Membro
                    {
                        Nome = novoMembro.Nome,
                        Telefone = novoMembro.Telefone,
                        Email = novoMembro.Email,
                        TipoMembro = novoMembro.TipoMembro,
                        DataCadastro = novoMembro.DataCadastro
                    };

                    _membroRepo.Add(membro);

                    var resultado = new
                    {
                        Mensagem = "Membro cadastrado com sucesso!",
                        Nome = membro.Nome,
                        Telefone = membro.Telefone,
                        Email = membro.Email,
                        TipoMembro = membro.TipoMembro,
                        DataCadastro = membro.DataCadastro
                    };

                    return Ok(resultado);
                }
                
            }

            // PUT api/<MembroController>/5
            [HttpPut("{id}")]
            public ActionResult<object> Put(int id, [FromForm] MembroDto membroAtualizado)
            {
                
                {
                    var membroExistente = _membroRepo.GetById(id);

                    if (membroExistente == null)
                    {
                        return NotFound(new { Mensagem = "Membro não encontrado." });
                    }

                    membroExistente.Nome = membroAtualizado.Nome;
                    membroExistente.Telefone = membroAtualizado.Telefone;
                    membroExistente.Email = membroAtualizado.Email;
                    membroExistente.TipoMembro = membroAtualizado.TipoMembro;
                    membroExistente.DataCadastro = membroAtualizado.DataCadastro;

                    _membroRepo.Update(membroExistente);

                    var resultado = new
                    {
                        Mensagem = "Membro atualizado com sucesso!",
                        Nome = membroExistente.Nome,
                        Telefone = membroExistente.Telefone,
                        Email = membroExistente.Email,
                        TipoMembro = membroExistente.TipoMembro,
                        DataCadastro = membroExistente.DataCadastro
                    };

                    return Ok(resultado);
                }
              
            }

            // DELETE api/<MembroController>/5
            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                
                {
                    var membroExistente = _membroRepo.GetById(id);

                    if (membroExistente == null)
                    {
                        return NotFound(new { Mensagem = "Membro não encontrado." });
                    }

                    _membroRepo.Delete(id);

                    var resultado = new
                    {
                        Mensagem = "Membro excluído com sucesso!",
                        Nome = membroExistente.Nome,
                        Telefone = membroExistente.Telefone,
                        Email = membroExistente.Email,
                        TipoMembro = membroExistente.TipoMembro,
                        DataCadastro = membroExistente.DataCadastro
                    };

                    return Ok(resultado);
                }
                
            }
        }
    }
}

