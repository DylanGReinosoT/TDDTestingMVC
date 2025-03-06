using System;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace TestCliente
{
    public class UnitTest1 : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait _wait;

        public UnitTest1()
        {
            // Inicializa el WebDriver para Microsoft Edge
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void TestPageTitle()
        {
            driver.Navigate().GoToUrl("https://www.bing.com");

            var buscarTexto = _wait.Until(d => d.FindElement(By.Name("q")));
            Thread.Sleep(3000);

            buscarTexto.SendKeys("Selenium");

            Thread.Sleep(2000);

            // Usar un selector más confiable para el botón de búsqueda
            var botonBuscar = _wait.Until(d => d.FindElement(By.Id("search_icon")));
            botonBuscar.Click();

            var resultado = _wait.Until(d => d.FindElements(By.ClassName("sb_count")));

            Assert.True(resultado.Count > 0, "No se encontró resultados.");

            Console.WriteLine("Test completado exitosamente.");
            Console.WriteLine("Esperando Resultados: ");
            Thread.Sleep(10000);
        }

        public void Dispose()
        {
            // Cerrar el navegador
            //driver.Quit();
        }





        //       [Theory]
        //       [InlineData("usuario@gmail.com", true)]
        //       [InlineData("test@empresa.com", true)]
        //       [InlineData("corrreo_gmail.com", false)]
        //       [InlineData("usuario@gmailcomcom", false)]
        //       public void ValidarEmail_DetectarCorreosValidos(string email, bool esperado)
        //       {
        //           bool resultado = EmailValido(email);
        //           Assert.Equal(esperado, resultado);
        //       }

        //       private bool EmailValido(string email)
        //       {
        //           string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        //           return Regex.IsMatch(email, pattern);
        //       }
    }
}
