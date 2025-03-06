using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TDDTestingMVC1.Models;

namespace TDDTestingMVC1.Data
{
	public class OpinionesClienteDataAccessLayer
	{
		private readonly string connectionString = "Server=PERSONAL\\SQL;Database=productos;User ID=sa;Password=admin;TrustServerCertificate=true;MultipleActiveResultSets=true";

		// Obtener todas las opiniones
		public List<OpinionesCliente> GetOpiniones()
		{
			List<OpinionesCliente> lst = new List<OpinionesCliente>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("opinionescliente_SelectAll", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					OpinionesCliente opinion = new OpinionesCliente
					{
						OpinionID = Convert.ToInt32(reader["OpinionID"]),
						ClienteID = Convert.ToInt32(reader["ClienteID"]),
						ProductoID = reader["ProductoID"] != DBNull.Value ? Convert.ToInt32(reader["ProductoID"]) : (int?)null,
						Calificacion = Convert.ToInt32(reader["Calificacion"]),
						Comentario = reader["Comentario"].ToString(),
						Fecha = Convert.ToDateTime(reader["Fecha"])
					};
					lst.Add(opinion);
				}
				con.Close();
			}
			return lst;
		}

		// Obtener una opinión por ID
		public OpinionesCliente GetOpinionById(int opinionID)
		{
			OpinionesCliente opinion = null;
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("opinionescliente_SelectOne", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@OpinionID", opinionID);
				con.Open();
				SqlDataReader reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					opinion = new OpinionesCliente
					{
						OpinionID = Convert.ToInt32(reader["OpinionID"]),
						ClienteID = Convert.ToInt32(reader["ClienteID"]),
						ProductoID = reader["ProductoID"] != DBNull.Value ? Convert.ToInt32(reader["ProductoID"]) : (int?)null,
						Calificacion = Convert.ToInt32(reader["Calificacion"]),
						Comentario = reader["Comentario"].ToString(),
						Fecha = Convert.ToDateTime(reader["Fecha"])
					};
				}
				con.Close();
			}
			return opinion;
		}

		// Agregar una opinión
		public void AddOpinion(OpinionesCliente opinion)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("opinionescliente_Insert", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ClienteID", opinion.ClienteID);
				cmd.Parameters.AddWithValue("@ProductoID", (object)opinion.ProductoID ?? DBNull.Value);
				cmd.Parameters.AddWithValue("@Calificacion", opinion.Calificacion);
				cmd.Parameters.AddWithValue("@Comentario", opinion.Comentario);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		// Actualizar una opinión
		public void UpdateOpinion(OpinionesCliente opinion)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("opinionescliente_Update", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@OpinionID", opinion.OpinionID);
				cmd.Parameters.AddWithValue("@Calificacion", opinion.Calificacion);
				cmd.Parameters.AddWithValue("@Comentario", opinion.Comentario);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		// Eliminar una opinión
		public bool DeleteOpinion(int opinionID)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("opinionescliente_Delete", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@OpinionID", opinionID);
				con.Open();
				int rowsAffected = cmd.ExecuteNonQuery();
				con.Close();
				return rowsAffected > 0;
			}
		}
	}
}
