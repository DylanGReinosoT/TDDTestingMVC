namespace TDDTestingMVC1.Models
{
	public class Circunferencia
	{
		public double Radio { get; set; }
		public double CentroX { get; set; }
		public double CentroY { get; set; }

		public string ObtenerEcuacion()
		{
			return $"(x - {CentroX})^2 + (y - {CentroY})^2 = {Radio * Radio}";
		}
	}
}
