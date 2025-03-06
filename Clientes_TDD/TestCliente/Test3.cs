using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCliente
{
	public class Test3
	{
		private readonly IWebDriver driver;
		public Test3()
		{
			driver = new EdgeDriver();
			driver.Manage().Window.Maximize();
		}
		//verificar que redireccione a la pagina con credenciales correctas
		[Fact]
		public void Verificar_credencialesCorrectas()
		{
			driver.Navigate().GoToUrl("https://www.automationexercise.com/login");
			var email = driver.FindElement(By.Name("email"));
			email.SendKeys("dgreinoso32@gmail.com");
			Thread.Sleep(3000);
			var password = driver.FindElement(By.Name("password"));
			password.SendKeys("Gabriel15");
			Thread.Sleep(3000);
			driver.FindElement(By.ClassName("btn")).Click();
			Thread.Sleep(3000);
			Assert.Equal("https://www.automationexercise.com/", driver.Url);
		}
	}
}
