using System.Diagnostics;

EnsureDeveloperControlPaneIsNotRunning();
var builder = DistributedApplication.CreateBuilder(args);

var userName = builder.AddParameter("username", "admin");
var password = builder.AddParameter("password", "JJD7YgCFNHoTcvc");

var postgreSql = builder.AddPostgres("postgreSql", userName, password, 5433)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume("examify-postgres-data");

var rabbitMq = builder.AddRabbitMQ("rabbitmq")
    .WithManagementPlugin()
    .WithLifetime(ContainerLifetime.Persistent);

var indentityDb = postgreSql.AddDatabase("identityDb");
var catalogDb = postgreSql.AddDatabase("catalogDb");
var quizDb = postgreSql.AddDatabase("quizDb");
var resultDb = postgreSql.AddDatabase("resultDb");

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
    .WithReference(resultDb)
    .WithReference(rabbitMq)
    .WaitFor(resultDb)
    .WaitFor(rabbitMq);

var notificationService = builder.AddProject<Projects.Examify_Notification>("notification-api")
    .WithReference(rabbitMq)
    .WaitFor(rabbitMq);

var uploadFileService = builder.AddProject<Projects.Examify_UploadFile>("upload-api");

builder.AddProject<Projects.Examify_Gateway>("gateway")
    .WithReference(identityService)
    .WithReference(catalogService)
    .WithReference(resultService)
    .WithReference(quizService)
    .WithReference(notificationService)
    .WithReference(uploadFileService);

builder.Build().Run();

void EnsureDeveloperControlPaneIsNotRunning()
{
    const string processName = "dcpctrl"; // The Aspire Developer Control Pane process name

    var process = Process.GetProcesses()
        .SingleOrDefault(p => p.ProcessName.Contains(processName, StringComparison.OrdinalIgnoreCase));

    if (process == null) return;

    Console.WriteLine(
        $"Shutting down developer control pane from previous run. Process: {process.ProcessName} (ID: {process.Id})");

    Thread.Sleep(TimeSpan.FromSeconds(5)); // Allow Docker containers to shut down to avoid orphaned containers

    try
    {
        process.Kill();
        Console.WriteLine($"Process {process.Id} killed successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to kill process {process.Id}: {ex.Message}");
    }
}