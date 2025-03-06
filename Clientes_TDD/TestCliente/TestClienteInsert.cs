using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCliente
{
	public class TestClienteInsert :IDisposable
	{
		private readonly IWebDriver driver;

		public TestClienteInsert()
		{
			driver = new EdgeDriver();
			driver.Manage().Window.Maximize();
		}

		[Fact]
		public void Create_Cliente_ReturnData()
		{
			driver.Navigate().GoToUrl("https://localhost:7221/Cliente/Create");
			var cedula = driver.FindElement(By.Id("Cedula"));
			cedula.SendKeys("1234567890");
			Thread.Sleep(3000);
			var apellidos = driver.FindElement(By.Id("Apellidos"));
			apellidos.SendKeys("Perez");
			Thread.Sleep(3000);
			var nombres = driver.FindElement(By.Id("Nombres"));
			nombres.SendKeys("Juan");
			Thread.Sleep(3000);
			var fechaNacimiento = driver.FindElement(By.Id("FechaNacimiento"));
			fechaNacimiento.SendKeys("01/01/2000");
			Thread.Sleep(3000);
			var mail = driver.FindElement(By.Id("Mail"));
			mail.SendKeys("sojos@mail.com");
			Thread.Sleep(3000);
			var telefono = driver.FindElement(By.Id("Telefono"));
			telefono.SendKeys("0987654321");
			Thread.Sleep(3000);
			var direccion = driver.FindElement(By.Id("Direccion"));
			direccion.SendKeys("Quito");
			Thread.Sleep(3000);
			driver.FindElement(By.Id("btn-Submit")).Click();
			Thread.Sleep(3000);
		}

		public void Dispose()
		{
			driver.Quit();
		}

	}
}
