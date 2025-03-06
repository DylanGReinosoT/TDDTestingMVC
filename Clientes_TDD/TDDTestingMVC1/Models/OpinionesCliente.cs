using System;
using System.ComponentModel.DataAnnotations;

namespace TDDTestingMVC1.Models
{
	public class OpinionesCliente
	{
		[Required]
		public int OpinionID { get; set; }

		[Required]
		public int ClienteID { get; set; }

		public int? ProductoID { get; set; } // Puede ser opcional si la opinión no es sobre un producto específico

		[Required]
		[Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
		public int Calificacion { get; set; }

		[Required]
		[StringLength(500, ErrorMessage = "El comentario no puede exceder los 500 caracteres.")]
		public string Comentario { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime Fecha { get; set; }
	}
}
