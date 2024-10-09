using TaskStatus = BuilderPattern.TaskBuilder.Common.Enums.TaskStatus;

namespace BuilderPattern.TaskBuilder.Common.Interfaces;

public interface ITask
{
    Guid TaskId { get; set; }
    string Name { get; set; }
    string? Details { get; set; }
    IList<ITask> Prerequisites { get; set; }
    IList<IDependency> Dependencies { get; set; }
    IList<IReward> Rewards { get; set; }
    TaskStatus Status { get; set; }
}