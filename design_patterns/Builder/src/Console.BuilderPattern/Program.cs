using BuilderPattern.TaskBuilder;
using BuilderPattern.TaskBuilder.Features.Tasks;
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

        Console.WriteLine(dailyTask);
    }
}
