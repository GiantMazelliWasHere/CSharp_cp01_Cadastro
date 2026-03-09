using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_WPF
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Idade: {Idade}";
        }
    }
}
