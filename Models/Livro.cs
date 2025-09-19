namespace BibliotecaConsole.Models
{
    public class Livro
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public int Ano { get; private set; }
        public bool Disponivel { get; private set; }

        public Livro(int id, string titulo, string autor, int ano)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Disponivel = true;
        }

        public void Emprestar()
        {
            Disponivel = false;
        }

        public void Devolver()
        {
            Disponivel = true;
        }

        public override string ToString()
        {
            return $"{Id} - {Titulo} ({Autor}, {Ano}) - {(Disponivel ? "Disponível" : "Emprestado")}";
        }
    }
}
