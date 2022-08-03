namespace Test.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class TestRequestConsumer : IConsumer<TestRequest>
    {
        public async Task Consume(ConsumeContext<TestRequest> context)
        {
            var rnd = new Random();
            var numItems = context.Message.Limit;
            var items = new List<string>(numItems);
            for (int i = 0; i < numItems; i++)
            {
                items.Add(rnd.NextInt64().ToString());
            }
            
            await context.RespondAsync<TestResponse>(new()
            {
                Values = items
            });
        }
    }
}