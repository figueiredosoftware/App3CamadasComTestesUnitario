using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

namespace EmpresaXYZ.DAL
{
    internal class DbHelper
    {
        //String de Conexão
        public static string Conexao = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Alessandro\Projetos\Projetos Versionados\App3CamadasComTestesUnitario\EmpresaXYZ\EmpresaXYZ.Models\EmpresaXYZ.mdf';Integrated Security=True";

        //Abre a conexão se necessário
        private static void AbrirConexaoSeNecessario(DbCommand cmd)
        {
            if (cmd.Connection.State != System.Data.ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
        }

        //Metodo que retorna um Command
        public static SqlCommand ObterCommand(string sql)
        {
            var cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = new SqlConnection(Conexao);
            return cmd;
        }

        //Metodo que retorna o resultado de um Scalar quando é um inteiro
        public static int ExecuteScalarInt(DbCommand cmd)
        {
            AbrirConexaoSeNecessario(cmd);
            int resultado = Convert.ToInt32(cmd.ExecuteScalar());
            return resultado;
        }

        //Retorna um DataReader
        public static DbDataReader ExecuteReader(DbCommand cmd)
        {
            AbrirConexaoSeNecessario(cmd);
            DbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        //Execute NonQuery
        public static int ExecuteNonQuery(DbCommand cmd)
        {
            AbrirConexaoSeNecessario(cmd);
            int resultado = cmd.ExecuteNonQuery();
            return resultado;
        }

    }
}
