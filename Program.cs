using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cassino
{
    class Program
    {
        private static double dinheiroTotal;
        private static double valorAposta;

        static void Main(string[] args)
        {
            int op = 1;
            Console.WriteLine("Bem vindo ao cassino!");
            Console.WriteLine("Informe seu nome completo ou apelido:");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe quanto dinheiro você tem.");
            dinheiroTotal = double.Parse(Console.ReadLine());
            while (op != 0)
            {
                Console.WriteLine("Escolha uma das opções abaixo:");
                Console.WriteLine("1 - Dados da conta");
                Console.WriteLine("2 - Jogos");
                Console.WriteLine("0 - Sair");

                op = int.Parse(Console.ReadLine());

                if (op == 0)
                {
                    Console.WriteLine("Saindo...");
                    break;
                }
                else if (op == 1)
                {
                    Console.WriteLine("Nome: " + nome);
                    Console.WriteLine("Saldo: " + dinheiroTotal);
                }
                else if (op == 2)
                {
                    SubmenuGames();
                }
                else
                {
                    Console.WriteLine("Opção inválida");

                }

            }
        }

        private static void SubmenuGames()
        {
            int op2 = 1;
            while (op2 != 0)
            {
                Console.WriteLine("Escolha uma das opções abaixo:");
                Console.WriteLine("1 - Dados");
                Console.WriteLine("2 - Roleta");
                Console.WriteLine("3 - Jackpot(Caça-níquel)");
                Console.WriteLine("0 - Voltar");

                op2 = int.Parse(Console.ReadLine());

                if (op2 == 0)
                {
                    Console.WriteLine("Voltando...");
                }
                else if (op2 == 1)
                {
                    SubmenuDados();
                }
                else if (op2 == 2)
                {
                    SubmenuRoleta();
                }
                else if (op2 == 3)
                {
                    SubmenuJackpot();
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            }
        }

        private static void SubmenuDados()
        {
            int op3 = 1;
            int numeroApostado;
            while (op3 != 0)
            {
                Console.WriteLine("Escolha uma das opções abaixo:");
                Console.WriteLine("1 - Dado de 4 lados");
                Console.WriteLine("2 - Dado de 6 lados");
                Console.WriteLine("3 - Dado de 8 lados");
                Console.WriteLine("0 - Voltar");

                op3 = int.Parse(Console.ReadLine());

                if (op3 == 0)
                {
                    Console.WriteLine("Voltando...");
                }
                else if (op3 == 1)
                //dado de 4 lados
                {
                    Console.WriteLine("Saldo: " + dinheiroTotal);
                    Console.WriteLine("Informe o valor da aposta:");
                    valorAposta = double.Parse(Console.ReadLine());
                    SubtrairDinheiro(valorAposta);

                    Console.WriteLine("Dado de 4 lados: você aposta certo valor e escolhe um número de um a quatro, se for esse o número que cair nos dados você ganha o dobro do valor que apostou");
                    numeroApostado = int.Parse(Console.ReadLine());
                    int numeroDado4 = new Random().Next(1, 5);

                    if (numeroApostado == numeroDado4)
                    {
                        Console.WriteLine("Você acertou");
                        Console.WriteLine("Você ganhou " + valorAposta * 2);
                        AdicionarDinheiro(valorAposta * 2);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                    else
                    {
                        Console.WriteLine("Você perdeu, o número que caiu foi " + numeroDado4);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                }
                else if (op3 == 2)
                //dado de 6 lados
                {
                    Console.WriteLine("Informe o valor da aposta:");
                    valorAposta = double.Parse(Console.ReadLine());
                    SubtrairDinheiro(valorAposta);

                    Console.WriteLine("Dado de 6 lados: você aposta certo valor e escolhe um número de um a seis, se for esse o número que cair nos dados você ganha o triplo do valor que apostou");
                    numeroApostado = int.Parse(Console.ReadLine());
                    int numeroDado6 = new Random().Next(1, 7);

                    if (numeroApostado == numeroDado6)
                    {
                        Console.WriteLine("Você acertou");
                        Console.WriteLine("Você ganhou " + valorAposta * 3);
                        AdicionarDinheiro(valorAposta * 3);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                    else
                    {
                        Console.WriteLine("Você perdeu, o número que caiu foi " + numeroDado6);
                        SubtrairDinheiro(valorAposta);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                }
                else if (op3 == 3)
                //dado de 8 lados
                {
                    Console.WriteLine("Informe o valor da aposta:");
                    valorAposta = double.Parse(Console.ReadLine());
                    SubtrairDinheiro(valorAposta);

                    Console.WriteLine("Dado de 8 lados: você aposta certo valor e escolhe um número de um a seis, se for esse o número que cair nos dados você ganha o quadruplo do valor que apostou");
                    numeroApostado = int.Parse(Console.ReadLine());
                    int numeroDado8 = new Random().Next(1, 9);

                    if (numeroApostado == numeroDado8)
                    {
                        Console.WriteLine("Você acertou");
                        Console.WriteLine("Você ganhou " + valorAposta * 4);
                        AdicionarDinheiro(valorAposta * 4);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                    else
                    {
                        Console.WriteLine("Você perdeu, o número que caiu foi " + numeroDado8);
                        SubtrairDinheiro(valorAposta);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            }

        }

        private static void SubmenuRoleta()
        {
            int op = 1;
            int numeroApostado;
            while (op != 0)
            {
                Console.WriteLine("Escolha uma das opções abaixo:");
                Console.WriteLine("1 - Aposta de cores(50% de chance) - prêmio menor(1,3x)");
                Console.WriteLine("2 - Aposta de números(10% de chance) - prêmio maior(10x)");
                Console.WriteLine("0 - Voltar");

                op = int.Parse(Console.ReadLine());

                if (op == 0)
                {
                    Console.WriteLine("Voltando...");
                }
                else if (op == 1)
                //aposta por cor
                {
                    Console.WriteLine("Saldo: " + dinheiroTotal);
                    Console.WriteLine("Informe o valor da aposta:");
                    valorAposta = double.Parse(Console.ReadLine());
                    SubtrairDinheiro(valorAposta);

                    Console.WriteLine("Aposta por cor: você aposta certo valor e escolhe uma cor, se for essa a cor que cair na roleta você ganha 30% a mais do valor que apostou");
                    Console.WriteLine("1 - Vermelho");
                    Console.WriteLine("2 - Preto");
                    numeroApostado = int.Parse(Console.ReadLine());
                    int cor = new Random().Next(1, 3);

                    if (numeroApostado == cor)
                    {
                        Console.WriteLine("Você acertou");
                        Console.WriteLine("Você ganhou " + valorAposta * 1.5);
                        AdicionarDinheiro(valorAposta * 1.5);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                    else if (numeroApostado != cor && cor == 1)
                    {
                        Console.WriteLine("Você perdeu, a cor que caiu foi Vermelho");
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                    else
                    {
                        Console.WriteLine("Você perdeu, a cor que caiu foi Preto");
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                }
                else if (op == 2)
                //Roleta de números
                {
                    Console.WriteLine("Informe o valor da aposta:");
                    valorAposta = double.Parse(Console.ReadLine());
                    SubtrairDinheiro(valorAposta);

                    int numeroRoleta = new Random().Next(1, 51);
                    Console.WriteLine("Essa roleta possui numeros de 1 a 50, você aposta certo valor em 5 números diferentes, se for um desses números que cair na roleta você ganha 10x o valor que apostou");
                    Console.WriteLine("O número que caiu foi " + numeroRoleta);

                    numeroApostado = int.Parse(Console.ReadLine());
                    int numeroApostado1 = int.Parse(Console.ReadLine());
                    int numeroApostado2 = int.Parse(Console.ReadLine());
                    int numeroApostado3 = int.Parse(Console.ReadLine());
                    int numeroApostado4 = int.Parse(Console.ReadLine());

                    if (numeroApostado == numeroRoleta || numeroApostado1 == numeroRoleta || numeroApostado2 == numeroRoleta || numeroApostado3 == numeroRoleta || numeroApostado4 == numeroRoleta)
                    {
                        Console.WriteLine("Você acertou");
                        Console.WriteLine("Você ganhou " + valorAposta * 10);
                        AdicionarDinheiro(valorAposta * 10);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                    else
                    {
                        Console.WriteLine("Você perdeu, o número que caiu foi " + numeroRoleta);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();

                    }
                }
            }
        }

        private static void SubmenuJackpot()
        {
            int op = 1;
            while (op != 0)
            {
                Console.WriteLine("Escolha uma das opções abaixo:");
                Console.WriteLine("1 - Jogar");
                Console.WriteLine("0 - Voltar");

                op = int.Parse(Console.ReadLine());

                if (op == 0)
                {
                    Console.WriteLine("Voltando...");
                }
                else if (op == 1)
                //Roleta de números
                {
                    Console.WriteLine("Informe o valor da aposta:");
                    valorAposta = double.Parse(Console.ReadLine());
                    SubtrairDinheiro(valorAposta);

                    int valor = new Random().Next(1, 101);

                    if (valor >= 100)
                    {
                        Console.WriteLine("Você ganhou um Jackpot");
                        Console.WriteLine("Você ganhou " + valorAposta * 20);
                        AdicionarDinheiro(valorAposta * 20);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                    else if (valor >= 95)
                    {
                        Console.WriteLine("Você acertou 3 setes");
                        Console.WriteLine("Você ganhou " + valorAposta * 10);
                        AdicionarDinheiro(valorAposta * 10);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                    else if (valor >= 80)
                    {
                        Console.WriteLine("Você acertou 3 cerejas");
                        Console.WriteLine("Você ganhou " + valorAposta * 4);
                        AdicionarDinheiro(valorAposta * 4);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                    else if (valor >= 60)
                    {
                        Console.WriteLine("Você acertou 3 simbolos em sequencia");
                        Console.WriteLine("Você ganhou " + valorAposta * 2);
                        AdicionarDinheiro(valorAposta * 2);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                    else if (valor >= 30)
                    {
                        Console.WriteLine("Você acertou dois simbolos iguais em sequencia");
                        Console.WriteLine("Você ganhou " + valorAposta * 1.5);
                        AdicionarDinheiro(valorAposta * 1.5);
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                    else
                    {
                        Console.WriteLine("Você não ganhou nada da aposta");
                        Console.WriteLine("Saldo: " + dinheiroTotal);
                        VerificarDinheiro();
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            }
        }

        public static void AdicionarDinheiro(double valor)
        {
            // Adiciona o valor a dinheiroTotal
            dinheiroTotal += valor;
        }

        public static void SubtrairDinheiro(double valor)
        {
            // Subtrai o valor de dinheiroTotal
            Console.WriteLine(valorAposta + " foi apostado e retirado de sua conta, boa sorte na aposta!");
            dinheiroTotal -= valor;
        }

        public static void VerificarDinheiro()
        {
            if (dinheiroTotal <= 0)
            {
                Console.WriteLine("Você não tem mais dinheiro para apostar, pobre");
                Environment.Exit(0);  // Encerra o programa
            }
        }
    }
}
