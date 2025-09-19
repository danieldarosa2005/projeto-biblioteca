using BibliotecaConsole.Models;

namespace BibliotecaConsole.Services
{
    public class Biblioteca
    {
        private readonly List<Livro> _livros = new();
        private readonly List<Usuario> _usuarios = new();
        private readonly List<Emprestimo> _emprestimos = new();

        private int _contadorLivros = 1;
        private int _contadorUsuarios = 1;
        private int _contadorEmprestimos = 1;

        public Livro CadastrarLivro(string titulo, string autor, int ano)
        {
            var livro = new Livro(_contadorLivros++, titulo, autor, ano);
            _livros.Add(livro);
            return livro;
        }

        public Usuario CadastrarUsuario(string nome, string email)
        {
            var usuario = new Usuario(_contadorUsuarios++, nome, email);
            _usuarios.Add(usuario);
            return usuario;
        }

        public Emprestimo? EmprestarLivro(int idLivro, int idUsuario)
        {
            var livro = _livros.FirstOrDefault(l => l.Id == idLivro && l.Disponivel);
            var usuario = _usuarios.FirstOrDefault(u => u.Id == idUsuario);

            if (livro == null || usuario == null)
                return null;

            livro.Emprestar();
            var emprestimo = new Emprestimo(_contadorEmprestimos++, livro, usuario);
            _emprestimos.Add(emprestimo);
            return emprestimo;
        }

        public bool DevolverLivro(int idEmprestimo)
        {
            var emprestimo = _emprestimos.FirstOrDefault(e => e.Id == idEmprestimo && !e.DataDevolucao.HasValue);
            if (emprestimo == null) return false;

            emprestimo.Devolver();
            return true;
        }

        public List<Livro> ListarLivrosDisponiveis()
        {
            return _livros.Where(l => l.Disponivel).ToList();
        }

        public List<Livro> ListarLivrosEmprestados()
        {
            return _livros.Where(l => !l.Disponivel).ToList();
        }

        public List<Usuario> ListarUsuarios()
        {
            return _usuarios;
        }

        public List<Emprestimo> ListarEmprestimos()
        {
            return _emprestimos;
        }
    }
}
