using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum FormaPagamento
//é uma abreviação de "enumeração". É uma estrutura de dados em C# que permite definir um conjunto de valores inteiros nomeados. 
//Em outras palavras, você pode criar um enum para representar um conjunto limitado de valores que um determinado conceito pode ter.
{
    Dinheiro,
    CartaoDebito,
    CartaoCredito,
    PIX
    
} //Esses são os valores do enum, também chamados de "enum members" ou membros do enum.

//A vantagem de usar um enum nesse contexto é que ele torna o código mais legível e ajuda a evitar erros de digitação,
//já que você pode usar esses nomes de enum em vez de números inteiros. Por exemplo, em vez de usar 1 para representar dinheiro e 2 para representar cartão de débito,
//você pode usar FormaPagamento.Dinheiro e FormaPagamento.CartaoDebito, o que torna o código mais claro e menos suscetível a erros.

namespace Loja
{
    
    class Program
    {
    //Estas linhas declaram variáveis estáticas , que é uma lista (ou coleção).
    //Essas listas são usadas para armazenar objetos dos tipos Produto e Venda ao longo da execução do programa.
    //Isso permite rastrear e manter um registro de produtos e vendas ao longo do tempo enquanto o programa é executado.
        static List<Produto> produtos = new List<Produto>();
        static List<Venda> vendas = new List<Venda>();
        static double saldo = 0;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White; // esta linha de código define a cor de fundo do console como branco 
            Console.ForegroundColor = ConsoleColor.DarkBlue; //esta linha de código define a cor do texto no console para azul escuro
            Console.WriteLine("\r\n ____  _  ____  _____  _____ _      ____    ____  ____    ____  _____ _          _  ____  ____  ____ \r\n/ ___\\/ \\/ ___\\/__ __\\/  __// \\__/|/  _ \\  /  _ \\/  _ \\  / ___\\/  __// \\ /\\     / |/  _ \\/  _ \\/  _ \\\r\n|    \\| ||    \\  / \\  |  \\  | |\\/||| / \\|  | | \\|| / \\|  |    \\|  \\  | | ||     | || / \\|| / \\|| / \\|\r\n\\___ || |\\___ |  | |  |  /_ | |  ||| |-||  | |_/|| \\_/|  \\___ ||  /_ | \\_/|  /\\_| || \\_/|| |-||| \\_/|\r\n\\____/\\_/\\____/  \\_/  \\____\\\\_/  \\|\\_/ \\|  \\____/\\____/  \\____/\\____\\\\____/  \\____/\\____/\\_/ \\|\\____/\r\n                                                                                                     \r\n");
            
            bool continuarCadastrando = true;

    while (continuarCadastrando) // loop
    {
        MostrarMenu();
        int escolha = int.Parse(Console.ReadLine());

        switch (escolha) //estrutura de controle chamada switch, que é usada para tomar decisões com base no valor de escolha.
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
                
            default: //para lidar com escolhas que não correspondem a nenhum dos casos específicos.
            
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
        //static void: é um método estático que não retorna um valor e não aceita parâmetros.
        //Geralmente, esse tipo de método é usado para realizar uma ação específica, 
        //como exibir um menu na tela para interação do usuário, como escolher opções em um programa.
        //indica que o método MostrarMenu não retorna nenhum valor quando é executado.
        //Isso significa que o método não produz um resultado que seja retornado quando é chamado.
        //Em vez disso, ele pode executar ações, mas não retorna um valor.
        //MostrarMenu()é usado para identificar e chamar o método quando necessário.
    
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
            //Esta linha cria uma nova instância da classe Produto e a atribui à variável novoProduto.
            //O construtor da classe Produto é chamado neste momento e recebe quatro argumentos.
            //O método .Add é um método que pertence à lista (ou coleção) e é usado para inserir um elemento nela.
            //gerenciam inventários, catálogos ou qualquer situação em que você precise manter uma coleção de objetos para posterior acesso e manipulação.

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
            
            //produtos: é uma lista (ou uma coleção) que contém elementos,
            //Count é uma propriedade que retorna o número de elementos atualmente na lista.
        {
            Produto produto = produtos[escolha];
            Console.Write("\n Quantidade de " + produto.Nome + " a ser vendida: ");
            int quantidadeVendida = int.Parse(Console.ReadLine());

            double valorTotal = quantidadeVendida * produto.Preco; // Declare a variável aqui

            Console.Write("\n Escolha a forma de pagamento (1 - Dinheiro: , 2 - Cartão de Débito: , 3 - Cartão de Crédito: , 4 - PIX: ): ");
            int formaPagamento = int.Parse(Console.ReadLine());

            Console.Write("\n Quantidade de parcelas (1 a 12): ");
            int numeroParcelas = int.Parse(Console.ReadLine());

            Venda novaVenda = new Venda
        {
            Produto = produto.Nome,
            ValorTotal = valorTotal,
            FormaPagamento = (FormaPagamento)formaPagamento,
            NumeroParcelas = numeroParcelas
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

            // Atualizar o saldo (deduzir o valor da compra)
            saldo -= (preco * quantidade);

            Console.Write("\n Escolha a forma de pagamento (1 - Dinheiro: , 2 - Cartão de Débito: , 3 - Cartão de Crédito: , 4 - PIX: ): ");
            int formaPagamento = int.Parse(Console.ReadLine());

            if (formaPagamento == 3) // Se a forma de pagamento for Cartão de Crédito, pergunte o número de parcelas
                {
                    Console.Write("\n Quantidade de parcelas (1 a 12): ");
                    int numeroParcelas = int.Parse(Console.ReadLine());

                    // Armazenar a compra com forma de pagamento e parcelas
                    Venda novaCompra = new Venda
                {
                    Produto = novoProduto.Nome,
                    ValorTotal = (preco * quantidade),
                    FormaPagamento = (FormaPagamento)formaPagamento,
                    NumeroParcelas = numeroParcelas
                };

                vendas.Add(novaCompra);
                }
            else
            {
                // Armazenar a compra com forma de pagamento sem parcelas
                Venda novaCompra = new Venda
            {       
                Produto = novoProduto.Nome,
                ValorTotal = (preco * quantidade),
                FormaPagamento = (FormaPagamento)formaPagamento,
                NumeroParcelas = 1 // Defina o número de parcelas como 1 para compras que não são a crédito.
            };

                vendas.Add(novaCompra);
            }

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
                // Código para processar cada elemento da coleção vendas,
                // usando a variável venda para acessar o elemento atual.
                // Essa é a palavra-chave que inicia o loop foreach. 
                //Ela indica que você deseja executar um bloco de código para cada elemento em uma coleção 
                //(neste caso, a coleção é representada por vendas).
            {
                Console.WriteLine("Produto: " + venda.Produto + ", Valor: " + venda.ValorTotal.ToString("F2") + " Reais, Forma de Pagamento: " + venda.FormaPagamento + ", Parcelas: " + venda.NumeroParcelas);
            //.ToString("F2"): é uma formatação que converte o valor em uma string formatada com duas casas decimais (formato de ponto flutuante com precisão de duas casas). 
            //Isso garante que o valor seja exibido com duas casas decimais, por exemplo, "50.00" em vez de "50".
            }
        } 


        static void ListarProdutos()
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + produtos[i].Nome + " - Marca: " + produtos[i].Marca + " - Preço: R$ " + produtos[i].Preco.ToString("F2") + " - Estoque: " + produtos[i].Quantidade);
            //(i + 1): i é uma variável de loop. Geralmente, i é usada como um índice para percorrer a lista produtos.
            //A expressão (i + 1) está sendo usada para mostrar o número da posição do produto na lista. 'i' ajusta essa posição para começar em 1.
            //Portanto, esta linha está formatando e exibindo informações sobre um produto, incluindo sua posição na lista, nome, marca e preço em reais. É uma maneira comum de listar produtos ou itens em um programa, onde cada linha representa um produto específico com detalhes formatados. 
            
            }
        }
    }
        class Venda
    {
        public string Produto { get; set; }
        public double ValorTotal { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public int NumeroParcelas { get; set; }
        
        //Piblic: é um modificador de acesso que indica a visibilidade de classes, métodos, propriedades e outros membros dentro de um programa.
        //ele pode ser acessado e usado de fora da classe, ou seja, de outros lugares do programa, incluindo outras classes e partes do código.
        //No contexto de uma propriedade, get é usado para obter o valor da propriedade,
        //e set é usado para definir o valor da propriedade
    }


        class Produto
    {
        public int NumeroSerie { get; private set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        private static int proximoNumeroSerie = 1;
        //Private: só pode ser acessada dentro da classe em que foi declarada. 
        //Ela não pode ser acessada diretamente de fora da classe.
        //= 1: Isso é uma inicialização da variável. Ele define o valor inicial da variável proximoNumeroSerie como 1.

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
