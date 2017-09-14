namespace EFCore.QueryAnalysis.Entities
{
    public class Livro
    {
        public int ID { get; set; }
        public int CategoriaID { get; set; }
        public int AutorID { get; set; }
        public string Titulo { get; set; }
        public int AnoPublicacao { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Autor Autor { get; set; }
    }
}