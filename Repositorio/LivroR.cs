﻿using Biblioteca_WebApi_ruan.Model;
using Biblioteca_WebApi_ruan.ORM;

namespace Biblioteca_WebApi_ruan.Repositorio
{
    public class LivroR
    {
        private BibliotecaWebApiRuanContext _context;

        public LivroR(BibliotecaWebApiRuanContext context)
        {
            _context = context;
        }
        public void Add(Livro livro)
        {

            // Cria uma nova entidade do tipo tbFuncionario a partir do objeto Funcionario recebido
            var tbLivro = new TbLivro()
            {
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                AnoPublicacao = livro.AnoPublicacao,
                FkCategoria = livro.FkCategoria,
                Disponibilidade = livro.Disponibilidade
            };

            // Adiciona a entidade ao contexto
            _context.TbLivros.Add(tbLivro);

            // Salva as mudanças no banco de dados
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbLivro = _context.TbLivros.FirstOrDefault(f => f.Id == id);

            // Verifica se a entidade foi encontrada
            if (tbLivro != null)
            {
                // Remove a entidade do contexto
                _context.TbLivros.Remove(tbLivro);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Funcionario não encontrado.");
            }
        }
        public List<Livro> GetAll()
        {
            List<Livro> listFun = new List<Livro>();

            var listTb = _context.TbLivros.ToList();

            foreach (var item in listTb)
            {
                var livro = new Livro
                {
                    Titulo =item.Titulo,
                    Autor = item.Autor,
                    AnoPublicacao = item.AnoPublicacao,
                    FkCategoria = item.FkCategoria,
                    Disponibilidade = item.Disponibilidade
                };

                listFun.Add(livro);
            }

            return listFun;
        }
        public Livro GetById(int id)
        {
            // Busca o funcionário pelo ID no banco de dados
            var item = _context.TbLivros.FirstOrDefault(f => f.Id == id);

            // Verifica se o funcionário foi encontrado
            if (item == null)
            {
                return null; // Retorna null se não encontrar
            }

            // Mapeia o objeto encontrado para a classe Funcionario
            var livro = new Livro
            {
                Titulo = item.Titulo,
                Autor = item.Autor,
                AnoPublicacao = item.AnoPublicacao,
                FkCategoria = item.FkCategoria,
                Disponibilidade = item.Disponibilidade
            };

            return livro; // Retorna o funcionário encontrado
        }
        public void Update(Livro livro)
        {
            // Busca a entidade existente no banco de dados pelo Id
            var tbLivro = _context.TbLivros.FirstOrDefault(f => f.Id == livro.Id);

            // Verifica se a entidade foi encontrada
            if (tbLivro != null)
            {
                // Atualiza os campos da entidade com os valores do objeto Funcionario recebido
                
                tbLivro.Titulo = livro.Titulo;
                tbLivro.Autor = livro.Autor;
                tbLivro.AnoPublicacao = livro.AnoPublicacao;
                tbLivro.FkCategoria = livro.FkCategoria;
                tbLivro.Disponibilidade = livro.Disponibilidade;


                // Atualiza as informações no contexto
                _context.TbLivros.Update(tbLivro);

                // Salva as mudanças no banco de dados
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Livro não encontrado.");
            }
        }

        internal void Add(object funcionario)
        {
            throw new NotImplementedException();
        }
    }
}
   
