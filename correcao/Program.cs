using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    
    class Program
    {
        
        static List<Produto> produtos = new List<Produto>();
        static List<Venda> vendas = new List<Venda>();
        static double saldo = 0;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\r\n ____  _  ____  _____  _____ _      ____    ____  ____    ____  _____ _          _  ____  ____  ____ \r\n/ ___\\/ \\/ ___\\/__ __\\/  __// \\__/|/  _ \\  /  _ \\/  _ \\  / ___\\/  __// \\ /\\     / |/  _ \\/  _ \\/  _ \\\r\n|    \\| ||    \\  / \\  |  \\  | |\\/||| / \\|  | | \\|| / \\|  |    \\|  \\  | | ||     | || / \\|| / \\|| / \\|\r\n\\___ || |\\___ |  | |  |  /_ | |  ||| |-||  | |_/|| \\_/|  \\___ ||  /_ | \\_/|  /\\_| || \\_/|| |-||| \\_/|\r\n\\____/\\_/\\____/  \\_/  \\____\\\\_/  \\|\\_/ \\|  \\____/\\____/  \\____/\\____\\\\____/  \\____/\\____/\\_/ \\|\\____/\r\n                                                                                                     \r\n");
            
            bool continuarCadastrando = true;

    while (continuarCadastrando)
    {
        MostrarMenu();
        int escolha = int.Parse(Console.ReadLine());

        switch (escolha)
        {
            case 1:
            
                CadastrarProduto();
                continuarCadastrando = PerguntarContinuarCadastrando();
                break;
            case 2:
            
                VenderProduto();
                continuarCadastrando = PerguntarContinuarCadastrando();
                break;
            case 3:
            
                ComprarProduto();
                continuarCadastrando = PerguntarContinuarCadastrando();
                break;
            case 4:
            
                GerarRelatorio();
                continuarCadastrando = PerguntarContinuarCadastrando();
                break;
            case 5:
            
                Console.Clear();
                continuarCadastrando = false; // Sair do loop e encerrar o programa
                break;
            default:
            
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
            }
        }
    }

static bool PerguntarContinuarCadastrando()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("\n Deseja Regressar ao MENU ? (s/n): ");
            string resposta = Console.ReadLine().ToLower(); // Converte a resposta para minúsculas

            if (resposta == "s")
        {
            Console.Clear(); // Limpa o console
            return true;
        }
        else if (resposta == "n")
        {
            Console.Clear();
            return true; // continuar executando o programa

        }
        else
        {
            Console.WriteLine("Resposta inválida. Por favor, responda com 's' ou 'n'.");
            return PerguntarContinuarCadastrando(); // Chama novamente a função se a resposta for inválida
        }
    }

        static void MostrarMenu()
    
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nMENU: ");
            Console.WriteLine("\n 1 - Cadastrar novo Produto");
            Console.WriteLine(" 2 - Realizar venda de produto");
            Console.WriteLine(" 3 - Realizar compra de produto");
            Console.WriteLine(" 4 - Gerar relatório do produto");
            Console.WriteLine(" 5 - Sair do programa");
            Console.Write("\nEscolha a Opção: ");
            
        }   

        static void CadastrarProduto()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n CADASTRAR PRODUTO: ");

            Console.Write("\n Nome do Produto: ");
            string nome = Console.ReadLine();

            Console.Write("\n Marca do Produto: ");
            string marca = Console.ReadLine();

            Console.Write("\n Preço do Produto: RS: ");
            double preco = double.Parse(Console.ReadLine());

            Console.Write("\n Quantidade do Produto: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto novoProduto = new Produto(nome, marca, preco, quantidade);
            produtos.Add(novoProduto);

            Console.WriteLine("\n Produto cadastrado com sucesso!");
            
        }
        
         static void VenderProduto()
{
    
    Console.Clear();
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine(" VENDA DE PRODUTO: ");

    Console.WriteLine("\n Lista de Produtos Disponíveis:");
    ListarProdutos();

    Console.Write("\n Escolha o número do produto a ser vendido: ");
    int escolha = int.Parse(Console.ReadLine()) - 1;

    if (escolha >= 0 && escolha < produtos.Count)
    {
        Produto produto = produtos[escolha];
        Console.Write("\n Quantidade de " + produto.Nome + " a ser vendida: ");
        int quantidadeVendida = int.Parse(Console.ReadLine());

        double valorTotal = quantidadeVendida * produto.Preco; // Declare a variável aqui

        Console.Write("\n Escolha a forma de pagamento (1 - Dinheiro, 2 - Cartão, 3 - Outra): ");
        int formaPagamento = int.Parse(Console.ReadLine());

        Venda novaVenda = new Venda
        {
            Produto = produto.Nome,
            ValorTotal = valorTotal,
            FormaPagamento = formaPagamento == 1 ? "Dinheiro" : (formaPagamento == 2 ? "Cartão" : "Outra")
        };

        vendas.Add(novaVenda); // Adiciona a venda à lista de vendas

        if (quantidadeVendida <= produto.Quantidade)
        {
            Console.WriteLine("\n Total a pagar: R$: " + valorTotal.ToString("F2") + " Reais.");

            Console.Write("\n Digite o valor pago: ");
            double valorPago = double.Parse(Console.ReadLine());

            if (valorPago >= valorTotal)
            {
                double troco = valorPago - valorTotal;
                Console.WriteLine("\n Troco: R$: " + troco.ToString("F2") + " Reais.");

                produto.Quantidade -= quantidadeVendida;
                saldo += valorTotal;
                Console.WriteLine("\n Venda concluída com sucesso!");
            }
            else
            {
                Console.WriteLine("\n Valor insuficiente para a compra.");
            }
        }
        else
        {
            Console.WriteLine(" Quantidade insuficiente de " + produto.Nome + " em estoque.");
        }
    }
    else
    {
        Console.WriteLine("\n Produto não encontrado.");
    }
}
          static void ComprarProduto()
          {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n COMPRAR PRODUTO: ");

            Console.Write("\n Nome do Produto: ");
            string nome = Console.ReadLine();

            Console.Write("\n Marca do Produto: ");
            string marca = Console.ReadLine();

            Console.Write("\n Preço do Produto: RS: ");
            double preco = double.Parse(Console.ReadLine());

            Console.Write("\n Quantidade do Produto: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto novoProduto = new Produto(nome, marca, preco, quantidade);
            produtos.Add(novoProduto);

            saldo -= (preco * quantidade); // Atualizar saldo
            Console.WriteLine("\n Compra realizada com sucesso!");
        }

        static void GerarRelatorio()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n RELATÓRIO: ");
            ListarProdutos();

            Console.WriteLine("\n Saldo Total de R$: " + saldo + " Reais.");

            Console.WriteLine("\n Histórico de Vendas:");
            
            foreach (var venda in vendas)
            {
                Console.WriteLine("Produto: " + venda.Produto + ", + Valor: " + venda.ValorTotal.ToString("F2") + " Reais, Forma de Pagamento: " + venda.FormaPagamento);
            }
        }


        static void ListarProdutos()
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + produtos[i].Nome + " - Marca: " + produtos[i].Marca + " - Preço: R$ " + produtos[i].Preco.ToString("F2") + " - Estoque: " + produtos[i].Quantidade);

            }
        }
    }
        class Venda
        {
            public string Produto { get; set; }
            public double ValorTotal { get; set; }
            public string FormaPagamento { get; set; }
        }

        class Produto
         {
            public int NumeroSerie { get; private set; }
            public string Nome { get; set; }
            public string Marca { get; set; }
            public double Preco { get; set; }
            public int Quantidade { get; set; }

            private static int proximoNumeroSerie = 1;

            public Produto(string nome, string marca, double preco, int quantidade)
        {
            
            NumeroSerie = proximoNumeroSerie++;
            Nome = nome;
            Marca = marca;
            Preco = preco;
            Quantidade = quantidade;
        }
    }
}
