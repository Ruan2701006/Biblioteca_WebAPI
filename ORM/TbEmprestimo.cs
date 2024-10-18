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
    
}
