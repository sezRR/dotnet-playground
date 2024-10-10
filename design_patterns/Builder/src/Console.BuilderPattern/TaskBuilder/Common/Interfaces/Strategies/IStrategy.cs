namespace BuilderPattern.TaskBuilder.Common.Interfaces.Strategies;

public interface IStrategy<TTask> where TTask: BaseTask
{
    TTask Execute();
}
