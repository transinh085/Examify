var builder = DistributedApplication.CreateBuilder(args);

var postgreSql = builder.AddPostgres("postgreSql")
    .WithPgWeb(c => c.WithLifetime(ContainerLifetime.Persistent))
    .WithLifetime(ContainerLifetime.Persistent);

var rabbitMq = builder.AddRabbitMQ("rabbitmq")
    .WithManagementPlugin()
    .WithLifetime(ContainerLifetime.Persistent);

var indentityDb = postgreSql.AddDatabase("identityDb");
var catalogDb = postgreSql.AddDatabase("catalogDb");
var quizDb = postgreSql.AddDatabase("quizDb");

var identityService = builder.AddProject<Projects.Examify_Identity>("identity-api")
    .WithReference(indentityDb)
    .WithReference(rabbitMq)
    .WaitFor(indentityDb)
    .WaitFor(rabbitMq);

var catalogService = builder.AddProject<Projects.Examify_Catalog>("catalog-api")
    .WithReference(catalogDb)
    .WaitFor(catalogDb);

var quizService = builder.AddProject<Projects.Examify_Quiz>("quiz-api")
    .WithReference(quizDb)
    .WaitFor(quizDb);

var resultService = builder.AddProject<Projects.Examify_Result>("result-api")
    .WithReference(rabbitMq)
    .WaitFor(rabbitMq);

var notificationService = builder.AddProject<Projects.Examify_Notification>("notification-api")
    .WithReference(rabbitMq)
    .WaitFor(rabbitMq);

builder.AddProject<Projects.Examify_Gateway>("gateway")
    .WithReference(identityService)
    .WithReference(catalogService)
    .WithReference(resultService)
    .WithReference(quizService)
    .WithReference(notificationService);

builder.Build().Run();