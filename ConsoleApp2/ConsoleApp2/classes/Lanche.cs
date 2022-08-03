using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.classes
{
    public class Lanche
    {
        public Lanche() {}

        public int Codigo { get; set; }
        public string Especificacao { get; set; }
        public double Preco { get; set; }

        public Lanche(int codigo, string especificacao, double preco)
        {
            this.Codigo = codigo;
            this.Especificacao = especificacao;
            this.Preco = preco;
        }
    }
}
