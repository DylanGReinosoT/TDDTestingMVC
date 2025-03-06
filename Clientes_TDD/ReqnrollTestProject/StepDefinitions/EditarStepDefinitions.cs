using System;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollTestProject.Utilities;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;
using Reqnroll.Assist;

namespace ReqnrollTestProject.StepDefinitions
{
	[Binding]
	public class EditarStepDefinitions
	{
		private readonly ClienteDataAccessLayer _cliente = new ClienteDataAccessLayer();
		private Cliente client = new Cliente();
		private IWebDriver _driver;
		private static ExtentReports _extent;
		private static ExtentTest _test;
		private readonly ScenarioContext _scenarioContext;

		public EditarStepDefinitions(ScenarioContext scenarioContext)
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

		// Se asume que la base de datos está conectada y se tiene acceso a los métodos de la DAL.

		[Given("Existe un cliente registrado en la BDD para edicion")]
		public void GivenExisteUnClienteRegistradoEnLaBDD(DataTable dataTable)
		{

			foreach (var row in dataTable.Rows)
			{
				var cedula = row["Cedula"].ToString();
				var apellidos = row["Apellidos"].ToString();
				var nombres = row["Nombres"].ToString();
				var fechaNacimiento = DateTime.Parse(row["FechaNacimiento"].ToString());
				var mail = row["Mail"].ToString();
				var telefono = row["Telefono"].ToString();
				var direccion = row["Direccion"].ToString();
				var estado = row["Estado"].ToString() == "1";  // Si es "1", convierte a true, sino a false

				// Aquí se agregarían estos datos a la base de datos o a una lista en memoria
				var nuevoCliente = new Cliente
				{
					Cedula = cedula,
					Apellidos = apellidos,
					Nombres = nombres,
					FechaNacimiento = fechaNacimiento,
					Mail = mail,
					Telefono = telefono,
					Direccion = direccion,
					Estado = estado
				};
				_cliente.AddCliente(nuevoCliente);
			}
		}

		[When("Modifico los datos del cliente en el formulario con datos válidos")]
		public void WhenModificoLosDatosDelClienteEnElFormularioConDatosValidos(DataTable dataTable)
		{
			foreach (var row in dataTable.Rows)
			{
				var cedula = row["Cedula"].ToString();
				var apellidos = row["Apellidos"].ToString();
				var nombres = row["Nombres"].ToString();
				var fechaNacimiento = DateTime.Parse(row["FechaNacimiento"].ToString());
				var mail = row["Mail"].ToString();
				var telefono = row["Telefono"].ToString();
				var direccion = row["Direccion"].ToString();
				var estado = row["Estado"].ToString() == "1";  // Si es "1", convierte a true, sino a false

				// Lógica para obtener el cliente de la base de datos o de la lista usando la cédula
				var clienteExistente = _cliente.GetClientes().Find(c => c.Cedula == cedula);

				if (clienteExistente != null)
				{
					// Actualizamos los datos del cliente
					clienteExistente.Apellidos = apellidos;
					clienteExistente.Nombres = nombres;
					clienteExistente.FechaNacimiento = fechaNacimiento;
					clienteExistente.Mail = mail;
					clienteExistente.Telefono = telefono;
					clienteExistente.Direccion = direccion;
					clienteExistente.Estado = estado;

					// Asignamos el cliente actualizado a la variable 'client'
					client = clienteExistente;

					// Actualizamos el cliente en la base de datos o en la lista
					_cliente.UpdateCliente(clienteExistente);
				}
			}
		}


		[When("Modifico los datos del cliente en el formulario con datos inválidos")]
		public void WhenModificoLosDatosDelClienteEnElFormularioConDatosInvalidos(DataTable dataTable)
		{
			foreach (var row in dataTable.Rows)
			{
				var cedula = row["Cedula"].ToString();
				var apellidos = row["Apellidos"].ToString();
				var nombres = row["Nombres"].ToString();
				var fechaNacimiento = row["FechaNacimiento"].ToString();
				var mail = row["Mail"].ToString();
				var telefono = row["Telefono"].ToString();
				var direccion = row["Direccion"].ToString();
				var estado = row["Estado"].ToString() == "1";  // Si es "1", convierte a true, sino a false

				try
				{
					
					if (string.IsNullOrEmpty(cedula))
					{
						throw new ArgumentException("La cédula es requerida.");
					}
					if (!DateTime.TryParse(fechaNacimiento, out DateTime fechaNac))
					{
						throw new ArgumentException("La fecha de nacimiento no es válida.");
					}
					if (string.IsNullOrEmpty(mail) || !mail.Contains("@"))
					{
						throw new ArgumentException("El correo electrónico no es válido.");
					}
					if (telefono.Length != 9 || !telefono.All(char.IsDigit))
					{
						throw new ArgumentException("El teléfono debe tener 9 dígitos.");
					}

					// Aquí agregaríamos los datos si son válidos
					var nuevoCliente = new Cliente
					{
						Cedula = cedula,
						Apellidos = apellidos,
						Nombres = nombres,
						FechaNacimiento = fechaNac,
						Mail = mail,
						Telefono = telefono,
						Direccion = direccion,
						Estado = estado
					};

					// Lógica para agregar cliente en base de datos o en la lista de clientes
					_cliente.AddCliente(nuevoCliente);
				}
				catch (ArgumentException ex)
				{
					// Registra el error sin detener la ejecución de la prueba
					Console.WriteLine($"Error en la validación: {ex.Message}");
					throw; // Relanza la excepción para asegurar que el error se registre en el informe de la prueba
				}
			}
		}

		[Then("El resultado de la actualización en la BDD debe ser")]
		public void ThenElResultadoDeLaActualizacionEnLaBDDDebeSer(DataTable expectedTable)
		{
			var expectedData = expectedTable.Rows[0];

			// Verificar si el cliente fue actualizado correctamente
			var updatedClient = _cliente.GetClienteByCodigo(client.Codigo);

			// Verificar si updatedClient es null
			if (updatedClient == null)
			{
				throw new InvalidOperationException($"No se encontró el cliente con código {client.Codigo} en la base de datos.");
			}

			// Comprobar que los datos coinciden con los datos esperados
			Assert.Equal(expectedData["Cedula"], updatedClient.Cedula);
			Assert.Equal(expectedData["Apellidos"], updatedClient.Apellidos);
			Assert.Equal(expectedData["Nombres"], updatedClient.Nombres);
			Assert.Equal(DateTime.Parse(expectedData["FechaNacimiento"]), updatedClient.FechaNacimiento);
			Assert.Equal(expectedData["Mail"], updatedClient.Mail);
			Assert.Equal(expectedData["Telefono"], updatedClient.Telefono);
			Assert.Equal(expectedData["Direccion"], updatedClient.Direccion);

			// Convertir el valor de "Estado" de 1 o 0 a booleano (true o false)
			bool expectedEstado = expectedData["Estado"] == "1"; // Aquí se compara con "1"
			Assert.Equal(expectedEstado, updatedClient.Estado);
		}




		[Then("Debe mostrar un mensaje de error indicando que la cédula es requerida")]
		public void ThenDebeMostrarUnMensajeDeErrorIndicandoQueLaCedulaEsRequerida()
		{
			// Simular que la cédula está vacía y verificar el error
			Assert.Throws<ArgumentException>(() => _cliente.UpdateCliente(client));
		}

		[Then("Debe mostrar un mensaje de error indicando que el correo es inválido")]
		public void ThenDebeMostrarUnMensajeDeErrorIndicandoQueElCorreoEsInvalido()
		{
			// Simular que el correo es inválido y verificar el error
			Assert.Throws<FormatException>(() => _cliente.UpdateCliente(client));
		}
	}
}
