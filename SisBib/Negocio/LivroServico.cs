using SisBib.Data;
using SisBib.Models;

namespace SisBib.Negocio
{
// A BLL contém as REGRAS DE NEGÓCIO e validações
public class LivroService
{
private LivroRepository _repository = new LivroRepository();

public bool CadastrarLivro(string titulo, string autor, out string mensagemErro)
{
// Regra de Negócio 1: Campos obrigatórios
if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(autor))
{
mensagemErro = "Título e Autor são obrigatórios!";
return false;
}

// Regra de Negócio 2: Título precisa ter pelo menos 3 caracteres
if (titulo.Length < 3)
{
mensagemErro = "O título do livro deve ter no mínimo 3 caracteres.";
return false;
}

Livro novoLivro = new Livro
{
Titulo = titulo,
Autor = autor,
Emprestado = false
};

_repository.Adicionar(novoLivro);
mensagemErro = string.Empty;
return true;
}

public List<Livro> ListarAcervo()
{
return _repository.ObterTodos();
}
}
}