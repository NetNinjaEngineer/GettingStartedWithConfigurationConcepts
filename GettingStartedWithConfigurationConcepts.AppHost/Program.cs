var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.GettingStartedWithConfigurationConcepts>("gettingstartedwithconfigurationconcepts");

builder.Build().Run();
