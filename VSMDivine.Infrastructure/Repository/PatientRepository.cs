using VSMDivine.Application.Interfaces;
using VSMDivine.Core.Entities;
using VSMDivine.Sql.Queries;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using VSMDivine.Logging;

namespace VSMDivine.Infrastructure.Repository
{
    public class PatientRepository : IPatientRepository
    {
        #region ===[ Private Members ]=============================================================

        private readonly IConfiguration configuration;

        #endregion

        #region ===[ Constructor ]=================================================================

        public PatientRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region ===[ IPatientRepository Methods ]==================================================

        public async Task<IReadOnlyList<Patient>> GetAllAsync()
        {
            Log.Information($"Patient GetAllAsync {DateTime.Now}");
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Patient>(PatientQueries.AllPatient);
                return result.ToList();
            }
        }

        public async Task<IReadOnlyList<Patient>> GetAllAsync(int pageSize = 10, int pageNumber = 1)
        {
            Log.Information($"Patient GetAllAsync {DateTime.Now}");
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Patient>(PatientQueries.AllPatientWithPagination, new { PageSize = pageSize, PageNumber = pageNumber });
                return result.ToList();
            }
        }

        public async Task<Patient> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Patient>(PatientQueries.PatientById, new { Id = id });
                return result;
            }
        }

        public async Task<string> AddAsync(Patient entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(PatientQueries.AddPatient, entity);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(Patient entity)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(PatientQueries.UpdatePatient, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new SqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(PatientQueries.DeletePatient, new { Id = id });
                return result.ToString();
            }
        }

        #endregion
    }
}
