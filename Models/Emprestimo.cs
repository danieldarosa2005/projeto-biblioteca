namespace BibliotecaConsole.Models
{
    public class Emprestimo
    {
        public int Id { get; private set; }
        public Livro Livro { get; private set; }
        public Usuario Usuario { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime? DataDevolucao { get; private set; }

        public Emprestimo(int id, Livro livro, Usuario usuario)
        {
            Id = id;
            Livro = livro;
            Usuario = usuario;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = null;
        }

        public void Devolver()
        {
            DataDevolucao = DateTime.Now;
            Livro.Devolver();
        }

        public override string ToString()
        {
            var status = DataDevolucao.HasValue ? $"Devolvido em {DataDevolucao}" : "Em andamento";
            return $"Empréstimo {Id}: {Livro.Titulo} para {Usuario.Nome} em {DataEmprestimo} - {status}";
        }
    }
}
