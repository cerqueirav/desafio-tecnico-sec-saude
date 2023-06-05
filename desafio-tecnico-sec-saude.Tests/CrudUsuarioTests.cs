using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Threading;
using Assert = NUnit.Framework.Assert;

namespace DesafioTecnicoSecSaude.Tests
{
    [TestClass]
    public class CrudUsuarioTests
    {
        private IWebDriver _driver;
        private string _baseUrl;


        [TestMethod]
        public void ShouldReturnArrayOfUsers()
        {
            _driver = new ChromeDriver();
            _baseUrl = "https://localhost:44350";

            _driver.Navigate().GoToUrl($"{_baseUrl}/ConsultarUsuarios");

            var usuarios = _driver.FindElements(By.CssSelector(".usuario-item"));

            NUnit.Framework.Assert.IsTrue(usuarios.Count > 0);
        }

        [TestMethod]
        public void Cadastra_EsperaUmNovoUsuarioCadastrado()
        {
            _driver = new ChromeDriver();
            _baseUrl = "https://localhost:44350";

            // Mock de Usuário
            var nome = "John Doe";
            var email = "johndoe@example.com";
            var cpf = "559.171.810-80";
            var senha = "55917181080";
            var cep = "40325130";
            var numero = "15";

            _driver.Navigate().GoToUrl($"{_baseUrl}/CadastrarUsuario");
            _driver.FindElement(By.Id("MainContent_nome")).SendKeys(nome);
            _driver.FindElement(By.Id("MainContent_email")).SendKeys(email);
            _driver.FindElement(By.Id("MainContent_senha")).SendKeys(senha);
            _driver.FindElement(By.Id("MainContent_cpf")).SendKeys(cpf);
            _driver.FindElement(By.Id("MainContent_cep")).SendKeys(cep);
            _driver.FindElement(By.Id("MainContent_numero")).SendKeys(numero);
            _driver.FindElement(By.Id("btnSalvar")).Click();

            Thread.Sleep(1000);

            var usuarios = _driver.FindElements(By.CssSelector(".usuario-item"));
            var novoUsuario = usuarios.FirstOrDefault(u => u.Text.Contains(nome));
            
            // Verifica se foi cadastrado
            Assert.IsNotNull(novoUsuario);
            Assert.IsTrue(novoUsuario.Text.Contains(email));
        }
    }
}
