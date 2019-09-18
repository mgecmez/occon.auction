using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Occon.Auction.Server.Api.DataStorage.RedisConfig
{
    public class RedisManager : IDbProvider
    {
        private static IDatabase _db;
        private string _redisKey;

        public RedisManager(string redisKey)
        {
            if (_db == null)
                _db = RedisStore.RedisDb;

            _redisKey = redisKey;
        }

        public T Get<T>(string key)
        {
            var value = _db.HashGet(_redisKey, key);
            if (value.IsNull)
                return default;

            return Deserialize<T>(value.ToString());
        }

        public T Get<T>(object id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist<T>(string key)
        {
            return _db.HashExists(_redisKey, key);
        }

        public bool Remove<T>(string key)
        {
            return _db.HashDelete(_redisKey, key);
        }

        public bool Remove<T>(object id)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string key, T value)
        {
            if (value == null)
                return;

            _db.HashSet(_redisKey, key, Serialize(value));
        }

        private string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        private T Deserialize<T>(string serialized)
        {
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}
