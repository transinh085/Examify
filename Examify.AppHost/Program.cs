var builder = DistributedApplication.CreateBuilder(args);

var postgreSql = builder.AddPostgres("postgreSql")
    .WithPgAdmin();

var classDb = postgreSql.AddDatabase("classDb");
var indentityDb = postgreSql.AddDatabase("identityDb");
var catalogDb = postgreSql.AddDatabase("catalogDb");
var quizDb = builder.AddMongoDB("quizDb").WithLifetime(ContainerLifetime.Persistent);

var identityService = builder.AddProject<Projects.Examify_Identity>("identity-api")
    .WithReference(indentityDb)
    .WaitFor(indentityDb);

var classService = builder.AddProject<Projects.Examify_Classroom>("class-api")
    .WithReference(classDb)
    .WaitFor(classDb);

var catalogService = builder.AddProject<Projects.Examify_Catalog>("catalog-api")
    .WithReference(catalogDb)
    .WaitFor(catalogDb);

var quizService = builder.AddProject<Projects.Examify_Quiz>("quiz-api")
    .WithReference(quizDb)
    .WaitFor(quizDb);

var resultService = builder.AddProject<Projects.Examify_Result>("result-api");

// var notificationService = builder.AddProject<Projects.Examify_Notification>("notification-api")
//     .WithHttpsEndpoint();

builder.AddProject<Projects.Examify_Gateway>("gateway")
    .WithReference(identityService)
    .WithReference(classService)
    .WithReference(catalogService)
    .WithReference(quizService)
    .WithReference(resultService);

builder.Build().Run();