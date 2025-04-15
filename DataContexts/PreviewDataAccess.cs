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
	}
}
