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
        public string[] nomeFun;
        public string[] enderecoFun;
        public string[] funcao;
        public string[] sexo;
        public double[] salario;
        public int[] codigo;
        public string msg;

        public DAOFuncionario()
        {
            conexaoFuncionario = new MySqlConnection("server=localhost;DataBase=Mercadinho;Uid=root;Password=;");

            try
            {
                conexaoFuncionario.Open();
                Console.WriteLine("Conectado com Sucesso!");
            }
            catch(Exception f)
            {
                Console.WriteLine("Algo deu Errado!\n\n" + f);
                conexaoFuncionario.Close();
            }
        }
    }
}
