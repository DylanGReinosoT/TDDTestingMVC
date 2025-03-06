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
	public class EliminarStepDefinitions
	{
		private readonly ClienteDataAccessLayer _cliente = new ClienteDataAccessLayer();
		private Cliente client = new Cliente();
		private IWebDriver _driver;
		private static ExtentReports _extent;
		private static ExtentTest _test;
		private readonly ScenarioContext _scenarioContext;
		private bool _resultado;  // Cambiar a bool


		public EliminarStepDefinitions(ScenarioContext scenarioContext)
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

		[Given("Existe un cliente registrado en la BDD para eliminar")]
		public void GivenExisteUnClienteRegistradoEnLaBDD(DataTable dataTable)
		{
			var row = dataTable.Rows[0];
			client.Codigo = int.Parse(row["Codigo"]);
			client.Cedula = row["Cedula"];
			client.Apellidos = row["Apellidos"];
			client.Nombres = row["Nombres"];
			client.FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]);
			client.Mail = row["Mail"];
			client.Telefono = row["Telefono"];
			client.Direccion = row["Direccion"];
			client.Estado = row["Estado"] == "1";

			// Insertar el cliente en la base de datos
			_cliente.AddCliente(client);
		}

		[When("Elimino el cliente de la BDD")]
		public void WhenEliminoElClienteDeLaBDD(DataTable dataTable)
		{
			// Asegúrate de que client esté inicializado
			Cliente client = new Cliente();  // Asegúrate de inicializar el objeto cliente

			var row = dataTable.Rows[0];
			client.Codigo = int.Parse(row["Codigo"]); // Convertir el código a int
			client.Cedula = row["Cedula"];
			var clienteExistente = _cliente.GetClienteByCodigo(client.Codigo);

			// Asegúrate de que clienteExistente no sea null antes de intentar eliminarlo
			if (clienteExistente != null)
			{
				// Intentar eliminar el cliente usando el código
				_resultado = _cliente.DeleteCliente(clienteExistente.Codigo);
			}
			else
			{
				// Manejo de error si el cliente no existe
				_resultado = false; // O realiza alguna acción para manejar el error
			}
		}




		[Then("El cliente ya no debe existir en la BDD")]
		public void ThenElClienteYaNoDebeExistirEnLaBDD(DataTable dataTable)
		{
			var row = dataTable.Rows[0];
			client.Codigo = int.Parse(row["Codigo"]); // Asegurar que se pase como int
			client.Cedula = row["Cedula"];

			// Buscar cliente en la base de datos por su código
			var clienteExistente = _cliente.GetClienteByCodigo(client.Codigo); // <- Corrección aquí

			// Validar que ya no existe
			if (clienteExistente != null)
			{
				throw new InvalidOperationException($"El cliente con código {client.Codigo} aún existe en la base de datos.");
			}
		}

		[Given("No existe un cliente registrado en la BDD con la cédula")]
		public void GivenNoExisteUnClienteRegistradoEnLaBDDConLaCedula(DataTable dataTable)
		{
			var row = dataTable.Rows[0];
			client.Codigo = int.Parse(row["Codigo"]);
			client.Cedula = row["Cedula"];

			var clienteExistente = _cliente.GetClienteByCodigo(client.Codigo);

			// Si el cliente existe, lo eliminamos para que no haya interferencias
			if (clienteExistente != null)
			{
				_cliente.DeleteCliente(clienteExistente.Codigo); // <- Corrección aquí
			}
		}


		[When("Intento eliminar el cliente de la BDD")]
		public void WhenIntentoEliminarElClienteDeLaBDD(DataTable dataTable)
		{
			var row = dataTable.Rows[0];
			var codigo = int.Parse(row["Codigo"]);  // Extrae solo el código

			// Intentar eliminar el cliente usando solo el código
			_resultado = _cliente.DeleteCliente(codigo);  // Pasas el código en lugar del objeto cliente
		}


		[Then("Debe mostrar un mensaje de error indicando que el cliente no existe")]
		public void ThenDebeMostrarUnMensajeDeErrorIndicandoQueElClienteNoExiste()
		{
			if (_resultado == false)
			{
				throw new Exception("No se pudo eliminar porque el cliente no existe en la base de datos.");
			}
		}

	}
}
