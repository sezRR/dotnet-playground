using BuilderPattern.TaskBuilder.Common.Interfaces;
using TaskStatus = BuilderPattern.TaskBuilder.Common.Enums.TaskStatus;

namespace BuilderPattern.TaskBuilder.Common;

public abstract class BaseTask(string name) : ITask, ICommonDetails
{
    public Guid TaskId { get; set; }

    private IList<ITask> _prerequisites = new List<ITask>(); // TODO: HASHMAP?
    private IList<IDependency> _dependencies = new List<IDependency>();
    private IList<IReward> _rewards = new List<IReward>();

    public TaskStatus Status { get; set; } = TaskStatus.NotStarted;

    public string Name { get; set; } = name;

    public string? Description { get; set; }

    public string? Details { get; set; }

    public IList<ITask> Prerequisites
    {
        get => _prerequisites;
        set => _prerequisites = value ?? throw new ArgumentNullException(nameof(value), "Prerequisites cannot be null!");
    }

    public IList<IDependency> Dependencies
    {
        get => _dependencies;
        set => _dependencies = value ?? throw new ArgumentNullException(nameof(value), "Dependencies cannot be null!");
    }

    public IList<IReward> Rewards
    {
        get => _rewards;
        set => _rewards = value ?? throw new ArgumentNullException(nameof(value), "Rewards cannot be null!");
    }

    public abstract bool Complete();

    public virtual bool CheckArePrerequisitesSatisfied()
    {
        foreach (var prerequisite in Prerequisites!)
            if (prerequisite.Status != TaskStatus.Completed)
                return false;

        return true;
    }
}