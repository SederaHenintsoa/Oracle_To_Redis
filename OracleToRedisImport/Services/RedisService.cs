using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace OracleToRedisImport.Services
{
    class RedisService
    {
        private IDatabase Mydb;

        public RedisService(string redisConn) {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConn);
            Mydb = redis.GetDatabase();
        }

        public void SaveObjectsTables<T>(string key, T obj)
        {
            //string key = "utilisateur:json:" + u.id_utilisateur;
            string json = JsonConvert.SerializeObject(obj);
            Mydb.StringSet(key, json);
        }

        internal void SaveObjectsTables(string p)
        {
            throw new NotImplementedException();
        }
    }
}
