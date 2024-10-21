var builder = DistributedApplication.CreateBuilder(args);

var postgreSql = builder.AddPostgres("postgreSql")
    .WithPgAdmin();

// var redis = builder.AddRedis("redis")
//     .WithRedisCommander();

var classDb = postgreSql.AddDatabase("classDb");
var indentityDb = postgreSql.AddDatabase("identityDb");
var catalogDb = postgreSql.AddDatabase("catalogDb");

var identityService = builder.AddProject<Projects.Examify_Identity>("identity-api")
    .WithReference(indentityDb)
    .WaitFor(indentityDb);

var classService = builder.AddProject<Projects.Examify_Classroom>("class-api")
    .WithReference(classDb)
    .WaitFor(classDb);

var catalogService = builder.AddProject<Projects.Examify_Catalog>("catalog-api")
        .WithReference(catalogDb)
        .WaitFor(catalogDb);

var notificationService = builder.AddProject<Projects.Examify_Notification>("notification-api")
    .WithHttpsEndpoint();

builder.AddProject<Projects.Examify_Gateway>("gateway")
    .WithReference(identityService)
    .WithReference(classService)
    .WithReference(notificationService);

builder.Build().Run();