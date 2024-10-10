namespace BuilderPattern.TaskBuilder.Common.Interfaces.Builders;

public interface ICommonDetailsBuilder<TBuilder, TOutput> 
    where TBuilder : IBuilder<TOutput>
    where TOutput: class
{
    TBuilder SetName(string name);
    TBuilder SetDescription(string description);
    TBuilder SetDetails(string details);
}
