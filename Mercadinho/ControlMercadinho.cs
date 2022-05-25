using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho
{
    class ControlMercadinho
    {
        DAO conexao;
        DAOFuncionario conexaoFuncionario;
        public int opcao;
        public ControlMercadinho()
        {
            conexao = new DAO();
        } // FIM DO CONSTRUTOR \\

        public void Menu()
        {
            Console.WriteLine("Escolha  uma das opções abaixo: \n\n" + 
                              "1. Cadastrar Cliente\n" +
                              "2. Cadastrar Funcionário\n" +
                              "3. Atualizar Cliente\n" +
                              "4. Atualizar Funcionário\n" + 
                              "5. Excluir Cliente\n" + 
                              "6. Excluir Funcionário\n" + 
                              "0. Sair");
            opcao = Convert.ToInt32(Console.ReadLine());
        } // FIM DO MENU \\
         public void Executar()
        {
            Menu();
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe o nome do Cliente: ");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Informe o endereço do Cliente: ");
                    string endereco = Console.ReadLine();
                    Console.WriteLine("Informe o telefone do Cliente: ");
                    string telefone = Console.ReadLine();
                    conexao.InserirCliente(nome, endereco, telefone);
                    break;

                case 2:
                    Console.WriteLine("Informe o nome do Funcionário: ");
                    string nomeFun = Console.ReadLine();
                    Console.WriteLine("Informe o endereço do Funcionário: ");
                    string enderecoFun = Console.ReadLine();
                    Console.WriteLine("Informe a função  do Funcionário: ");
                    string funcao = Console.ReadLine();
                    Console.WriteLine("Informe o salário do Funcionário: ");
                    double salario = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Informe o sexo do Funcionário: ");
                    string sexo = Console.ReadLine();
                   conexaoFuncionario.InserirFuncionario(enderecoFun, funcao, salario, nomeFun, sexo);
                    break;
                default:
                    Console.WriteLine("Código informado Inválido!");
                    break;
            }
        }

    } // FIM DA CLASSE \\
} // FIM DO PROJETO \\
