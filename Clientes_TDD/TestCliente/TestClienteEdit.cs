using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace TestCliente
{
	public class TestClienteEdit : IDisposable
	{
		private readonly IWebDriver driver;
		private readonly WebDriverWait wait;

		public TestClienteEdit()
		{
			driver = new EdgeDriver();
			driver.Manage().Window.Maximize();
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		}

		[Fact]
		public void Edit_Cliente_ReturnData()
		{
			driver.Navigate().GoToUrl("https://localhost:7221/Cliente");
			driver.FindElement(By.ClassName("btn-warning")).Click();
			Thread.Sleep(3000);
			driver.Navigate().GoToUrl("https://localhost:7221/Cliente/Edit/6");
			var cedula = wait.Until(d => d.FindElement(By.Id("Cedula")));
			cedula.Clear();
			cedula.SendKeys("1234567890");
			Thread.Sleep(3000);
			var apellidos = wait.Until(d => d.FindElement(By.Id("Apellidos")));
			apellidos.Clear();
			apellidos.SendKeys("Reinoso");
			Thread.Sleep(3000);
			var nombres = wait.Until(d => d.FindElement(By.Id("Nombres")));
			nombres.Clear();
			nombres.SendKeys("Dylan");
			Thread.Sleep(3000);
			var fechaNacimiento = wait.Until(d => d.FindElement(By.Id("FechaNacimiento")));
			fechaNacimiento.Clear();
			fechaNacimiento.SendKeys("01/01/2000");
			Thread.Sleep(3000);
			var mail = wait.Until(d => d.FindElement(By.Id("Mail")));
			mail.Clear();
			mail.SendKeys("dylanreinoso32@gmail.com");
			Thread.Sleep(3000);
			var telefono = wait.Until(d => d.FindElement(By.Id("Telefono")));
			telefono.Clear();
			telefono.SendKeys("096904828");
			Thread.Sleep(3000);
			var direccion = wait.Until(d => d.FindElement(By.Id("Direccion")));
			direccion.Clear();
			direccion.SendKeys("Quito");
			Thread.Sleep(3000);
			driver.FindElement(By.Id("btn-Edit")).Click();
			Thread.Sleep(3000);
		}

		public void Dispose()
		{
			driver.Quit();
			driver.Dispose();
		}
	}
}
