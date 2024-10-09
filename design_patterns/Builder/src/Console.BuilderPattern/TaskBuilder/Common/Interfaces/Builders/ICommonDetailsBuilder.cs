namespace BuilderPattern.TaskBuilder.Common.Interfaces.Builders;

public interface ICommonDetailsBuilder<TBuilder, TOutput> 
    where TBuilder : IBuilder<TOutput>
    where TOutput: class
{
    ICommonDetailsBuilder<TBuilder, TOutput> SetName(string name);
    ICommonDetailsBuilder<TBuilder, TOutput> SetDescription(string description);
    ICommonDetailsBuilder<TBuilder, TOutput> SetDetails(string details);
}
