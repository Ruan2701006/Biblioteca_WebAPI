using Biblioteca_WebApi_ruan.Model;
using Biblioteca_WebApi_ruan.ORM;


namespace Biblioteca_WebApi_ruan.Repositorio
{
    public class CategoriaR
    {
        private BibliotecaWebApiRuanContext _context;
        

        public CategoriaR(BibliotecaWebApiRuanContext context)
        {
            _context = context;
        }
        public void Add(Categoria categoria)
        {
            var tbCategoria = new TbCategoria()
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Descricao = categoria.Descricao,
            };

            // Adiciona a entidade ao contexto
            _context.TbCategorias.Add(tbCategoria);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbCategoria = _context.TbCategorias.FirstOrDefault(f => f.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbCategoria != null)
            {
                // Remove a entidade do contexto
                _context.TbCategorias.Remove(tbCategoria);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Categoria não encontrada."); 
            }
        }
        public List<Categoria> GetAll()
        {
            List<Categoria> listFun = new List<Categoria>();

            var listTb = _context.TbCategorias.ToList();

            foreach (var item in listTb)
            {
                var categorias = new Categoria
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Descricao = item.Descricao,
                    
                };

                listFun.Add(categorias);
            }

            return listFun;
        }
        public Categoria GetById(int id)
        {
            // Busca o funcionário pelo ID no banco de dados
            var item = _context.TbCategorias.FirstOrDefault(f => f.Id == id);

            // Verifica se o funcionário foi encontrado
            if (item == null)
            {
                return null; // Retorna null se não encontrar
            }

            // Mapeia o objeto encontrado para a classe Funcionario
            var categorias = new Categoria
            {
                Id = item.Id,
                Nome = item.Nome,
                Descricao = item.Descricao,
            };

            return categorias; // Retorna o funcionário encontrado
        }
        public void Update(Categoria categoria)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbCategoria = _context.TbCategorias.FirstOrDefault(f => f.Id == categoria.Id);

            // Verifica se a entidade foi encontrada
            if (tbCategoria != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Funcionario recebido
                tbCategoria.Id = categoria.Id;
                tbCategoria.Nome = categoria.Nome;
                tbCategoria.Descricao = categoria.Descricao;
                

                // Atualiza as informações no contexto
                _context.TbCategorias.Update(tbCategoria);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Funcionário não encontrado.");
            }
        }

    }
}
    

       