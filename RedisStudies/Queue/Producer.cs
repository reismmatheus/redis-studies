using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RedisStudies.Queue
{
    public class Producer
    {
        private readonly string _connString;
        private readonly string _queueKey;
        public Producer(string connString, string queueKey)
        {
            _connString = connString;
            _queueKey = queueKey;
        }

        public void Pop()
        {
            var conn = ConnectionMultiplexer.Connect(_connString);

            var database = conn.GetDatabase();

            for (int i = 0; i < 50; i++)
            {
                var value = $@"
                {{
                    order: {i},
                    request: []
                }}
                ";
                database.ListLeftPush(_queueKey, value);
                Console.WriteLine($"{DateTime.UtcNow:o} - {i}");
            }
        }
    }
}
