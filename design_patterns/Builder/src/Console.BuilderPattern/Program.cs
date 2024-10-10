using BuilderPattern.TaskBuilder.Features.Tasks;
using BuilderPattern.TaskBuilder.Features.Tasks.Builders;
using BuilderPattern.TaskBuilder.Features.Tasks.Strategies;

namespace BuilderPattern;

public static class Program
{
    private static void Main(string[] args)
    {
        var director = new Director();
        var buildDailyTaskWithoutDependencyStrategy = new BuildDailyTaskWithoutDependencyStrategy();

        director.SetBuilderStrategy(buildDailyTaskWithoutDependencyStrategy);
        DailyTask dailyTask = director.Construct<DailyTask>();

        // Output detailed dailyTask information
        Console.WriteLine($"Name -> {dailyTask.Name}");
        Console.WriteLine($"Description -> {dailyTask.Description}");
        Console.WriteLine($"Details -> {dailyTask.Details}");
        Console.WriteLine($"Status -> {dailyTask.Status}");

        foreach (var prerequisite in dailyTask.Prerequisites)
            Console.WriteLine($"Prerequisite -> {prerequisite.Name}");
        foreach (var dependency in dailyTask.Dependencies)
            Console.WriteLine($"Dependency -> {dependency.Name}");
        foreach (var reward in dailyTask.Rewards)
            Console.WriteLine($"Reward -> {reward.Name}");

        // Custom builded Task
        var customTask = new DailyTaskBuilder()
            .SetStatus(TaskBuilder.Common.Enums.TaskStatus.Blocked)
            .SetDetails("Complete this task once a day to earn rewards.")
            .SetDescription("A task that can be completed once a day.")
            .SetName("My Custom Task")
            .AddPrerequisite(dailyTask)
            .Build();
    }
}
