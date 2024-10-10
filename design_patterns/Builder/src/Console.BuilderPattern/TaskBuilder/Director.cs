using BuilderPattern.TaskBuilder.Common;
using BuilderPattern.TaskBuilder.Common.Interfaces.Builders;

namespace BuilderPattern.TaskBuilder;

//public class Director
//{
//    private object? _builderStrategy;

//    public void SetBuilderStrategy<TTask, TTaskBuilder>(IBuilderStrategy<TTask, TTaskBuilder> builderStrategy)
//        where TTask : BaseTask
//        where TTaskBuilder : ITaskBuilder<TTask>
//    {
//        _builderStrategy = builderStrategy as IBuilderStrategy<BaseTask, ITaskBuilder<BaseTask>>
//                           ?? throw new InvalidCastException("Invalid builder strategy type.");
//    }

//    public TTask Construct<TTask>() where TTask : BaseTask
//    {
//        if (_builderStrategy is IBuilderStrategy<TTask, ITaskBuilder<TTask>> strategy)
//            return strategy.Execute();

//        throw new InvalidOperationException("Builder strategy is not set or incompatible.");
//    }
//}

public class Director
{
    private IBuilderStrategy? _builderStrategy;

    public void SetBuilderStrategy(IBuilderStrategy builderStrategy)
    {
        _builderStrategy = builderStrategy;
    }

    public TTask Construct<TTask>() where TTask : BaseTask
    {
        if (_builderStrategy is IBuilderStrategy<TTask, ITaskBuilder<TTask>> strategy)
            return strategy.Execute();

        throw new InvalidOperationException("Builder strategy is not set or incompatible.");
    }
}

