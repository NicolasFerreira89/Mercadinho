using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Mercadinho
{
    class DAOEstoque
    {
        public MySqlConnection conexaoEstoque;
        public int[] codigoProduto;
        public string[] nomeProduto;
        public int[] quantidade;
        public double[] valorUni;
        public string dadosProduto;
        public string comando;
        public string resultado;
        public int p;
        public int contador;
        public string msg;

        public DAOEstoque()
        {
            conexaoEstoque = new MySqlConnection("server=localhost;DataBase=Mercadinho;Uid=root;Password=;");
            try
            {
                conexaoEstoque.Open();
                Console.WriteLine("Conectado com Sucesso!");
            }
            catch (Exception g)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + g);
                conexaoEstoque.Close();
            }
        }

        public void CadastrarProduto(string nomeProduto, int quantidade, double valorUni)
        {
            try
            {

                dadosProduto = "('','" + nomeProduto + "','" + quantidade + "','" + valorUni + "')";
                comando = "Insert into Produto(codigoProduto, nomeProduto, quantidade, valorUni) values" + dadosProduto;
                MySqlCommand sql = new MySqlCommand(comando, conexaoEstoque);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Produto Registrado!.");
            }
            catch (Exception p)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + p);


                Console.ReadLine();
            }
        }

        public void PreencherVetorProduto()
        {
            string query = "select * from Produto";


            codigoProduto = new int[100];
            nomeProduto = new string[100];
            quantidade = new int[100];
            valorUni = new double[100];

            for (p = 0; p < 100; p++)
            {
                codigoProduto[p] = 0;
                nomeProduto[p] = "";
                quantidade[p] = 0;
                valorUni[p] = 0;

            }
            MySqlCommand coletarProduto = new MySqlCommand(query, conexaoEstoque);

            MySqlDataReader leituraProduto = coletarProduto.ExecuteReader();

            p = 0;
            contador = 0;

            while(leituraProduto.Read())
            {
                codigoProduto[p] = Convert.ToInt32(leituraProduto["codigoProduto"]);
                nomeProduto[p] = leituraProduto["nomeProduto"] + "";
               quantidade[p] = Convert.ToInt32(leituraProduto["quantidade"]);
               valorUni[p] = Convert.ToInt32(leituraProduto["valor"]);
                p++;
                contador++;
            }

            leituraProduto.Close();
        }

        public string ConsultarProduto()
        {
            PreencherVetorProduto();
            msg = "";

            for (p =0; p < contador; p++)
            {
                msg += "Código do Produto: " + codigoProduto[p] +
                       ",Produtos: " + nomeProduto[p] +
                       ",Nome do Cliente: " + nomeCliente[p] +
                       ",CPF:" + cpfProduto[p] +
                       ","
                       ",Quantidade: " + quantidade[p] +
                       ",Valor Unitário:" + valorUni[p] +
                       "\n\n";
            }
            return msg;
        }

        public string ConsultarProduto(int cod)
        {
            if(codigoProduto[p] == cod )
            {
                msg = " Código do Produto: " + codigoProduto[p] +
                          ",Nome do Produto: " + nomeProduto[p] +
                          ",Quantidade: " + quantidade[p] +
                          ",Valor Unitário:" + valorUni[p] +
                          "\n\n";
                return msg;
            }
            return "Código do Produto Informado não encontrado!";
        }

        public string AtualizarProduto(int codigoProduto, string campo, string novoDado)
        {
            try
            {
                string query = "update Produto set " + campo + " = '" + novoDado + "'where codigoProduto = '" + codigoProduto + "'";
                MySqlCommand sql = new MySqlCommand(query, conexaoEstoque);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "Dados do Produto Atualizados!.";
            }
            catch(Exception p)
            {
                return "Algo deu Errado!\n\n" + p;
            }
        }

        public string DeletarProduto(int codigoProduto)
        {
            try
            {
                string query = "delete from Produto where codigoProduto = '" + codigoProduto + "'";
                MySqlCommand sql = new MySqlCommand(query, conexaoEstoque);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + ".";
            }
            catch (Exception p)
            {
                return "Algo deu Errado!\n\n" + p;
            }
        }
    } // FIM DA CLASSE \\
} // FIM DO PROJETO \\
