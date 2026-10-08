using System;
using System.Collections.Generic;
using SisBib.Business;
using SisBib.Models;

namespace SisBib.UI
{
public class MenuConsole
{
private LivroService _livroService = new LivroService();

public void ExibirMenu()
{
bool rodando = true;

while (rodando)
{
Console.Clear();
Console.WriteLine("-
-SISTEMA DE BIBLIOTECA ESCOLAR ---");
Console.WriteLine("1
Cadastrar Novo Livro");
Console.WriteLine("2
Listar Coleção");
Console.WriteLine("0
Sair");
Console.Write("Escolha uma opção: ");
string opcao = Console.ReadLine();

switch (opcao)
{
case "1":
ExecutarCadastro();
break;
case "2":
ExecutarListagem();
break;
case "0":
rodando = false;
Console.WriteLine("Encerrando o sistema...");
break;
default:
Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar.");
Console.ReadKey();
break;
}
}
}

private void ExecutarCadastro()
{
Console.Clear();
Console.WriteLine("-
-CADASTRO DE LIVRO ---");
Console.Write("Título do Livro: ");
string titulo = Console.ReadLine();

Console.Write("Autor do Livro: ");
string autor = Console.ReadLine();

// Chama a camada de negócio
bool sucesso = _livroService.CadastrarLivro(titulo, autor, out string mensagem);

if (sucesso)
{
Console.WriteLine("Livro cadastrado com sucesso!");
}
else
{
Console.WriteLine($"Erro ao cadastrar: {mensagem}");
}

Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
Console.ReadKey();
}

private void ExecutarListagem()
{
Console.Clear();
Console.WriteLine("-
-ACERVO DA BIBLIOTECA ---");
List<Livro> acervo = _livroService.ListarAcervo();

if (acervo.Count == 0)
{
Console.WriteLine("Nenhum livro cadastrado até o momento.");
}
else
{
foreach (var livro in acervo)
{
string status = livro.Emprestado ? "[Emprestado]" : "[Disponível]";
Console.WriteLine($"ID: {livro.Id} | Título: {livro.Titulo} | Autor: {livro.Autor} | Status: {status}");
}
}

Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
Console.ReadKey();
}
}
}