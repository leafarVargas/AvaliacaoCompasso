using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Exercicio1
{
    public class Restaurante : Cardapio
    {

        static void Main(string[] args)
        {

            bool exibeMenu = true;
            while (exibeMenu)
            {
                exibeMenu = Menu();
            }

            int[] mesas = { 1, 2, 3, 4 };
            mesas[0] = 1;
            mesas[1] = 2;
            mesas[2] = 3;
            mesas[3] = 4;
        }
        
        private static bool Menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ PEDIDOS ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗    ");
            Console.WriteLine("║ 1 EFETUAR PEDIDO                              ║    ");
            Console.WriteLine("║ 2 SAIR                                        ║    ");
            Console.WriteLine("╚═══════════════════════════════════════════════╝    ");
            Console.WriteLine(" ");
            Console.Write("DIGITE UMA OPÇÃO : ");

            switch (Console.ReadLine())
            {
                case "1":

                    Console.WriteLine("CODIGO \t" + "PRODUTO \t" + "PREÇO \t");
                    MostrarCardapio();
                    Console.WriteLine(" ");
                    Console.WriteLine("DIGITE O NÚMERO DA MESA QUE DESEJA ESCOLHER ( ENTRE 1 E 4): ");
                    
                    int opc = int.Parse(Console.ReadLine());
                    bool exibecardapio = true;

                    var pedidos = new List<Pedido>();


                    while (exibecardapio)
                        {
                            Console.WriteLine("ESCOLHA SEU PRODUTO: (Digite 999 para concluir) ");
                            int prod = int.Parse(Console.ReadLine());

                            Console.WriteLine("DIGITE A QUANTIDADE: ");
                            int quant = int.Parse(Console.ReadLine());

                            
                            var item = new Pedido(opc, quant, prod);  

                            pedidos.Add(item);

                            Console.WriteLine(pedidos);
                            Console.ReadLine();

                            if (prod == 999)
                            {
                                return !exibecardapio;
                            }

                         }

                    return true;

                case "2":

                    return false;
                        
                
                default:
                    return true;
            }
        }
        private static void MostrarCardapio()
        {
            foreach (var cardapioList in cardapioLista())
            {
                Console.WriteLine(cardapioList.codigoProd + "\t" + cardapioList.descricaoProd + "\t R$ " + cardapioList.valorProd + "\t");
            }
        }
    }
}