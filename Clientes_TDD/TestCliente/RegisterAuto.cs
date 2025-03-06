using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace TestCliente
{
	public class RegisterAuto : IDisposable
	{
		private readonly IWebDriver driver;
		private readonly WebDriverWait wait;

		public RegisterAuto()
		{
			driver = new EdgeDriver();
			driver.Manage().Window.Maximize();
			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
		}

		[Fact]
		public void Verificar_Vacios()
		{
			driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

			IWebElement emailField = driver.FindElement(By.Name("email"));
			IWebElement passwordField = driver.FindElement(By.Name("password"));

			driver.FindElement(By.ClassName("btn")).Click();

			string emailValidationMessage = emailField.GetAttribute("validationMessage");
			string passwordValidationMessage = passwordField.GetAttribute("validationMessage");

			// Verificar que los mensajes sean los esperados
			Assert.False(string.IsNullOrEmpty(emailValidationMessage), "El mensaje de validación del email no apareció.");
			Assert.False(string.IsNullOrEmpty(passwordValidationMessage), "El mensaje de validación de la contraseña no apareció.");
		}

		public void Dispose()
		{
			driver.Quit();
			driver.Dispose();
		}
	}
}
