using BuilderPattern.TaskBuilder.Common.Enums;
using TaskStatus = BuilderPattern.TaskBuilder.Common.Enums.TaskStatus;

namespace BuilderPattern.TaskBuilder.Common.Interfaces.Builders;

public interface ITaskBuilder<TTask> : IBuilder<TTask>, ICommonDetailsBuilder<ITaskBuilder<TTask>, TTask> where TTask : BaseTask
{
    ITaskBuilder<TTask> AddDependency(IDependency dependency);
    ITaskBuilder<TTask> AddPrerequisite(BaseTask prerequisite);
    ITaskBuilder<TTask> AddReward(IReward reward);
    ITaskBuilder<TTask> SetStatus(TaskStatus taskStatus);
}
