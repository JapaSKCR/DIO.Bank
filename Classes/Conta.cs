using System;

namespace DIO.Bank
{
    public class Conta
    {

        private TipoConta tipoConta {get; set;}   
        private string nome {get; set;}
        private double saldo {get; set;}
        private double credito {get; set;}

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.tipoConta = tipoConta;
            this.nome = nome;
            this.credito = credito;
            this.saldo = saldo;

        }

        public bool Sacar(double saque)
        {
            if(this.saldo < saque && saque < (this.credito*-1) )
            {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.saldo -= saque;
            Console.WriteLine("Saldo atual de {0} é {1}", this.nome, this.saldo);
            return true;
        }

        public void depositar(double deposito)
        {
            this.saldo += deposito;
            Console.WriteLine("Saldo atual de {0} é {1}", this.nome, this.saldo);
        }

        public void transferir(double valor, Conta destino)
        {
            if(this.Sacar(valor))
            {
                destino.depositar(valor);
            }
           
        }

        public override string ToString(){
            
            string retorno = "";
            retorno += "TipoConta: " + this.tipoConta;
            retorno += " Nome: " + this.nome;
            retorno += " Saldo: " + this.saldo;
            retorno += " Crédito: " + this.credito;
            
            return retorno;

        }
    }
}