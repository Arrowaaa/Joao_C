using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace correcao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string produto = "", marca = "";
            float preco = 0;
            double compra1, compra2, compra3, valor1 = 5, valor2 = 6, valor3 = 3, valorpago1;
            double valorpago2, valorpago3, troco1, troco2, troco3, precototal, precototal2, precototal3;
            int menu, quantidade2 = 10, quantidade3 = 10;
            string produto1 = "Coxinha", produto2 = "Pão", produto3 = "Suco";
            int quantidade = 0;
            string loop = "s";
            string loop2 = "s";
            float saldo = 0; // Saldo total inicial



            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\r\n ____  _  ____  _____  _____ _      ____    ____  ____    ____  _____ _          _  ____  ____  ____ \r\n/ ___\\/ \\/ ___\\/__ __\\/  __// \\__/|/  _ \\  /  _ \\/  _ \\  / ___\\/  __// \\ /\\     / |/  _ \\/  _ \\/  _ \\\r\n|    \\| ||    \\  / \\  |  \\  | |\\/||| / \\|  | | \\|| / \\|  |    \\|  \\  | | ||     | || / \\|| / \\|| / \\|\r\n\\___ || |\\___ |  | |  |  /_ | |  ||| |-||  | |_/|| \\_/|  \\___ ||  /_ | \\_/|  /\\_| || \\_/|| |-||| \\_/|\r\n\\____/\\_/\\____/  \\_/  \\____\\\\_/  \\|\\_/ \\|  \\____/\\____/  \\____/\\____\\\\____/  \\____/\\____/\\_/ \\|\\____/\r\n                                                                                                     \r\n");
            Console.ResetColor();



            while (loop == "s")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;



                Console.WriteLine("Welcome Sr.");
                Console.WriteLine("MENU: ");
                Console.WriteLine("1 - Cadastrar novo Produto: ");
                Console.WriteLine("2 - Realizar venda de produto: ");
                Console.WriteLine("3 - Realizar compra de produto: ");
                Console.WriteLine("4 - Gerar relatório do produto: ");
                Console.Write("Escolha a Opção: ");
                menu = int.Parse(Console.ReadLine());
                Console.Clear();



                if (menu == 1)
                {
                    while (loop2 == "s")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;



                        Console.WriteLine("\n CADASTRAR: ");


                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n Qual é o Produto que deseja cadastrar? ");
                        produto = Console.ReadLine();



                        Console.Write("\n Qual a marca do produto ? ");
                        marca = Console.ReadLine();



                        Console.Write("\n Qual é o preço do produto ? ");
                        preco = float.Parse(Console.ReadLine());



                        Console.Write("\n Qual é a quantidade do produto ? ");
                        quantidade = int.Parse(Console.ReadLine());



                        Console.WriteLine("\nO produto cadastrado foi: ");
                        Console.WriteLine("Produto: " + produto);
                        Console.WriteLine("Marca: " + marca);
                        Console.WriteLine("Quantidade: " + quantidade);
                        Console.WriteLine("Preço: " + preco);




                        Console.Write("Deseja Fazer um novo cadastro ? (s/n) ");

                        loop2 = Console.ReadLine();
                        Console.Clear();
                    }
                }
                else if (menu == 2)
                {


                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("VENDER: ");

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write("\nInforme o valor da venda: ");
                    float valorVenda = float.Parse(Console.ReadLine());

                    if (valorVenda == 1)
                    {
                        int quantidade1 = 10;

                        Console.WriteLine("\n Produto: " + produto1 + "\n Valor: " + valor1);
                        Console.Write("\nQual é a quantidade de " + produto1 + ": ");
                        compra1 = int.Parse(Console.ReadLine());


                        // Realize a lógica de venda aqui
                        if (compra1 <= quantidade)
                        {

                            precototal = compra1 * quantidade1;
                            Console.WriteLine("Valor total a pagar: R$: " + precototal + " Reais.");

                            Console.WriteLine("\nQual o valor recebido? ");
                            valorpago1 = float.Parse(Console.ReadLine());

                            if (valorpago1 < precototal)
                            {
                                Console.WriteLine("Valor Insuficiente!");
                            }
                            else if (valorpago1 > precototal)
                            {
                                troco1 = valorpago1 - precototal;
                                Console.WriteLine("Seu troco " + troco1);
                            }
                            else if (valorpago1 == precototal)
                            {
                                Console.WriteLine("Compra Finalizada!");
                            }
                        }
                    }

                    else if (valorVenda == 2)
                      {


                            Console.WriteLine("\n Produto: " + produto2 + "\n Valor: " + valor2);
                            Console.Write("\nQual é a quantidade de " + produto2 + ": ");
                            compra2 = int.Parse(Console.ReadLine());

                            if (compra2 <= quantidade2)
                            {

                                precototal2 = compra2 * quantidade2;
                                Console.WriteLine("Valor total a pagar: R$: " + precototal2 + " Reais.");

                                Console.WriteLine("\nQual o valor recebido? ");
                                valorpago2 = float.Parse(Console.ReadLine());

                                if (valorpago2 < precototal2)
                                {
                                    Console.WriteLine("Valor Insuficiente!");
                                }
                                else if (valorpago2 > precototal2)
                                {
                                    troco2 = valorpago2 - precototal2;
                                    Console.WriteLine("Seu troco " + troco2);
                                }
                                else if (valorpago2 == precototal2)
                                {
                                    Console.WriteLine("Compra Finalizada!");
                                }
                            }
                        }

                        if (valorVenda == 3)
                        {
                            Console.WriteLine("\n Produto: " + produto3 + "\n Valor: " + valor3);
                            Console.Write("\nQual é a quantidade de " + produto3 + ": ");
                            compra3 = int.Parse(Console.ReadLine());

                            if (compra3 <= quantidade3)
                            {

                                precototal3 = compra3 * quantidade3;
                                Console.WriteLine("Valor total a pagar: R$: " + precototal3 + " Reais.");

                                Console.WriteLine("\nQual o valor recebido? ");
                                valorpago3 = float.Parse(Console.ReadLine());

                                if (valorpago3 < precototal3)
                                {
                                    Console.WriteLine("Valor Insuficiente!");
                                }
                                else if (valorpago3 > precototal3)
                                {
                                    troco3 = valorpago3 - precototal3;
                                    Console.WriteLine("Seu troco " + troco3);
                                }
                                else if (valorpago3 == precototal3)
                                {
                                    Console.WriteLine("Compra Finalizada!");
                                }
                            }



                            else if (menu == 3)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("COMPRAR: ");

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Informe o valor da compra: ");
                                float valorCompra = float.Parse(Console.ReadLine());



                                // Realize a lógica de compra aqui
                                quantidade++; // Aumente a quantidade de produtos
                                saldo += valorCompra; // Atualize o saldo
                                Console.WriteLine("Compra realizada com sucesso!");
                            }
                            else if (menu == 4)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("Você Escolheu gerar um Relatório do Produto: ");

                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine("Produto: " + produto);
                                Console.WriteLine("Marca: " + marca);
                                Console.WriteLine("Estoque: " + quantidade);
                                Console.WriteLine("Valor: " + preco);
                                Console.WriteLine("Saldo total: " + saldo);
                            }
                            else
                            {

                                Console.WriteLine("Opção inválida. Escolha uma opção válida do menu.");

                            }

                            Console.Write("Deseja Regressar ao MENU? (s/n) ");
                            loop = Console.ReadLine();
                            Console.Clear();



                            //ToUpper Converte todos os strimer em Maiusculo.
                            //ToLower Converte todos os strimer em Menusculo.
                            //While Comando de loop
                            //Console.ForegroundColor = ConsoleColor.DarkRed; // Altera a cor da fontes
                        }
                        Console.ReadKey();
                    }
                }
            }
        }
    }

        
    
