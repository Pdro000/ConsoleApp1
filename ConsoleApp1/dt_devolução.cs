using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho
{
    using System;

    class Program
    {
        static void Main()
        {
            // Data de empréstimo
            DateTime dataEmprestimo = new DateTime(2024, 7, 1); // Exemplo: emprestado em 1 de julho de 2024

            // Data de devolução
            DateTime dataDevolucao = new DateTime(2024, 7, 8); // Exemplo: devolvido em 8 de julho de 2024

            // Prazo de devolução (7 dias)
            int prazoDevolucao = 7;

            // Calcula a data limite de devolução
            DateTime dataLimite = dataEmprestimo.AddDays(prazoDevolucao);

            // Verifica se a data de devolução está dentro do prazo
            if (dataDevolucao <= dataLimite)
            {
                Console.WriteLine("Livro devolvido dentro do prazo.");
            }
            else
            {
                Console.WriteLine("Livro devolvido fora do prazo.");
            }
        }
    }


}

