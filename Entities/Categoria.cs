using System.Collections.Generic;

namespace EFCore.QueryAnalysis.Entities
{
    public class Categoria
    {
        public int ID { get; set; }
        public int BibliotecaID { get; set; }
        public string Nome { get; set; }

        public virtual Biblioteca Biblioteca { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
    }
}