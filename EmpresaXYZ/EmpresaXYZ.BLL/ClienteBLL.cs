using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpresaXYZ.BLL;
using EmpresaXYZ.Models;
using EmpresaXYZ.DAL;

namespace EmpresaXYZ.BLL
{
    public class ClienteBLL
    {
        public int Incluir(Cliente cli)
        {
            Validar(cli);
            var dal = new ClienteDAL();
            return dal.Incluir(cli);
        }

        public List<Cliente> Listagem()
        {
            var dal = new ClienteDAL();
            return dal.Listagem();
        }

        private void Validar(Cliente cli)
        {
            if (string.IsNullOrEmpty(cli.Nome))
            {
                throw new Exception("O nome deve ser informado");
            }
        }
    }
}
