using Cadastro;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cadastro<Pessoa> cadastroPessoas = new Cadastro<Pessoa>();
            bool rodando = true;

            while (rodando)
            {
                Console.WriteLine("\n--- MENU DE CADASTRO ---");
                Console.WriteLine("1 - Adicionar");
                Console.WriteLine("2 - Listar");
                Console.WriteLine("3 - Buscar");
                Console.WriteLine("4 - Remover");
                Console.WriteLine("5 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite o Nome Completo: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite a Idade: ");
                        int idade = int.Parse(Console.ReadLine());


                        cadastroPessoas.Adicionar(new Pessoa { Nome = nome, Idade = idade });
                        break;

                    case "2":
                        cadastroPessoas.Listar();
                        break;

                    case "3":
                        Console.Write("Digite o ID para buscar: ");
                        int idBusca = int.Parse(Console.ReadLine());
                        cadastroPessoas.Buscar(idBusca);
                        break;

                    case "4":
                        Console.Write("Digite o ID para remover: ");
                        int idRemover = int.Parse(Console.ReadLine());
                        cadastroPessoas.Remover(idRemover);
                        break;

                    case "5":
                        rodando = false;
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}