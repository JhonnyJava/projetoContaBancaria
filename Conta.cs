using System;
namespace Conta.Bank
{
    class Conta
    {
        private TipoConta tipoConta {get; set;}
        private string nome { get; set; }
        private double saldo {get; set;}
        private double credito {get; set;}

        public Conta(TipoConta tipoDeConta, string nome, double saldoInicial, double creditoInicial)
        {
            this.tipoConta = tipoDeConta;
            this.nome = nome;
            this.saldo = saldoInicial;
            this.credito = creditoInicial;
        }

        public bool Sacar(double valor)
        {

            double valorDisponivelSaque = this.saldo + this.credito;
                if(valor > valorDisponivelSaque)
                {
                    Console.WriteLine("Saldo insuficiente!");
                    return false;
                }

                this.saldo -= valor;
                return true;
        }
        public void Depositar(double valor)
        {
            this.saldo += valor;

        }
        public void Transferir(double valor, Conta destino)
        {
            if(this.Sacar(valor))
            {
                destino.Depositar(valor);
            }
        }
        public override string ToString()
        {
            string retorno = "[ "; 
            retorno += this.tipoConta + " | ";
            retorno += "Nome: " + this.nome + " | ";
            retorno += "Saldo: " + this.saldo + " | ";
            retorno += "Credito: " + this.credito;
            retorno += " ]";

            return retorno;
        }

    }
}