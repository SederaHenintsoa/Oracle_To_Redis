using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StackExchange.Redis;

namespace OracleToRedisImport.Services
{
    class JsonToRedisService
    {
        private IDatabase Mydb;

        public JsonToRedisService(string redisConnexion)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnexion);
            Mydb = redis.GetDatabase();
        }

        public void SaveJson(string redisKey, string json)
        {
            Mydb.StringSet(redisKey, json);
        }
    }
}
