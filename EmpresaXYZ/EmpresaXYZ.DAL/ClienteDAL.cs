using EmpresaXYZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaXYZ.DAL
{
    public class ClienteDAL
    {
        //Incluir
        public int Incluir(Cliente cli)
        {
            string sql = @"INSERT INTO CLIENTES (NOME, EMAIL) VALUES (@NOME, @EMAIL); 
                           SELECT @@IDENTITY";
            int resultado = 0;
            using (var cmd = DbHelper.ObterCommand(sql))
            {
                cmd.Parameters.AddWithValue("@NOME", cli.Nome);
                cmd.Parameters.AddWithValue("@EMAIL", cli.Email);
                resultado = DbHelper.ExecuteScalarInt(cmd);
            }

            return resultado;
        }

        //Listagem
        public List<Cliente> Listagem()
        {
            string sql = @"SELECT CLIENTEID, NOME, EMAIL FROM CLIENTES";
            var lista = new List<Cliente>();

            using(var cmd = DbHelper.ObterCommand(sql))
            {
                using(var dr = DbHelper.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        lista.Add(new Cliente()
                        {
                            Nome = dr["Nome"].ToString(),
                            Email = dr["Email"].ToString(),
                            ClienteId = Convert.ToInt32(dr["ClienteId"])
                        });
                    }
                }
            }
            return lista;
        }



    }
}
