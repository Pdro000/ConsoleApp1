using ConsoleApp1;
using Trabalho;

IBiblioteca minhaBiblioteca = new Biblioteca();
Cliente cliente= new Cliente();


Console.WriteLine("Bem-vindo à biblioteca!");

    while (true)
    {
        Console.WriteLine("\nEscolha uma opção:");
        Console.WriteLine("1 - Mostrar livros disponíveis");
        Console.WriteLine("2 - Mostrar detalhes de um livro");
        Console.WriteLine("3 - Alugar um livro");
        Console.WriteLine("4 - Devolver um livro");
        Console.WriteLine("5 - Contar livros disponíveis");
        Console.WriteLine("6 - Cadastrar um novo livro");
        Console.WriteLine("0 - Sair");

        int opcao;
        if (!int.TryParse(Console.ReadLine(), out opcao))
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
            continue;
        }

        switch (opcao)
        {
            case 1:
                minhaBiblioteca.MostrarLivrosDisponiveis();
                break;
            case 2:
                Console.Write("Digite o título do livro para ver detalhes: ");
                string tituloDetalhes = Console.ReadLine();
                minhaBiblioteca.MostrarDetalhesLivro(tituloDetalhes);
                break;
            case 3:
                Console.Write("Digite o título do livro que deseja alugar: ");
                string tituloAlugar = Console.ReadLine();
                minhaBiblioteca.AlugarLivro(tituloAlugar);
                break;
            case 4:
                Console.Write("Digite o título do livro que deseja devolver: ");
                string tituloDevolver = Console.ReadLine();
                minhaBiblioteca.DevolverLivro(tituloDevolver);
                break;
            case 5:
                int livrosDisponiveis = minhaBiblioteca.ContarLivrosDisponiveis();
                Console.WriteLine($"Número de livros disponíveis: {livrosDisponiveis}");
                break;
            case 6:
                Console.Write("Digite o título do novo livro: ");
                string novoTitulo = Console.ReadLine();
                Console.Write("Digite o nome do autor do novo livro: ");
                string novoAutor = Console.ReadLine();
                Console.WriteLine("Qual tempo de devolução?");
                int devolucao = int.Parse(Console.ReadLine());
                minhaBiblioteca.AdicionarLivro(novoTitulo, novoAutor, devolucao);
                break;
            case 0:
                Console.WriteLine("Saindo do programa...");
                return;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

   