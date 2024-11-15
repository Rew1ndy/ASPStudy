var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Lab15>("lab15");

builder.Build().Run();
