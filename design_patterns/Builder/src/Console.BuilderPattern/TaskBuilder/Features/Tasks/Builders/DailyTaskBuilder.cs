using BuilderPattern.TaskBuilder.Common;
using BuilderPattern.TaskBuilder.Common.Interfaces;
using BuilderPattern.TaskBuilder.Common.Interfaces.Builders;
using TaskStatus = BuilderPattern.TaskBuilder.Common.Enums.TaskStatus;

namespace BuilderPattern.TaskBuilder.Features.Tasks.Builders;

public class DailyTaskBuilder : ITaskBuilder<DailyTask>
{
    private readonly DailyTask _dailyTask = new("default");

    public ITaskBuilder<DailyTask> AddDependency(IDependency dependency)
    {
        _dailyTask.Dependencies.Add(dependency);
        return this;
    }

    public ITaskBuilder<DailyTask> AddPrerequisite(BaseTask prerequisite)
    {
        _dailyTask.Prerequisites.Add(prerequisite);
        return this;
    }

    public ITaskBuilder<DailyTask> AddReward(IReward reward)
    {
        _dailyTask.Rewards.Add(reward);
        return this;
    }

    public DailyTask Build()
    {
        return _dailyTask;
    }

    public ITaskBuilder<DailyTask> SetDescription(string description)
    {
        _dailyTask.Description = description;
        return this;
    }

    public ITaskBuilder<DailyTask> SetDetails(string details)
    {
        _dailyTask.Details = details;
        return this;
    }

    public ITaskBuilder<DailyTask> SetName(string name)
    {
        _dailyTask.Name = name;
        return this;
    }

    public ITaskBuilder<DailyTask> SetStatus(TaskStatus taskStatus)
    {
        _dailyTask.Status = taskStatus;
        return this;
    }
}
