using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TDDTestingMVC1.Models;

namespace TDDTestingMVC1.Data
{
	public class ProductoDataAccessLayer
	{
		private readonly string connectionString = "Server=PERSONAL\\SQL;Database=productos;User ID=sa;Password=admin;TrustServerCertificate=true;MultipleActiveResultSets=true";

		// Obtener todos los productos
		public List<Producto> GetProductos()
		{
			List<Producto> lst = new List<Producto>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("producto_SelectAll", con);
				cmd.CommandType = CommandType.StoredProcedure;
				con.Open();
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Producto producto = new Producto
					{
						ProductoID = Convert.ToInt32(reader["ProductoID"]),
						NombreProducto = reader["NombreProducto"].ToString(),
						Precio = Convert.ToDecimal(reader["Precio"]),
						UnitsInStock = Convert.ToInt32(reader["UnitsInStock"])
					};
					lst.Add(producto);
				}
				con.Close();
			}
			return lst;
		}

		// Obtener un producto por ID
		public Producto GetProductoById(int productoID)
		{
			Producto producto = null;
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("producto_SelectOne", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ProductoID", productoID);
				con.Open();
				SqlDataReader reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					producto = new Producto
					{
						ProductoID = Convert.ToInt32(reader["ProductoID"]),
						NombreProducto = reader["NombreProducto"].ToString(),
						Precio = Convert.ToDecimal(reader["Precio"]),
						UnitsInStock = Convert.ToInt32(reader["UnitsInStock"])
					};
				}
				con.Close();
			}
			return producto;
		}

		// Agregar un producto
		public void AddProducto(Producto producto)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("producto_Insert", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
				cmd.Parameters.AddWithValue("@Precio", producto.Precio);
				cmd.Parameters.AddWithValue("@UnitsInStock", producto.UnitsInStock);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		// Actualizar un producto
		public void UpdateProducto(Producto producto)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("producto_Update", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ProductoID", producto.ProductoID);
				cmd.Parameters.AddWithValue("@NombreProducto", producto.NombreProducto);
				cmd.Parameters.AddWithValue("@Precio", producto.Precio);
				cmd.Parameters.AddWithValue("@UnitsInStock", producto.UnitsInStock);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		// Eliminar un producto
		public bool DeleteProducto(int productoID)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("producto_Delete", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@ProductoID", productoID);
				con.Open();
				int rowsAffected = cmd.ExecuteNonQuery();
				con.Close();
				return rowsAffected > 0;
			}
		}
	}
}
