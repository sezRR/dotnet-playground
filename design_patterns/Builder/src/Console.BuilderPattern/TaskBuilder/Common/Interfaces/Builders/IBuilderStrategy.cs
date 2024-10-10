using BuilderPattern.TaskBuilder.Common.Interfaces.Strategies;

namespace BuilderPattern.TaskBuilder.Common.Interfaces.Builders;

public interface IBuilderStrategy
{
    BaseTask Execute();
}

public interface IBuilderStrategy<TTask, TTaskBuilder> : IBuilderStrategy/*, IStrategy<TTask>*/
    where TTask : BaseTask
    where TTaskBuilder : ITaskBuilder<TTask>
{
    //public TTaskBuilder TaskBuilder { get; }
    new TTask Execute();
}
