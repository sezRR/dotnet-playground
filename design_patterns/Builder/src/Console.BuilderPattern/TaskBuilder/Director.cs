using BuilderPattern.TaskBuilder.Common.Interfaces.Builders;
using BuilderPattern.TaskBuilder.Common;

public class Director
{
    private IBuilderStrategy? _builderStrategy;

    public void SetBuilderStrategy(IBuilderStrategy builderStrategy)
    {
        _builderStrategy = builderStrategy;
    }

    public TTask Construct<TTask>() where TTask : BaseTask
    {
        if (_builderStrategy is IBuilderStrategy<TTask> strategy)
            return strategy.Execute();

        throw new InvalidOperationException("Builder strategy is not set or incompatible.");
    }
}
