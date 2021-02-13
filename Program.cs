using System;
using System.Collections.Generic;

namespace Conta.Bank
{
    class Program
    {
        private static void RealizaSaque(List<Conta> contas)
        {
            Console.WriteLine("Digite o numero da conta: ");
            int contaOrigem = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o valor que deseja sacar: ");
            double valor = Double.Parse(Console.ReadLine());

            Conta conta1 = contas[contaOrigem];
            conta1.Sacar(valor);
        }

        private static void RealizarDeposito(List<Conta> contas)
        {
            Console.WriteLine("Informe a conta de Destino: ");
            int contaDestino = int.Parse(Console.ReadLine());
             Console.WriteLine("Informe o valor que deseja depositar: ");
            double valor = Double.Parse(Console.ReadLine());
            Conta conta = contas[contaDestino];
            conta.Sacar(valor);
        }
        public static void ListarContas(List<Conta> contas)
        {
            Conta conta;
            Console.Clear();
            if (contas.Count != 0)
            {
                for (int i = 0; i < contas.Count; i++)
                {
                    conta = contas[i];
                    Console.WriteLine($"{i} - " + conta.ToString());
                }
            }
            Console.Write("Aperte qualquer tela...");
            Console.ReadKey();

        }

        public static void InserirConta(List<Conta> contas)
        {
            Console.WriteLine("Digite 1 para pessoa Fisica ou 2 para pessoa Juridica: ");
            int tipoInformado = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Defina o saldo Inicial: ");
            double valorInformado = Double.Parse(Console.ReadLine());
            Console.WriteLine("Defina o credito inicial: ");
            double creditoInformado = Double.Parse(Console.ReadLine());

            Conta conta = new Conta((TipoConta)tipoInformado, nome, valorInformado, creditoInformado);
            contas.Add(conta);
        }
        private static void Transferir(List<Conta> contas)
        {
            Console.WriteLine("Digite a conta de origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a conta destino: ");
            int contaDestino = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o valor: ");
            double valor = Double.Parse(Console.ReadLine());
            Conta conta1 = contas[contaOrigem];
            Conta conta2 = contas[contaDestino];
            conta1.Transferir(valor, conta2);
        }
        static void Main(string[] args)
        {
            List<Conta> contas = new List<Conta>();
            string opccaoUsuario = obterOpcaoUsuario();
            while(opccaoUsuario.ToUpper() != "X")
            {
                switch (opccaoUsuario)
                {
                    case "1":
                    //Listar Contas
                    ListarContas(contas);
                    break;
                    //inserir nova Conta
                    case "2":
                    InserirConta(contas);
                    break;
                    //Transferir
                    case "3":
                    Transferir(contas);
                    break;
                    //Realizar Saque
                    case "4":
                    RealizaSaque(contas);
                    break;
                    case "5":
                    RealizarDeposito(contas);
                    break;
                    case "C":
                    Console.Clear();
                    break;
                    case "X":
                    break;
                    default:
                    break;
                }
                opccaoUsuario = obterOpcaoUsuario();
            }
            
        }


        public static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Banco 1.0");
            Console.WriteLine("Imforme a opção desejada: ");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("x - Sair");
            Console.WriteLine();
            string opccaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opccaoUsuario;
        }
    }
}