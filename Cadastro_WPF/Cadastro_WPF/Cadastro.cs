using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_WPF
{
    public class Cadastro<T>
    {
        private Dictionary<int, T> dados = new Dictionary<int, T>();

        public void Adicionar(int id, T item)
        {
            if (!dados.ContainsKey(id))
            {
                dados.Add(id, item);
                Console.WriteLine("Item adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro: Já existe um item com este ID.");
            }
        }

        public void Listar()
        {
            if (dados.Count == 0)
            {
                Console.WriteLine("A lista está vazia.");
                return;
            }

            foreach (var item in dados)
            {
                Console.WriteLine($"ID: {item.Key} | Dados: {item.Value}");
            }
        }

        public void Buscar(int id)
        {
            if (dados.TryGetValue(id, out T item))
            {
                Console.WriteLine($"Encontrado: {item}");
            }
            else
            {
                Console.WriteLine("Item não encontrado.");
            }
        }

        public void Remover(int id)
        {
            if (dados.Remove(id))
            {
                Console.WriteLine("Item removido com sucesso!");
            }
            else
            {
                Console.WriteLine("ID não encontrado para remoção.");
            }
        }

        public T ObterPorId(int id)
        {
            dados.TryGetValue(id, out T item);
            return item;
        }

        public Dictionary<int, T> ObterTodos()
        {
            return dados;
        }
    }
}
