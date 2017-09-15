using System;
using System.Linq;
using EFCore.QueryAnalysis.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.QueryAnalysis.Data
{
    public class Queries
    {
        public static void InserirDadosIniciais()
        {
            using (var db = new AppDataContext())
            {
                db.Database.EnsureCreated();

                db.Bibliotecas.Add(new Biblioteca { ID = 1, Nome = "Biblioteca Canal .NET" });
                db.Bibliotecas.Add(new Biblioteca { ID = 2, Nome = "Biblioteca Coding Night" });
                db.Bibliotecas.Add(new Biblioteca { ID = 3, Nome = "Biblioteca de SP" });

                db.Autores.Add(new Autor { ID = 1, Nome = "Eric Evans", DataNascimento = DateTime.Parse("02/07/1945") });
                db.Autores.Add(new Autor { ID = 2, Nome = "Robert C. Martin", DataNascimento = DateTime.Parse("01/01/1952") });
                db.Autores.Add(new Autor { ID = 3, Nome = "Vaughn Vernon" });
                db.Autores.Add(new Autor { ID = 4, Nome = "Scott Millet", DataNascimento = DateTime.Parse("02/06/1972") });
                db.Autores.Add(new Autor { ID = 5, Nome = "Martin Fowler", DataNascimento = DateTime.Parse("01/01/1963") });

                db.Categorias.Add(new Categoria { ID = 1, BibliotecaID = 1, Nome = "Desenvolvimento de Software" });
                db.Categorias.Add(new Categoria { ID = 2, BibliotecaID = 2, Nome = "Desenvolvimento de Software" });
                db.Categorias.Add(new Categoria { ID = 3, BibliotecaID = 3, Nome = "Aventura" });
                db.Categorias.Add(new Categoria { ID = 4, BibliotecaID = 3, Nome = "Romance" });
                db.Categorias.Add(new Categoria { ID = 5, BibliotecaID = 3, Nome = "Suspense" });
                db.Categorias.Add(new Categoria { ID = 6, BibliotecaID = 3, Nome = "Poesia" });

                db.Livros.Add(new Livro { CategoriaID = 1, AutorID = 1, Titulo = "Domain-Driven Design: Tackling Complexity in the Heart of Software", AnoPublicacao = 2003 });
                db.Livros.Add(new Livro { CategoriaID = 1, AutorID = 2, Titulo = "Agile Principles, Patterns, and Practices in C#", AnoPublicacao = 2006 });
                db.Livros.Add(new Livro { CategoriaID = 1, AutorID = 2, Titulo = "Clean Code: A Handbook of Agile Software Craftsmanship", AnoPublicacao = 2008 });
                db.Livros.Add(new Livro { CategoriaID = 1, AutorID = 3, Titulo = "Implementing Domain-Driven Design",  AnoPublicacao = 2013 });
                db.Livros.Add(new Livro { CategoriaID = 1, AutorID = 4, Titulo = "Patterns, Principles, and Practices of Domain-Driven Design", AnoPublicacao = 2015 });
                db.Livros.Add(new Livro { CategoriaID = 1, AutorID = 5, Titulo = "Refactoring: Improving the Design of Existing Code ", AnoPublicacao = 2012 });
                
                db.Livros.Add(new Livro { CategoriaID = 2, AutorID = 1, Titulo = "Domain-Driven Design: Tackling Complexity in the Heart of Software", AnoPublicacao = 2003 });
                db.Livros.Add(new Livro { CategoriaID = 2, AutorID = 2, Titulo = "Agile Principles, Patterns, and Practices in C#", AnoPublicacao = 2006 });
                db.Livros.Add(new Livro { CategoriaID = 2, AutorID = 2, Titulo = "Clean Code: A Handbook of Agile Software Craftsmanship", AnoPublicacao = 2008 });

                db.SaveChanges();
            }
        }

        public static void ConsultaSimples()
        {
            using (var db = new AppDataContext())
            {
                var livros = db.Livros.ToList();
                livros.ForEach(x => Console.WriteLine(x.Titulo));
            }

            /*
                Query executada no banco:

                SELECT [l].[ID], [l].[AnoPublicacao], [l].[AutorID], [l].[CategoriaID], [l].[Titulo]
                FROM [Livro] AS [l]
            */
        }

        public static void ConsultaSimplesNoTracking()
        {
            using (var db = new AppDataContext())
            {
                var livros = db.Livros.AsNoTracking().ToList();
                livros.ForEach(x => Console.WriteLine(x.Titulo));
            }

            /*
                Query executada no banco:

                SELECT [l].[ID], [l].[AnoPublicacao], [l].[AutorID], [l].[CategoriaID], [l].[Titulo]
                FROM [Livro] AS [l]
            */
        }

        public static void ConsultaSimplesFiltroErrado()
        {
            using (var db = new AppDataContext())
            {
                var livros = db.Livros.ToList().Where(x => x.Titulo.Contains("Domain")).ToList();
                livros.ForEach(x => Console.WriteLine(x.Titulo));
            }

            /*
                Query executada no banco:

                SELECT [l].[ID], [l].[AnoPublicacao], [l].[AutorID], [l].[CategoriaID], [l].[Titulo]
                FROM [Livro] AS [l]
            */
        }

        public static void ConsultaSimplesFiltroCorreto()
        {
            using (var db = new AppDataContext())
            {
                var livros = db.Livros.AsNoTracking().Where(x => x.Titulo.Contains("Domain")).ToList();
                livros.ForEach(x => Console.WriteLine(x.Titulo));
            }

            /*
                Query executada no banco:

                SELECT [x].[ID], [x].[AnoPublicacao], [x].[AutorID], [x].[CategoriaID], [x].[Titulo]
                FROM [Livro] AS [x]
                WHERE CHARINDEX(N'Domain', [x].[Titulo]) > 0
            */
        }

        public static void ConsultaSimplesFiltroOrderByFirstErrado()
        {
            using (var db = new AppDataContext())
            {
                var livro = db.Livros.Where(x => x.Titulo.Contains("Domain")).ToList().OrderByDescending(x => x.AnoPublicacao).FirstOrDefault();
                Console.WriteLine(livro.Titulo);
            }

            /*
                Query executada no banco:

                SELECT [x].[ID], [x].[AnoPublicacao], [x].[AutorID], [x].[CategoriaID], [x].[Titulo]
                FROM [Livro] AS [x]
                WHERE CHARINDEX(N'Domain', [x].[Titulo]) > 0
            */
        }

        public static void ConsultaSimplesFiltroOrderByFirstCorreto()
        {
            using (var db = new AppDataContext())
            {
                var livro = db.Livros.AsNoTracking().OrderByDescending(x => x.AnoPublicacao).FirstOrDefault(x => x.Titulo.Contains("Domain"));
                Console.WriteLine(livro.Titulo);
            }

            /*
                Query executada no banco:

                SELECT TOP(1) [x].[ID], [x].[AnoPublicacao], [x].[AutorID], [x].[CategoriaID], [x].[Titulo]
                FROM [Livro] AS [x]
                WHERE CHARINDEX(N'Domain', [x].[Titulo]) > 0
                ORDER BY [x].[AnoPublicacao] DESC
            */
        }

        public static void ConsultaIncludeDesnecessario()
        {
            using (var db = new AppDataContext())
            {
                var livros = db.Livros.Include(x => x.Autor).Include(x => x.Categoria).Where(x => x.Autor.Nome.Contains("Evans")).ToList();
                livros.ForEach(x => Console.WriteLine(x.Titulo));
            }

            /*
                Query executada no banco:

                SELECT [x].[ID], [x].[AnoPublicacao], [x].[AutorID], [x].[CategoriaID], [x].[Titulo], [x.Categoria].[ID], [x.Categoria].[BibliotecaID], [x.Categoria].[Nome], [x.Autor].[ID], [x.Autor].[DataNascimento], [x.Autor].[Nome]
                FROM [Livro] AS [x]
                INNER JOIN [Categoria] AS [x.Categoria] ON [x].[CategoriaID] = [x.Categoria].[ID]
                INNER JOIN [Autor] AS [x.Autor] ON [x].[AutorID] = [x.Autor].[ID]
                WHERE CHARINDEX(N'Evans', [x.Autor].[Nome]) > 0
            */
        }

        public static void ConsultaIncludeCorreto()
        {
            using (var db = new AppDataContext())
            {
                var livros = db.Livros.AsNoTracking().Include(x => x.Autor).Where(x => x.Autor.Nome.Contains("Evans")).Select(x => x.Titulo).ToList();
                livros.ForEach(x => Console.WriteLine(x));
            }

            /*
                Query executada no banco:

                SELECT [x].[Titulo]
                FROM [Livro] AS [x]
                INNER JOIN [Autor] AS [x.Autor] ON [x].[AutorID] = [x.Autor].[ID]
                WHERE CHARINDEX(N'Evans', [x.Autor].[Nome]) > 0
            */
        }
    }
}
