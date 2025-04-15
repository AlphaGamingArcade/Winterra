using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Winterra.Models.DataModels;

namespace Winterra.DataContexts
{
	public class ContentDataAccess
	{
		private readonly string? _connectionString;

		public ContentDataAccess(IConfiguration configuration)
		{
			this._connectionString = configuration.GetConnectionString("DefaultConnection");
		}
		
        public int GetContentCount()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) AS cnt FROM ww_content";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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
                Console.WriteLine($"SQL-Exception [CharacterDataAccess -> GetCharacterCount]: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception [CharacterDataAccess -> GetCharacterCount]: {ex.Message}");
            }

            return 0;
        }

		public List<Content> GetContentList()
		{
			List<Content> contentList = new List<Content>();

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
								Content content = new Content
								{
									Id = Convert.ToInt32(reader["content_id"]),
									Type = Convert.ToString(reader["content_type"]),
									Title = Convert.ToString(reader["content_title"]),
									PublishedAt = Convert.ToDateTime(reader["content_published_at"]),
								};

								contentList.Add(content);
							}
						}

					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine($"SQL-Exception [ContentDataAccess -> GetVisitDataList]: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception [ContentDataAccess -> GetVisitDataList]: {ex.Message}");
			}

			return contentList;
		}
	}
}
