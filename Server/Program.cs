using Test.Consumers;
using MassTransit;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumersFromNamespaceContaining<TestRequestConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", 52906, "/", h =>
                {
                    h.Username("username");
                    h.Password("password");
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    }).Build();

await host.RunAsync();