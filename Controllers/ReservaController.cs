using Biblioteca_WebApi_ruan.Model;
using Biblioteca_WebApi_ruan.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_WebApi_ruan.Controllers

    {
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class ReservaController : ControllerBase
        {
            private readonly ReservaR _reservaRepo;

            public ReservaController(ReservaR reservaRepo)
            {
                _reservaRepo = reservaRepo;
            }

            // GET: api/<ReservaController>
            [HttpGet]
            public ActionResult<List<Reserva>> GetAll()
            {
                
                {
                    var reservas = _reservaRepo.GetAll();

                    if (reservas == null || !reservas.Any())
                    {
                        return NotFound(new { Mensagem = "Nenhuma reserva encontrada." });
                    }

                    var listaRes = reservas.Select(reserva => new Reserva
                    {
                        Id = reserva.Id,
                        FkLivros = reserva.FkLivros,
                        FkMembros = reserva.FkMembros,
                        DataReserva = reserva.DataReserva
                    }).ToList();

                    return Ok(listaRes);
                }
                
            }

            // GET: api/Reserva/{id}
            [HttpGet("{id}")]
            public ActionResult<Reserva> GetById(int id)
            {
                
                {
                    var reserva = _reservaRepo.GetById(id);

                    if (reserva == null)
                    {
                        return NotFound(new { Mensagem = "Reserva não encontrada." });
                    }

                    var reservaId = new Reserva
                    {
                        Id = reserva.Id,
                        FkLivros = reserva.FkLivros,
                        FkMembros = reserva.FkMembros,
                        DataReserva = reserva.DataReserva
                    };

                    return Ok(reservaId);
                }
                
            }

            // POST api/<ReservaController>
            [HttpPost]
            public ActionResult<object> Post([FromForm] ReservaDto novoReserva)
            {
                
                {
                    var reserva = new Reserva
                    {
                        FkLivros = novoReserva.FkLivros,
                        FkMembros = novoReserva.FkMembros,
                        DataReserva = novoReserva.DataReserva,
                    };

                    _reservaRepo.Add(reserva);

                    var resultado = new
                    {
                        Mensagem = "Reserva cadastrada com sucesso!",
                        FkLivros = reserva.FkLivros,
                        FkMembros = reserva.FkMembros,
                        DataReserva = reserva.DataReserva
                    };

                    return Ok(resultado);
                }
                
            }

            // PUT api/<ReservaController>/5
            [HttpPut("{id}")]
            public ActionResult<object> Put(int id, [FromForm] ReservaDto reservaAtualizado)
            {
                
                {
                    var reservaExistente = _reservaRepo.GetById(id);

                    if (reservaExistente == null)
                    {
                        return NotFound(new { Mensagem = "Reserva não encontrada." });
                    }

                    reservaExistente.FkLivros = reservaAtualizado.FkLivros;
                    reservaExistente.FkMembros = reservaAtualizado.FkMembros;
                    reservaExistente.DataReserva = reservaAtualizado.DataReserva;

                    _reservaRepo.Update(reservaExistente);

                    var resultado = new
                    {
                        Mensagem = "Reserva atualizada com sucesso!",
                        FkLivros = reservaExistente.FkLivros,
                        FkMembros = reservaExistente.FkMembros,
                        DataReserva = reservaExistente.DataReserva
                    };

                    return Ok(resultado);
                }
                
            }

            // DELETE api/<ReservaController>/5
            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                
                {
                    var reservaExistente = _reservaRepo.GetById(id);

                    if (reservaExistente == null)
                    {
                        return NotFound(new { Mensagem = "Reserva não encontrada." });
                    }

                    _reservaRepo.Delete(id);

                    var resultado = new
                    {
                        Mensagem = "Reserva excluída com sucesso!",
                        FkLivros = reservaExistente.FkLivros,
                        FkMembros = reservaExistente.FkMembros,
                        DataReserva = reservaExistente.DataReserva
                    };

                    return Ok(resultado);
                }
               
            }
        }
    }


