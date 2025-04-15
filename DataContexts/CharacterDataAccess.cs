using Microsoft.Data.SqlClient;
using Winterra.Helpers;
using Winterra.Models.DataModels;

namespace Winterra.DataContexts
{
    public class CharacterDataAccess
    {
        private readonly string? _connectionString;

        public CharacterDataAccess(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public int GetCharacterCount()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) AS cnt FROM ww_character";
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

        public List<Character> GetCharacterList()
        {
            List<Character> characterList = new List<Character>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT TOP 10 * FROM ww_character ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Character character = new Character
                                {
                                    Id = Convert.ToInt32(reader["character_id"]),
                                    Image = Convert.ToString(reader["character_image"]),
                                    Name = Convert.ToString(reader["character_name"]),
                                };
                                
                                characterList.Add(character);
                            }
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL-Exception [CharacterDataAccess -> GetCharacterList]: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception [CharacterDataAccess -> GetCharacterList]: {ex.Message}");
            }

            return characterList;
        }
    }
}
