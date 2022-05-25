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
            conexaoFuncionario =  new DAOFuncionario(); 
        } // FIM DO CONSTRUTOR \\

        public void Menu()
        {
            Console.WriteLine("Escolha  uma das opções abaixo: \n\n" + 
                              "1. Cadastrar Cliente\n" +
                              "2. Cadastrar Funcionário\n" +
                              "3. Atualizar Cliente\n" +
                              "4. Atualizar Funcionário\n" +
                              "5. Consultar Tudo Cliente\n" +
                              "6. Consultar Cliente por CPF\n" +
                              "7. Consultar Tudo Funcionário\n" +
                              "8. Consultar Funcionário por Código\n" +
                              "9. Excluir Cliente\n" + 
                              "10.Excluir Funcionário\n" + 
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

                case 3:
                    Console.WriteLine("Informe o Campo que deseja atualizar");
                    string campo = Console.ReadLine();
                    Console.WriteLine("Informe o dado Novo Para esse campo: ");
                    string novoDado = Console.ReadLine();
                    Console.WriteLine("Insorme O Codigo que deseja  Atualzar ");
                    int cpf  = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexao.AtualizarCliente(cpf, campo, novoDado));
                    break;

                case 4: 
                    Console.WriteLine("Informr o campo do funcionario que deseja atualizar");
                    string field = Console.ReadLine();
                    Console.WriteLine("Informe o dado novo para esse campo: ");
                    string newData = Console.ReadLine();
                    Console.WriteLine("insira O Codigo que deseja Atualizar ");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexaoFuncionario.AtualizarFuncionario(codigo, field, newData));
                    break;

                case 5:
                    Console.WriteLine(conexao.ConsultarTudoCliente());
                    break;

                case 6:
                    Console.WriteLine("Informe o CPF do cliente que deseja consultar.");
                    cpf = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexao.ConsultarTudoCliente(cpf));
                    break;

                case 7:
                    Console.WriteLine(conexaoFuncionario.ConsultarTudoFuncionario());
                    break;

                case 8:
                    Console.WriteLine("Informe o Código do Funcionário que deseja consultar.");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexaoFuncionario.ConsultarTudoFuncionario(codigo));
                    break;

                case 9:
                    Console.WriteLine("Informe o CPF que deseja apagar");
                    cpf = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexao.DeletarCliente(cpf));
                    break;

                case 10:
                    Console.WriteLine("Informe o Código que deseja apagar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexaoFuncionario.DeletarFuncionario(codigo));
                    break;

                case 0:
                    Console.WriteLine("Obrigado!");
                    break;
                default:
                    Console.WriteLine("Código informado Inválido!");
                    break;

            }
        }

    } // FIM DA CLASSE \\
} // FIM DO PROJETO \\
