using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCliente
{
	public class Test_correo : IDisposable
	{
		private readonly IWebDriver driver;
		private readonly WebDriverWait wait;

		public Test_correo()
		{
			driver = new EdgeDriver();
			driver.Manage().Window.Maximize();
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
		}

		[Fact]
		public void Verificar_IncorrectoContraseña()
		{
			driver.Navigate().GoToUrl("https://www.automationexercise.com/login");
			var email = driver.FindElement(By.Name("email"));
			email.SendKeys("dgreinoso32@gmail.com");

			// Ingresar contraseña incorrecta
			var password = driver.FindElement(By.Name("password"));
			password.SendKeys("12345");

			driver.FindElement(By.ClassName("btn")).Click();

			var errorMessageElement = wait.Until(drv => drv.FindElement(By.XPath("//p[contains(text(),'Your email or password is incorrect!')]")));
			string actualErrorMessage = errorMessageElement.Text;
			Assert.Equal("Your email or password is incorrect!", actualErrorMessage);
		}


		public void Dispose()
		{
			driver.Quit();
			driver.Dispose();
		}
	}
}
