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
        DAOEstoque conexaoEstoque;
        public int opcao;
        public ControlMercadinho()
        {
            conexao = new DAO();
            conexaoFuncionario =  new DAOFuncionario();
            conexaoEstoque = new DAOEstoque();
        } // FIM DO CONSTRUTOR \\

        public void Menu()
        {
            Console.WriteLine("Escolha  uma das opções abaixo: \n\n" + 
                              "1. Cadastrar Cliente\n" +
                              "2. Cadastrar Funcionário\n" +
                              "3. Cadastrar Produto\n" +
                              "4. Atualizar Cliente\n" +
                              "5. Atualizar Funcionário\n" +
                              "6. Atualizar Produto\n" +
                              "7. Consultar Tudo Cliente\n" +
                              "8. Consultar Cliente por CPF\n" +
                              "9. Consultar Tudo Funcionário\n" +
                              "10. Consultar Funcionário por Código\n" +
                              "11. Consultar Todos os Produtos\n" +
                              "12.Consultar Produto por Código" +
                              "13. Excluir Cliente\n" + 
                              "14.Excluir Funcionário\n" + 
                              "15. Excluir Produto\n" +
                              "16. Consultar Carga horária Horista\n" +
                              "17. Consultar comissão do Gerente\n" +
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
                    Console.WriteLine("Informe a quantidade de hora trabalhada ");
                    int horaTrabalhada = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o sexo do Funcionário: ");
                    string sexo = Console.ReadLine();
                   conexaoFuncionario.InserirFuncionario(enderecoFun, funcao, salario, horaTrabalhada, nomeFun, sexo);
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
                    Console.WriteLine("Informe o nome do Produto: ");
                    string nomeProduto = Console.ReadLine();
                    Console.WriteLine("Informe a quantidade em estoque do Produto: ");
                    int quantidade = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o valor Unitário do Produto: ");
                    double valorUni = Convert.ToDouble(Console.ReadLine());
                    conexaoEstoque.CadastrarProduto(nomeProduto, quantidade, valorUni);
                    break;

                case 5: 
                    Console.WriteLine("Informr o campo do funcionario que deseja atualizar");
                    string field = Console.ReadLine();
                    Console.WriteLine("Informe o dado novo para esse campo: ");
                    string newData = Console.ReadLine();
                    Console.WriteLine("insira O Codigo que deseja Atualizar ");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexaoFuncionario.AtualizarFuncionario(codigo, field, newData));
                    break;

                case 6:
                    Console.WriteLine("Informar o campo do Produto que deseja atualizar");
                     campo = Console.ReadLine();
                    Console.WriteLine("Informe o dado novo para esse campo: ");
                     novoDado = Console.ReadLine();
                    Console.WriteLine("Insira o Codigo do Produto que deseja Atualizar ");
                    int codigoProduto = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexaoEstoque.AtualizarProduto(codigoProduto, campo, novoDado));
                    break;

                case 7:
                    Console.WriteLine(conexao.ConsultarTudoCliente());
                    break;

                case 8:
                    Console.WriteLine("Informe o CPF do cliente que deseja consultar.");
                    cpf = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexao.ConsultarTudoCliente(cpf));
                    break;

                case 9:
                    Console.WriteLine(conexaoFuncionario.ConsultarTudoFuncionario());
                    break;

                case 10:
                    Console.WriteLine("Informe o Código do Funcionário que deseja consultar.");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexaoFuncionario.ConsultarTudoFuncionario(codigo));
                    break;

                case 11:
                    Console.WriteLine(conexaoEstoque.ConsultarProduto());
                    break;

                case 12:
                    Console.WriteLine("Informe o Código do produto que deseja consultar.");
                    codigoProduto = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexao.ConsultarTudoCliente(codigoProduto));
                    break;

                case 13:
                    Console.WriteLine("Informe o CPF do Cliente que deseja apagar");
                    cpf = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexao.DeletarCliente(cpf));
                    break;

                case 14:
                    Console.WriteLine("Informe o Código do Funcionário que deseja apagar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexaoFuncionario.DeletarFuncionario(codigo));
                    break;

                case 15:
                    Console.WriteLine("Informe o Código do Produto que deseja apagar");
                    codigoProduto = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(conexaoEstoque.DeletarProduto(codigoProduto));
                    break;

                case 16:
                    Console.WriteLine("Informe a quantidade de horas trabalhadas ");
                    horaTrabalhada = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("O Funcionário vai receber: R$ " + conexaoFuncionario.Horistas(horaTrabalhada) + " por horas trabalhadas" );
                    break;

                case 17:
                    Console.WriteLine("Informe o vendido no mercado: ");
                     double vendas = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Informe o salário do Gerente: ");
                     double comissao = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("O total de comissao do gerente é de: R$" + conexaoFuncionario.ComissaoMensalista(comissao, vendas));
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
