using Microsoft.AspNetCore.Mvc;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;
using System.Collections.Generic;
using System.Linq;

namespace TDDTestingMVC1.Controllers
{
	public class ProductoController : Controller
	{
		private readonly ProductoDataAccessLayer _productoDAL = new ProductoDataAccessLayer();

		// Mostrar lista de productos
		public IActionResult Index()
		{
			List<Producto> productos = _productoDAL.GetProductos();
			return View(productos);
		}

		// Mostrar formulario para crear un producto
		public IActionResult Create()
		{
			return View();
		}

		// Procesar la creación de un producto
		[HttpPost]
		public IActionResult Create(Producto producto)
		{
			if (ModelState.IsValid)
			{
				_productoDAL.AddProducto(producto);
				return RedirectToAction("Index");
			}
			return View(producto);
		}

		// Mostrar detalles de un producto
		public IActionResult Details(int id)
		{
			Producto producto = _productoDAL.GetProductoById(id);
			if (producto == null)
				return NotFound();
			return View(producto);
		}

		// Mostrar formulario para editar un producto
		public IActionResult Edit(int id)
		{
			Producto producto = _productoDAL.GetProductoById(id);
			if (producto == null)
				return NotFound();
			return View(producto);
		}

		// Procesar la edición de un producto
		[HttpPost]
		public IActionResult Edit(Producto producto)
		{
			if (ModelState.IsValid)
			{
				_productoDAL.UpdateProducto(producto);
				return RedirectToAction("Index");
			}
			return View(producto);
		}

		// Mostrar formulario de confirmación para eliminar un producto
		public IActionResult Delete(int id)
		{
			Producto producto = _productoDAL.GetProductos().FirstOrDefault(p => p.ProductoID == id);
			if (producto == null)
				return NotFound();
			return View(producto);
		}

		// Procesar la eliminación de un producto
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			_productoDAL.DeleteProducto(id);
			return RedirectToAction("Index");
		}
	}
}
