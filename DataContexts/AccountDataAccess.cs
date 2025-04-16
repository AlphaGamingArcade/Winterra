using Microsoft.Data.SqlClient;
using Winterra.Helpers;
using Winterra.Models.DataModels;
using Winterra.Models.InputModels;

namespace Winterra.DataContexts
{
    public class AccountDataAccess
    {
        private readonly string? _connectionString;

        public AccountDataAccess(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool CheckLogin(Login account)
        {
            bool isLoginSuccessful = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT password FROM accounts WHERE email = @account_email";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@account_email", System.Data.SqlDbType.VarChar, 32).Value = account.Email;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHashedPassword = reader.GetString(0);
                                // Verify the password using your HashHelper
                                if (HashHelper.VerifyPassword(account.Password, storedHashedPassword))
                                {
                                    isLoginSuccessful = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL-Exception [AccountDataAccess -> CheckLogin]: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception [AccountDataAccess -> CheckLogin]: {ex.Message}");
            }

            return isLoginSuccessful;
        }
        public void UpdateAfterLogin(string accountEmail, string accountSession)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE accounts SET account_session = @account_session WHERE email = @account_email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@account_email", System.Data.SqlDbType.VarChar, 32).Value = accountEmail;
                    command.Parameters.Add("@account_session", System.Data.SqlDbType.VarChar, 64).Value = accountSession;
                    command.ExecuteNonQuery();
                }

            }
        }
        public void UpdateAfterLogout(string accountEmail)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "UPDATE accounts SET account_session = NULL WHERE email = @account_email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@account_email", System.Data.SqlDbType.VarChar, 32).Value = accountEmail;
                    command.ExecuteNonQuery();
                }

            }
        }
        public Account? GetLoginMemberData(string? email)
		{
			Account? accountData = null;

            if (email != null)
            {
				try
				{
					using (SqlConnection connection = new SqlConnection(_connectionString))
					{
						connection.Open();

						string query = "SELECT * FROM accounts WHERE email = @account_email";
						using (SqlCommand command = new SqlCommand(query, connection))
						{
							command.Parameters.Add("@account_email", System.Data.SqlDbType.VarChar, 32).Value = email;

							using (SqlDataReader reader = command.ExecuteReader())
							{
								if (reader.Read())
								{
									accountData = new Account
									{
										Id = Convert.ToInt32(reader["id"]),
										Name = Convert.ToString(reader["name"]),
                                        DeviceId = Convert.ToString(reader["device_id"]),
                                        Gems = Convert.ToInt32(reader["gems"]),
                                        IsOnline = Convert.ToInt32(reader["is_online"]),
                                        ClientId = Convert.ToInt32(reader["client_id"]),
                                        Trophies = Convert.ToInt32(reader["trophies"]),
                                        Banned =  Convert.ToInt32(reader["banned"]),
                                        Shield =  Convert.ToDateTime(reader["shield"]),
                                        Xp = Convert.ToInt32(reader["xp"]),
										Level = Convert.ToInt32(reader["level"]),
                                        ClanJoinTimer = reader.IsDBNull(reader.GetOrdinal("clan_join_timer")) ? (DateTime?)null : Convert.ToDateTime(reader["clan_join_timer"]),
                                        ClanId = Convert.ToInt32(reader["clan_id"]),
                                        ClanRank = Convert.ToInt32(reader["clan_rank"]),
                                        WarId = Convert.ToInt32(reader["war_id"]),
                                        GlobalChatBlocked = Convert.ToInt32(reader["global_chat_blocked"]),
                                        LastChat = reader.IsDBNull(reader.GetOrdinal("last_chat")) ? (DateTime?)null : Convert.ToDateTime(reader["last_chat"]),
                                        ChatColor = Convert.ToString(reader["chat_color"]),
                                        Email = Convert.ToString(reader["email"]),
                                        Password = Convert.ToString(reader["password"]),
                                        MapLayout = Convert.ToInt32(reader["map_layout"]),
                                        ShieldCouldron1 = reader.IsDBNull(reader.GetOrdinal("shld_cldn_1")) ? (DateTime?)null : Convert.ToDateTime(reader["shld_cldn_1"]),
                                        ShieldCouldron2 = reader.IsDBNull(reader.GetOrdinal("shld_cldn_2")) ? (DateTime?)null : Convert.ToDateTime(reader["shld_cldn_2"]),
                                        ShieldCouldron3 = reader.IsDBNull(reader.GetOrdinal("shld_cldn_3")) ? (DateTime?)null : Convert.ToDateTime(reader["shld_cldn_3"]),
                                        LastLogin =  reader.IsDBNull(reader.GetOrdinal("last_login")) ? (DateTime?)null : Convert.ToDateTime(reader["last_login"]),
                                        CampaignLevel = Convert.ToInt32(reader["campaign_level"]),
                                        Admin = Convert.ToInt32(reader["admin"]),
                                        Verified = Convert.ToString(reader["verified"]),
                                        Session = Convert.ToString(reader["account_session"])
									};
								}
							}

						}
					}
				}
				catch (SqlException ex)
				{
					Console.WriteLine($"SQL-Exception [AccountDataAccess -> GetLoginMemberData]: {ex.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception [AccountDataAccess -> GetLoginMemberData]: {ex.Message}");
				}
			}

			return accountData;
		}

        public int GetAccountCount(int? adminLevel = 0)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) AS cnt FROM accounts WHERE admin = @adminLevel";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@adminLevel", adminLevel);
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
                Console.WriteLine($"SQL-Exception [AccountDataAccess -> GetCharacterCount]: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception [AccountDataAccess -> GetCharacterCount]: {ex.Message}");
            }

            return 0;
        }
        public List<Account> GetAccountList(int? adminLevel = 0)
        {
            List<Account> accountList = new List<Account>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT TOP 10 * FROM accounts WHERE admin = @admin_level";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@admin_level", adminLevel);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Account character = new Account
									{
										Id = Convert.ToInt32(reader["id"]),
										Name = Convert.ToString(reader["name"]),
                                        DeviceId = Convert.ToString(reader["device_id"]),
                                        Gems = Convert.ToInt32(reader["gems"]),
                                        IsOnline = Convert.ToInt32(reader["is_online"]),
                                        ClientId = Convert.ToInt32(reader["client_id"]),
                                        Trophies = Convert.ToInt32(reader["trophies"]),
                                        Banned =  Convert.ToInt32(reader["banned"]),
                                        Shield =  Convert.ToDateTime(reader["shield"]),
                                        Xp = Convert.ToInt32(reader["xp"]),
										Level = Convert.ToInt32(reader["level"]),
                                        ClanJoinTimer = reader.IsDBNull(reader.GetOrdinal("clan_join_timer")) ? (DateTime?)null : Convert.ToDateTime(reader["clan_join_timer"]),
                                        ClanId = Convert.ToInt32(reader["clan_id"]),
                                        ClanRank = Convert.ToInt32(reader["clan_rank"]),
                                        WarId = Convert.ToInt32(reader["war_id"]),
                                        GlobalChatBlocked = Convert.ToInt32(reader["global_chat_blocked"]),
                                        LastChat = reader.IsDBNull(reader.GetOrdinal("last_chat")) ? (DateTime?)null : Convert.ToDateTime(reader["last_chat"]),
                                        ChatColor = Convert.ToString(reader["chat_color"]),
                                        Email = Convert.ToString(reader["email"]),
                                        Password = Convert.ToString(reader["password"]),
                                        MapLayout = Convert.ToInt32(reader["map_layout"]),
                                        ShieldCouldron1 = reader.IsDBNull(reader.GetOrdinal("shld_cldn_1")) ? (DateTime?)null : Convert.ToDateTime(reader["shld_cldn_1"]),
                                        ShieldCouldron2 = reader.IsDBNull(reader.GetOrdinal("shld_cldn_2")) ? (DateTime?)null : Convert.ToDateTime(reader["shld_cldn_2"]),
                                        ShieldCouldron3 = reader.IsDBNull(reader.GetOrdinal("shld_cldn_3")) ? (DateTime?)null : Convert.ToDateTime(reader["shld_cldn_3"]),
                                        LastLogin =  reader.IsDBNull(reader.GetOrdinal("last_login")) ? (DateTime?)null : Convert.ToDateTime(reader["last_login"]),
                                        CampaignLevel = Convert.ToInt32(reader["campaign_level"]),
                                        Admin = Convert.ToInt32(reader["admin"]),
                                        Verified = Convert.ToString(reader["verified"]),
                                        Session = Convert.ToString(reader["account_session"])
									};
                                
                                accountList.Add(character);
                            }
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL-Exception [AccountDataAccess -> GetAccountList]: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception [AccountDataAccess -> GetAccountList]: {ex.Message}");
            }

            return accountList;
        }
        public Account? GetAccountData(int? accountId)
        {
           Account? accountData = null;

            if (accountId != null)
            {
				try
				{
					using (SqlConnection connection = new SqlConnection(_connectionString))
					{
						connection.Open();

						string query = "SELECT * FROM accounts WHERE id = @account_id";
						using (SqlCommand command = new SqlCommand(query, connection))
						{
							command.Parameters.Add("@account_id", System.Data.SqlDbType.Int, 32).Value = accountId;

							using (SqlDataReader reader = command.ExecuteReader())
							{
								if (reader.Read())
								{
									accountData = new Account
									{
										Id = Convert.ToInt32(reader["id"]),
										Name = Convert.ToString(reader["name"]),
                                        DeviceId = Convert.ToString(reader["device_id"]),
                                        Gems = Convert.ToInt32(reader["gems"]),
                                        IsOnline = Convert.ToInt32(reader["is_online"]),
                                        ClientId = Convert.ToInt32(reader["client_id"]),
                                        Trophies = Convert.ToInt32(reader["trophies"]),
                                        Banned =  Convert.ToInt32(reader["banned"]),
                                        Shield =  Convert.ToDateTime(reader["shield"]),
                                        Xp = Convert.ToInt32(reader["xp"]),
										Level = Convert.ToInt32(reader["level"]),
                                        ClanJoinTimer = reader.IsDBNull(reader.GetOrdinal("clan_join_timer")) ? (DateTime?)null : Convert.ToDateTime(reader["clan_join_timer"]),
                                        ClanId = Convert.ToInt32(reader["clan_id"]),
                                        ClanRank = Convert.ToInt32(reader["clan_rank"]),
                                        WarId = Convert.ToInt32(reader["war_id"]),
                                        GlobalChatBlocked = Convert.ToInt32(reader["global_chat_blocked"]),
                                        LastChat = reader.IsDBNull(reader.GetOrdinal("last_chat")) ? (DateTime?)null : Convert.ToDateTime(reader["last_chat"]),
                                        ChatColor = Convert.ToString(reader["chat_color"]),
                                        Email = Convert.ToString(reader["email"]),
                                        Password = Convert.ToString(reader["password"]),
                                        MapLayout = Convert.ToInt32(reader["map_layout"]),
                                        ShieldCouldron1 = reader.IsDBNull(reader.GetOrdinal("shld_cldn_1")) ? (DateTime?)null : Convert.ToDateTime(reader["shld_cldn_1"]),
                                        ShieldCouldron2 = reader.IsDBNull(reader.GetOrdinal("shld_cldn_2")) ? (DateTime?)null : Convert.ToDateTime(reader["shld_cldn_2"]),
                                        ShieldCouldron3 = reader.IsDBNull(reader.GetOrdinal("shld_cldn_3")) ? (DateTime?)null : Convert.ToDateTime(reader["shld_cldn_3"]),
                                        LastLogin =  reader.IsDBNull(reader.GetOrdinal("last_login")) ? (DateTime?)null : Convert.ToDateTime(reader["last_login"]),
                                        CampaignLevel = Convert.ToInt32(reader["campaign_level"]),
                                        Admin = Convert.ToInt32(reader["admin"]),
                                        Verified = Convert.ToString(reader["verified"]),
                                        Session = Convert.ToString(reader["account_session"])
									};
								}
							}

						}
					}
				}
				catch (SqlException ex)
				{
					Console.WriteLine($"SQL-Exception [AccountDataAccess -> GetAccountData]: {ex.Message}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Exception [AccountDataAccess -> GetAccountData]: {ex.Message}");
				}
			}

			return accountData;
        }

        public void UpdateAfterEdit(Account account)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                        UPDATE accounts 
                        SET 
                            name = @account_name,
                            gems = @account_gems,
                            verified = @account_verified,
                            banned = @account_banned
                        WHERE id = @account_id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@account_id", account.Id);
                        command.Parameters.AddWithValue("@account_name", account.Name);
                        command.Parameters.AddWithValue("@account_gems", account.Gems);
                        command.Parameters.AddWithValue("@account_verified", account.Verified);
                        command.Parameters.AddWithValue("@account_banned", account.Banned);

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL-Exception [AccountDataAccess -> UpdateAfterEdit]: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception [AccountDataAccess -> UpdateAfterEdit]: {ex.Message}");
                }
            }
        }
    }
}
