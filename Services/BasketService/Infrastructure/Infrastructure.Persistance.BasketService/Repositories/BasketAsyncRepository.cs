﻿using Application.BasketService.Interfaces.Repositories;
using Domain.BasketService.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.BasketService.Repositories
{
    public class BasketAsyncRepository : IBasketAsyncRepository
    {
        private readonly IDatabase _database;

        public BasketAsyncRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id,
            JsonSerializer.Serialize(basket), TimeSpan.FromDays(7));

            if (!created) return null;
            return await GetBasketAsync(basket.Id);
        }
    }
}