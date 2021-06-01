using EmpresaXYZ.DAL;
using EmpresaXYZ.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmpresaXYZ.Test
{
    [TestClass]
    public class ClienteDALUnitTest
    {
        [TestMethod]
        public void Incluir()
        {
            var cliente = new Cliente();
            cliente.Nome = "Maria da Silva Teste01";
            cliente.Email = "Maria@teste.com.br";

            var dal = new ClienteDAL();
            int novoId = dal.Incluir(cliente);

            Assert.AreEqual(true, novoId > 0, @"O ID do cliente deveria ser um número maior que zero !");
        }

        [TestMethod]
        public void Listagem()
        {
            var dal = new ClienteDAL();
            var lista = dal.Listagem();

            Assert.AreEqual(true, lista.Count > 0, "Deve haver um cliente na lista");
        }
    }
}
