using System;
using System.Collections.Generic;

namespace Biblioteca_WebApi_ruan.ORM;

public partial class TbEmprestimo
{
    public int Id { get; set; }

    public DateOnly DataEmprestimo { get; set; }

    public DateOnly DataDevolucao { get; set; }

    public int FkMenbros { get; set; }

    public int FkLivros { get; set; }

    public virtual TbLivro FkLivrosNavigation { get; set; } = null!;

    public virtual TbMembro FkMenbrosNavigation { get; set; } = null!;
    public string Nome { get; internal set; }
    public string Descricao { get; internal set; }
    public string Email { get; internal set; }
    public string Telefone { get; internal set; }
    public string Cargo { get; internal set; }
}
