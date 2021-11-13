﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Npgsql;
using Structures;
using Structures.Options;
using Dapper;

namespace Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly IOptions<DatabaseOption> _options;
        public ItemRepository(IOptions<DatabaseOption> options)
        {
            _options = options;
        }
        
        
        public async Task<long> SaveToDb(Item item)
        {
            long id = -1;
            string sql = @"INSERT INTO def.storage (item_name, price) VALUES (@Name, @Price) RETURNING id;";
            try 
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_options.Value.Url))
                {
                    id = await connection.QueryFirstAsync<int>(sql, new
                    {
                        Name = item.Name,
                        Price = item.Price
                    });
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return id;
        }
    }
}