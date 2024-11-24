var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WebApi>("WebApi");

builder.Build().Run();
