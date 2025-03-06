using Microsoft.AspNetCore.Mvc;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;
using System.Collections.Generic;
using System.Linq;

namespace TDDTestingMVC1.Controllers
{
	public class OpinionesClienteController : Controller
	{
		private readonly OpinionesClienteDataAccessLayer _opinionesDAL = new OpinionesClienteDataAccessLayer();
		private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();
		private readonly ProductoDataAccessLayer _productoDAL = new ProductoDataAccessLayer();

		// Mostrar lista de opiniones
		public IActionResult Index()
		{
			List<OpinionesCliente> opiniones = _opinionesDAL.GetOpiniones();
			return View(opiniones);
		}

		// Mostrar formulario para crear una opinión
		public IActionResult Create()
		{
			var clientes = _clienteDAL.GetClientes();
			var productos = _productoDAL.GetProductos();

			if (clientes == null || productos == null)
			{
				throw new Exception("Error: Clientes o Productos son nulos. Verifica que se estén obteniendo correctamente.");
			}

			ViewBag.Clientes = clientes;
			ViewBag.Productos = productos;

			return View();
		}


		// Procesar la creación de una opinión
		[HttpPost]
		public IActionResult Create(OpinionesCliente opinion)
		{
			if (ModelState.IsValid)
			{
				_opinionesDAL.AddOpinion(opinion);
				return RedirectToAction("Index");
			}
			return View(opinion);
		}

		// Mostrar detalles de una opinión
		public IActionResult Details(int id)
		{
			OpinionesCliente opinion = _opinionesDAL.GetOpinionById(id);
			if (opinion == null)
				return NotFound();
			return View(opinion);
		}

		// Mostrar formulario para editar una opinión
		public IActionResult Edit(int id)
		{
			OpinionesCliente opinion = _opinionesDAL.GetOpinionById(id);
			if (opinion == null)
				return NotFound();

			// Poblar ViewBag con las listas de clientes y productos
			ViewBag.Clientes = _clienteDAL.GetClientes(); // Asegúrate de que este método exista
			ViewBag.Productos = _productoDAL.GetProductos(); // Asegúrate de que este método exista

			return View(opinion);
		}

		// Procesar la edición de una opinión
		[HttpPost]
		public IActionResult Edit(OpinionesCliente opinion)
		{
			if (ModelState.IsValid)
			{
				_opinionesDAL.UpdateOpinion(opinion);
				return RedirectToAction("Index");
			}
			return View(opinion);
		}

		// Mostrar formulario de confirmación para eliminar una opinión
		public IActionResult Delete(int id)
		{
			OpinionesCliente opinion = _opinionesDAL.GetOpiniones().FirstOrDefault(o => o.OpinionID == id);
			if (opinion == null)
				return NotFound();
			return View(opinion);
		}

		// Procesar la eliminación de una opinión
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			_opinionesDAL.DeleteOpinion(id);
			return RedirectToAction("Index");
		}
	}
}
