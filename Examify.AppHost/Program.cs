using Aspirant.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var postgreSql = builder.AddPostgres("postgreSql")
    .WithPgAdmin()
    .WithDataVolume();

var classDb = postgreSql.AddDatabase("classDb");
var indentityDb = postgreSql.AddDatabase("identityDb");

var identityService = builder.AddProject<Projects.Examify_Identity>("identity-api")
    .WithReference(indentityDb)
    .WaitFor(indentityDb); 

var classService = builder.AddProject<Projects.Examify_Classroom>("class-api")
    .WithReference(classDb)
    .WaitFor(classDb);

var notificationService = builder.AddProject<Projects.Examify_Notification>("notification-api")
    .WithHttpsEndpoint();

builder.AddProject<Projects.Examify_Gateway>("gateway")
    .WithReference(identityService)
    .WithReference(classService)
    .WithReference(notificationService);

builder.Build().Run();