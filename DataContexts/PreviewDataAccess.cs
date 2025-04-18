using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Winterra.Models.DataModels;

namespace Winterra.DataContexts
{
	public class PreviewDataAccess
	{
		private readonly string? _connectionString;

		public PreviewDataAccess(IConfiguration configuration)
		{
			this._connectionString = configuration.GetConnectionString("DefaultConnection");
		}
		public int GetPreviewCount(string? previewType = "")
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					string query = "SELECT COUNT(*) AS cnt FROM ww_preview WHERE preview_type = @preview_type";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@preview_type", previewType);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								return (int)reader["cnt"];
							}
						}

					}

				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine($"SQL-Exception [PreviewDataAccess -> GetPreviewCount]: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception [PreviewDataAccess -> GetPreviewCount]: {ex.Message}");
			}

			return 0;
		}
		public List<Preview> GetPreviewList(string? previewType = "")
		{
			List<Preview> previewList = new List<Preview>();

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					string query = "SELECT TOP 10 * FROM ww_preview WHERE preview_type = @preview_type";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@preview_type", previewType);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Preview preview = new Preview
								{
									Id = Convert.ToInt32(reader["preview_id"]),
									Type = Convert.ToString(reader["preview_type"]),
									Image = Convert.ToString(reader["preview_image"]),
									Name = Convert.ToString(reader["preview_name"])
								};

								previewList.Add(preview);
							}
						}

					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine($"SQL-Exception [PreviewDataAccess -> GetPreviewDataList]: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception [PreviewDataAccess -> GetPreviewDataList]: {ex.Message}");
			}

			return previewList;
		}
		public Preview? GetPreviewData(int? id)
		{
			Preview? previewData = null;
			if (id != null)
			{
				try
				{
					using (SqlConnection connection = new SqlConnection(_connectionString))
					{
						connection.Open();

						string query = "SELECT * FROM ww_preview WHERE preview_id = @preview_id";
						using (SqlCommand command = new SqlCommand(query, connection))
						{
							command.Parameters.Add("@preview_id", System.Data.SqlDbType.Int, 32).Value = id;

							using (SqlDataReader reader = command.ExecuteReader())
							{
								if (reader.Read())
								{
									previewData = new Preview
									{
										Id = Convert.ToInt32(reader["preview_id"]),
										Type = Convert.ToString(reader["preview_type"]),
										Image = Convert.ToString(reader["preview_image"]),
										Name = Convert.ToString(reader["preview_name"])
									};
								}
							}

						}
					}
				}
				catch (SqlException ex)
				{
					Console.WriteLine($"SQL-Exception [PreviewDataAccess -> GetPreviewData]: {ex.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception [PreviewDataAccess -> GetPreviewData]: {ex.Message}");
				}
			}

			return previewData;
		}
		public void UpdateAfterEdit(Preview preview)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				try
				{
					connection.Open();

					string query = @"
                        UPDATE ww_preview 
                        SET 
                            preview_type = @preview_type,
                            preview_image = @preview_image,
                            preview_name = @preview_name
                        WHERE preview_id = @preview_id";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@preview_id", preview.Id);
						command.Parameters.AddWithValue("@preview_type", preview.Type);
						command.Parameters.AddWithValue("@preview_image", preview.Image);
						command.Parameters.AddWithValue("@preview_name", preview.Name);

						command.ExecuteNonQuery();
					}
				}
				catch (SqlException ex)
				{
					Console.WriteLine($"SQL-Exception [PreviewDataAccess -> UpdateAfterEdit]: {ex.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception [PreviewDataAccess -> UpdateAfterEdit]: {ex.Message}");
				}
			}
		}

		public List<Preview> GetPreviewListPaged(int pageNumber, int pageSize, string? previewType = "")
		{
			List<Preview> previewList = new List<Preview>();

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					string query = @"
						SELECT * FROM ww_preview
						WHERE preview_type = @preview_type
						ORDER BY preview_id
						OFFSET @offset ROWS
						FETCH NEXT @page_size ROWS ONLY;";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						int offset = (pageNumber - 1) * pageSize;

						command.Parameters.AddWithValue("@preview_type", previewType ?? string.Empty);
						command.Parameters.AddWithValue("@offset", offset);
						command.Parameters.AddWithValue("@page_size", pageSize);

						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Preview preview = new Preview
								{
									Id = Convert.ToInt32(reader["preview_id"]),
									Type = Convert.ToString(reader["preview_type"]),
									Image = Convert.ToString(reader["preview_image"]),
									Name = Convert.ToString(reader["preview_name"])
								};

								previewList.Add(preview);
							}
						}
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine($"SQL-Exception [PreviewDataAccess -> GetPreviewListPaged]: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception [PreviewDataAccess -> GetPreviewListPaged]: {ex.Message}");
			}

			return previewList;
		}
	}
}
