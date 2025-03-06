using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace TestCliente
{
	public class TestClienteDelete : IDisposable
	{
		private readonly IWebDriver driver;
		private readonly WebDriverWait wait;

		public TestClienteDelete()
		{
			driver = new EdgeDriver();
			driver.Manage().Window.Maximize();
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		}

		[Fact]
		public void Delete_Cliente()
		{
			driver.Navigate().GoToUrl("https://localhost:7221/Cliente");
			driver.FindElement(By.ClassName("btn-danger")).Click();
			driver.Navigate().GoToUrl("https://localhost:7221/Cliente/Delete/6");
			var btnDelete = wait.Until(d => d.FindElement(By.Id("btn-Delete")));
			btnDelete.Click();
			Thread.Sleep(3000);
			wait.Until(d => d.Url.Contains("/Cliente"));
			Assert.True(driver.Url.Contains("/Cliente"), $"La URL esperada debería contener '/Cliente', pero fue '{driver.Url}'");
		}

		public void Dispose()
		{
			driver.Quit();
			driver.Dispose();
		}
	}
}
