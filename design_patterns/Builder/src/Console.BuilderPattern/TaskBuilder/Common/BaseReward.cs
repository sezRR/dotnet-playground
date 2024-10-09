using BuilderPattern.TaskBuilder.Common.Interfaces;

namespace BuilderPattern.TaskBuilder.Common;

public abstract class BaseReward<T> : IReward
{
    public Guid TaskId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Details { get; set; }

    public virtual Func<T>? RewardLogic { get; set; }

    public void ClaimReward()
    {
        RewardLogic?.Invoke();
        Console.WriteLine($"Reward claimed for the task {TaskId}!");
    }
}
