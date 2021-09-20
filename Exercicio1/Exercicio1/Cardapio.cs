using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    public class Cardapio
    {
        public static List<Produto> cardapioLista()
        {
            var cardapioList = new List<Produto>();

            var cachorroQuente = new Produto(100, "Cachorro Quente", 5.70);
            cardapioList.Add(cachorroQuente);

            var xCompleto = new Produto(101, "X - Completo", 18.30);
            cardapioList.Add(xCompleto);

            var xSalada = new Produto(102, "X - Salada", 16.50);
            cardapioList.Add(xSalada);

            var hamburguer = new Produto(103, "Hamburguer", 22.40);
            cardapioList.Add(hamburguer);

            var cocaCola = new Produto(104, "Coca 2L     ", 10.00);
            cardapioList.Add(cocaCola);

            var refri = new Produto(105, "Refrigerante", 1.0);
            cardapioList.Add(refri);

            return cardapioList;
        }

        
    }

}
