namespace Test.Consumers
{
    using MassTransit;

    public class TestRequestConsumerDefinition :
        ConsumerDefinition<TestRequestConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<TestRequestConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
        }
    }
}