using BuilderPattern.TaskBuilder.Common;
using BuilderPattern.TaskBuilder.Common.Interfaces.Builders;
using BuilderPattern.TaskBuilder.Features.Tasks.Builders;

namespace BuilderPattern.TaskBuilder.Features.Tasks.Strategies;

public class BuildDailyTaskWithoutDependencyStrategy : IBuilderStrategy<DailyTask>
{
    public DailyTaskBuilder TaskBuilder { get; } = new();

    public DailyTask Execute()
    {
        return TaskBuilder
            .SetStatus(Common.Enums.TaskStatus.NotStarted)
            .SetDetails("Complete this task once a day to earn rewards.")
            .SetDescription("A task that can be completed once a day.")
            .SetName("My Daily Task")
            .Build();
    }

    BaseTask IBuilderStrategy.Execute() => Execute();
}
