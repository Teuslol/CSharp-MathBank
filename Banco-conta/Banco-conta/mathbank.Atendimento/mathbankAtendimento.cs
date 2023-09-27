using Banco_conta.mathbank.Exceptions;
using Banco_conta.mathbank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Banco_conta.mathbank.Atendimento
{
    internal class mathbankAtendimento
    {
        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>(){
          new ContaCorrente(95, "123456-X"){Saldo=100,Titular = new Cliente{Cpf="11111",Nome ="Gabi"}},
          new ContaCorrente(95, "951258-X"){Saldo=200,Titular = new Cliente{Cpf="22222",Nome ="Teus"}},
          new ContaCorrente(94, "987321-W"){Saldo=60,Titular = new Cliente{Cpf="33333",Nome ="Snoop"}}
        };
        public void AtendimentoCliente()
        {
            try
            {


                char opcao = '0';
                while (opcao != '6')
                {
                    Console.Clear();
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("--- Atendimento               ---");
                    Console.WriteLine("--- 1 - Cadastrar             ---");
                    Console.WriteLine("--- 2 - Listar Contas         ---");
                    Console.WriteLine("--- 3 - Remover Conta         ---");
                    Console.WriteLine("--- 4 - Ordenar Contas        ---");
                    Console.WriteLine("--- 5 - Pesquisar Conta       ---");
                    Console.WriteLine("--- 6 - Sair do Sistema       ---");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Digite a opção desejada: ");

                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception excecao)
                    {
                        throw new MathBankException(excecao.Message);
                    }

                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarContas();
                            break;
                        case '3':
                            RemoverContas();
                            break;
                        case '4':
                            OrdenarContas();
                            break;
                        case '5':
                            PesquisarContas();
                            break;
                        case '6':
                            EncerrarAplicacao();
                            break;
                        default:
                            Console.WriteLine("Opção não Implementada");
                            break;
                    }
                }
            }
            catch (MathBankException excecao)
            {
                Console.WriteLine($"{excecao.Message}");
            }
        }


            private void CadastrarConta()
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---      Cadastrar Conta      ---");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("\n");
                Console.WriteLine("== Informe Dados da Conta ==");

                Console.Write("Número da Agência: ");
                int numeroAgencia = int.Parse(Console.ReadLine());
                ContaCorrente conta = new ContaCorrente(numeroAgencia);

                Console.WriteLine($"Número da conta [NOVA] : {conta.Conta}");
                Console.Write("Informe o saldo inicial: ");
                conta.Saldo = double.Parse(Console.ReadLine());

                Console.Write("Informe nome do Titular: ");
                conta.Titular.Nome = Console.ReadLine();

                Console.Write("Infome CPF do Titular: ");
                conta.Titular.Cpf = Console.ReadLine();

                Console.Write("Infome Profissão do Titular: ");
                conta.Titular.Profissao = Console.ReadLine();

                _listaDeContas.Add( conta );
                Console.WriteLine("... Conta Cadastrada com Sucesso! ...");
                Console.ReadKey();


            }

            private void ListarContas()
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---       Listar Contas       ---");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("\n");
                if (_listaDeContas.Count <= 0)
                {
                    Console.WriteLine("... Não há contas Cadastradas! ...");
                    Console.ReadKey();
                    return;
                }
                foreach (ContaCorrente item in _listaDeContas)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                    Console.ReadKey();
                }
            }

            private void RemoverContas()
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("---      Remover Contas       ---");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("\n");

                Console.Write("Informe o número da Conta: ");
                string numeroConta = Console.ReadLine();
                ContaCorrente conta = null ;
                foreach (var item in _listaDeContas)
                {
                    if (item.Conta.Equals(numeroConta))
                    {
                        conta = item;
                    }
                }
                if (conta != null)
                {
                    _listaDeContas.Remove(conta);
                    Console.WriteLine(".. Conta Removida! ..");
                }
                else
                {
                    Console.WriteLine(".. Conta para remoção não encontrada ..");
                }
                Console.ReadKey ();


            }

            private void OrdenarContas()
            {
                _listaDeContas.Sort();
                Console.WriteLine(".. Lista de contas ordenadas ..");
                Console.ReadKey();
            }

            private void PesquisarContas()
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===    PESQUISAR CONTAS     ===");
                Console.WriteLine("===============================");
                Console.WriteLine("\n");
                Console.Write("Deseja pesquisar por (1) NÚMERO DA CONTA ou (2)CPF TITULAR ou " +
                    " (3) Nº AGÊNCIA : ");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            Console.Write("Informe o número da Conta: ");
                            string _numeroConta = Console.ReadLine();
                            ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                            Console.WriteLine(consultaConta.ToString());
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Informe o CPF do Titular: ");
                            string _cpf = Console.ReadLine();
                            ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                            Console.WriteLine(consultaCpf.ToString());
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Write("Informe o Nº da Agência: ");
                            int _numeroAgencia = int.Parse(Console.ReadLine());
                            var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);
                            ExibirListaDeContas(contasPorAgencia);
                            Console.ReadKey();
                            break;
                        }
                    default:
                        Console.WriteLine("Opção não implementada.");
                        break;
                }

            }



            private void EncerrarAplicacao()
            {
                Console.WriteLine("... Encerrando a aplicação ...");
                Console.ReadKey();
            }


            private ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
            {
                return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
            }

            private ContaCorrente ConsultaPorCPFTitular(string? cpf)
            {
                return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
            }

            private List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
            {
                var consulta = (from conta in _listaDeContas where conta.Numero_agencia == numeroAgencia select conta).ToList();
                return consulta;
            }

            private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
            {
                if(contasPorAgencia == null)
                {
                    Console.WriteLine(".. A consulta não Retornou Contas ..");
                }
                else
                {
                    foreach (var item in contasPorAgencia)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }





    }
}


