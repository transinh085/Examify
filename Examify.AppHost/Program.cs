var builder = DistributedApplication.CreateBuilder(args);

var postgreSql = builder.AddPostgres("postgreSql");
var identityDB = postgreSql.AddDatabase("identityDB");

var identityService = builder.AddProject<Projects.Examify_Identity>("identity-api").WithReference(identityDB);
var classService = builder.AddProject<Projects.Examify_Class>("class-api")
    .WithHttpsEndpoint(port: 57119)
    .WithReference(postgreSql);

var notificationService = builder.AddProject<Projects.Examify_Notification>("notification-api")
    .WithHttpsEndpoint();

builder.AddProject<Projects.Examify_Gateway>("gateway")
    .WithReference(identityService)
    .WithReference(classService)
    .WithReference(notificationService);

builder.Build().Run();