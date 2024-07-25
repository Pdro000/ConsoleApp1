using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IBiblioteca
    {
        void AdicionarLivro(string titulo, string autor, int devolucao);
        void MostrarLivrosDisponiveis();
        void MostrarDetalhesLivro(string titulo);
        void AlugarLivro(string titulo);
        void DevolverLivro(string titulo);
        int ContarLivrosDisponiveis();
    }
}
