using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    public class Pedido
    {
        private int mesa { get; set; }
        private int quant { get; set; }
        private int produto { get; set; }

        public Pedido(int mesa, int quant, int produto)
        {
            this.mesa = mesa;
            this.quant = quant;
            this.produto = produto;
        }
    }
}
