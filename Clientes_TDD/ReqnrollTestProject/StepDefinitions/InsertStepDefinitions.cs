using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject.Utilities;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;

namespace ReqnrollTestProject.StepDefinitions
{
    [Binding]
    public class InsertStepDefinitions
    {
        private readonly ClienteDataAccessLayer _cliente = new ClienteDataAccessLayer();
        private Cliente client = new Cliente(); 
        private int _resultado = 0;
		private IWebDriver _driver;
		private static ExtentReports _extent;
		private static ExtentTest _test;
		private readonly ScenarioContext _scenarioContext;

		public InsertStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}
		[BeforeTestRun]
		public static void BeforeTestRun()
		{
			var sparkReport = new ExtentSparkReporter("ExtentReport.html");
			_extent = new ExtentReports();
			_extent.AttachReporter(sparkReport);
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
			_driver = WebDriverManager.GetDriver("edge");
			_test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);

		}

		[Given("Llenar los campos del formulario")]
        public void GivenLlenarLosCamposDelFormulario(DataTable dataTable)
        {
            _resultado = dataTable.Rows.Count();

            Assert.True(_resultado > 0);
		}

        [When("Registro de usuario en la BDD")]
        public void WhenRegistroDeUsuarioEnLaBDD(DataTable dataTable)
        {
           var cliente = dataTable.CreateSet<Cliente>().ToList();
            Cliente cls = new Cliente();
			foreach (var item in cliente)
			{
				cls.Cedula = item.Cedula;
				cls.Apellidos = item.Apellidos;
				cls.Nombres = item.Nombres;
				cls.FechaNacimiento = item.FechaNacimiento;
				cls.Mail = item.Mail;
				cls.Telefono = item.Telefono;
				cls.Direccion = item.Direccion;
				cls.Estado = item.Estado;
			}
			_cliente.AddCliente(cls); 
		}

        [Then("El resultado del registro en l a BDD")]
        public void ThenElResultadoDelRegistroEnLABDD(DataTable dataTable)
        {
			var clientesRegistrados = _cliente.GetClientes();

			var clienteEsperado = dataTable.CreateSet<Cliente>().First();
			
			var clienteRegistrado = clientesRegistrados.FirstOrDefault(c => c.Cedula == clienteEsperado.Cedula);
			Assert.NotNull(clienteRegistrado);
			Assert.Equal(clienteEsperado.Cedula, clienteRegistrado.Cedula);
		}
    }
}
