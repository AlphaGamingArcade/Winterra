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

		public int GetContentCount(string? contentType = "")
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					string query = "SELECT COUNT(*) AS cnt FROM ww_content where content_type = @content_type";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@content_type", contentType);
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
				Console.WriteLine($"SQL-Exception [ContentDataAccess -> GetCharacterCount]: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception [ContentDataAccess -> GetCharacterCount]: {ex.Message}");
			}

			return 0;
		}

		public List<Content> GetContentList(string? contentType = "")
		{
			List<Content> contentList = new List<Content>();

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					string query = "SELECT TOP 10 * FROM ww_content where content_type = @content_type";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@content_type", contentType);
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Content content = new Content
								{
									Id = Convert.ToInt32(reader["content_id"]),
									Type = Convert.ToString(reader["content_type"]),
									Title = Convert.ToString(reader["content_title"]),
									Data = Convert.ToString(reader["content_data"]),
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
		public Content? GetContentData(int? id)
		{
			Content? contentData = null;

			if (id != null)
			{
				try
				{
					using (SqlConnection connection = new SqlConnection(_connectionString))
					{
						connection.Open();

						string query = "SELECT * FROM ww_content WHERE content_id = @content_id";
						using (SqlCommand command = new SqlCommand(query, connection))
						{
							command.Parameters.Add("@content_id", System.Data.SqlDbType.Int, 32).Value = id;

							using (SqlDataReader reader = command.ExecuteReader())
							{
								if (reader.Read())
								{
									contentData = new Content
									{
										Id = Convert.ToInt32(reader["content_id"]),
										Type = Convert.ToString(reader["content_type"]),
										Title = Convert.ToString(reader["content_title"]),
										Data = Convert.ToString(reader["content_data"]),
										PublishedAt = Convert.ToDateTime(reader["content_published_at"]),
									};
								}
							}

						}
					}
				}
				catch (SqlException ex)
				{
					Console.WriteLine($"SQL-Exception [ContentDataAccess -> GetContentData]: {ex.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception [ContentDataAccess -> GetContentData]: {ex.Message}");
				}
			}

			return contentData;
		}

		public void UpdateAfterEdit(Content content)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				try
				{
					connection.Open();

					string query = @"
                        UPDATE ww_content 
                        SET 
                            content_type = @content_type,
                            content_title = @content_title,
                            content_published_at = @content_published_at,
							content_data = @content_data
                        WHERE content_id = @content_id";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@content_id", content.Id);
						command.Parameters.AddWithValue("@content_type", content.Type);
						command.Parameters.AddWithValue("@content_title", content.Title);
						command.Parameters.AddWithValue("@content_published_at", content.PublishedAt);
						command.Parameters.AddWithValue("@content_data", content.Data);

						command.ExecuteNonQuery();
					}
				}
				catch (SqlException ex)
				{
					Console.WriteLine($"SQL-Exception [ContentDataAccess -> UpdateAfterEdit]: {ex.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception [ContentDataAccess -> UpdateAfterEdit]: {ex.Message}");
				}
			}
		}

		public List<Content> GetContentListPaged(int pageNumber, int pageSize, string? contentType = "")
		{
			List<Content> contentList = new List<Content>();

			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					string query = @"
						SELECT * FROM ww_content
						WHERE content_type = @content_type
						ORDER BY content_id
						OFFSET @offset ROWS
						FETCH NEXT @page_size ROWS ONLY;";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						int offset = (pageNumber - 1) * pageSize;

						command.Parameters.AddWithValue("@content_type", contentType ?? string.Empty);
						command.Parameters.AddWithValue("@offset", offset);
						command.Parameters.AddWithValue("@page_size", pageSize);

						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								Content content = new Content
								{
									Id = Convert.ToInt32(reader["content_id"]),
									Type = Convert.ToString(reader["content_type"]),
									Title = Convert.ToString(reader["content_title"]),
									Data = Convert.ToString(reader["content_data"]),
									PublishedAt = Convert.ToDateTime(reader["content_published_at"])
								};

								contentList.Add(content);
							}
						}
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine($"SQL-Exception [ContentDataAccess -> GetContentListPaged]: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception [ContentDataAccess -> GetContentListPaged]: {ex.Message}");
			}

			return contentList;
		}

		public void SaveNewContent(Content content)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				try
				{
					connection.Open();

					string query = @"
						INSERT INTO ww_content 
						(content_type, content_title, content_published_at, content_data) 
						VALUES 
						(@content_type, @content_title, @content_published_at, @content_data)";

					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@content_type", content.Type ?? string.Empty);
						command.Parameters.AddWithValue("@content_title", content.Title ?? string.Empty);
						command.Parameters.AddWithValue("@content_published_at", content.PublishedAt);
						command.Parameters.AddWithValue("@content_data", content.Data ?? string.Empty);

						command.ExecuteNonQuery();
					}
				}
				catch (SqlException ex)
				{
					Console.WriteLine($"SQL-Exception [ContentDataAccess -> SaveNewContent]: {ex.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception [ContentDataAccess -> SaveNewContent]: {ex.Message}");
				}
			}
		}
	}
}
