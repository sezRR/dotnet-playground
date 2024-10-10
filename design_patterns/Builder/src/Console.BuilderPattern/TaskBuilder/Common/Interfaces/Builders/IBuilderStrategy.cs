namespace BuilderPattern.TaskBuilder.Common.Interfaces.Builders;

public interface IBuilderStrategy
{
    BaseTask Execute();
}

public interface IBuilderStrategy<TTask> : IBuilderStrategy
    where TTask : BaseTask
{
    new TTask Execute();
}
