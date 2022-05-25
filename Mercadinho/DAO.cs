using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Mercadinho
{
    class DAO
    {
        public MySqlConnection conexao;
        public string dadosCliente;
        public string comando;
        public string resultado;
        public int contador;
        public int i;
        public string msg;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public int[] cpf;
       
        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=Mercadinho;Uid=root;Password=;");
            try
            {
                conexao.Open();
                Console.WriteLine("Conectado com Sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + e);
                conexao.Close();
            }
        }

        public void InserirCliente(string nome, string endereco, string telefone)
        {
            try { 

                dadosCliente = "('','" + nome + "','" + endereco + "','" + telefone + "')";
                comando = "Insert into Cliente(cpf, nome, endereco, telefone) values" + dadosCliente;
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Linhas Afetadas.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + e);
                Console.ReadLine();
            }
        }

        public void PreencherVetorCliente()
        {
            string query = "select * from Cliente";

            cpf = new int[100];
            nome = new string[100];
            endereco = new string[100];
            telefone = new string[100];

            for (i = 0; i < 100; i++)
            {
                cpf[i] = 0;
                nome[i] = "";
                endereco[i] = "";
                telefone[i] = "";
            }
            MySqlCommand coletarCliente = new MySqlCommand(query, conexao);

            MySqlDataReader leituraCliente = coletarCliente.ExecuteReader();

            i = 0;
            contador = 0;
            while (leituraCliente.Read())
            {
                cpf[i] = Convert.ToInt32(leituraCliente["cpf"]);
                nome[i] = leituraCliente["nome"] + "";
                telefone[i] = leituraCliente["telefone"] + "";
                endereco[i] = leituraCliente["endereco"] + "";
                i++;
                contador++;
            }

            leituraCliente.Close();
        } // FIM DO PREECHER VETOR CLIENTE \\ 

        public string ConsultarTudoCliente()
        {
            PreencherVetorCliente();
            msg = "";

            for(i =0; i < contador; i++)
            {
                msg += "CPF: " + cpf[i] +
                       ",Nome: " + nome[i] +
                       ",Endereço: " + endereco[i] +
                       ",Telefone:" + telefone[i] +
                       "\n\n";
            }
            return msg;
        } 
         public string ConsultarTudoCliente(int cod)
         {
            PreencherVetorCliente();
            for(int i=0; i < contador; i++)
            {
                if(cpf[i] == cod)
                {
                    msg = " CPF: " + cpf[i] +
                          ",Nome: " + nome[i] +
                          ", Endereço: " + endereco[i] +
                          ",Telefone: " + telefone[i] +
                          "\n\n";

                    return msg;
                }
            }

            return "CPF Informado não encontrado!";
         }
        public string AtualizarCliente(int cpf, string campo, string novoDado)
        {
            try
            {
                string query = "update Cliente set " + campo + " = '" + novoDado + "'where cpf = '" + cpf + "'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "Linha Afetada.";
            }
            catch (Exception e)
            {
                return "Algo deu Errado!\n\n" + e;
            }
        } // FIM DO ATUALIZAR CLIENTE \\

        public string DeletarCliente(int cpf)
        {
            try
            {
                string query = "delete from Cliente where cpf = '" + cpf + "'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "Linha Afetada.";
            }
            catch (Exception e)
            {
                return "Algo deu Errado!\n\n" + e;
            }
        }
    } // FIM DA CLASSE \\
} // FIM DO PROJETO \\
