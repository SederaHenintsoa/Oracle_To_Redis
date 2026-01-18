using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace OracleToRedisImport.Services
{
    class JsonToRedisService
    {
        private IDatabase _db;
        private ConnectionMultiplexer redis;

        public JsonToRedisService(string redisConnexion)
        {
            redis = ConnectionMultiplexer.Connect(redisConnexion);
            _db = redis.GetDatabase();
        }

        public void SaveJsons(string key, object value)
        {
            //_db.StringSet(redisKey, json);
            string json = JsonConvert.SerializeObject(value);
            _db.StringSet(key, json);
        }
    
        public List<string> GetAllkeys()
        {
            var server = redis.GetServer(redis.GetEndPoints().First());
            return server.Keys().Select(k => k.ToString()).ToList();
        }
        
       
        /* RedisKey[] GetAllkeys()
        {
            var server = redis.GetServer(redis.GetEndPoints().First());
            return server.Keys().ToArray();
        }
         */


        public string GetValue(string key)
        {
            return _db.StringGet(key);
        }
    }
}
