using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    public class Produto
    {
        public int codigoProd { get; set; }
        public string descricaoProd { get; set; }
        public double valorProd { get; set; }

        public Produto(int codigoProd, string descricaoProd, double valorProd)
        {
            this.codigoProd = codigoProd;
            this.descricaoProd = descricaoProd;
            this.valorProd = valorProd;
        }
    }
}
