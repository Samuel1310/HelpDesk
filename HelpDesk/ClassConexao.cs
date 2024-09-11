using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projetinho
{
    internal class ClassConexao
    {
        public static MySqlConnection conn;
        private static string conexao = "server=localhost;" +
                                        "database=projeto_helpdesk;" +
                                        "uid=root;" +
                                        "pwd=;" +
                                        "Convert Zero Datetime=true";


        public static bool Conectar()
        {
            try
            {
                conn = new MySqlConnection(conexao);
                conn.Open();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public static void Desconectar()
        {
            conn.Close();

        }



    }
}
