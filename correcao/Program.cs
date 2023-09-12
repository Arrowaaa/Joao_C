using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum FormaPagamento
{
    Dinheiro,
    CartaoDebito,
    CartaoCredito,
    PIX
}

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
                int escolha;

                while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 5)
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    MostrarMenu();
                }

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
                        continuarCadastrando = false;
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
            Console.Write("\n Deseja Regressar ao MENU? (s/n): ");
            string resposta = Console.ReadLine().ToLower();

            while (resposta != "s" && resposta != "n")
            {
                Console.WriteLine("Resposta inválida. Por favor, responda com 's' ou 'n'.");
                Console.Write("\n Deseja Regressar ao MENU? (s/n): ");
                resposta = Console.ReadLine().ToLower();
            }

            Console.Clear();
            return resposta == "s";
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

            double preco;
            while (!double.TryParse(Console.ReadLine(), out preco) || preco <= 0)
            {
                Console.WriteLine("Preço inválido. Insira um valor válido.");
                Console.Write("\n Preço do Produto (RS): ");
            }

            int quantidade;
            while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 1)
            {
                Console.WriteLine("Quantidade inválida. Insira um valor válido.");
                Console.Write("\n Quantidade do Produto: ");
            }

            Produto novoProduto = new Produto(nome, marca, preco, quantidade);
            produtos.Add(novoProduto);

            Console.WriteLine("\n Total pago pelo Produto: R$: " + (preco * quantidade).ToString("F2") + " Reais.");
            Console.WriteLine("\n Produto cadastrado com sucesso!");
        }

        static void VenderProduto()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" VENDA DE PRODUTO: ");

            int formaPagamento;
            while (!int.TryParse(Console.ReadLine(), out formaPagamento) || formaPagamento < 1 || formaPagamento > 4)
            {
                Console.WriteLine("Opção de pagamento inválida. Tente novamente.");
                Console.Write("\n Escolha a forma de pagamento (1 - Dinheiro, 2 - Cartão de Débito, 3 - Cartão de Crédito, 4 - PIX): ");
            }

            Console.WriteLine("\n Lista de Produtos Disponíveis:");
            ListarProdutos();

            int escolhaProduto;
            while (!int.TryParse(Console.ReadLine(), out escolhaProduto) || escolhaProduto < 1 || escolhaProduto > produtos.Count)
            {
                Console.WriteLine("Produto inválido. Escolha um produto válido.");
                Console.Write("\n Escolha o número do produto a ser vendido: ");
            }

            Produto produto = produtos[escolhaProduto - 1];
            Console.Write("\n Quantidade de " + produto.Nome + " a ser vendida: ");
            int quantidadeVendida;
            
            while (!int.TryParse(Console.ReadLine(), out quantidadeVendida) || quantidadeVendida < 1 || quantidadeVendida > produto.Quantidade)
            {
                Console.WriteLine("Quantidade inválida. Insira uma quantidade disponível.");
                Console.Write("\n Quantidade de " + produto.Nome + " a ser vendida: ");
            }

            double valorTotal = quantidadeVendida * produto.Preco;

            switch ((FormaPagamento)formaPagamento)
            {
                case FormaPagamento.Dinheiro:
                    double valorPago;
                    
                    while (true)
                    {
                        Console.Write("\n Digite o valor pago em dinheiro: ");
                        if (double.TryParse(Console.ReadLine(), out valorPago) && valorPago >= valorTotal)
                            break;
                        
                        Console.WriteLine("Valor insuficiente ou inválido. Insira um valor válido.");
                    }

                    double troco = valorPago - valorTotal;
                    Console.WriteLine("\n Troco: R$: " + troco.ToString("F2") + " Reais.");

                    produto.Quantidade -= quantidadeVendida;
                    saldo += valorTotal;
                    break;

                case FormaPagamento.CartaoDebito:
                    // Simule uma autorização do cartão de débito (pode ser uma chamada a um serviço externo)
                    bool autorizado = SimularAutorizacaoCartaoDebito();

                    if (autorizado)
                    {
                        produto.Quantidade -= quantidadeVendida;
                        saldo += valorTotal;

                        Console.WriteLine("\n Pagamento com Cartão de Débito autorizado.");
                    }
                    else
                    {
                        Console.WriteLine("\n Pagamento com Cartão de Débito não autorizado. Transação cancelada.");
                    }
                    break;

                case FormaPagamento.CartaoCredito:
                    Console.Write("\n Digite o número de parcelas (1 a 12): ");
                    int numeroParcelas;

                    while (!int.TryParse(Console.ReadLine(), out numeroParcelas) || numeroParcelas < 1 || numeroParcelas > 12)
                    {
                        Console.WriteLine("Número de parcelas inválido. Insira um número válido.");
                        Console.Write("\n Digite o número de parcelas (1 a 12): ");
                    }

                    Venda novaVendaCredito = new Venda
                    {
                        Produto = produto.Nome,
                        ValorTotal = valorTotal,
                        FormaPagamento = (FormaPagamento)formaPagamento,
                        NumeroParcelas = numeroParcelas
                    };

                    vendas.Add(novaVendaCredito);

                    produto.Quantidade -= quantidadeVendida;
                    saldo += valorTotal;

                    Console.WriteLine("\n Venda com Cartão de Crédito autorizada.");
                    break;

                case FormaPagamento.PIX:
                    double valorPagoPIX;

                    while (true)
                    {
                        Console.Write("\n Digite o valor pago via PIX: ");
                        if (double.TryParse(Console.ReadLine(), out valorPagoPIX) && valorPagoPIX >= valorTotal)
                            break;

                        Console.WriteLine("Valor insuficiente ou inválido. Insira um valor válido.");
                    }

                    produto.Quantidade -= quantidadeVendida;
                    saldo += valorTotal;

                    Console.WriteLine("\n Venda com PIX realizada com sucesso.");
                    break;

                default:
                    Console.WriteLine("\n Opção de pagamento não reconhecida.");
                    break;
            }

            MostrarMenu();
        }

        static void ComprarProduto()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n COMPRAR PRODUTO: ");

            Console.Write("\n Nome do Produto: ");
            string nome = Console.ReadLine();

            Console.Write("\n Marca do Produto: ");
            string marca = Console.ReadLine();

            double preco;
            while (!double.TryParse(Console.ReadLine(), out preco) || preco <= 0)
            {
                Console.WriteLine("Preço inválido. Insira um valor válido.");
                Console.Write("\n Preço do Produto (RS): ");
            }

            int quantidade;
            while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 1)
            {
                Console.WriteLine("Quantidade inválida. Insira um valor válido.");
                Console.Write("\n Quantidade do Produto: ");
            }

            Produto novoProduto = new Produto(nome, marca, preco, quantidade);
            produtos.Add(novoProduto);

            saldo -= (preco * quantidade);

            Console.Write("\n Escolha a forma de pagamento (1 - Dinheiro, 2 - Cartão de Débito, 3 - Cartão de Crédito, 4 - PIX): ");
            int formaPagamento;

            while (!int.TryParse(Console.ReadLine(), out formaPagamento) || formaPagamento < 1 || formaPagamento > 4)
            {
                Console.WriteLine("Opção de pagamento inválida. Tente novamente.");
                Console.Write("\n Escolha a forma de pagamento (1 - Dinheiro, 2 - Cartão de Débito, 3 - Cartão de Crédito, 4 - PIX): ");
            }

            Console.WriteLine("\n Total a pagar: R$: " + (preco * quantidade).ToString("F2") + " Reais.");

            if ((FormaPagamento)formaPagamento == FormaPagamento.CartaoCredito)
            {
                int numeroParcelas;
                while (!int.TryParse(Console.ReadLine(), out numeroParcelas) || numeroParcelas < 1 || numeroParcelas > 12)
                {
                    Console.WriteLine("Número de parcelas inválido. Insira um número válido (1 a 12).");
                    Console.Write("\n Quantidade de parcelas (1 a 12): ");
                }

                Venda novaCompraCredito = new Venda
                {
                    Produto = novoProduto.Nome,
                    ValorTotal = (preco * quantidade),
                    FormaPagamento = (FormaPagamento)formaPagamento,
                    NumeroParcelas = numeroParcelas
                };

                vendas.Add(novaCompraCredito);
            }
            else
            {
                Venda novaCompra = new Venda
                {
                    Produto = novoProduto.Nome,
                    ValorTotal = (preco * quantidade),
                    FormaPagamento = (FormaPagamento)formaPagamento,
                    NumeroParcelas = 1
                };

                vendas.Add(novaCompra);
            }

            Console.WriteLine("\n Compra realizada com sucesso!");
            MostrarMenu();
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
                Console.WriteLine("\n Produto: " + venda.Produto + ", Valor: " + venda.ValorTotal.ToString("F2") + " Reais, Forma de Pagamento: " + venda.FormaPagamento + "," + " Parcelas: " + venda.NumeroParcelas);
            }
        }

        static void ListarProdutos()
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + produtos[i].Nome + " - Marca: " + produtos[i].Marca + " - Preço: R$ " + produtos[i].Preco.ToString("F2") + " - Estoque: " + produtos[i].Quantidade);
            }
        }

        static bool SimularAutorizacaoCartaoDebito()
        {
            // Simulação de autorização do cartão de débito.
            // Neste exemplo, sempre retorna verdadeiro para simular uma autorização bem-sucedida.
            return true;
        }
    }

    class Produto
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        public Produto(string nome, string marca, double preco, int quantidade)
        {
            Nome = nome;
            Marca = marca;
            Preco = preco;
            Quantidade = quantidade;
        }
    }

    class Venda
    {
        public string Produto { get; set; }
        public double ValorTotal { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public int NumeroParcelas { get; set; }
    }
}
