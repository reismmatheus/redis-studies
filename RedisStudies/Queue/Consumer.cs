using StackExchange.Redis;
using System;
using System.Threading;

namespace RedisStudies.Queue
{
    public class Consumer
    {
        private readonly string _connString;
        private readonly string _queueKey;
        public Consumer(string connString, string queueKey)
        {
            _connString = connString;
            _queueKey = queueKey;
        }

        public void Pop()
        {
            var conn = ConnectionMultiplexer.Connect(_connString);

            var database = conn.GetDatabase();

            while (database.ListLength(_queueKey) > 0)
            {
                var data = database.ListRightPop(_queueKey);

                Console.WriteLine($"{DateTime.Now:o} - {data}");

                Thread.Sleep(100);
            }
        }
    }
}
