using Biblioteca_WebApi_ruan.Model;
using Biblioteca_WebApi_ruan.ORM;

namespace Biblioteca_WebApi_ruan.Repositorio
{
    public class EmprestimoR
    {
        private BibliotecaWebApiRuanContext _context;

        public EmprestimoR(BibliotecaWebApiRuanContext context)
        {
            _context = context;
        }
        public void Add(Emprestimo emprestimo)
        {
            var tbEmprestimo = new TbEmprestimo()
            {
                DataDevolucao = emprestimo.DataDevolucao,
                DataEmprestimo = emprestimo.DataEmprestimo,
                FkLivros = emprestimo.FkLivros,
                FkMenbros = emprestimo.FkMenbros
            };

            // Adiciona a entidade ao contexto
            _context.TbEmprestimos.Add(tbEmprestimo);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbEmprestimo = _context.TbEmprestimos.FirstOrDefault(f => f.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbEmprestimo != null)
            {
                // Remove a entidade do contexto
                _context.TbEmprestimos.Remove(tbEmprestimo);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Emprestimo não encontrado.");
            }
        }
        public List<Emprestimo> GetAll()
        {
            List<Emprestimo> listFun = new List<Emprestimo>();

            var listTb = _context.TbEmprestimos.ToList();

            foreach (var item in listTb)
            {
                var emprestimo = new Emprestimo
                {
                    DataDevolucao = item.DataDevolucao,
                    DataEmprestimo = item.DataEmprestimo,
                    FkLivros = item.FkLivros,
                    FkMenbros = item.FkMenbros
                };

                listFun.Add(emprestimo);
            }

            return listFun;
        }
        public Emprestimo GetById(int id)
        {
            // Busca o funcionário pelo ID no banco de dados
            var item = _context.TbEmprestimos.FirstOrDefault(f => f.Id == id);

            // Verifica se o funcionário foi encontrado
            if (item == null)
            {
                return null; // Retorna null se não encontrar
            }

            // Mapeia o objeto encontrado para a classe Funcionario
            var empretimo = new Emprestimo
            {
                DataDevolucao = item.DataDevolucao,
                DataEmprestimo = item.DataEmprestimo,
                FkLivros = item.FkLivros,
                FkMenbros = item.FkMenbros
            };

            return empretimo; // Retorna o funcionário encontrado
        }
        public void Update(Emprestimo emprestimo)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbEmprestimo = _context.TbEmprestimos.FirstOrDefault(f => f.Id == emprestimo.Id);

            // Verifica se a entidade foi encontrada
            if (tbEmprestimo != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Funcionario recebido
                tbEmprestimo.DataDevolucao = emprestimo.DataDevolucao;
                tbEmprestimo.DataEmprestimo = emprestimo.DataEmprestimo;
                tbEmprestimo.FkLivros = emprestimo.FkLivros;
                tbEmprestimo.FkMenbros = emprestimo.FkMenbros;


                // Atualiza as informações no contexto
                _context.TbEmprestimos.Update(tbEmprestimo);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Funcionário não encontrado.");
            }
        }

        internal void Add(object emprestimo)
        {
            throw new NotImplementedException();
        }
    }
}
    
