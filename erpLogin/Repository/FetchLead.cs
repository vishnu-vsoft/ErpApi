using erpLogin.Model;
using System.Data.SqlClient;

namespace erpLogin.Repository
{
    public interface IFetchLead
    {
        public Task<List<LeadRegister>> getLeadDetails();
    }
    public class FetchLead : IFetchLead
    {
        private readonly IConfiguration _configuration;
        public FetchLead(IConfiguration configuration) { 
            _configuration = configuration;
        }

        public async Task<List<LeadRegister>> getLeadDetails()
        {
            string connectionString = _configuration.GetConnectionString("ConnectionStrings") ?? "";
            SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            var leads = new List<LeadRegister>();
            var sqlCommand = new SqlCommand("SELECT * FROM LeadRegister", connection);
            using(SqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
            {
                {
                    while (await reader.ReadAsync()) {
                        var lead = new LeadRegister
                        {
                            Id = reader["Id"].ToString(),
                            LeadName = reader["Name"].ToString() ?? "",
                            LeadMobileNo = reader["MobileNo"].ToString() ?? "",
                            LeadAddress = reader["Address"].ToString(),
                            LeadEmail = reader["Email"].ToString(),
                            HighLevelRequirement = reader["HighLevelRequirement"].ToString() ?? "",
                            Location = reader["Locations"].ToString() ?? "",
                            LeadStatus = reader["Status"].ToString() ?? "",
                            Remarks = reader["Remarks"].ToString() ?? "",
                            LeadFeasibility = reader["Feasibility"].ToString() ?? ""

                        };
                        leads.Add(lead);
                    }
                }
            }
            return leads;
            
        }
    }
}
