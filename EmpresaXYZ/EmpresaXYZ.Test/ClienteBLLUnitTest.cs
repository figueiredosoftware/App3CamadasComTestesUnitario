using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmpresaXYZ.Models;
using EmpresaXYZ.BLL;

namespace EmpresaXYZ.Test
{
    [TestClass]
    public class ClienteBLLUnitTest
    {
        [TestMethod]
        public void Incluir()
        {
            var cli = new Cliente()
            {
                Nome = "José",
                Email = "Jose@teste.com.br"
            };
            var bll = new ClienteBLL();
            int resultado = bll.Incluir(cli);

            Assert.AreEqual<bool>(true, resultado > 0);
        }

        [TestMethod]
        public void IncluirSemNome()
        {
            var cli = new Cliente()
            {
                Nome = null,
                Email = "Jose@teste.com.br"
            };

            try
            {
                var bll = new ClienteBLL();
                int resultado = bll.Incluir(cli);
                Assert.Fail("Deveria ter dado erro. Passei o Nome como Null");
            }
            catch (Exception ex)
            {
                Assert.AreEqual<string>("O nome deve ser informado", ex.Message);
            }
        }
    }
}
