using Biblioteca_WebApi_ruan.ORM;

namespace Biblioteca_WebApi_ruan.Repositorio
{
    public class UsuarioR
    {
        private readonly BibliotecaWebApiRuanContext _context;

        public UsuarioR(BibliotecaWebApiRuanContext context)
        {
            _context = context;
        }

        public TbUsuario GetByCredentials(string usuario, string senha)
        {
            // Aqui você deve usar a lógica de hash para comparar a senha
            return _context.TbUsuarios.FirstOrDefault(u => u.Usuario == usuario && u.Senha == senha);
        }

        // Você pode adicionar métodos adicionais para gerenciar usuários
    }
}
  
