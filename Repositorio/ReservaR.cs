using Biblioteca_WebApi_ruan.Model;
using Biblioteca_WebApi_ruan.ORM;

namespace Biblioteca_WebApi_ruan.Repositorio
{
    public class ReservaR
    {
        private BibliotecaWebApiRuanContext _context;
        public ReservaR(BibliotecaWebApiRuanContext context)
        {
            _context = context;
        }
        public void Add(Reserva reserva)
        {

            // Cria uma nova entidade do tipo tbReserva a partir do objeto Funcionario recebido
            var tbReserva = new TbReserva()
            {
                FkLivros = reserva.FkLivros,
                FkMembros = reserva.FkMembros,
                DataReserva = reserva.DataReserva
            };

            // Adiciona a entidade ao contexto
            _context.TbReservas.Add(tbReserva);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbReserva = _context.TbReservas.FirstOrDefault(r => r.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbReserva != null)
            {
                // Remove a entidade do contexto
                _context.TbReservas.Remove(tbReserva);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Reserva não encontrado.");
            }
        }
        public List<Reserva> GetAll()
        {
            List<Reserva> listRes = new List<Reserva>();

            var listTb = _context.TbReservas.ToList();

            foreach (var item in listTb)
            {
                var reserva = new Reserva
                {
                    Id = item.Id,
                    DataReserva = item.DataReserva,
                    FkLivros = item.FkLivros,
                    FkMembros = item.FkMembros
                };

                listRes.Add(reserva);
            }

            return listRes;
        }
        public Reserva GetById(int id)
        {
            // Busca o Reserva pelo ID no banco de dados
            var item = _context.TbReservas.FirstOrDefault(r => r.Id == id);

            // Verifica se o Reserva foi encontrado
            if (item == null)
            {
                return null; // Retorna null se não encontrar
            }

            // Mapeia o objeto encontrado para a classe Reserva
            var reserva = new Reserva
            {
                Id = item.Id,
                DataReserva = item.DataReserva,
                FkLivros = item.FkLivros,
                FkMembros = item.FkMembros
            };

            return reserva; // Retorna o Emprestimo encontrado
        }
        public void Update(Reserva reserva)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbReserva = _context.TbReservas.FirstOrDefault(e => e.Id == reserva.Id);

            // Verifica se a entidade foi encontrada
            if (tbReserva != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Membro recebido
                tbReserva.DataReserva = reserva.DataReserva;
                tbReserva.FkLivros = reserva.FkLivros;
                tbReserva.FkMembros = reserva.FkMembros;



                // Atualiza as informações no contexto
                _context.TbReservas.Update(tbReserva);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Emprestimo não encontrado.");
            }
        }
    }
}
    
