using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    public class Cadastro<T>
    {
        private Dictionary<int, T> dados = new Dictionary<int, T>();
        private int proximoId = 1;

        public void Adicionar(T item)
        {
            dados.Add(proximoId, item);
            Console.WriteLine($"Item adicionado com sucesso! (ID gerado: {proximoId})");
            proximoId++;
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
    }

}
