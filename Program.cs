using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

       static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
           
           string opcoes = opcaoDoUsuario();

            while(opcoes.ToUpper() != "X")
            {
                switch(opcoes){
                    case "1": 
                    ListarContas();
                    break;
                    case "2": 
                    InserirConta();
                    break;
                    case "3": 
                    Transferir();
                    break;
                    case "4": 
                    Sacar();
                    break;
                    case "5": 
                    Depositar();
                    break;
                    case "C":
                    Console.Clear();
                    break;
                    default:
                    throw new ArgumentOutOfRangeException();
            
                }
                opcoes = opcaoDoUsuario();
            }
            
            
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int entConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado:");
            double entSaque = double.Parse(Console.ReadLine());

            listaContas[entConta].Sacar(entSaque);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int entConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            double entSaque = double.Parse(Console.ReadLine());

            listaContas[entConta].Sacar(entSaque);
            
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da conta de origem: ");
            int entConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta destino: ");
            int entContaDestino = int.Parse(Console.ReadLine());


            Console.WriteLine("Digite o valor a ser transferido:");
            double entSaque = double.Parse(Console.ReadLine());

            listaContas[entConta].transferir(entSaque, listaContas[entContaDestino]);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.WriteLine("Digite 1 para Conta Física ou 2 para Conta Jurídica:");
            int entConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente:");
            string entNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo Inicial:");
            double entSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito Inicial:");
            double entCredito = double.Parse(Console.ReadLine());

            Conta conta = new Conta(tipoConta: (TipoConta)entConta, nome: entNome, saldo: entSaldo, credito: entCredito);
            listaContas.Add(conta);

        }

        private static void ListarContas()
        {
            if(listaContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada:");
                return;
            }

             foreach (Conta item in listaContas)
             {
                Console.Write("#{0} - ", listaContas.IndexOf(item));
                Console.WriteLine(item);
             }

        }

        private static string opcaoDoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank Online é nois q ta");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoDoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoDoUsuario;
        }
    }
}
