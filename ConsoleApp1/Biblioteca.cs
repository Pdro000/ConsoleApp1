using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Biblioteca : IBiblioteca
    {
        private List<ILivro> livros;
        private List<HistoricoEmprestimos> historico;

        public Biblioteca()
        {
            livros = new List<ILivro>();
            historico = new List<HistoricoEmprestimos>();

            // Exemplos de livros pré-cadastrados
            AdicionarLivro("A Guerra dos Tronos", "George R. R. Martin", 30);
            AdicionarLivro("O Senhor dos Anéis", "J. R. R. Tolkien", 60);
            AdicionarLivro("1984", "George Orwell", 25);
            AdicionarLivro("Harry Potter e a Pedra Filosofal", "J. K. Rowling", 60);
        }

        public void AdicionarLivro(string titulo, string autor, int devolucao)
        {
            Livro novoLivro = new Livro { Titulo = titulo, Autor = autor, devolucao = devolucao, EstaAlugado = false };
            livros.Add(novoLivro);
            Console.WriteLine("Livro cadastrado com sucesso!");
        }

        public void MostrarLivrosDisponiveis()
        {
            Console.WriteLine("Livros disponíveis na biblioteca:");
            foreach (var livro in livros)
            {
                if (!livro.EstaAlugado)
                    Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}");
            }
        }

        public void MostrarDetalhesLivro(string titulo)
        {
            ILivro livro = livros.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (livro != null)
            {
                Console.WriteLine($"Detalhes do livro '{livro.Titulo}':");
                Console.WriteLine($"Autor: {livro.Autor}");
                Console.WriteLine($"Status de Aluguel: {(livro.EstaAlugado ? "Alugado" : "Disponível")}");
            }
            else
            {
                Console.WriteLine("Livro não encontrado na biblioteca.");
            }
        }
         
        public void devolverlivro (string titulo)
        {

        }
        public void AlugarLivro(string titulo)
        {
            ILivro livro = livros.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (livro != null)
            {
                if (livro.EstaAlugado)
                {
                    Console.WriteLine("Este livro já está alugado.");
                }
                else
                {
                    livro.EstaAlugado = true;
                    historico.Add(new HistoricoEmprestimos { TituloLivro = titulo, DataEmprestimo = DateTime.Today });
                    Console.WriteLine("Livro alugado com sucesso!");
                    Console.WriteLine("tempo de devolução: " + livro.devolucao);
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado na biblioteca.");
            }
        }

        public void DevolverLivro(string titulo)
        {
            ILivro livro = livros.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (livro != null)
            {
                if (!livro.EstaAlugado)
                {
                    Console.WriteLine("Este livro não está alugado.");
                }
                else
                {
                    livro.EstaAlugado = false;
                    var emprestimo = historico.FindLast(e => e.TituloLivro.Equals(titulo, StringComparison.OrdinalIgnoreCase));
                    if (emprestimo != null)
                    {
                        emprestimo.DataDevolucao = DateTime.Today;
                        CalcularMulta(emprestimo);
                    }
                    else
                    {
                        Console.WriteLine("Não foi possível encontrar o histórico de empréstimo para este livro.");
                    }
                    Console.WriteLine("Livro devolvido com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado na biblioteca.");
            }
        }

        private void CalcularMulta(HistoricoEmprestimos emprestimo)
        {
            // Taxa diária de multa (exemplo: R$ 0,50 por dia de atraso)
            double taxaDiariaMulta = 0.50;

            // Calcula o número de dias de atraso
            TimeSpan periodoAtraso = emprestimo.DataDevolucao.Subtract(emprestimo.DataEmprestimo);
            int diasAtraso = periodoAtraso.Days;

            // Calcula a multa total
            double multa = diasAtraso * taxaDiariaMulta;

            Console.WriteLine($"Multa calculada para devolução em atraso ({diasAtraso} dias): R$ {multa}");
        }

        public int ContarLivrosDisponiveis()
        {
            int count = 0;
            foreach (var livro in livros)
            {
                if (!livro.EstaAlugado)
                    count++;
            }
            return count;
        }
    }
}
