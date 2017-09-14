using System.Collections.Generic;

namespace EFCore.QueryAnalysis.Entities
{
    public class Biblioteca
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Categoria> Categorias { get; set; }
    }
}