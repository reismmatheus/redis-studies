using RedisStudies.Queue;
using System;

namespace RedisStudies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Queue Example");

            var connString = "localhost";
            var queueKey = "github-example";

            var consumer = new Consumer(connString, queueKey);
            var producer = new Producer(connString, queueKey);

            Console.WriteLine("Push");
            producer.Push();

            Console.WriteLine("Pop");
            consumer.Pop();

            Console.ReadLine();
        }
    }
}
