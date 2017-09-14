using System;
using EFCore.QueryAnalysis.Data;

namespace EFCore.QueryAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Queries.InserirDadosIniciais();
            
            Queries.ConsultaSimples();
            Queries.ConsultaSimplesNoTracking();
            
            Console.WriteLine(new string('-', 10));
            
            Queries.ConsultaSimplesFiltroErrado();
            Queries.ConsultaSimplesFiltroCorreto();

            Console.WriteLine(new string('-', 10));

            Queries.ConsultaSimplesFiltroOrderByFirstErrado();
            Queries.ConsultaSimplesFiltroOrderByFirstCorreto();
            
            Console.WriteLine(new string('-', 10));

            Queries.ConsultaIncludeDesnecessario();
            Queries.ConsultaIncludeCorreto();
        }
    }
}
