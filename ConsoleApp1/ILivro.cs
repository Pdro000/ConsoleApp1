using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface ILivro
    {
        string Titulo { get; set; }
        string Autor { get; set; }
        bool EstaAlugado { get; set; }
        int  devolucao { get; set; }
    }
}
