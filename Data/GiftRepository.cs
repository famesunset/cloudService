using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Npgsql;
using Structures;
using Structures.Options;
using Dapper;

namespace Data
{
    public class GiftRepository : IGiftRepository
    {
        private readonly IOptions<DatabaseOption> _options;
        public GiftRepository(IOptions<DatabaseOption> options)
        {
            _options = options;
        }

        public async Task<string> GetName()
        {
            string sql = @"select Name from Users";
            string result = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(_options.Value.Url))
                {
                    result = await connection.QueryFirstOrDefaultAsync<string>(sql);
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            return result;
        }
    }
}