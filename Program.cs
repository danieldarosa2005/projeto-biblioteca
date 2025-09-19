using BibliotecaConsole.Models;
using BibliotecaConsole.Services;

var biblioteca = new Biblioteca();
bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("===== Sistema da Biblioteca =====");
    Console.WriteLine("1 - Cadastrar Livro");
    Console.WriteLine("2 - Cadastrar Usuário");
    Console.WriteLine("3 - Emprestar Livro");
    Console.WriteLine("4 - Devolver Livro");
    Console.WriteLine("5 - Listar Livros Disponíveis");
    Console.WriteLine("6 - Listar Livros Emprestados");
    Console.WriteLine("7 - Listar Usuários");
    Console.WriteLine("8 - Listar Empréstimos");
    Console.WriteLine("0 - Sair");
    Console.Write("\nEscolha uma opção: ");

    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Título: ");
            var titulo = Console.ReadLine() ?? string.Empty;

            Console.Write("Autor: ");
            var autor = Console.ReadLine() ?? string.Empty;

            Console.Write("Ano: ");
            int ano = int.TryParse(Console.ReadLine(), out var anoLivro) ? anoLivro : 0;

            var livro = biblioteca.CadastrarLivro(titulo, autor, ano);
            Console.WriteLine($"\nLivro cadastrado: {livro}");
            break;

        case "2":
            Console.Write("Nome: ");
            var nome = Console.ReadLine() ?? string.Empty;

            Console.Write("E-mail: ");
            var email = Console.ReadLine() ?? string.Empty;

            var usuario = biblioteca.CadastrarUsuario(nome, email);
            Console.WriteLine($"\nUsuário cadastrado: {usuario}");
            break;

        case "3":
            Console.Write("ID do Livro: ");
            int idLivro = int.TryParse(Console.ReadLine(), out var idL) ? idL : 0;

            Console.Write("ID do Usuário: ");
            int idUsuario = int.TryParse(Console.ReadLine(), out var idU) ? idU : 0;

            var emprestimo = biblioteca.EmprestarLivro(idLivro, idUsuario);
            Console.WriteLine(emprestimo != null
                ? $"\nEmpréstimo realizado: {emprestimo}"
                : "\nNão foi possível realizar o empréstimo.");
            break;

        case "4":
            Console.Write("ID do Empréstimo: ");
            int idEmprestimo = int.TryParse(Console.ReadLine(), out var idE) ? idE : 0;

            bool devolvido = biblioteca.DevolverLivro(idEmprestimo);
            Console.WriteLine(devolvido
                ? "\nLivro devolvido com sucesso."
                : "\nEmpréstimo não encontrado ou já devolvido.");
            break;

        case "5":
            Console.WriteLine("\nLivros Disponíveis:");
            var disponiveis = biblioteca.ListarLivrosDisponiveis();
            disponiveis.ForEach(l => Console.WriteLine(l));
            break;

        case "6":
            Console.WriteLine("\nLivros Emprestados:");
            var emprestados = biblioteca.ListarLivrosEmprestados();
            emprestados.ForEach(l => Console.WriteLine(l));
            break;

        case "7":
            Console.WriteLine("\nUsuários:");
            var usuarios = biblioteca.ListarUsuarios();
            usuarios.ForEach(u => Console.WriteLine(u));
            break;

        case "8":
            Console.WriteLine("\nEmpréstimos:");
            var emprestimos = biblioteca.ListarEmprestimos();
            emprestimos.ForEach(e => Console.WriteLine(e));
            break;

        case "0":
            continuar = false;
            break;

        default:
            Console.WriteLine("\nOpção inválida.");
            break;
    }

    if (continuar)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
