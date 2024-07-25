using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{


    public class Livro : ILivro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool EstaAlugado { get; set; }
        public int devolucao { get; set; }
        public int Id { get; set; }
    }

}
