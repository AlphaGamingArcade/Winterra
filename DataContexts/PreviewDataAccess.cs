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

		public List<Preview> GetPreviewList()
		{
			List<Preview> previewList = new List<Preview>();

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					string query = "SELECT TOP 10 * FROM ww_content";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Preview preview = new Preview
								{
									Id = Convert.ToInt32(reader["content_id"]),
									Type = Convert.ToString(reader["content_type"]),
									Image = Convert.ToString(reader["content_title"])
								};

								previewList.Add(preview);
							}
						}

					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine($"SQL-Exception [PreviewDataAccess -> GetVisitDataList]: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception [PreviewDataAccess -> GetVisitDataList]: {ex.Message}");
			}

			return previewList;
		}
	}
}
