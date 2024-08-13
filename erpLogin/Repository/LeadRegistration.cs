using erpLogin.Model;
using System.Data.SqlClient;

namespace erpLogin.Repository
{
    public interface ILeadReg
    {
        Task<string> RegisterLead(LeadRegister registration);
    }

    public class LeadReg : ILeadReg
    {
       
        private readonly IConfiguration _configuration;
        public LeadReg(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> RegisterLead(LeadRegister registration) 
        {
            string connectionString = _configuration.GetConnectionString("ConnectionStrings") ?? "";
            using (SqlConnection connection  = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                SqlCommand cmd = new SqlCommand("Upsertlead",connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", registration.Id ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@LeadName", registration.LeadName);
                cmd.Parameters.AddWithValue("@LeadMobileNo", registration.LeadMobileNo);
                cmd.Parameters.AddWithValue("@LeadAddress", registration.LeadAddress);
                cmd.Parameters.AddWithValue("@LeadEmail", registration.LeadEmail);
                cmd.Parameters.AddWithValue("@HighLevelRequirement", registration.HighLevelRequirement);
                cmd.Parameters.AddWithValue("@Locations", registration.Location);
                cmd.Parameters.AddWithValue("@LeadStatus", registration.LeadStatus ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Remarks", registration.Remarks ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Feasibility", registration.LeadFeasibility ?? (object)DBNull.Value);

                  
                 await cmd.ExecuteNonQueryAsync();
                return "Successfully inserted";
            }
            
        }

        
    }

}
