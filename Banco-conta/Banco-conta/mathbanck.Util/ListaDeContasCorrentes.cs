using Banco_conta.mathbank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco_conta.mathbanck.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao = 0;

        public ListaDeContasCorrentes(int tamanhoInicial=5)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar(ContaCorrente item)
        {
            Console.WriteLine($"Adicionar item na posição {_proximaPosicao}");
            VerificarCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if(_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("Aumentando a capacidade da lista!");
            ContaCorrente[] novoArrey = new ContaCorrente[tamanhoNecessario];

            for(int i = 0; i < _itens.Length; i++)
            {
                novoArrey[i] = _itens[i];
            }
            _itens = novoArrey;
        }

        public void Remover (ContaCorrente conta)
        {
            int indiceItem = -1;
            for(int i=0; i < _proximaPosicao;i++)
            {
                ContaCorrente contaAtual = _itens[i];
                if(contaAtual == conta)
                {
                    indiceItem = i; 
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao; i++)
            {
                _itens[i] = _itens[i+1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;

        }

        public void ExibeLista()
        {
            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    var conta = _itens[i];
                    Console.WriteLine($" Indice[{i}] = " +
                        $"Conta:{conta.Conta} - " +
                        $"N° da Agência: {conta.Numero_agencia}");
                }
            }
        }


        public ContaCorrente RecuperarContaNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return RecuperarContaNoIndice(indice);
            }
        }

    }
}
