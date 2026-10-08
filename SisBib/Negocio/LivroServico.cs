using SisBib.Data
using SisBib.Models;
namespace SisBib.Negocio;

{
    // A BLL contém as REGRAS DE NEGÓCIO e validações

    public class LivroService

{
    
    private LivroRepositorio_repository = new LivroRepositorio();
    public bool CadastrarLivro(string titulo, string autor, out string mensagemErro)
    {
        // Regra de Negócio 1: Campos Obrigatórios

        if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
        {
            mensagemErro = "Título e Autor são obrigatórios!";
            return false;
        }

        // Regra de Negócio 2: Título precisa ter ao menos 3 caracteres

        if (titulo.Length < 3)
        {
            mensagemErro = "O título do livro deve ter no mínimo 3 carcateres.";
            return false;
        }
        Livro novoLivro = new Livro
        {
            Titulo = titulo,
            Autor = autor,
            Emprestado = false
        };
        _repository.Adicinar(novoLivro);
        mensagemErro = string.Empty;
        return true;
    }
    public List <Livro> ListarAcervo()
    {
        return_repository.ObterTodos();
    }

    
}
}