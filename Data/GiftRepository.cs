using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
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
        
        public async Task<IEnumerable<GiftOutResp>> GetGiftByUserIdAsync(IdUserIdRequest r)
        {
            string sql = @"select id, title, price, description, url, pic from gifts where userid = @Userid";
            IEnumerable<GiftOutResp> result = new List<GiftOutResp>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_options.Value.Url))
                {
                    result = await connection.QueryAsync<GiftOutResp>(sql, new
                    {
                        Userid = r.Id
                    });
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(JsonSerializer.Serialize(e));
            }
            
            return result.ToList();
        }

        public async Task<GiftOutResp> GetGiftByIdAsync(IdRequest id)
        {
            string sql = @"select id, title, price, description, url, pic from gifts where id = @Id";
            GiftOutResp result = new GiftOutResp();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_options.Value.Url))
                {
                    result = await connection.QueryFirstOrDefaultAsync<GiftOutResp>(sql, new
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
        
        public async Task<GiftResp> AddGiftAsync(GiftReq gift)
        {
            long addedId = 0;
            string sql = @"insert into gifts 
                            (userid, title, price, description, url, pic)
                           values (@userid, @title, @price, @description, @url, @pic)
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
                        pic = gift.Pic,
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