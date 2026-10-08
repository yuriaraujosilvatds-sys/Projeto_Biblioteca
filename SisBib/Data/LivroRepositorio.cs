using System.Collections.Generic;
using SisBib.Models;

namespace SisBib.Data
{
// A DAL APENAS armazena e recupera dados. Não faz validações nem imprime texto.
public class LivroRepository
{
private static List<Livro> _tabelaLivros = new List<Livro>();
private static int _proximoId = 1;

public void Adicionar(Livro livro)
{
livro.Id = _proximoId++;
_tabelaLivros.Add(livro);
}

public List<Livro> ObterTodos()
{
return _tabelaLivros;
}
}
}