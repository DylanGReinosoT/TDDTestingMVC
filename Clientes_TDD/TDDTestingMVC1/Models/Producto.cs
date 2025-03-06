using System.ComponentModel.DataAnnotations;

namespace TDDTestingMVC1.Models
{
	public class Producto
	{
		[Required]
		public int ProductoID { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "El nombre del producto no puede exceder los 100 caracteres.")]
		public string NombreProducto { get; set; }

		[Required]
		[Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
		public decimal Precio { get; set; }

		[Required]
		[Range(0, int.MaxValue, ErrorMessage = "Las unidades en stock no pueden ser negativas.")]
		public int UnitsInStock { get; set; }

		[Required]
		public bool Estado { get; set; }
	}
}
