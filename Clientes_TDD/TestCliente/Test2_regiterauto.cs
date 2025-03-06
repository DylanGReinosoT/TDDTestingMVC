using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace TestCliente
{
	public class Test2_regiterauto : IDisposable
	{
		private readonly IWebDriver driver;
		private readonly WebDriverWait wait;

		public Test2_regiterauto()
		{
			driver = new EdgeDriver();
			driver.Manage().Window.Maximize();
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
		}

		// Verificar que el mensaje de error aparece con un correo incorrecto
		[Fact]
		public void Verificar_correoIncorrecctos()
		{
			driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

			// Ingresar email incorrecto
			var email = driver.FindElement(By.Name("email"));
			email.SendKeys("correo@incorrecto");
			var password = driver.FindElement(By.Name("password"));
			password.SendKeys("Gabriel15");

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
