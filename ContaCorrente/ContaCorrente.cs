using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente
{
    public class ContaCorrente
    {
        public int numero { get; set; }
        public double saldo { get; set; }
        public bool especial { get; set; }
        public double limite { get; set; }
        public Movimentacao[] movimentacoes { get; set; }
        private int qtdMovimentacoes { get; set; }

        public ContaCorrente()
        {
            movimentacoes = new Movimentacao[100];
            qtdMovimentacoes = 0;
        }


        public void Depositar(double valor)
        {
            Movimentacao mov = new Movimentacao();
            mov.valor = valor;
            mov.tipo = "credito";
            movimentacoes[qtdMovimentacoes] = mov;
            qtdMovimentacoes++;
            saldo += valor;
        }

        public void Sacar(double valor)
        {
            if (valor <= limite + saldo)
            {
                Movimentacao mov = new Movimentacao();
                mov.valor = valor;
                mov.tipo = "debito";
                movimentacoes[qtdMovimentacoes] = mov;
                qtdMovimentacoes++;
                saldo -= valor;
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
            }
        }

        public double SaldoAtual()
        {
            Console.WriteLine($"Saldo na conta: R${saldo}");
            return saldo;
        }

        public void Extrato()
        {
            Console.WriteLine("Extrato:");
            for (int i = 0; i < qtdMovimentacoes; i++)
            {
                Console.WriteLine(movimentacoes[i].valor + " - " + movimentacoes[i].tipo);
            }
        }
        

        public void Transferir(ContaCorrente destino, double valor)
        {
            if (valor <= saldo)
            {
                Sacar(valor);
                destino.Depositar(valor);
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
            }
        }
    }
}
