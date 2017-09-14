using System;
using System.Collections.Generic;

namespace EFCore.QueryAnalysis.Entities
{
    public class Autor
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }
    }
}