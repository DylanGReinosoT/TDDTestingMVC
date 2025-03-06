using Microsoft.AspNetCore.Mvc;
using TDDTestingMVC1.Data;
using TDDTestingMVC1.Models;
using System.Collections.Generic;

namespace TDDTestingMVC1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();

        // Mostrar lista de clientes
        public IActionResult Index()
        {
            List<Cliente> clientes = _clienteDAL.GetClientes();
            
			return View(clientes);
        }

        // Mostrar formulario para crear un cliente
        public IActionResult Create()
        {
            return View();
        }

        // Procesar la creación de un cliente
        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteDAL.AddCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // Mostrar detalles de un cliente
        public IActionResult Details(int id)
        {
            Cliente cliente = _clienteDAL.GetClienteByCodigo(id);
            if (cliente == null)
                return NotFound();
            return View(cliente);
        }

        // Mostrar formulario para editar un cliente
        public IActionResult Edit(int id)
        {
            Cliente cliente = _clienteDAL.GetClienteByCodigo(id);
            if (cliente == null)
                return NotFound();
            return View(cliente);
        }

        // Procesar la edición de un cliente
        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteDAL.UpdateCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/9
        public IActionResult Delete(int id)
        {
            Cliente client = _clienteDAL.GetClientes().FirstOrDefault(c => c.Codigo == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Cliente/Delete/9
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _clienteDAL.DeleteCliente(id);
            return RedirectToAction("Index");
        }





    }
}
