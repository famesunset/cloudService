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
        
        public async Task<IEnumerable<Gift>> GetGiftByUserIdAsync(IdRequest r)
        {
            string sql = @"select id, title, price, description, url, accumulated, isActive from gifts where userid = @userId";
            IEnumerable<Gift> result = new List<Gift>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_options.Value.Url))
                {
                    result = await connection.QueryAsync<Gift>(sql, new
                    {
                        userid = r.Id
                    });
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(JsonSerializer.Serialize(e));
            }
            
            return result;
        }

        public async Task<Gift> GetGiftByIdAsync(IdRequest id)
        {
            string sql = @"select id, title, price, description, url, accumulated, isActive from gifts where id = @Id";
            Gift result = new Gift();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_options.Value.Url))
                {
                    result = await connection.QueryFirstOrDefaultAsync<Gift>(sql, new
                    {
                        Id = id.Id
                    });
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(JsonSerializer.Serialize(e));
            }
            
            return result;
        }
        
        public async Task<GiftResp> AddGiftAsync(Gift gift)
        {
            long addedId = 0;
            string sql = @"insert into gifts 
                            (userid, title, price, description, url, accumulated, isActive)
                           values (@userid, @title, @price, @description, @url, @accumulated, @isActive)
                           RETURNING id;";
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_options.Value.Url))
                {
                    addedId = await connection.ExecuteScalarAsync<long>(sql, new
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

            return new GiftResp()
            {
                Id = addedId
            };
        }
    }
}