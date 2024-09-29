var builder = DistributedApplication.CreateBuilder(args);

var postgreSql = builder.AddPostgres("postgreSql").WithPgAdmin();
var classDb = postgreSql.AddDatabase("classDb");

var identityService = builder.AddProject<Projects.Examify_Identity>("identity-api");
var classService = builder.AddProject<Projects.Examify_Classroom>("class-api")
    .WithHttpsEndpoint(port: 57119)
    .WithReference(classDb);

var notificationService = builder.AddProject<Projects.Examify_Notification>("notification-api")
    .WithHttpsEndpoint();

builder.AddProject<Projects.Examify_Gateway>("gateway")
    .WithReference(identityService)
    .WithReference(classService)
    .WithReference(notificationService);

builder.Build().Run();