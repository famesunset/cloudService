using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Text.Json;
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

        public async Task<IEnumerable<Gift>> GetGiftByIdAsync(List<long> ids)
        {
            string sql = @"select id, title, price, description, url, accumulated, isActive from gifts where id = ANY (@Id)";
            IEnumerable<Gift> result = new List<Gift>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_options.Value.Url))
                {
                    result = await connection.QueryAsync<Gift>(sql, new
                    {
                        Id = ids?.ToArray()
                    });
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(JsonSerializer.Serialize(e));
            }
            
            return result;
        }
        
        public async Task AddGiftAsync(Gift gift)
        {
            string sql = @"insert into gifts 
                            (userid, title, price, description, url, accumulated, isActive)
                           values (@userid, @title, @price, @description, @url, @accumulated, @isActive)";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_options.Value.Url))
                {
                    await connection.ExecuteAsync(sql, new
                    {
                        title = gift.Title,
                        price = gift.Price,
                        description = gift.Description,
                        url = gift.URL,
                        accumulated = gift.Accumulated,
                        isActive = gift.IsActive,
                        userid = gift.UserId
                    });
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(JsonSerializer.Serialize(e));
            }
        }
    }
}