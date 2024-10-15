﻿using System;
using System.Collections.Generic;

namespace Biblioteca_WebApi_ruan.ORM;

public partial class TbCategoria
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public virtual ICollection<TbLivro> TbLivros { get; set; } = new List<TbLivro>();
}
