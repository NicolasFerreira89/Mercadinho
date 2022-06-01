using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Mercadinho
{
    class DAOFuncionario
    {
        public MySqlConnection conexaoFuncionario;
        public string dadosFuncionario;
        public string comando;
        public string resultado;
        public int contador;
        public int f;
        public string fixo;
        public double ConsultarVendas;
        public string[] nomeFun;
        public string[] enderecoFun;
        public string[] funcao;
        public string[] sexo;
        public double[] salario;
        public int[] codigo;
        public int[] horaTrabalhada;
        public string msg;

        public DAOFuncionario()
        {
            conexaoFuncionario = new MySqlConnection("server=localhost;DataBase=Mercadinho;Uid=root;Password=;");

            try
            {
                conexaoFuncionario.Open();
                Console.WriteLine("Conectado com Sucesso!");
            }
            catch (Exception g)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + g);
                conexaoFuncionario.Close();
            }
        }

        public void InserirFuncionario(string enderecoFun, string funcao, double salario, int horaTrabalhada, string nomeFun, string sexo)
        {
            try
            {
                dadosFuncionario = "('','" + enderecoFun + "','" + funcao + "','" + salario + "','" + horaTrabalhada + "','" + nomeFun + "','" + sexo + "')";
                comando = "Insert into Funcionario(codigo, endereco, funcao, salario, horaTrabalhada, nome, sexo) values" + dadosFuncionario;
                MySqlCommand sql = new MySqlCommand(comando, conexaoFuncionario);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Funcionário Cadastrado!.");
            }
            catch (Exception g)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + g);
                Console.ReadLine();
            }
        } // FIM DO INSERIR FUNCIONARIO \\


        public double ComissaoMensalista(double comissao, double vendas)
        {
            if (vendas <= 10000)
            {
                ConsultarVendas = (vendas * 5) / 100;
            }
            if (vendas > 10000)
            {
                ConsultarVendas = ((10000 * 5) / 100) + ((vendas - 10000) * 20) / 100;
            }
            return comissao + ConsultarVendas;
        }

        public int Horistas(int horaTrabalhada)
        {
            return horaTrabalhada * 60;
        }

        public void PreencherVetorFuncionario()
        {
            string query = "select * from Funcionario";

            codigo = new int[100];
            nomeFun = new string[100];
            enderecoFun = new string[100];
            funcao = new string[100];
            horaTrabalhada = new int[100];
            salario = new double[100];
            sexo = new string[100];

            for (f = 0; f < 100; f++)
            {
                codigo[f] = 0;
                nomeFun[f] = "";
                enderecoFun[f] = "";
                funcao[f] = "";
                horaTrabalhada[100] = 0;
                salario[f] = 0;
                sexo[f] = "";
            }
            MySqlCommand coletarFuncionario = new MySqlCommand(query, conexaoFuncionario);

            MySqlDataReader leituraFuncionario = coletarFuncionario.ExecuteReader();

            f = 0;
            contador = 0;
            while (leituraFuncionario.Read())
            {
                codigo[f] = Convert.ToInt32(leituraFuncionario["codigo"]);
                nomeFun[f] = leituraFuncionario["nome"] + "";
                enderecoFun[f] = leituraFuncionario["endereco"] + "";
                funcao[f] = leituraFuncionario["funcao"] + "";
                horaTrabalhada[f] = Convert.ToInt32(leituraFuncionario["horaTrabalhada"]);
                salario[f] = Convert.ToDouble(leituraFuncionario["salario"]) + 0;
                sexo[f] = leituraFuncionario["sexo"] + "";
                f++;
                contador++;
            }

            leituraFuncionario.Close();
        } // FIM DO PREECHER VETOR FUNCIONARIO \\

        public string ConsultarTudoFuncionario()
        {
            PreencherVetorFuncionario();
            msg = "";

            for(f =0; f < contador; f++)
            {
                msg += "Código: " + codigo[f] +
                       ",Nome do Funcionário: " + nomeFun[f] +
                       ",Endereço do Funcionário: " + enderecoFun[f] +
                       ",Função do Funcionário: " + funcao[f] +
                       ",Salário: " + salario[f] +
                       ",Horas Trabalhadas:" + horaTrabalhada[f] +
                       ",Sexo: " + sexo[f] +
                       "\n\n";

                
            }
            return msg;
        }

        public string ConsultarTudoFuncionario(int cod)
        {
            PreencherVetorFuncionario();
            for(int f=0; f < contador; f++)
            {
                if(codigo[f] == cod)
                {
                    msg = "Código: " + codigo[f] +
                       ",Nome do Funcionário: " + nomeFun[f] +
                       ",Endereço do Funcionário: " + enderecoFun[f] +
                       ",Função do Funcionário: " + funcao[f] +
                       ",Salário: " + salario[f] +
                        ",Horas Trabalhadas:" + horaTrabalhada[f] +
                       ",Sexo: " + sexo[f] +
                       "\n\n";

                    return msg;
                }
            }
            return "Código Informado não encontrado!";
        }

        public string AtualizarFuncionario(int codigo, string field, string newData)
        {
            try
            {
                string query = "update Funcionario set " + field + "='" + newData + "' where  codigo ='" + codigo + "'";
                MySqlCommand sql = new MySqlCommand(query, conexaoFuncionario);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "Dados Atualiazados!.";
            }
            catch (Exception g)
            {
                return "Algo deu Errado!\n\n" + g;
            }
        }

        public string DeletarFuncionario(int codigo)
        {
            try
            {
                string query = "delete from Funcionario where codigo ='" + codigo + "'";
                MySqlCommand sql = new MySqlCommand(query, conexaoFuncionario);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "Funcionário Excluído!.";
            }
            catch (Exception g)
            {
                return "Algo deu Errado!\n\n" + g;
            }
        }
    } // FIM DA CLASSE \\
} // FIM DO PROJETO \\
