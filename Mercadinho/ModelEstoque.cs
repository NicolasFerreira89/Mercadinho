using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Mercadinho
{
    class ModelEstoque
    {
        public MySqlConnection notaFiscal;
        public string[] nomeCliente;
        public long[] CPF;
        public DateTime[] datadeCompra;
        public string[] produtos;
        public int quantidade;
        public double valorUni;
        public double valorTotal;




    } // FIM DA CLASSE \\
}// FIM DO PROJETO \\
